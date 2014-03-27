using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_VLayout : IRERP_SM_Layout/* TIRERP_SM_VLayout<IRERP_SM_VLayout> { }
    public class TIRERP_SM_VLayout <T>: TIRERP_SM_Layout<T>
        where T : IRERPControlBase*/
    {
        public IRERP_SM_VLayout()
        {
            /*width="100%";
            height = "100%";*/
        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.VLayout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.VLayout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}