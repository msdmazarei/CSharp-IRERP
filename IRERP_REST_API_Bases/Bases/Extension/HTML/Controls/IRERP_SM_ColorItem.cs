using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_ColorItem : IRERP_SM_TextItem/* TIRERP_SM_ColorItem<IRERP_SM_ColorItem> { }
    public class TIRERP_SM_ColorItem<T> : TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/
  
    {
        public IRERP_SM_ColorItem() 
        {
            this.type = Types.IRERPControlTypes_FormItemType.color;
        }
        bool? _allowComplexMode;
        public virtual bool? allowComplexMode { get { return _allowComplexMode; } set { if (IsInInitializeTime) _allowComplexMode = value; else throw NotImplementerdForIR(); } }

        string _defaultPickerMode;
        public virtual string defaultPickerMode { get { return _defaultPickerMode; } set { if (IsInInitializeTime) _defaultPickerMode = value; else throw NotImplementerdForIR(); } }

        public virtual object pickerIconProperties { get; set; }
        public virtual bool? showPickerIcon { get; set; }

        public virtual bool? supportsTransparency { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (allowComplexMode != null) Parts.Add("allowComplexMode", "allowComplexMode:" + bool2JSON((bool)allowComplexMode) + "");
                if (showPickerIcon != null) Parts.Add("showPickerIcon", "showPickerIcon:" + bool2JSON((bool)showPickerIcon) + "");
                if (supportsTransparency != null) Parts.Add("supportsTransparency", "supportsTransparency:" + bool2JSON((bool)supportsTransparency) + "");
                if (defaultPickerMode != null) Parts.Add("defaultPickerMode", "defaultPickerMode:" + string2JSON(defaultPickerMode.ToString()) + "");
                if (pickerIconProperties != null) Parts.Add("pickerIconProperties", "pickerIconProperties:" + Object2JSON(pickerIconProperties) + "");

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