using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.IRERPActionResults
{
    public class IRERPMethodActionResult :ActionResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public object data { get; set; }
        public string RedirectToUrl { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(IRERPApplicationUtilities.ToJson(this));
        }
    }
}