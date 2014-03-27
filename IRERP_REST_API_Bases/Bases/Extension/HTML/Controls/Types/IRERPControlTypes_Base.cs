using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class IRERPControlTypes_Base : IRERPControlBase { }
    public class TIRERPControlTypes_Base <T> : IRERPControlTypes_Base
        where T : IRERPControlTypes_Base
    {
        public T SET<PT>(Expression<Func<T, object>> express, PT value)
        {
            ((PropertyInfo)IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetClassMember(express)).SetValue
            (this, value, null);
            return (T)(IRERPControlTypes_Base)this;
        }
    }
}