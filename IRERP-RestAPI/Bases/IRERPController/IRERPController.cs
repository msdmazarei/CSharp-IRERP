using IRERP_RestAPI.Bases.ActionFilters;
using IRERP_RestAPI.Bases.ClientEngine;
using IRERP_RestAPI.Bases.IRERPActionResults;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IRERP_RestAPI.Bases.IRERPController
{
    [NHSessionManage]
    [RedirectToLoginIfUserNotLogged("Login/Index")]
    [LogSupport]
    public  partial class IRERPController : Controller
    {
        public ActionResult ErrorPage()
        {
            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            // Bail if we can't do anything; app will crash.
            if (filterContext == null)
                return;
            // since we're handling this, log to elmah

            var ex = filterContext.Exception ?? new Exception("No further information exists.");
            IRERPApplicationUtilities.Logger().log(LogType.Fatal, ex.ToString());
            //RollBack All Transactions
            try
            {
                var s = new NHSessionManage();
                s.RollBackAllTransaction();
                s.CloseAllSessions();
            }
            catch (Exception ex1)
            {
                IRERPApplicationUtilities.Logger().log(LogType.Fatal, ex1.ToString());
            }

            IRERPApplicationUtilities.Logger().WriteToFiles();

            filterContext.ExceptionHandled = true;
            string errmsg ="";
            if (ex.Message!=null && ex.Message.Trim()!="")
                errmsg = ex.Message;
            else
                errmsg="خطایی رخ داده است. مجدد تلاش کنید.";
            

            filterContext.Result =
                          new RedirectToRouteResult(
                              new RouteValueDictionary { {"area",""},{ "controller", "Error" }, { "action", "GeneralError" } }
                              );

            //base.OnException(filterContext);
        }
        public virtual void InitControllerSessionValues()
        {
        }

        public IRERPController()
        {
            if(!DAL.isDbSetuped) DAL.SetupDb();
#if DEBUG           
            //Only For Testing
            //if (InstanceStatics.LoggedUser == null)
            //    InstanceStatics.LoggedUser = ModelRepositories.UserRepository.GetUserById(801);
#endif
        }
        public virtual string virtualurl { get; set; } //Use For virtual controller calling like in ReportRequest
        public virtual string[] DataSource_GetUrlParts()
        {
            return GetUrlParts();
/*            try
            {
                string[] parts = null;
                if (virtualurl != null)
                    parts = virtualurl.Split('/');
                else
                 parts = Request.Url.AbsolutePath.Split('/');
                List<string> rtn = new List<string>();
                rtn.AddRange(parts);
                var ind= rtn.IndexOf("DataSource");
                List<string> rtn1 = new List<string>();
                if(ind>0)
                {
                for(int i=ind+1;i<rtn.Count;i++)
                    rtn1.Add(rtn[i]);
                    return rtn1.ToArray();
                //return Request.Url.AbsolutePath.Substring(Request.UrlReferrer.AbsolutePath.Length + "DataSource/".Length).Split('/');
                } else return new string[]{};
            }
            catch
            {
                return
                    null;
            }*/
        }

        public virtual string[] GetUrlParts(string Key="DataSource")
        {
            try
            {
                string[] parts = null;
                if (virtualurl != null)
                    parts = virtualurl.Split('/');
                else
                    parts = Request.Url.AbsolutePath.Split('/');
                List<string> rtn = new List<string>();
                rtn.AddRange(parts);
                var ind = rtn.IndexOf(Key);
                List<string> rtn1 = new List<string>();
                if (ind > 0)
                {
                    for (int i = ind + 1; i < rtn.Count; i++)
                        rtn1.Add(rtn[i]);
                    return rtn1.ToArray();
                    //return Request.Url.AbsolutePath.Substring(Request.UrlReferrer.AbsolutePath.Length + "DataSource/".Length).Split('/');
                }
                else return new string[] { };
            }
            catch
            {
                return
                    null;
            }
        }

        public virtual Type DataSourceMetaModelType
        {
            get
            {
              throw new NotImplementedException();
            }
        }
        // Use To retrive when Member addressing in DataSource Exists
        public virtual INHibernateEntity MetaModelInstance 
        {
            get 
            {
                
                throw new NotImplementedException();
            }
        }

        IRERPProfile? _datasourcePassedProfile = null;
        public virtual IRERPProfile DataSource_PassedProfile
        {
            get
            {
                if (_datasourcePassedProfile == null)
                {
                    string[] UrlParts = DataSource_GetUrlParts();

                    bool validUrlPart = UrlParts != null;
                    validUrlPart = validUrlPart ? UrlParts.Length > 0 : false;

                    
                    if (validUrlPart) 
                        _datasourcePassedProfile =IRERPApplicationUtilities.GetProfileFromString( UrlParts[0]); 
                    else 
                        _datasourcePassedProfile= IRERPProfile.General;
                }
                return (IRERPProfile)_datasourcePassedProfile;
            }
        }

        string[] _members = null;
        public virtual string[] Members
        {
            get
            {
                if (_members != null)
                    return _members;

                    string[] UrlParts = DataSource_GetUrlParts();

                    bool validUrlPart = UrlParts != null;
                    validUrlPart = validUrlPart ? UrlParts.Length > 1 : false;

                    string[] Members1 = null;
                    if (validUrlPart) Members1 = new string[UrlParts.Length - 1];
                    Array.Copy(UrlParts, 1, Members1, 0, Members1.Length);
                    _members = Members1;

                    return _members;
            }
            set
            {
                _members = value;
            }
        }
   
        public virtual ActionResult DataSource()
        {
            //Call Method : /Controller/DataSource/Profile -- > object 
            //  /Controller/DataSource/Profile/ClassMember --> Return ClassMember ->User.Member
            //  /Controller/DataSource/Profile/ClassMember1/SubClassMember  --> User.Member.Member
            //  /Controller/DataSource/Profile/ClassMember1/SubClassMember/...  --> User.Member.Member...
            InitControllerSessionValues();

            ClientEngine.ClientEngineDataCarrier ClientRequest = ClientEngine.ClientEngineDataCarrier.ClientRequest();
            switch (ClientRequest.type)
            {
                case ClientEngine.ClientEngineDataCarrierType.fetch:
                    string irerpFetchType = IRERPApplicationUtilities.GetHttpParameter("_irerpFetchType");
                    if(irerpFetchType!=null)
                        if(irerpFetchType.Trim()!="")
                            switch (irerpFetchType)
                            {
                                case "irerpSummary":
                                    return SummaryMethod((FetchRequest)ClientRequest);
                                /*
                                 case "IRERP_SummaryMsg":
                                    return SummaryMessageMethod((FetchRequest)ClientRequest);
                                 */
                            }
                    return FetchMethod((FetchRequest)ClientRequest);
                case ClientEngineDataCarrierType.post:
                    return AddMethod((AddRequest)ClientRequest);
                case ClientEngineDataCarrierType.put:
                    return UpdateRequest((UpdateRequest)ClientRequest);
                case ClientEngineDataCarrierType.delete:
                    return DeleteRequest((ClientEngine.DeleteRequest)ClientRequest);
            }

            
          
            

            return null;
        }
        public virtual ActionResult SummaryMessage()
        {
            InitControllerSessionValues();
            ClientEngine.ClientEngineDataCarrier ClientRequest = ClientEngine.ClientEngineDataCarrier.ClientRequest();

            string[] UrlParts = GetUrlParts("SummaryMessage");
            bool validUrlPart = UrlParts != null;
            validUrlPart = validUrlPart ? UrlParts.Length > 1 : false;

            string[] Members1 = null;
            if (validUrlPart) Members1 = new string[UrlParts.Length - 1];
            Array.Copy(UrlParts, 1, Members1, 0, Members1.Length);
            Members = Members1;

            return SummaryMessageMethod((FetchRequest)ClientRequest);
        }
        public virtual ActionResult FileFieldUpload()
        {
            var rtn = new IRERP_RestAPI.Bases.IRERPActionResults.IRERPMethodActionResult();
            InitControllerSessionValues();
            ClientEngine.ClientEngineDataCarrier ClientRequest = ClientEngine.ClientEngineDataCarrier.ClientRequest();

            string[] UrlParts = GetUrlParts("FileFieldUpload");
            bool validUrlPart = UrlParts != null;
            validUrlPart = validUrlPart ? UrlParts.Length > 1 : false;
            Members = UrlParts;
           /* string[] Members1 = null;
            if (validUrlPart) Members1 = new string[UrlParts.Length - 1];
            Array.Copy(UrlParts, 1, Members1, 0, Members1.Length);
            Members = Members1;
            */
            return FileFieldUploadMethod(ClientRequest);
        }
        public virtual ActionResult FileFieldDownload()
        {
            var rtn = new IRERP_RestAPI.Bases.IRERPActionResults.IRERPMethodActionResult();
            InitControllerSessionValues();
            ClientEngine.ClientEngineDataCarrier ClientRequest = ClientEngine.ClientEngineDataCarrier.ClientRequest();

            string[] UrlParts = GetUrlParts("FileFieldDownload");
            bool validUrlPart = UrlParts != null;
            validUrlPart = validUrlPart ? UrlParts.Length > 1 : false;
            Members = UrlParts;
            /* string[] Members1 = null;
             if (validUrlPart) Members1 = new string[UrlParts.Length - 1];
             Array.Copy(UrlParts, 1, Members1, 0, Members1.Length);
             Members = Members1;
             */
            return FileFieldDownloadMethod(ClientRequest);
        }
        public virtual string ControllerUrl
        {
            get
            {
                var path = Request.FilePath;
                var pathparts = path.Split('/');
                string[] _pathparts = new string[pathparts.Length - 1];
                Array.Copy(pathparts, _pathparts, _pathparts.Length);
                path = string.Join("/", _pathparts);
                if (path.Substring(path.Length - 1, 1) != "/") path += "/";
                return path;
            }
        }
    }
    
}