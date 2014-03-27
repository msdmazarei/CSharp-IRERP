using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IRERP_RestAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "IRERP-api/DS-General/{profile}/{class}/",
                defaults: new  { controller="IRERPGeneralEntity" }
               
            );

            config.Routes.MapHttpRoute(
               name: "DefaultApi1",
               routeTemplate: "IRERP-api/DS-General/{profile}/{class}/{property}",
               defaults: new { controller="IRERPGeneralEntity"}
           );
   
        }
    }
}
