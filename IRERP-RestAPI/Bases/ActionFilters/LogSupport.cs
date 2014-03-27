using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.Routing;
namespace IRERP_RestAPI.Bases.ActionFilters
{
    public class LogSupport : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logger = IRERP_RestAPI.Bases.IRERPApplicationUtilities.Logger();
            if (InstanceStatics.LoggedUser != null)
                logger.eventID = -1;//InstanceStatics.LoggedUser.id;
            else
                logger.eventID = 0;

            /*string path = logger.LogPath;
            if (path.Substring(path.Length - 1, 1) != "\\") path += "\\";
            
            if (InstanceStatics.LoggedUser != null)
                logger.correctpath = path + DateTime.Now.ToShortDateString().Replace("/", "-") + "\\" + InstanceStatics.LoggedUser.Email + "\\";
            else
                logger.correctpath = path + DateTime.Now.ToShortDateString().Replace("/", "-") + "\\MSDSYS\\";*/

        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            IRERPApplicationUtilities.Logger().WriteToFiles();
            base.OnResultExecuted(filterContext);
        }
    }
}