using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_FromString : IRERPControlBase
    {
        public string str { get; set; }
        public bool Simicolumnafter_intostring { get; set; }
        public IRERP_SM_FromString(string str,bool Simicolumnafter_intostring=true)
        {
            this.str = str;
            this.Simicolumnafter_intostring = Simicolumnafter_intostring;
        }
        public IRERP_SM_FromString(MvcHtmlString str)
        {
            this.str = str.ToString();

        }
        public override string ToString()
        {
            if (Simicolumnafter_intostring)
                return str + ";";
            else return str;
        }
        public override string ToStringAsMemberOfOther()
        {
            if (str != null)
            {
                string trimmedstr = str.Trim();
                if (trimmedstr[trimmedstr.Length - 1] == ';')
                    return trimmedstr.Substring(0, trimmedstr.Length - 1);
            }
            return str;
        }
    }
}
