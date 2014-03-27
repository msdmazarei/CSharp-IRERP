using IRERP_RestAPI.Bases.IRERPController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Controllers
{
    public class TestReportController :  IRERPController<MetaModel.Support_MetaModel>
    {
        //
        // GET: /TestReport/

        public ActionResult Index()
        {
            return View(MetaModelInstance);
        }

        public ActionResult ReportBankLog()
        {
            return View(MetaModelInstance);
        }

        public ActionResult ReportUserAcc()
        {
            return View(MetaModelInstance);
        }

        public ActionResult InvoiceSummary()
        {
            return new IRERP_RestAPI.Bases.IRERPActionResults.IRERPMethodActionResult()
            {
                data="Hello"
            };
        }
        public ActionResult ReportInvoice()
        {
            return View(MetaModelInstance);
        }

    }
}
