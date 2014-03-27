using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.ActionFilters
{
    
    public class RedirectToLoginIfUserNotLogged : ActionFilterAttribute
    {
        string _LoginController = "";
        public RedirectToLoginIfUserNotLogged(string LoginController = "/Login" )
        {
            _LoginController = LoginController;
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (InstanceStatics.LoggedUser == null)
        {
            string calltype = filterContext.HttpContext.Request.Form["calltype"];
            if (calltype == "ajaxCall")
            {
                filterContext.Result = new GeneralAction();
            } 
            else

                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = _LoginController }));
           
        }
    }
    }

    public class GeneralAction : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write("Test");
        }
    }
}