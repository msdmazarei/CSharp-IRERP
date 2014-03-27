using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsdLib.CSharp.BLLCore;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using NHibernate;
using MsdLib.ExtensionFuncs.ISessionExtension;


namespace IRERP_RestAPI.WorkFlows
{
    public class WorkFlows
    {
        static void AtFinal(ref FunctionResult<INHibernateEntity> rtn, ref ISession NHSession, ref ITransaction NHTransaction,ref bool CommitTran)
        {
            IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Workflow result is "+ rtn.Result.ToString());
            if (rtn.Result)
            {
                if (CommitTran)
                    try
                    {
                        IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Session Flush and Commit Transaction");
                        NHSession.Flush();
                        NHTransaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Error Happen in Commit tRans cause:"+ex.ToString());
                        rtn.Result = false;
                        rtn.Error = new PException(ex.Message, ex);
                        //try rollback
                        try{NHTransaction.Rollback();}
                        catch (Exception ex1) { IRERPApplicationUtilities.Logger().log(LogType.Fatal, "Could Not Rollback cause:"+ ex1.ToString()); }
                    }

            }
            else
            {
                IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Result Error is :"+rtn.Error==null?"":rtn.Error.Message);
                if (CommitTran)
                    try
                    {
                        IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Session Flush and RollBack Transaction");
                        NHSession.Flush();
                        NHTransaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        IRERPApplicationUtilities.Logger().log(LogType.PerformaInvoice, "Error Happen in Rollback casue:"+ ex.ToString());
                        rtn.Result = false;
                        rtn.Error = new PException(ex.Message, ex);
                    }
            }
        }
        static void makedbvarsready(ref ISession NHSession, ref ITransaction NHTransaction, ref User Operator)
        {
            if (NHSession == null)
                NHSession = DBFactory.Instance.Session;
            if (NHTransaction == null)
                NHTransaction = DBFactory.Instance.Session.Transaction;
       
            if (Operator == null)
                Operator = InstanceStatics.LoggedUser;
            //Flush Cache Before Cleare It
            NHSession.Flush();
            if (!NHTransaction.IsActive)
                NHTransaction = MsdLib.CSharp.DALCore.DbSessionManager.NewTransaction();
            //Clear Cache
            DBFactory.Instance.ClearCache();
            
            
        }

      

    }
}
