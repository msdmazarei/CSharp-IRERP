using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Bases.Extension.Methods
{
    public static class  MvcViews
    {
        public static string CID(this System.Web.Mvc.WebViewPage view, string id)
    {
        return IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)view.ViewContext.Controller, id);
    }
        public static string FN<T>(this System.Web.Mvc.WebViewPage view,Expression<Func<T, object>> exp)
        {
            return IRERPApplicationUtilities.GPN(exp,false).ToClientDsFieldName()/* .Replace(".", "___")*/;
        }
    
    }
}