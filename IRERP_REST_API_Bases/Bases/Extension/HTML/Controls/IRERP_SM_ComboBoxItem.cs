using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_ComboBoxItem : IRERP_SM_TextItem/* TIRERP_SM_ComboBoxItem<IRERP_SM_ComboBoxItem> { }
    public class TIRERP_SM_ComboBoxItem <T>: TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/
  
    {
        public IRERP_SM_ComboBoxItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.comboBox;
        }
        public virtual bool? addUnknownValues { get; set; }
        public virtual bool? allowEmptyValue { get; set; }
        public virtual bool? completeOnTab { get; set; }
        public virtual bool? defaultToFirstOption { get; set; }
        bool? _cachePickListResults;
        public virtual bool? cachePickListResults { get { return _cachePickListResults; } set { if (IsInInitializeTime) _cachePickListResults = value; else throw NotImplementerdForIR(); } }

        bool? _fetchDisplayedFieldsOnly;
        public virtual bool? fetchDisplayedFieldsOnly { get { return _fetchDisplayedFieldsOnly; } set { if (IsInInitializeTime) _fetchDisplayedFieldsOnly = value; else throw NotImplementerdForIR(); } }

      
        bool? _filterWithValue;
        public virtual bool? filterWithValue { get { return _filterWithValue; } set { if (IsInInitializeTime) _filterWithValue = value; else throw NotImplementerdForIR(); } }
        public virtual bool? generateExactMatchCriteria { get; set; }
        public virtual Types.IRERPControlTypes_Criteria pickListCriteria { get; set; }
        IRERP_SM_ListGridFiled[] _pickListFields;
        public virtual IRERP_SM_ListGridFiled[] pickListFields { get { return _pickListFields; } set { if (IsInInitializeTime) _pickListFields = value; else throw NotImplementerdForIR(); } }
        IRERP_SM_ListGrid _pickListProperties;
        public virtual IRERP_SM_ListGrid pickListProperties { get { return _pickListProperties; } set { if (IsInInitializeTime) _pickListProperties = value; else throw NotImplementerdForIR(); } }
        public virtual bool? progressiveLoading { get; set; }
        IRERP_SM_ListGridRecord[] _separatorRows;
        public virtual IRERP_SM_ListGridRecord[] separatorRows { get { return _separatorRows; } set { if (IsInInitializeTime) _separatorRows = value; else throw NotImplementerdForIR(); } }

        bool? _showAllOptions;
        public virtual bool? showAllOptions { get { return _showAllOptions; } set { if (IsInInitializeTime) _showAllOptions = value; else throw NotImplementerdForIR(); } }
        public virtual bool? showOptionsFromDataSource { get; set; }
        public virtual bool? showPickerIcon { get; set; }
        public virtual bool? showPickListOnKeypress { get; set; }

        string _sortField;
        public virtual string sortField { get { return _sortField; } set { if (IsInInitializeTime) _sortField = value; else throw NotImplementerdForIR(); } }

        public virtual string valueField { get; set; }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (addUnknownValues != null) Parts.Add("addUnknownValues", "addUnknownValues:" + bool2JSON((bool)addUnknownValues) + "");
                if (allowEmptyValue != null) Parts.Add("allowEmptyValue", "allowEmptyValue:" + bool2JSON((bool)allowEmptyValue) + "");
                if (defaultToFirstOption != null) Parts.Add("defaultToFirstOption", "defaultToFirstOption:" + bool2JSON((bool)defaultToFirstOption) + "");
                if (completeOnTab != null) Parts.Add("completeOnTab", "completeOnTab:" + bool2JSON((bool)completeOnTab) + "");
                if (filterWithValue != null) Parts.Add("filterWithValue", "filterWithValue:" + bool2JSON((bool)filterWithValue) + "");
                if (cachePickListResults != null) Parts.Add("cachePickListResults", "cachePickListResults:" + bool2JSON((bool)cachePickListResults) + "");
                if (fetchDisplayedFieldsOnly != null) Parts.Add("fetchDisplayedFieldsOnly", "fetchDisplayedFieldsOnly:" + bool2JSON((bool)fetchDisplayedFieldsOnly) + "");
                if (generateExactMatchCriteria != null) Parts.Add("generateExactMatchCriteria", "generateExactMatchCriteria:" + bool2JSON((bool)generateExactMatchCriteria) + "");
                if (progressiveLoading != null) Parts.Add("progressiveLoading", "progressiveLoading:" + bool2JSON((bool)progressiveLoading) + "");
                if (showAllOptions != null) Parts.Add("showAllOptions", "showAllOptions:" + bool2JSON((bool)showAllOptions) + "");
                if (showOptionsFromDataSource != null) Parts.Add("showOptionsFromDataSource", "showOptionsFromDataSource:" + bool2JSON((bool)showOptionsFromDataSource) + "");
                if (showPickListOnKeypress != null) Parts.Add("showPickListOnKeypress", "showPickListOnKeypress:" + bool2JSON((bool)showPickListOnKeypress) + "");
                if (showPickerIcon != null) Parts.Add("showPickerIcon", "showPickerIcon:" + bool2JSON((bool)showPickerIcon) + "");
                if (selectOnFocus != null) Parts.Add("selectOnFocus", "selectOnFocus:" + bool2JSON((bool)selectOnFocus) + "");
               
                if (valueField != null) Parts.Add("valueField", "valueField:" + string2JSON(valueField.ToString()) + "");
                if (sortField != null) Parts.Add("sortField", "sortField:" + string2JSON(sortField.ToString()) + "");
                if (pickListProperties != null) Parts.Add("pickListProperties", "pickListProperties:" + string2JSON(pickListProperties.ToString()) + "");
                
                List<string> _fi = new List<string>();
                if (pickListFields != null) foreach (var a in pickListFields) _fi.Add(a.ToStringAsMemberOfOther());
                if (pickListFields != null) Parts.Add("pickListFields", "pickListFields:[" + string.Join(",", _fi) + "]");

                List<string> _fi1 = new List<string>();
                if (separatorRows != null) foreach (var a in separatorRows) _fi1.Add(a.ToStringAsMemberOfOther());
                if (separatorRows != null) Parts.Add("separatorRows", "separatorRows:[" + string.Join(",", _fi1) + "]");

                if (pickListCriteria != null) Parts.Add("pickListCriteria", "pickListCriteria:" + pickListCriteria.ToStringAsMemberOfOther() + "");

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