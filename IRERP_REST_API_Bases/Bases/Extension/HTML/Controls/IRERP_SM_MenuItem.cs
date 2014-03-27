using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_MenuItem : IRERP_SM_ListGridRecord/* TIRERP_SM_MenuItem<IRERP_SM_MenuItem> { }
    public class TIRERP_SM_MenuItem<T> : TIRERP_SM_ListGridRecord<T>
        where T:IRERPControlBase*/

    {
        string _title;
        public virtual string title { get { return _title; } set { if (IsInInitializeTime) _title = value; else throw NotImplementerdForIR(); } }
        IRERP_SM_Menu _submenu;
        public virtual IRERP_SM_Menu submenu { get { return _submenu; } set { if (IsInInitializeTime) _submenu = value; else throw NotImplementerdForIR(); } }
        public IRERPControlTypes_StringMethods click { get; set; }
        string _icon;
        public virtual string icon { get { return _icon; } set { if (IsInInitializeTime) _icon = value; else throw NotImplementerdForIR(); } }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();

                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");
                if (submenu != null) Parts.Add("submenu", "submenu:" + submenu.ToStringAsMemberOfOther() + "");
                if (click != null) Parts.Add("click", "click:" + click.ToString() + "");
                if (icon != null) Parts.Add("icon", "icon:" + string2JSON(icon.ToString()) + "");

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