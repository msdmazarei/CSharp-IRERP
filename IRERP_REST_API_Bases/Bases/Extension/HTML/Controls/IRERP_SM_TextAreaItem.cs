using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_TextAreaItem : IRERP_SM_FormItem /*TIRERP_SM_TextAreaItem<IRERP_SM_TextAreaItem> { }
    public class TIRERP_SM_TextAreaItem <T>: TIRERP_SM_FormItem<T>
        where T : IRERPControlBase*/
  
    {
        public IRERP_SM_TextAreaItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.text;
        }
        public virtual bool? changeOnKeypress { get; set; }
        public virtual object emptyStringValue { get; set; }
        public virtual int? minHeight { get; set; }
        public virtual bool? printFullText { get; set; }
        public virtual bool? showHintInField { get; set; }
        public virtual IRERPControlTypes_TEXTAREA_WRAP? wrap { get; set; }
        public virtual string MsdHelpMessage { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (changeOnKeypress != null) Parts.Add("changeOnKeypress", "changeOnKeypress:" + bool2JSON((bool)changeOnKeypress) + "");
                if (printFullText != null) Parts.Add("printFullText", "printFullText:" + bool2JSON((bool)printFullText) + "");
                if (showHintInField != null) Parts.Add("showHintInField", "showHintInField:" + bool2JSON((bool)showHintInField) + "");
                if (emptyStringValue != null) Parts.Add("emptyStringValue", "emptyStringValue:" + Object2JSON(emptyStringValue) + "");
                if (minHeight != null) Parts.Add("minHeight", "minHeight:" + int2JSON((int)minHeight) + "");
                if (wrap != null) Parts.Add("wrap", "wrap:" + enum2JSON(wrap) + "");
                if (MsdHelpMessage != null) Parts.Add("MsdHelpMessage", "MsdHelpMessage:" + string2JSON(MsdHelpMessage));


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