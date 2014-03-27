using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_CancelItem : IRERP_SM_ButtonItem/* TIRER_SM_CancelItem<IRER_SM_CancelItem> { }

    public class TIRER_SM_CancelItem<T> : TIRERP_SM_ButtonItem<T>
        where T: IRERPControlBase*/
    {
        //public virtual string title { get; set; }

        public IRERP_SM_CancelItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.cancel;
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