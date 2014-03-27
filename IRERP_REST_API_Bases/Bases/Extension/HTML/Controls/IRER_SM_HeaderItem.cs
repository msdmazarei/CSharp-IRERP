using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_HeaderItem : IRERP_SM_FormItem/* TIRER_SM_HeaderItem<IRER_SM_HeaderItem> { }
    public class TIRER_SM_HeaderItem <T>: TIRERP_SM_FormItem<T>
        where T : IRERPControlBase*/
   
    {
        public IRERP_SM_HeaderItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.header;
        }
        public virtual bool? startRow { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (startRow != null) Parts.Add("startRow", "startRow:" + bool2JSON((bool)startRow) + "");
                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


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