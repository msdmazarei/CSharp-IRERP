using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRER_SM_HiddenItem : IRERP_SM_FormItem/*TIRER_SM_HiddenItem<IRER_SM_HiddenItem> { }
    public class TIRER_SM_HiddenItem <T>: TIRERP_SM_FormItem<T>
        where T : IRERPControlBase*/

    {
        public IRER_SM_HiddenItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.hidden;
        }

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