using System.Web.Mvc;

namespace IRERP_RestAPI.Areas.Report
{
    public class ReportAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Report";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Report_default",
                "Report/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute("ReportArea_DataSource", "Report/{controller}/{DataSource}/{*parts}",
            defaults: new { controller = "Home", action = "DataSource" },
            constraints: new { DataSource = @"DataSource" }
            );
        }
    }
}
