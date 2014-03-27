using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_FormItem : IRERPControlBase /*TIRERP_SM_FormItem<IRERP_SM_FormItem> { }
      public class TIRERP_SM_FormItem<T>: IRERPControlBase
            where T:class*/
    {
            string _name;
            public virtual string textBoxStyle { get; set; }
            public virtual string name { get { return _name; } set { if (IsInInitializeTime) _name = value; else throw NotImplementerdForIR(); } }
            public virtual Types.IRERPControlTypes_FormItemType? type {get;set;}
            public virtual bool? showTitle { get; set; }
            public virtual int? width { get; set; }
            public virtual object valueMap { get; set; }
            public virtual object defaultValue { get; set; }
            public virtual IRERPControlTypes_Alignment? align { get; set; }
            public virtual bool? allowExpressions { get; set; }
            public virtual bool? alwaysFetchMissingValues { get; set; }
            public virtual string ariaRole { get; set; }
            public virtual object ariaState { get; set; }
            public virtual bool? browserSpellCheck { get; set; }
            public virtual bool? canEdit { get; set; }
            public virtual bool? canFocus { get; set; }
            public virtual int? cellHeight { get; set; }
            public virtual int? colSpan { get; set; }
            public virtual int? decimalPad { get; set; }
            public virtual int? decimalPrecision { get; set; }
            public virtual bool? disabled { get; set; }
            public virtual bool? disableIconsOnReadOnly { get; set; }
            public virtual int? pickListWidth { get; set; }
            IRERPControlBase _containerWidget;
            public virtual IRERPControlBase containerWidget { get { return _containerWidget; } set { if (IsInInitializeTime) _containerWidget = value; else throw NotImplementerdForIR(); } }
            string _displayField;
            public virtual string displayField { get { return _displayField; } set { if (IsInInitializeTime) _displayField = value; else throw NotImplementerdForIR(); } }
            public virtual string editPendingCSSText { get; set; }
            public virtual string emptyDisplayValue { get; set; }
            string _criteriaField;
            public virtual string criteriaField { get { return _criteriaField; } set { if (IsInInitializeTime) _criteriaField = value; else throw NotImplementerdForIR(); } }
            public virtual string dateFormatter { get; set; }
            public virtual string defaultIconSrc { get; set; }
            IRERP_SM_FormItem _editorType;
            public virtual IRERP_SM_FormItem editorType { get { return _editorType; } set { if (IsInInitializeTime) _editorType = value; else throw NotImplementerdForIR(); } }
            public virtual string emptyValueIcon { get; set; }
            public virtual bool? endRow { get; set; }
            public virtual int? errorIconHeight { get; set; }
            public virtual string errorIconSrc { get; set; }
            public virtual int? errorIconWidth { get; set; }
            public virtual int? errorMessageWidth { get; set; }
            public virtual IRERPControlTypes_Alignment? errorOrientation { get; set; }
            public virtual bool? fetchMissingValues { get; set; }
            bool? _filterLocally;
            public virtual bool? filterLocally { get { return _filterLocally; } set { if (IsInInitializeTime) _filterLocally = value; else throw NotImplementerdForIR(); } }
            IRERP_SM_DynamicForm _form;
            public virtual IRERP_SM_DynamicForm form { get { return _form; } set { if (IsInInitializeTime) _form = value; else throw NotImplementerdForIR(); } }
            public virtual int? globalTabIndex { get; set; }
            public virtual int? height { get; set; }
            public virtual IRERPControlTypes_HTMLString hint { get; set; }
            public virtual string hintStyle { get; set; }
            public virtual IRERPControlTypes_Alignment? hoverAlign { get; set; }
            public virtual int? hoverDelay { get; set; }
            public virtual IRERPControlTypes_VerticalAlignment? hoverVAlign { get; set; }
            public virtual int? iconHeight { get; set; }
            public virtual int? hoverOpacity { get; set; }
            public virtual string iconPrompt { get; set; }
            public virtual IRERPControlTypes_VerticalAlignment? iconVAlign { get; set; }
            public virtual int? iconWidth { get; set; }
            public virtual string ID { get; set; }
            public virtual string imageURLPrefix { get; set; }
            public virtual string imageURLSuffix { get; set; }
            public virtual string locateItemBy { get; set; }
            public virtual bool? implicitSave { get; set; }
            public virtual bool? implicitSaveOnBlur { get; set; }
            public virtual int? left { get; set; }
            public virtual IRERPControlTypes_Alignment? textAlign { get; set; }
            public virtual string title { get; set; }
            public Types.IRERPControlTypes_StringMethods changed { get; set; }
            string _multipleValueSeparator;
            public virtual string multipleValueSeparator { get { return _multipleValueSeparator; } set { if (IsInInitializeTime) _multipleValueSeparator = value; else throw NotImplementerdForIR(); } }

            string _optionOperationId;
            public virtual string optionOperationId { get { return _optionOperationId; } set { if (IsInInitializeTime) _optionOperationId = value; else throw NotImplementerdForIR(); } }

            string _optionCriteria;
            public virtual string optionCriteria { get { return _optionCriteria; } set { if (IsInInitializeTime) _optionCriteria = value; else throw NotImplementerdForIR(); } }

            string _optionDataSource;
            public virtual string optionDataSource { get { return _optionDataSource; } set { if (IsInInitializeTime) _optionDataSource = value; else throw NotImplementerdForIR(); } }

            public virtual int? pickerIconHeight { get; set; }

            string _pickerIconName;
            public virtual string pickerIconName { get { return _pickerIconName; } set { if (IsInInitializeTime) _pickerIconName = value; else throw NotImplementerdForIR(); } }

            string _pickerIconPrompt;
            public virtual string pickerIconPrompt { get { return _pickerIconPrompt; } set { if (IsInInitializeTime) _pickerIconPrompt = value; else throw NotImplementerdForIR(); } }

            public virtual int? pickerIconWidth { get; set; }
            public virtual IRERPControlBase pickerProperties { get; set; }
            public virtual string prompt { get; set; }
            public virtual bool? redrawOnChange { get; set; }
            public virtual bool? rejectInvalidValueOnChange { get; set; }
            bool? _required;
            public virtual bool? required { get { return _required; } set { if (IsInInitializeTime) _required = value; else throw NotImplementerdForIR(); } }
            public virtual string requiredMessage { get; set; }
            public virtual int? rowSpan { get; set; }
            public virtual bool? saveOnEnter { get; set; }
            public virtual bool? selectOnFocus { get; set; }


            public virtual IRERPControlBase picker { get; set; }
            public virtual string pickerConstructor { get; set; }
            public virtual string pickerIconDefaults { get; set; }
            public virtual string pickerIconSrc { get; set; }
            public virtual string titleStyle { get; set; }
            public virtual IRERPControlTypes_TitleOrientation? titleOrientation { get; set; }

            protected override Dictionary<string, string> GetOutPutParts()
            {
                if (IsInInitializeTime)
                {
                    var Parts = base.GetOutPutParts();
                    if (name != null) Parts.Add("name", "name:" + string2JSON(name.ToString()) + "");
                    if (showTitle != null) Parts.Add("showTitle", "showTitle:" + bool2JSON((bool)showTitle) + "");
                    if (width != null) Parts.Add("width", "width:" + string2JSON(width.ToString()) + "");
                    if (valueMap != null) Parts.Add("valueMap", "valueMap:" + Object2JSON(valueMap) + "");
                    if (defaultValue != null) Parts.Add("defaultValue", "defaultValue:" + Object2JSON(defaultValue) + "");
                    if (align != null) Parts.Add("align", "align:" + enum2JSON(align) + "");
                    if (allowExpressions != null) Parts.Add("allowExpressions", "allowExpressions:" + bool2JSON((bool)allowExpressions) + "");
                    if (alwaysFetchMissingValues != null) Parts.Add("alwaysFetchMissingValues", "alwaysFetchMissingValues:" + bool2JSON((bool)alwaysFetchMissingValues) + "");
                    if (ariaRole != null) Parts.Add("ariaRole", "ariaRole:" + string2JSON(ariaRole.ToString()) + "");
                    if (ariaState != null) Parts.Add("ariaState", "ariaState:" + Object2JSON(ariaState) + "");
                    if (browserSpellCheck != null) Parts.Add("browserSpellCheck", "browserSpellCheck:" + bool2JSON((bool)browserSpellCheck) + "");
                    if (canEdit != null) Parts.Add("canEdit", "canEdit:" + bool2JSON((bool)canEdit) + "");
                    if (canFocus != null) Parts.Add("canFocus", "canFocus:" + bool2JSON((bool)canFocus) + "");
                    if (cellHeight != null) Parts.Add("cellHeight", "cellHeight:" + int2JSON((int)cellHeight) + "");
                    if (colSpan != null) Parts.Add("colSpan", "colSpan:" + int2JSON((int)colSpan) + "");
                    if (decimalPad != null) Parts.Add("decimalPad", "decimalPad:" + int2JSON((int)decimalPad) + "");
                    if (decimalPrecision != null) Parts.Add("decimalPrecision", "decimalPrecision:" + int2JSON((int)decimalPrecision) + "");
                    if (disabled != null) Parts.Add("disabled", "disabled:" + bool2JSON((bool)disabled) + "");
                    if (disableIconsOnReadOnly != null) Parts.Add("disableIconsOnReadOnly", "disableIconsOnReadOnly:" + bool2JSON((bool)disableIconsOnReadOnly) + "");
                    if (containerWidget != null) Parts.Add("containerWidget", "containerWidget:" + containerWidget.ToStringAsMemberOfOther() + "");
                    if (displayField != null) Parts.Add("displayField", "displayField:" + string2JSON(displayField.ToString()) + "");
                    if (editPendingCSSText != null) Parts.Add("editPendingCSSText", "editPendingCSSText:" + string2JSON(editPendingCSSText.ToString()) + "");
                    if (emptyDisplayValue != null) Parts.Add("emptyDisplayValue", "emptyDisplayValue:" + string2JSON(emptyDisplayValue.ToString()) + "");
                    if (criteriaField != null) Parts.Add("criteriaField", "criteriaField:" + string2JSON(criteriaField.ToString()) + "");
                    if (dateFormatter != null) Parts.Add("dateFormatter", "dateFormatter:" + string2JSON(dateFormatter.ToString()) + "");
                    if (defaultIconSrc != null) Parts.Add("defaultIconSrc", "defaultIconSrc:" + string2JSON(defaultIconSrc.ToString()) + "");
                    if (editorType != null) Parts.Add("editorType", "editorType:" +enum2JSON( editorType.type) + "");
                    if (endRow != null) Parts.Add("endRow", "endRow:" + bool2JSON((bool)endRow) + "");
                    if (errorIconHeight != null) Parts.Add("errorIconHeight", "errorIconHeight:" + int2JSON((int)errorIconHeight) + "");
                    if (errorIconSrc != null) Parts.Add("errorIconSrc", "errorIconSrc:" + string2JSON(errorIconSrc.ToString()) + "");
                    if (errorIconWidth != null) Parts.Add("errorIconWidth", "errorIconWidth:" + int2JSON((int)errorIconWidth) + "");
                    if (errorMessageWidth != null) Parts.Add("errorMessageWidth", "errorMessageWidth:" + int2JSON((int)errorMessageWidth) + "");
                    if (errorOrientation != null) Parts.Add("errorOrientation", "errorOrientation:" + enum2JSON(errorOrientation) + "");
                    if (fetchMissingValues != null) Parts.Add("fetchMissingValues", "fetchMissingValues:" + bool2JSON((bool)fetchMissingValues) + "");
                    if (filterLocally != null) Parts.Add("filterLocally", "filterLocally:" + bool2JSON((bool)filterLocally) + "");
                    if (form != null) Parts.Add("form", "form:" + form.ToStringAsMemberOfOther() + "");
                    if (globalTabIndex != null) Parts.Add("globalTabIndex", "globalTabIndex:" + int2JSON((int)globalTabIndex) + "");
                    if (height != null) Parts.Add("height", "height:" + int2JSON((int)height) + "");
                    if (hint != null) Parts.Add("hint", "hint:" + string2JSON(hint.ToString()) + "");
                    if (hintStyle != null) Parts.Add("hintStyle", "hintStyle:" + string2JSON(hintStyle.ToString()) + "");
                    if (hoverAlign != null) Parts.Add("hoverAlign", "hoverAlign:" + enum2JSON(hoverAlign) + "");
                    if (hoverDelay != null) Parts.Add("hoverDelay", "hoverDelay:" + int2JSON((int)hoverDelay) + "");
                    if (hoverVAlign != null) Parts.Add("hoverVAlign", "hoverVAlign:" + enum2JSON(hoverVAlign) + "");
                    if (iconHeight != null) Parts.Add("iconHeight", "iconHeight:" + int2JSON((int)iconHeight) + "");
                    if (ID != null) Parts.Add("ID", "ID:" + string2JSON(ID.ToString()) + "");
                    if (hoverOpacity != null) Parts.Add("hoverOpacity", "hoverOpacity:" + int2JSON((int)hoverOpacity) + "");
                    if (iconPrompt != null) Parts.Add("iconPrompt", "iconPrompt:" + string2JSON(iconPrompt.ToString()) + "");
                    if (iconVAlign != null) Parts.Add("iconVAlign", "iconVAlign:" + enum2JSON(iconVAlign) + "");
                    if (iconWidth != null) Parts.Add("iconWidth", "iconWidth:" + int2JSON((int)iconWidth) + "");
                    if (imageURLPrefix != null) Parts.Add("imageURLPrefix", "imageURLPrefix:" + string2JSON(imageURLPrefix.ToString()) + "");
                    if (pickListWidth != null) Parts.Add("pickListWidth", "pickListWidth:" + int2JSON(pickListWidth) + "");

                    if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");

                    if (imageURLSuffix != null) Parts.Add("imageURLSuffix", "imageURLSuffix:" + string2JSON(imageURLSuffix.ToString()) + "");
                    if (locateItemBy != null) Parts.Add("locateItemBy", "locateItemBy:" + string2JSON(locateItemBy.ToString()) + "");
                    if (implicitSave != null) Parts.Add("implicitSave", "implicitSave:" + bool2JSON((bool)implicitSave) + "");
                    if (implicitSaveOnBlur != null) Parts.Add("implicitSaveOnBlur", "implicitSaveOnBlur:" + bool2JSON((bool)implicitSaveOnBlur) + "");
                    if (left != null) Parts.Add("left", "left:" + int2JSON((int)left) + "");
                    if (multipleValueSeparator != null) Parts.Add("multipleValueSeparator", "multipleValueSeparator:" + string2JSON(multipleValueSeparator.ToString()) + "");
                    if (optionOperationId != null) Parts.Add("optionOperationId", "optionOperationId:" + string2JSON(optionOperationId.ToString()) + "");
                    if (optionCriteria != null) Parts.Add("optionCriteria", "optionCriteria:" + string2JSON(optionCriteria.ToString()) + "");
                    if (optionDataSource != null) Parts.Add("optionDataSource", "optionDataSource:" + string2JSON(optionDataSource.ToString()) + "");
                    if (pickerIconHeight != null) Parts.Add("pickerIconHeight", "pickerIconHeight:" + int2JSON((int)pickerIconHeight) + "");
                    if (pickerIconName != null) Parts.Add("pickerIconName", "pickerIconName:" + string2JSON(pickerIconName.ToString()) + "");
                    if (pickerIconPrompt != null) Parts.Add("pickerIconPrompt", "pickerIconPrompt:" + string2JSON(pickerIconPrompt.ToString()) + "");
                    if (pickerIconWidth != null) Parts.Add("pickerIconWidth", "pickerIconWidth:" + int2JSON((int)pickerIconWidth) + "");
                    if (pickerProperties != null) Parts.Add("pickerProperties", "pickerProperties:" +pickerProperties.ToStringAsMemberOfOther() + "");
                    if (prompt != null) Parts.Add("prompt", "prompt:" + string2JSON(prompt.ToString()) + "");
                    if (redrawOnChange != null) Parts.Add("redrawOnChange", "redrawOnChange:" + bool2JSON((bool)redrawOnChange) + "");
                    if (rejectInvalidValueOnChange != null) Parts.Add("rejectInvalidValueOnChange", "rejectInvalidValueOnChange:" + bool2JSON((bool)rejectInvalidValueOnChange) + "");
                    if (required != null) Parts.Add("required", "required:" + bool2JSON((bool)required) + "");
                    if (saveOnEnter != null) Parts.Add("saveOnEnter", "saveOnEnter:" + bool2JSON((bool)saveOnEnter) + "");
                    if (selectOnFocus != null) Parts.Add("selectOnFocus", "selectOnFocus:" + bool2JSON((bool)selectOnFocus) + "");
                    if (rowSpan != null) Parts.Add("rowSpan", "rowSpan:" +int2JSON((int)rowSpan) + "");
                    if (requiredMessage != null) Parts.Add("requiredMessage", "requiredMessage:" + string2JSON(requiredMessage.ToString()) + "");
                    if (picker != null) Parts.Add("picker", "picker:" + picker.ToStringAsMemberOfOther() + "");
                    if (pickerConstructor != null) Parts.Add("pickerConstructor", "pickerConstructor:" + string2JSON(pickerConstructor.ToString()) + "");
                    if (pickerIconDefaults != null) Parts.Add("pickerIconDefaults", "pickerIconDefaults:" + string2JSON(pickerIconDefaults.ToString()) + "");
                    if (pickerIconSrc != null) Parts.Add("pickerIconSrc", "pickerIconSrc:" + string2JSON(pickerIconSrc.ToString()) + "");
                    if (type != null) Parts.Add("type", "type:" + enum2JSON(type) + "");
                    if (titleStyle != null) Parts.Add("titleStyle", "titleStyle:" + string2JSON(titleStyle));
                    if (titleOrientation != null) Parts.Add("titleOrientation", "titleOrientation:" + enum2JSON(titleOrientation));
                    if (textAlign != null) Parts.Add("textAlign", "textAlign:" + enum2JSON(textAlign));
                    if (textBoxStyle != null) Parts.Add("textBoxStyle", "textBoxStyle:" + string2JSON(textBoxStyle));
                    if (changed != null) Parts.Add("changed", "changed:" + changed.ToString() + "");
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