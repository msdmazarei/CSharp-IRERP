using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Headers;
using NHibernate.Criterion;
using NHibernate;


namespace IRERP_RestAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_BeginRequest() 
        {
#if DEBUG
            System.Diagnostics.Trace.WriteLine(
                "OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO Request From :" + 
                HttpContext.Current.Request.UserHostAddress.ToString()+" OOOOO ContextNo:"
                +HttpContext.Current.GetHashCode().ToString()
                );
#endif
      //      MsdLib.CSharp.DALCore.DbSessionManager.GetSession(); //Create Session
        }
        protected void Application_Start()
        {

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            RegisterApis(GlobalConfiguration.Configuration);
            //TO setuap DB
            //DAL.SetupDb();
            
        }
        protected void Application_EndRequest(object sender, EventArgs args)
        {
            //MsdLib.CSharp.DALCore.DbSessionManager.CloseSession();
        }
        public static void RegisterApis(HttpConfiguration config)
        {
            // Add IRERPSerializer  formatter instead - add at top to make default
            //config.Formatters.Insert(0, new JavaScriptSerializerFormatter());
            config.Formatters.Insert(0, new IRERP_RestAPI.Bases.ClientEngine.IRERPSerializerFormatter());

            
        }
    }
}