using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Tab:/* TIRERP_SM_Tab<IRERP_SM_Tab> { }
    public class TIRERP_SM_Tab<T> : */IRERPControlBase
    {
        public virtual string title { get; set; }
        public virtual IRERPControlBase pane { get; set; }
        public virtual string ID { get; set; }
        public virtual string width { get; set; }
        public virtual string height { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");
                if (ID != null) Parts.Add("ID", "ID:" + string2JSON(ID.ToString()) + "");
                if (width != null) Parts.Add("width", "width:" + string2JSON(width.ToString()) + "");
                if (height != null) Parts.Add("height", "height:" + string2JSON(height.ToString()) + "");

              
               
                if (pane != null) Parts.Add("pane", "pane:" + pane.ToStringAsMemberOfOther()+ "");

                return Parts;
            }
            else
            {
                return new Dictionary<string, string>();
            }

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