using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Routing;
using MsdLib.ExtensionFuncs.ISessionExtension;
namespace IRERP_RestAPI.Bases.ActionFilters
{
    public class NHSessionManage : ActionFilterAttribute
    {
        public const string dbconnectionkey = "MSD_DBCONNECTION";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
#if DEBUG
            
            System.Diagnostics.Trace.WriteLine("Creating NHibernate Session For Request");
#endif
            //create A Connection
            /*
            string connkey = dbconnectionkey + "_" + HttpContext.Current.GetHashCode().ToString();
            if (HttpContext.Current.Items[connkey] == null)
            {
                System.Data.IDbConnection dbcon = new System.Data.SqlClient.SqlConnection(
                    System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                try{
                    dbcon.Open();
                    HttpContext.Current.Items.Add(connkey, dbcon);
                }catch(Exception ex)
                {
                    IRERPApplicationUtilities.Logger().log(LogType.Fatal, ex.ToString());
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Error" }, { "action", "DbConnectionError" } }
                );
                    base.OnActionExecuting(filterContext);
                    return;
                }
               
            }*/
            try
            {
                DAL.SetupDb();
                MsdLib.CSharp.DALCore.DbSessionManager.GetSession();
            }
            catch (Exception ex)
            {
                    IRERPApplicationUtilities.Logger().log(LogType.Fatal, ex.ToString());
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Error" }, { "action", "DbConnectionError" } }
                              );
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
#if DEBUG
            System.Diagnostics.Trace.WriteLine("Closing Session For HttpContext:" + filterContext.HttpContext.GetHashCode().ToString());
#endif
            ClearAllSeassions();
            CommitOrRollBackAllTransactions();
            CloseAllSessions();
            
            /* When SessionFactory is static no nned to close and dispose it
            IRERPApplicationUtilities.ResumeNext(()=>
            MsdLib.CSharp.DALCore.DBFactory.Instance.SessionFactory.Close());
            IRERPApplicationUtilities.ResumeNext(()=>
            MsdLib.CSharp.DALCore.DBFactory.Instance.SessionFactory.Dispose());
            */

            //Close Connection
            string connkey = dbconnectionkey + "_" + HttpContext.Current.GetHashCode().ToString();
            if (HttpContext.Current.Items[connkey] != null)
            {
                System.Data.IDbConnection dbcon = (System.Data.IDbConnection)HttpContext.Current.Items[connkey];
                try{
                    dbcon.Close();
                    dbcon.Dispose();
                }
                catch (Exception ex)
                {
                    IRERPApplicationUtilities.LOG(ex.Message);

                }

            }
            base.OnResultExecuted(filterContext);
        }
        //To Avoid unnecessery and unwanted updates and deletes 
        public void ClearAllSeassions()
        {
            var sessl = MsdLib.CSharp.DALCore.DBFactory.AllSessions();
            if (sessl != null && sessl.Count > 0)
                sessl = (from x in sessl select x).Distinct().ToList();
            sessl.ForEach(x =>
            {
                if (x is NHibernate.ISession)
                {
                    NHibernate.ISession sess = (NHibernate.ISession)x;
                    if (sess.IsDirty())
                        sess.Clear();
                }
            });

        }
        public void CloseAllSessions()
        {
            var sessl = MsdLib.CSharp.DALCore.DBFactory.AllSessions();
            if(sessl!=null && sessl.Count>0)
                sessl = (from x in sessl select x).Distinct().ToList();
           sessl.ForEach(x => {
                if (x != null)
                {
                      if(
                          x is NHibernate.ISession)
                        {
                            NHibernate.ISession sess = (NHibernate.ISession) x;
                            IRERPApplicationUtilities.ResumeNext(()=>sess.Close());
                            IRERPApplicationUtilities.ResumeNext(()=>sess.Dispose());
                        } 
                        else if(
                          x is NHibernate.IStatelessSession
                          )
                        {
                            NHibernate.IStatelessSession sess = (NHibernate.IStatelessSession) x;
                            IRERPApplicationUtilities.ResumeNext(()=>sess.Close());
                            IRERPApplicationUtilities.ResumeNext(()=>sess.Dispose());

                        } 
                }
            });
        }
        void FlushAllSessions()
        {
            var sessl = MsdLib.CSharp.DALCore.DBFactory.AllSessions();
            if(sessl!=null && sessl.Count>0)
                sessl = (from x in sessl select x).Distinct().ToList();


           sessl.ForEach(x =>
                {
                    if (x != null)
                    {
                        if(x is NHibernate.ISession)
                        {
                            NHibernate.ISession sess = (NHibernate.ISession) x;
                            if(sess.IsOpen && sess.IsConnected)
                                IRERPApplicationUtilities.ResumeNext(()=>sess.Flush());
                        } 
                        else if(
                            x is NHibernate.IStatelessSession
                            )
                        {
                            NHibernate.IStatelessSession sess = (NHibernate.IStatelessSession) x;
                        } 
                    }
                });
        }
        public void RollBackAllTransaction()
        {
            List<NHibernate.ITransaction> trans = MsdLib.CSharp.DALCore.DBFactory.AllTransactions();
            if (trans != null && trans.Count > 0)
                trans = (from x in trans select x).Distinct().ToList();

            FlushAllSessions();
            trans.ForEach(x =>
            {
                if (x != null)
                {
                    if (x.IsActive)
                    {
                        if (x.WasCommitted || x.WasRolledBack)
                        {
                            //Dispose x 
                            IRERPApplicationUtilities.ResumeNext(() => x.Dispose());
                        }
                        else
                        {
                            IRERPApplicationUtilities.ResumeNext(() =>
                            {
                                try{x.Rollback();}catch {  }
                            });
                        }
                    }
                    else
                        IRERPApplicationUtilities.ResumeNext(() => x.Dispose());
                }
            });
        }
        void CommitOrRollBackAllTransactions()
        {
            List<NHibernate.ITransaction> trans = MsdLib.CSharp.DALCore.DBFactory.AllTransactions();
            if (trans != null && trans.Count > 0)
                trans = (from x in trans select x).Distinct().ToList();
                
            FlushAllSessions();
            trans.ForEach(x => {
                if (x != null)
                {
                    if (x.IsActive)
                    {
                        if (x.WasCommitted || x.WasRolledBack)
                        {
                            //Dispose x 
                            IRERPApplicationUtilities.ResumeNext(() => x.Dispose());
                        }
                        else
                        {
                            IRERPApplicationUtilities.ResumeNext(() =>{
                                try { 
                                    
                                    x.Commit(); } catch { x.Rollback(); }
                            });
                        }
                    }
                    else
                        IRERPApplicationUtilities.ResumeNext(() => x.Dispose());
                }
            });
        }
        
    }
}