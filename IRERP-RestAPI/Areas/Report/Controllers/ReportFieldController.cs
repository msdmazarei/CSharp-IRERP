using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.MvcDesign;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Areas.Report.MetaModels;
using Stimulsoft.Report;
using System.Web.Routing;
using System.Data;

namespace IRERP_RestAPI.Areas.Report.Controllers
{
    public class ReportFieldController : IRERPController<Report_MetaModel>
    {
        //
        // GET: /Report/ReportField/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AllReportField()
        {
            return View();
        }


    }
}
