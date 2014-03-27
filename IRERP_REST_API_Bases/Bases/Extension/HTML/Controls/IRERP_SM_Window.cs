using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Window : IRERP_SM_Layout/* TIRERP_SM_Window<IRERP_SM_Window> { }
    public class TIRERP_SM_Window<T> : TIRERP_SM_Layout<T>
        where T:IRERPControlBase*/
      {
        public virtual Types.IRERPControlTypes_HTMLString title { get; set; }
        public virtual bool? autoSize { get; set; }
        public virtual bool? autoCenter { get; set; }
        public virtual bool? isModal { get; set; }
        public virtual bool? showHeader { get; set; }
        public virtual bool? canDragResize { get; set; }
        public virtual string bodyColor { get; set; }
        public virtual bool? showMaximizeButton { get; set; }
        public virtual string src { get; set; }

        bool? _showModalMask;
        public virtual bool? showModalMask { get { return _showModalMask; } set { if (IsInInitializeTime) _showModalMask = value; else throw NotImplementerdForIR(); } }

        IRERPControlBase[] _items;
        public virtual IRERPControlBase[] items { get { return _items; } set { if (IsInInitializeTime) _items = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + enum2JSON(title) + "");
                if (autoSize != null) Parts.Add("autoSize", "autoSize:" + bool2JSON((bool)autoSize) + "");

                if (autoCenter != null) Parts.Add("autoCenter", "autoCenter:" + bool2JSON((bool)autoCenter) + "");
                if (isModal != null) Parts.Add("isModal", "isModal:" + bool2JSON((bool)isModal) + "");
                if (showHeader != null) Parts.Add("showHeader", "showHeader:" + bool2JSON((bool)showHeader) + "");

                if (showModalMask != null) Parts.Add("showModalMask", "showModalMask:" + bool2JSON((bool)showModalMask) + "");

                if (src != null) Parts.Add("src", "src:" + string2JSON(src) + "");
                if (bodyColor != null) Parts.Add("bodyColor", "bodyColor:" + string2JSON(bodyColor) + "");
                if (canDragResize != null) Parts.Add("canDragResize", "canDragResize:" + bool2JSON(canDragResize));
                List<string> _fi = new List<string>();
                if (items != null) foreach (var a in items) _fi.Add(a.ToStringAsMemberOfOther());
                if (items != null) Parts.Add("items", "items:[" + string.Join(",", _fi) + "]");
                if (showMaximizeButton != null) Parts.Add("showMaximizeButton", "showMaximizeButton :" + bool2JSON(showMaximizeButton));
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

                return "isc.Window.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }

        public override string ToString()
        {
            if (IsInInitializeTime)

                return "isc.Window.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}