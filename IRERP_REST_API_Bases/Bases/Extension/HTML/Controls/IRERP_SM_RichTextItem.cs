using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_RichTextItem :IRERP_SM_CanvasItem/* TIRERP_SM_RichTextItem<IRERP_SM_RichTextItem> { }
    public class TIRERP_SM_RichTextItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/

    {

        public IRERP_SM_RichTextItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.text;
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