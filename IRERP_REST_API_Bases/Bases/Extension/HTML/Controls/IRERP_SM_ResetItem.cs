using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_ResetItem : IRERP_SM_ButtonItem/* TIRERP_SM_ResetItem<IRERP_SM_ResetItem> { }

    public class TIRERP_SM_ResetItem <T>: TIRERP_SM_ButtonItem<T>
        where T: IRERPControlBase*/
  
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