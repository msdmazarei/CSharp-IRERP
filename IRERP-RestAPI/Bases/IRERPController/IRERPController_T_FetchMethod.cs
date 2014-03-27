using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.IRERPController
{
    partial class IRERPControllers<T> : IRERPController
       where T : IRERPControllerMetaModel.ControllerMetaModelBase<T>
    {
        public override IRERPActionResults.IRERPFetchResponseActionResult FetchMethod(ClientEngine.FetchRequest req)
        {
            
            return base.FetchMethod(req);
        }
    }
}