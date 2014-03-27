using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_ToolStripButton : IRERP_SM_Button/* TIRERP_SM_ToolStripButton<IRERP_SM_ToolStripButton> { }
        public class TIRERP_SM_ToolStripButton<T>:TIRERP_SM_Button<T>
            where T : IRERPControlBase*/
    {

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.ToolStripButton.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.ToolStripButton.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}