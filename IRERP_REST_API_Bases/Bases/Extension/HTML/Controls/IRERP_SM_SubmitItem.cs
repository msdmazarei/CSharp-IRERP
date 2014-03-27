using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_SubmitItem : IRERP_SM_ButtonItem/*TIRERP_SM_SubmitItem<IRERP_SM_SubmitItem> { }

    public class TIRERP_SM_SubmitItem<T> : TIRERP_SM_ButtonItem<T>
        where T: IRERPControlBase*/

    {
        //public virtual string title { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");


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