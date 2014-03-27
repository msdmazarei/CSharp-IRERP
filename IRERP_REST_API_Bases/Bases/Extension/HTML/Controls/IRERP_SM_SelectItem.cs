using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_SelectItem : IRERP_SM_FormItem/* TIRERP_SM_SelectItem<IRERP_SM_SelectItem> { }

    public class TIRERP_SM_SelectItem <T>: TIRERP_SM_FormItem<T>
        where T: IRERPControlBase*/
    
    {
        public IRERP_SM_SelectItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.irerpSelectItem;
        }
        public virtual bool? addUnknownValues { get; set; }
        public virtual bool? allowEmptyValue { get; set; }
        public virtual bool? defaultToFirstOption { get; set; }
        public virtual bool? escapeHTML { get; set; }
        public virtual bool? hiliteOnFocus { get; set; }
        bool? _autoFetchData;
        public virtual bool? autoFetchData { get { return _autoFetchData; } set { if (IsInInitializeTime) _autoFetchData = value; else throw NotImplementerdForIR(); } }

        bool? _cachePickListResults;
        public virtual bool? cachePickListResults { get { return _cachePickListResults; } set { if (IsInInitializeTime) _cachePickListResults = value; else throw NotImplementerdForIR(); } }

        bool? _fetchDisplayedFieldsOnly;
        public virtual bool? fetchDisplayedFieldsOnly { get { return _fetchDisplayedFieldsOnly; } set { if (IsInInitializeTime) _fetchDisplayedFieldsOnly = value; else throw NotImplementerdForIR(); } }

      
        public virtual string hiliteColor { get; set; }

        public virtual string hiliteTextColor { get; set; }
        public virtual bool? multiple { get; set; }

        IRERPControlTypes_MultipleAppearance? _multipleAppearance;
        public virtual IRERPControlTypes_MultipleAppearance? multipleAppearance { get { return _multipleAppearance; } set { if (IsInInitializeTime) _multipleAppearance = value; else throw NotImplementerdForIR(); } }

       
        
        public virtual int? pickButtonHeight { get; set; }
        public virtual string pickButtonSrc { get; set; }
        public virtual int? pickButtonWidth { get; set; }

        object _pickerIconProperties;
        public virtual object pickerIconProperties { get { return _pickerIconProperties; } set { if (IsInInitializeTime) _pickerIconProperties = value; else throw NotImplementerdForIR(); } }

        IRERP_SM_ListGrid _pickListProperties;
        public virtual IRERP_SM_ListGrid pickListProperties { get { return _pickListProperties; } set { if (IsInInitializeTime) _pickListProperties = value; else throw NotImplementerdForIR(); } }

        public virtual bool? progressiveLoading { get; set; }
        public virtual bool? showFocused { get; set; }
        public virtual bool? showHintInField { get; set; }
        public virtual bool? showOptionsFromDataSource { get; set; }
        public virtual bool? showOver { get; set; }
        public virtual bool? showPickerIcon { get; set; }

        string _sortField;
        public virtual string sortField { get { return _sortField; } set { if (IsInInitializeTime) _sortField = value; else throw NotImplementerdForIR(); } }

        public virtual string valueField { get; set; }

        string _optionFilterContext;
        public virtual string optionFilterContext { get { return _optionFilterContext; } set { if (IsInInitializeTime) _optionFilterContext = value; else throw NotImplementerdForIR(); } }

        IRERP_SM_ListGridFiled[] _pickListFields;
        public virtual IRERP_SM_ListGridFiled[] pickListFields { get { return _pickListFields; } set { if (IsInInitializeTime) _pickListFields = value; else throw NotImplementerdForIR(); } }

        public virtual Types.IRERPControlTypes_Criteria pickListCriteria { get; set; }
        public virtual string MsdManageUrl { get; set; }
        public virtual string MsdHoverFields { get; set; }
        public virtual string MsdHelpMessage { get; set; }
        public virtual Types.IRERPControlTypes_StringMethods MsdWindowManageTitle { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (addUnknownValues != null) Parts.Add("addUnknownValues", "addUnknownValues:" + bool2JSON((bool)addUnknownValues) + "");
                if (allowEmptyValue != null) Parts.Add("allowEmptyValue", "allowEmptyValue:" + bool2JSON((bool)allowEmptyValue) + "");
                if (defaultToFirstOption != null) Parts.Add("defaultToFirstOption", "defaultToFirstOption:" + bool2JSON((bool)defaultToFirstOption) + "");
                if (escapeHTML != null) Parts.Add("escapeHTML", "escapeHTML:" + bool2JSON((bool)escapeHTML) + "");
                if (hiliteOnFocus != null) Parts.Add("hiliteOnFocus", "hiliteOnFocus:" + bool2JSON((bool)hiliteOnFocus) + "");
                if (autoFetchData != null) Parts.Add("autoFetchData", "autoFetchData:" + bool2JSON((bool)autoFetchData) + "");
                if (cachePickListResults != null) Parts.Add("cachePickListResults", "cachePickListResults:" + bool2JSON((bool)cachePickListResults) + "");
                if (fetchDisplayedFieldsOnly != null) Parts.Add("fetchDisplayedFieldsOnly", "fetchDisplayedFieldsOnly:" + bool2JSON((bool)fetchDisplayedFieldsOnly) + "");
                if (multiple != null) Parts.Add("multiple", "multiple:" + bool2JSON((bool)multiple) + "");
                if (progressiveLoading != null) Parts.Add("progressiveLoading", "progressiveLoading:" + bool2JSON((bool)progressiveLoading) + "");
                if (showFocused != null) Parts.Add("showFocused", "showFocused:" + bool2JSON((bool)showFocused) + "");
                if (showOptionsFromDataSource != null) Parts.Add("showOptionsFromDataSource", "showOptionsFromDataSource:" + bool2JSON((bool)showOptionsFromDataSource) + "");
                if (showOver != null) Parts.Add("showOver", "showOver:" + bool2JSON((bool)showOver) + "");
                if (showPickerIcon != null) Parts.Add("showPickerIcon", "showPickerIcon:" + bool2JSON((bool)showPickerIcon) + "");
                if (selectOnFocus != null) Parts.Add("selectOnFocus", "selectOnFocus:" + bool2JSON((bool)selectOnFocus) + "");
                if (showHintInField != null) Parts.Add("showHintInField", "showHintInField:" + bool2JSON((bool)showHintInField) + "");
                if (hiliteColor != null) Parts.Add("hiliteColor", "hiliteColor:" + string2JSON(hiliteColor.ToString()) + "");
                if (hiliteTextColor != null) Parts.Add("hiliteTextColor", "hiliteTextColor:" + string2JSON(hiliteTextColor.ToString()) + "");
                if (pickButtonHeight != null) Parts.Add("pickButtonHeight", "pickButtonHeight:" + int2JSON((int)pickButtonHeight) + "");
                if (pickButtonWidth != null) Parts.Add("pickButtonWidth", "pickButtonWidth:" + int2JSON((int)pickButtonWidth) + "");
                if (pickButtonSrc != null) Parts.Add("pickButtonSrc", "pickButtonSrc:" + string2JSON(pickButtonSrc.ToString()) + "");
                if (valueField != null) Parts.Add("valueField", "valueField:" + string2JSON(valueField.ToString()) + "");
                if (sortField != null) Parts.Add("sortField", "sortField:" + string2JSON(sortField.ToString()) + "");
                if (multipleAppearance != null) Parts.Add("multipleAppearance", "multipleAppearance:" + enum2JSON(multipleAppearance) + "");
               //============================================================== 
                
                
                if (pickListProperties != null) Parts.Add("pickListProperties", "pickListProperties:" + pickListProperties.ToStringWithoutConstructor() + "");
                //================================================
                
                if (pickerIconProperties != null) Parts.Add("pickerIconProperties", "pickerIconProperties:" +Object2JSON(pickerIconProperties) + "");

                if (optionFilterContext != null) Parts.Add("optionFilterContext", "optionFilterContext:" + string2JSON(optionFilterContext.ToString()) + "");

                List<string> _fi = new List<string>();
                if (pickListFields != null) foreach (var a in pickListFields) _fi.Add(a.ToStringAsMemberOfOther());
                if (pickListFields != null) Parts.Add("pickListFields", "pickListFields:[" + string.Join(",", _fi) + "]");

                if (pickListCriteria != null) Parts.Add("pickListCriteria", "pickListCriteria:" + pickListCriteria.ToStringAsMemberOfOther() + "");
                if (MsdManageUrl != null) Parts.Add("MsdManageUrl", "MsdManageUrl:" + string2JSON(MsdManageUrl));
                if (MsdHoverFields != null) Parts.Add("MsdHoverFields", "MsdHoverFields:" + MsdHoverFields);
                if (MsdHelpMessage != null) Parts.Add("MsdHelpMessage", "MsdHelpMessage:" + string2JSON(MsdHelpMessage));
                if (MsdWindowManageTitle != null) Parts.Add("MsdWindowManageTitle", "MsdWindowManageTitle:" + MsdWindowManageTitle.ToString());
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