using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_AutoFitTextAreaItem : IRERP_SM_TextAreaItem/* TIRERP_SM_AutoFitTextAreaItem<IRERP_SM_AutoFitTextAreaItem> { }
    public class TIRERP_SM_AutoFitTextAreaItem <T>: TIRERP_SM_TextAreaItem<T>
        where T : IRERPControlBase*/

    {
        public virtual int? maxHeight { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (maxHeight != null) Parts.Add("maxHeight", "maxHeight:" + int2JSON((int)maxHeight) + "");

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