using IRERP_RestAPI.Bases.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.IRERPActionResults
{
    public class IRERPAddResponseActionResult : ActionResult
    {
        AddResponse response { get; set; }

        public IRERPAddResponseActionResult(AddResponse addResponse)
        {
            response = addResponse;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(response.ToJson());
        }
    }
}