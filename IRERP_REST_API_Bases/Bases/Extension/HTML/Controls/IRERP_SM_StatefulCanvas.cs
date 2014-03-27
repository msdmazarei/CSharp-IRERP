using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_StatefulCanvas : IRERP_SM_Canvas/* TIRERP_SM_Label<IRERP_SM_StatefulCanvas> { }
    public class TIRERP_SM_StatefulCanvas<T> : TIRERP_SM_Canvas<T>
        where T : IRERPControlBase*/
    {
        public Nullable<Types.IRERPControlTypes_Alignment> align { get; set; }

        public virtual Types.IRERPControlTypes_HTMLString title { get; set; }
        public virtual string baseStyle { get; set; }
        public virtual string icon { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");
                if (baseStyle != null) Parts.Add("baseStyle", "baseStyle:" + string2JSON(baseStyle) + "");
                if (icon != null) Parts.Add("icon", "icon:" + string2JSON(icon) + "");
                if (align != null) Parts.Add("align", "align:" + enum2JSON(align) + "");


                return Parts;
            }
            else
            {
                return new Dictionary<string, string>();
            }

        }
    }
}