using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_ButtonItem : IRERP_SM_CanvasItem /*TIRERP_SM_ButtonItem<IRERP_SM_ButtonItem> { }

    public class TIRERP_SM_ButtonItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
  
    {
        public IRERP_SM_ButtonItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.button;
        }
        bool? _autoFit;
        public virtual bool? autoFit { get { return _autoFit; } set { if (IsInInitializeTime) _autoFit = value; else throw NotImplementerdForIR(); } }

        public IRERPControlTypes_StringMethods click { get; set; }

        IRERPControlBase _buttonConstructor;
        public virtual IRERPControlBase buttonConstructor { get { return _buttonConstructor; } set { if (IsInInitializeTime) _buttonConstructor = value; else throw NotImplementerdForIR(); } }

        object _buttonProperties;
        public virtual object buttonProperties { get { return _buttonProperties; } set { if (IsInInitializeTime) _buttonProperties = value; else throw NotImplementerdForIR(); } }


        string _icon;
        public virtual string icon { get { return _icon; } set { if (IsInInitializeTime) _icon = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (autoFit != null) Parts.Add("autoFit", "autoFit:" + bool2JSON((bool)autoFit) + "");
                if (icon != null) Parts.Add("icon", "icon:" + string2JSON(icon.ToString()) + "");
                if (buttonProperties != null) Parts.Add("buttonProperties", "buttonProperties:" + Object2JSON(buttonProperties) + "");
                if (buttonConstructor != null) Parts.Add("buttonConstructor", "buttonConstructor:" + buttonConstructor.ToStringAsMemberOfOther() + "");
                if (click != null) Parts.Add("click", "click:" + click.ToString() + "");

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