using IRERP_RestAPI.Bases.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.IRERPActionResults
{
    public class IRERPFetchResponseActionResult : ActionResult
    {
         FetchResponse response { get; set; }
         public FetchResponse GetResponse() { return response; }

        public IRERPFetchResponseActionResult(FetchResponse fetch)
        {
            response = fetch;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Write(response.ToJson());
        }
    }
}