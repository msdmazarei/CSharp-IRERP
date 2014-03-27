using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_ToolbarItem : IRERP_SM_CanvasItem/* TIRERP_SM_ToolbarItem<IRERP_SM_ToolbarItem> { }

    public class TIRERP_SM_ToolbarItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
  
    {
      
        public virtual IRERPControlBase buttonConstructor { get; set; }
        object _buttonProperties;
        public virtual object buttonProperties { get { return _buttonProperties; } set { if (IsInInitializeTime) _buttonProperties = value; else throw NotImplementerdForIR(); } }
        bool? _vertical;
        public virtual bool? vertical { get { return _vertical; } set { if (IsInInitializeTime) _vertical = value; else throw NotImplementerdForIR(); } }
        public virtual IRERP_SM_Button[] buttons { get; set; }

         
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (vertical != null) Parts.Add("vertical", "vertical:" + bool2JSON((bool)vertical) + "");
                if (buttonProperties != null) Parts.Add("buttonProperties", "buttonProperties:" + Object2JSON(buttonProperties) + "");
                if (buttonConstructor != null) Parts.Add("buttonConstructor", "buttonConstructor:" + string2JSON(buttonConstructor.ToStringAsMemberOfOther()) + "");

                List<string> _fi = new List<string>();

                if (buttons != null) foreach (var a in buttons) _fi.Add(a.ToStringAsMemberOfOther());

                if (buttons != null) Parts.Add("buttons", "buttons:[" + string.Join(",", _fi) + "]");


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