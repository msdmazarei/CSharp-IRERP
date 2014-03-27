using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Chart : IRERP_SM_Label
    {
        public Types.IRERPControlTypes_StringMethods dataRenderer { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            var parts = base.GetOutPutParts();
           if(dataRenderer !=null) parts.Add("dataRenderer","dataRenderer:"+ dataRenderer.ToString());
           return parts;
        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.IRERPChart.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.IRERPChart.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}