using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.MvcDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IRERP_RestAPI.Areas.Report.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Report/Test/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetLocalization()
        {
            // Load the localization file requested by the designer
            string name = StiMvcDesigner.GetLocalizationName(this.Request);
            string path = Server.MapPath("~/Content/Localization/");
            //return StiMvcDesignerHelper.GetLocalizationResult(path + name);
            return null;
        }
    }
}
