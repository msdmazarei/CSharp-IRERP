using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
   public class IREREP_SM_VStack : IRERP_SM_Layout
    {
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.VStack.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.VStack.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}
