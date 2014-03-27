using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_FloatItem : IRERP_SM_TextItem/* TIRER_SM_FloatItem<IRER_SM_FloatItem> { }

    public class TIRER_SM_FloatItem <T>: TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/
    
   
    {
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "}";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "};";
            else
                return "";
        }

    }
}