using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class IRERPControlTypes_StringMethods
    {
         string _value = null;
         bool isJsFunction = false;
         string[] args = null;
         public IRERPControlTypes_StringMethods(string[] _args,string str, bool isJsFunction = false)
         {
             this.isJsFunction = isJsFunction;
             _value = str;
             this.args = _args;
         }
         public IRERPControlTypes_StringMethods(string str,bool isJsFunction=false)
        {
            this.isJsFunction = isJsFunction;
            _value = str;

        }
        public override string ToString()
        {
            string funcdef = "function (){";
            if (isJsFunction) return _value;
            else
            {
                if (args != null)
                {
                    funcdef = "function(" + string.Join(",", args) + "){";
                }
                

                return funcdef + _value + "}";
            }
        }
    }
}