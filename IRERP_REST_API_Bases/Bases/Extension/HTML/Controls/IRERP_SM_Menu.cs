using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Menu : IRERP_SM_ListGrid /*TIRERP_SM_Menu<IRERP_SM_Menu> { }
    public class TIRERP_SM_Menu<T> : TIRERP_SM_ListGrid<T>
        where T : IRERPControlBase*/
    {
        public IRERPControlTypes_StringMethods itemClick { get; set; }

        public virtual IRERP_SM_MenuItem[] data { get; set; }
        
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (itemClick != null) Parts.Add("itemClick", "itemClick:" + itemClick.ToString() + "");

                List<string> _fi = new List<string>();

              if(data!=null)foreach (var a in data) _fi.Add(a.ToStringAsMemberOfOther());

                if (data != null) Parts.Add("data", "data:[" + string.Join(",", _fi) + "]");
                return Parts;
            }
            else
            { return new Dictionary<string, string>(); }

        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.irerpMenu.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.irerpMenu.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}