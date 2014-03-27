using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_MenuButton : IRERP_SM_Button/* TIRERP_SM_MenuButton<IRERP_SM_MenuButton> { }
    public class TIRERP_SM_MenuButton<T> : TIRERP_SM_Button<T>
        where T : IRERPControlBase*/
    
    {
        public virtual IRERP_SM_Menu menu { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();

                if (menu != null) Parts.Add("menu", "menu:" + menu.ToStringAsMemberOfOther() + "");
                return Parts;
            }
            else
            { return new Dictionary<string, string>(); }

        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.irerpMenuButton.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.irerpMenuButton.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}