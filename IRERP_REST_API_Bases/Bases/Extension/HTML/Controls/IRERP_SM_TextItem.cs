using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
     public class IRERP_SM_TextItem :IRERP_SM_FormItem /*TIRERP_SM_TextItem<IRERP_SM_TextItem> { }

    public class TIRERP_SM_TextItem<T>: TIRERP_SM_FormItem<T>
        where T : TIRERP_SM_FormItem<T>*/
     
    { 
        public virtual bool? changeOnKeypress { get; set; }
        public virtual IRERPControlTypes_CharacterCasing? characterCasing { get; set; }
        public virtual object emptyStringValue { get; set; }
        public virtual bool? formatOnFocusChange { get; set; }
        public virtual string keyPressFilter { get; set; }
        public virtual int? length { get; set; }
        public virtual string mask { get; set; }
        public virtual bool? maskOverwriteMode { get; set; }
        public virtual string maskPadChar { get; set; }
        public virtual string maskPromptChar { get; set; }
        public virtual bool? maskSaveLiterals { get; set; }
        public virtual bool? printFullText { get; set; }
        public virtual bool? showHintInField { get; set; }
        public virtual string MsdHelpMessage { get; set; }
      public IRERP_SM_TextItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.irerpTextItem;
        }
        
            protected override Dictionary<string, string> GetOutPutParts()
            {
                if (IsInInitializeTime)
                {
                    var Parts = base.GetOutPutParts();
                    if (keyPressFilter != null) Parts.Add("keyPressFilter", "keyPressFilter:" + string2JSON(keyPressFilter.ToString()) + "");
                    if (changeOnKeypress != null) Parts.Add("changeOnKeypress", "changeOnKeypress:" + bool2JSON((bool)changeOnKeypress) + "");
                    if (formatOnFocusChange != null) Parts.Add("formatOnFocusChange", "formatOnFocusChange:" + bool2JSON((bool)formatOnFocusChange) + "");
                    if (maskOverwriteMode != null) Parts.Add("maskOverwriteMode", "maskOverwriteMode:" + bool2JSON((bool)maskOverwriteMode) + "");
                    if (maskSaveLiterals != null) Parts.Add("maskSaveLiterals", "maskSaveLiterals:" + bool2JSON((bool)maskSaveLiterals) + "");
                    if (printFullText != null) Parts.Add("printFullText", "printFullText:" + bool2JSON((bool)printFullText) + "");
                    if (showHintInField != null) Parts.Add("showHintInField", "showHintInField:" + bool2JSON((bool)showHintInField) + "");
                    if (mask != null) Parts.Add("mask", "mask:" + string2JSON(mask.ToString()) + "");
                    if (maskPadChar != null) Parts.Add("maskPadChar", "maskPadChar:" + string2JSON(maskPadChar.ToString()) + "");
                    if (maskPromptChar != null) Parts.Add("maskPromptChar", "maskPromptChar:" + string2JSON(maskPromptChar.ToString()) + "");
                    if (length != null) Parts.Add("length", "length:" + int2JSON((int)length) + "");
                    if (characterCasing != null) Parts.Add("characterCasing", "characterCasing:" + enum2JSON(characterCasing) + "");
                    if (emptyStringValue != null) Parts.Add("emptyStringValue", "emptyStringValue:" + Object2JSON(emptyStringValue) + "");
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