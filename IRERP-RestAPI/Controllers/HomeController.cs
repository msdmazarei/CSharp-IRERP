using IRERP_RestAPI.Models;
using MsdLib.CSharp.DataVirtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Filters;
using IRERP_RestAPI.Bases.DataVirtualization;
using System.Diagnostics;
using MsdLib.ExtentionFuncs.Strings;
using IRERP_RestAPI.Areas.Report.Models;
using MsdLib.CSharp.DALCore;
using MsdLib.ExtensionFuncs.ISessionExtension;

namespace IRERP_RestAPI.Controllers
{
    [IRERP_RestAPI.Bases.ActionFilters.NHSessionManage]
    public class HomeController : Controller
    {
        public ActionResult MapTest()
        {
            return View();
        }
        public ActionResult FileFieldUpload()
         {
            return new IRERP_RestAPI.Bases.IRERPActionResults.IRERPMethodActionResult()
            {
                data = "Hello",
                Success = true
            };
        }
        public ActionResult caltest()
        {
            DAL.SetupDb();
            return View();
        }
        public ActionResult Index()
        {

            //var usr = ModelRepositories.UserRepository.GetUserById(4194);//4194
            //var srvc = ModelRepositories.PetiakWifiService_Repository.GetServiceByServiceName("PNE-5");
            //var performa = ModelRepositories.PetiakWifiPerforma_Repository.GetByPerformaNumber(177468);

            //var h = IRERP_RestAPI.WorkFlows.WorkFlows.AddServicePerforma(srvc, usr, 1, usr, CommitTran: true);
            //var h1 = IRERP_RestAPI.WorkFlows.WorkFlows.IssueServiceInvoice(performa, usr, CommitTran: true);


            return new RedirectResult("/Support/Support");
        }   
        public ActionResult FreeSpace()
        {
            return View();
        }
    }
}


