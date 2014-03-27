using System.Web.Mvc;

namespace IRERP_RestAPI.Areas.BaseInformation
{
    public class BaseInformationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BaseInformation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BaseInformation_default",
                "BaseInformation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute("BaseInformationArea_DataSource", "BaseInformation/{controller}/{DataSource}/{*parts}",
    defaults: new { controller = "Bases", action = "DataSource" },
    constraints: new { DataSource = @"DataSource" }
    );


            context.MapRoute("BaseInformationArea_FileFieldUpload", "BaseInformation/{controller}/{FileFieldUpload}/{*parts}",
    defaults: new { controller = "Bases", action = "FileFieldUpload" },
    constraints: new { FileFieldUpload = @"FileFieldUpload" }
    );
        }
    }
}
