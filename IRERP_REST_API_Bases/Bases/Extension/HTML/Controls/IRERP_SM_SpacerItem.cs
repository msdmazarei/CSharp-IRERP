using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_SpacerItem : IRERP_SM_FormItem/* TIRERP_SM_SpacerItem<IRERP_SM_SpacerItem> { }
    public class TIRERP_SM_SpacerItem <T>: TIRERP_SM_FormItem<T>
        where T : IRERPControlBase*/
  
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