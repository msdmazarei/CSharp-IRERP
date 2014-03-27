using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IRERP_RestAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //  /Controller/DataSource/Profile -- > object 
            //  /Controller/DataSource/Profile/ClassMember --> Return ClassMember ->User.Member
            //  /Controller/DataSource/Profile/ClassMember1/SubClassMember  --> User.Member.Member
            //  /Controller/DataSource/Profile/ClassMember1/SubClassMember/...  --> User.Member.Member...

            routes.MapRoute("DataSource", "{controller}/{DataSource}/{*parts}", 
                defaults: new { controller = "Home", action = "DataSource" },
                constraints: new { DataSource = @"DataSource"}
                );
            routes.MapRoute("SummaryMessage", "{controller}/{SummaryMessage}/{*parts}",
            defaults: new { controller = "Home", action = "SummaryMessage" },
            constraints: new { SummaryMessage = @"SummaryMessage" }
            );

            routes.MapRoute("FileFieldUpload", "{controller}/{FileFieldUpload}/{*parts}",
          defaults: new { controller = "Home", action = "FileFieldUpload" },
          constraints: new { FileFieldUpload = @"FileFieldUpload" }
          );



        }
    }
}