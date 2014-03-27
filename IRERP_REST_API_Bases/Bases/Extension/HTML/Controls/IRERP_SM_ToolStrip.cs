using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_ToolStrip : IRERP_SM_Layout /*TIRERP_SM_ToolStrip<IRERP_SM_ToolStrip> { }
        public class TIRERP_SM_ToolStrip<T>:TIRERP_SM_Layout<T>
            where T:IRERPControlBase*/
    {

            public override string ToStringAsMemberOfOther()
            {
                if (IsInInitializeTime)
                    return "isc.ToolStrip.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
                else
                    return "";
            }
            public override string ToString()
            {
                if (IsInInitializeTime)
                    return "isc.ToolStrip.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
                else
                    return "";
            }
        
    }
}