using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class IRERPControlTypes_HTMLString 
    {
        string _value = null;
        public IRERPControlTypes_HTMLString(string str)
        {
            _value = str;
        }
        public override string ToString()
        {
            return _value;
        }
    }
}