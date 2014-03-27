using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{ 
    public class IRERPControlTypes_ListGridFiled : IRERPControlBase
    {
        public string name { get; set; }
        public string valueMap { get; set; }
        public virtual bool? canEdit { get; set; }
        bool? _canHide;
        public virtual bool? canHide { get { return _canHide; } set { if (IsInInitializeTime) _canHide = value; else throw NotImplementerdForIR(); } }
        public virtual IRERPControlTypes_Alignment? align { get; set; }
        public virtual IRERPControlTypes_StringMethods showIf { get; set; }
        public virtual IRERPControlTypes_StringMethods formatCellValue { get; set; }
        public virtual bool? autoFetchDisplayMap { get; set; }
        bool? _autoFitWidth;
        public virtual bool? autoFitWidth { get { return _autoFitWidth; } set { if (IsInInitializeTime) _autoFitWidth = value; else throw NotImplementerdForIR(); } }
        bool? _autoFreeze;
        public virtual bool? autoFreeze { get { return _autoFreeze; } set { if (IsInInitializeTime) _autoFreeze = value; else throw NotImplementerdForIR(); } }
        public virtual string baseStyle { get; set; }
        bool? _canDragResize;
        public virtual bool? canDragResize { get { return _canDragResize; } set { if (IsInInitializeTime) _canDragResize = value; else throw NotImplementerdForIR(); } }
        bool? _canExport;
        public virtual bool? canExport { get { return _canExport; } set { if (IsInInitializeTime) _canExport = value; else throw NotImplementerdForIR(); } }
        public virtual bool? canFilter { get; set; }
        bool? _canFreeze;
        public virtual bool? canFreeze { get { return _canFreeze; } set { if (IsInInitializeTime) _canFreeze = value; else throw NotImplementerdForIR(); } }
        public virtual bool? canGroupBy { get; set; }
        public virtual bool? canHilite { get; set; }
        bool? _canReorder;
        public virtual bool? canReorder { get { return _canReorder; } set { if (IsInInitializeTime) _canReorder = value; else throw NotImplementerdForIR(); } }
        public virtual bool? canSort { get; set; }
        public virtual bool? canSortClientOnly { get; set; }
        public virtual bool? canToggle { get; set; }
        public virtual IRERPControlTypes_Alignment? cellAlign { get; set; }
        string _dataPath;
        public virtual string dataPath { get { return _dataPath; } set { if (IsInInitializeTime) _dataPath = value; else throw NotImplementerdForIR(); } }
        public virtual IRERPControlTypes_DateDisplayFormat? dateFormatter { get; set; }
        public virtual int? decimalPad { get; set; }
        public virtual int? decimalPrecision { get; set; }
        public virtual object defaultFilterValue { get; set; }
        string _defaultIconSrc;
        public virtual string defaultIconSrc { get { return _defaultIconSrc; } set { if (IsInInitializeTime) _defaultIconSrc = value; else throw NotImplementerdForIR(); } }
        public virtual object defaultValue { get; set; }
        string _displayField;
        public virtual string displayField { get { return _displayField; } set { if (IsInInitializeTime) _displayField = value; else throw NotImplementerdForIR(); } }
        public virtual bool? displayValueFromRecord { get; set; }
        int? _editorIconHeight;
        public virtual int? editorIconHeight { get { return _editorIconHeight; } set { if (IsInInitializeTime) _editorIconHeight = value; else throw NotImplementerdForIR(); } }
        int? _editorIconWidth;
        public virtual int? editorIconWidth { get { return _editorIconWidth; } set { if (IsInInitializeTime) _editorIconWidth = value; else throw NotImplementerdForIR(); } }
        public virtual string editorImageURLPrefix { get; set; }
        public virtual string editorImageURLSuffix { get; set; }
        public virtual int? editorValueIconHeight { get; set; }
        public virtual object editorValueIcons { get; set; }
        public virtual int? editorValueIconWidth { get; set; }
        public virtual IRERPControlTypes_HTMLString emptyCellValue { get; set; }
        public virtual IREREPControlTypes_EnterKeyEditAction? enterKeyEditAction { get; set; }
        public virtual bool? escapeHTML { get; set; }
        public virtual IRERPControlTypes_EscapeKeyEditAction? escapeKeyEditAction { get; set; }
        bool? _exportRawValues;
        public virtual bool? exportRawValues { get { return _exportRawValues; } set { if (IsInInitializeTime) _exportRawValues = value; else throw NotImplementerdForIR(); } }
        public virtual object filterEditorValueMap { get; set; }
        public virtual bool? filterOnKeypress { get; set; }
        IRERPControlTypes_OperatorId? _filterOperator;
        public virtual IRERPControlTypes_OperatorId? filterOperator { get { return _filterOperator; } set { if (IsInInitializeTime) _filterOperator = value; else throw NotImplementerdForIR(); } }
        bool? _frozen;
        public virtual bool? frozen { get { return _frozen; } set { if (IsInInitializeTime) _frozen = value; else throw NotImplementerdForIR(); } }
        int? _groupGranularity;
        public virtual int? groupGranularity { get { return _groupGranularity; } set { if (IsInInitializeTime) _groupGranularity = value; else throw NotImplementerdForIR(); } }
        string _groupingMode;
        public virtual string groupingMode { get { return _groupingMode; } set { if (IsInInitializeTime) _groupingMode = value; else throw NotImplementerdForIR(); } }
        int? _groupPrecision;
        public virtual int? groupPrecision { get { return _groupPrecision; } set { if (IsInInitializeTime) _groupPrecision = value; else throw NotImplementerdForIR(); } }
        public virtual string headerBaseStyle { get; set; }
        string _headerTitle;
        public virtual string headerTitle { get { return _headerTitle; } set { if (IsInInitializeTime) _headerTitle = value; else throw NotImplementerdForIR(); } }
        public virtual string headerTitleStyle { get; set; }
        public virtual int? hiliteIconHeight { get; set; }
        public virtual int? hiliteIconLeftPadding { get; set; }
        IREREPControlTypes_HiliteIconPosition? _hiliteIconPosition;
        public virtual IREREPControlTypes_HiliteIconPosition? hiliteIconPosition { get { return _hiliteIconPosition; } set { if (IsInInitializeTime) _hiliteIconPosition = value; else throw NotImplementerdForIR(); } }
        public virtual int? hiliteIconRightPadding { get; set; }
        public virtual int? hiliteIconSize { get; set; }
        public virtual int? hiliteIconWidth { get; set; }
        string _icon;
        public virtual string icon { get { return _icon; } set { if (IsInInitializeTime) _icon = value; else throw NotImplementerdForIR(); } }
        int? _iconHeight;
        public virtual int? iconHeight { get { return _iconHeight; } set { if (IsInInitializeTime) _iconHeight = value; else throw NotImplementerdForIR(); } }
        string _iconOrientation;
        public virtual string iconOrientation { get { return _iconOrientation; } set { if (IsInInitializeTime) _iconOrientation = value; else throw NotImplementerdForIR(); } }
        int? _iconSize;
        public virtual int? iconSize { get { return _iconSize; } set { if (IsInInitializeTime) _iconSize = value; else throw NotImplementerdForIR(); } }
        int? _iconSpacing;
        public virtual int? iconSpacing { get { return _iconSpacing; } set { if (IsInInitializeTime) _iconSpacing = value; else throw NotImplementerdForIR(); } }
        string _iconVAlign;
        public virtual string iconVAlign { get { return _iconVAlign; } set { if (IsInInitializeTime) _iconVAlign = value; else throw NotImplementerdForIR(); } }
        int? _iconWidth;
        public virtual int? iconWidth { get { return _iconWidth; } set { if (IsInInitializeTime) _iconWidth = value; else throw NotImplementerdForIR(); } }
        public virtual bool? ignoreKeyboardClicks { get; set; }
        public virtual int? imageHeight { get; set; }
        public virtual int? imageSize { get; set; }
        public virtual string imageURLPrefix { get; set; }
        public virtual string imageURLSuffix { get; set; }
        public virtual int? imageWidth { get; set; }
        string _includeFrom;
        public virtual string includeFrom { get { return _includeFrom; } set { if (IsInInitializeTime) _includeFrom = value; else throw NotImplementerdForIR(); } }
        bool? _includeInRecordSummary;
        public virtual bool? includeInRecordSummary { get { return _includeInRecordSummary; } set { if (IsInInitializeTime) _includeInRecordSummary = value; else throw NotImplementerdForIR(); } }
        bool? _isRemoveField;
        public virtual bool? isRemoveField { get { return _isRemoveField; } set { if (IsInInitializeTime) _isRemoveField = value; else throw NotImplementerdForIR(); } }
        public virtual bool? leaveHeaderMenuButtonSpace { get; set; }
        public virtual string linkText { get; set; }
        public virtual string linkURLPrefix { get; set; }
        public virtual string linkTextProperty { get; set; }
        public virtual string linkURLSuffix { get; set; }
        bool? _multiple;
        public virtual bool? multiple { get { return _multiple; } set { if (IsInInitializeTime) _multiple = value; else throw NotImplementerdForIR(); } }
        public string optionDataSource { get; set; }
        string _optionOperationId;
        public virtual string optionOperationId { get { return _optionOperationId; } set { if (IsInInitializeTime) _optionOperationId = value; else throw NotImplementerdForIR(); } }
        
        IRERPControlTypes_TextMatchStyle? _optionTextMatchStyle;
        public virtual IRERPControlTypes_TextMatchStyle? optionTextMatchStyle { get { return _optionTextMatchStyle; } set { if (IsInInitializeTime) _optionTextMatchStyle = value; else throw NotImplementerdForIR(); } }
        bool? _partialSummary;
        public virtual bool? partialSummary { get { return _partialSummary; } set { if (IsInInitializeTime) _partialSummary = value; else throw NotImplementerdForIR(); } }
        string _prompt;
        public virtual string prompt { get { return _prompt; } set { if (IsInInitializeTime) _prompt = value; else throw NotImplementerdForIR(); } }
        public virtual bool? required { get; set; }
        public virtual bool? shouldPrint { get; set; }
        public virtual bool? showAlternateStyle { get; set; }
        public virtual bool? showDefaultContextMenu { get; set; }
        public virtual bool? showHover { get; set; }
        public virtual bool? showTitle { get; set; }
        public virtual bool? showValueIconOnly { get; set; }
        public virtual bool? sortByDisplayField { get; set; }
        public virtual bool? sortByMappedValue { get; set; }
        bool? _showDisabledIcon;
        public virtual bool? showDisabledIcon { get { return _showDisabledIcon; } set { if (IsInInitializeTime) _showDisabledIcon = value; else throw NotImplementerdForIR(); } }
        bool? _showDownIcon;
        public virtual bool? showDownIcon { get { return _showDownIcon; } set { if (IsInInitializeTime) _showDownIcon = value; else throw NotImplementerdForIR(); } }
        bool? _showFileInline;
        public virtual bool? showFileInline { get { return _showFileInline; } set { if (IsInInitializeTime) _showFileInline = value; else throw NotImplementerdForIR(); } }
        bool? _showFocusedIcon;
        public virtual bool? showFocusedIcon { get { return _showFocusedIcon; } set { if (IsInInitializeTime) _showFocusedIcon = value; else throw NotImplementerdForIR(); } }
        bool? _showGridSummary;
        public virtual bool? showGridSummary { get { return _showGridSummary; } set { if (IsInInitializeTime) _showGridSummary = value; else throw NotImplementerdForIR(); } }
        bool? _showGroupSummary;
        public virtual bool? showGroupSummary { get { return _showGroupSummary; } set { if (IsInInitializeTime) _showGroupSummary = value; else throw NotImplementerdForIR(); } }
        bool? _showRollOverIcon;
        public virtual bool? showRollOverIcon { get { return _showRollOverIcon; } set { if (IsInInitializeTime) _showRollOverIcon = value; else throw NotImplementerdForIR(); } }
        bool? _showSelectedIcon;
        public virtual bool? showSelectedIcon { get { return _showSelectedIcon; } set { if (IsInInitializeTime) _showSelectedIcon = value; else throw NotImplementerdForIR(); } }
        public virtual IRERPControlTypes_SortDirection? sortDirection { get; set; }
        IRERPControlTypes_SummaryFunction? _summaryFunction;
        public virtual IRERPControlTypes_SummaryFunction? summaryFunction { get { return _summaryFunction; } set { if (IsInInitializeTime) _summaryFunction = value; else throw NotImplementerdForIR(); } }
        public virtual string summaryTitle { get; set; }
        public virtual IRERPControlTypes_HTMLString summaryValue { get; set; }
        string _summaryValueTitle;
        public virtual string summaryValueTitle { get { return _summaryValueTitle; } set { if (IsInInitializeTime) _summaryValueTitle = value; else throw NotImplementerdForIR(); } }
        public virtual string target {get;set;}
        public virtual string title{get;set;}
        public virtual string  valueField {get;set;}
        public virtual string valueIconOrientation { get; set; }
        public virtual bool?  validateOnChange {get;set;}
        public virtual bool? suppressValueIcon { get; set; }
          public virtual int? valueIconHeight { get; set; }
          public virtual int? valueIconLeftPadding { get; set; }
          public virtual int? valueIconRightPadding { get; set; }
          public virtual int? valueIconSize { get; set; }
          public virtual int? valueIconWidth { get; set; }
          public virtual int? width { get; set; }
          public virtual IREREPControlTypes_TimeDisplayFormat? timeFormatter { get; set; }
          IREREPControlTypes_ListGridFieldType? _type;
          public virtual IREREPControlTypes_ListGridFieldType? type { get { return _type; } set { if (IsInInitializeTime) _type = value; else throw NotImplementerdForIR(); } }

          public virtual object valueIcons { get; set; }

          bool? _createDefaultTreeField;
          public virtual bool? createDefaultTreeField { get { return _createDefaultTreeField; } set { if (IsInInitializeTime) _createDefaultTreeField = value; else throw NotImplementerdForIR(); } }
          public virtual bool? wrap { get; set; }
         
        protected override Dictionary<string, string> GetOutPutParts()
        {
            var Dic = base.GetOutPutParts();
            if (name != null) Dic.Add("name", "name:" + string2JSON(name));
            if (valueMap != null) Dic.Add("valueMap", "valueMap:" + valueMap);
            if (canEdit != null) Dic.Add("canEdit", "canEdit:" + bool2JSON(canEdit));
            if (canHide != null) Dic.Add("canHide", "canHide:" + bool2JSON(canHide));
            if (showIf != null) Dic.Add("showIf", "showIf:" + showIf.ToString());
            if (formatCellValue != null) Dic.Add("formatCellValue", "formatCellValue:" + formatCellValue.ToString());
            if (align != null) Dic.Add("align", "align:" + enum2JSON(align) + "");
            if (autoFetchDisplayMap != null) Dic.Add("autoFetchDisplayMap", "autoFetchDisplayMap:" + bool2JSON(autoFetchDisplayMap));
            if (autoFitWidth != null) Dic.Add("autoFitWidth", "autoFitWidth:" + bool2JSON(autoFitWidth));
            if (autoFreeze != null) Dic.Add("autoFreeze", "autoFreeze:" + bool2JSON(autoFreeze));
            if (baseStyle != null) Dic.Add("baseStyle", "baseStyle:" + string2JSON(baseStyle));
            if (canDragResize != null) Dic.Add("canDragResize", "canDragResize:" + bool2JSON(canDragResize));
            if (canExport != null) Dic.Add("canExport", "canExport:" + bool2JSON(canExport));
            if (canFilter != null) Dic.Add("canFilter", "canFilter:" + bool2JSON(canFilter));
            if (canFreeze != null) Dic.Add("canFreeze", "canFreeze:" + bool2JSON(canFreeze));
            if (canGroupBy != null) Dic.Add("canGroupBy", "canGroupBy:" + bool2JSON(canGroupBy));
            if (canHilite != null) Dic.Add("canHilite", "canHilite:" + bool2JSON(canHilite));
            if (canReorder != null) Dic.Add("canReorder", "canReorder:" + bool2JSON(canReorder));
            if (canSort != null) Dic.Add("canSort", "canSort:" + bool2JSON(canSort));
            if (canSortClientOnly != null) Dic.Add("canSortClientOnly", "canSortClientOnly:" + bool2JSON(canSortClientOnly));
            if (canToggle != null) Dic.Add("canToggle", "canToggle:" + bool2JSON(canToggle));
            if (cellAlign != null) Dic.Add("cellAlign", "cellAlign:" + enum2JSON(cellAlign) + "");
            if (dataPath != null) Dic.Add("dataPath", "dataPath:" + dataPath.ToString());
            if (dateFormatter != null) Dic.Add("dateFormatter", "dateFormatter:" + enum2JSON(dateFormatter) + "");
            if (decimalPad != null) Dic.Add("decimalPad", "decimalPad:" + int2JSON(decimalPad));
            if (decimalPrecision != null) Dic.Add("decimalPrecision", "decimalPrecision:" + int2JSON(decimalPrecision));
            if (defaultFilterValue != null) Dic.Add("defaultFilterValue", "defaultFilterValue:" + Object2JSON(defaultFilterValue));
            if (defaultIconSrc != null) Dic.Add("defaultIconSrc", "defaultIconSrc:" + defaultIconSrc.ToString());
            if (defaultValue != null) Dic.Add("defaultValue", "defaultValue:" + Object2JSON(defaultValue) + "");
            if (displayField != null) Dic.Add("displayField", "displayField:" + string2JSON(displayField.ToString()) + "");
            if (displayValueFromRecord != null) Dic.Add("displayValueFromRecord", "displayValueFromRecord:" + bool2JSON(displayValueFromRecord));
            if (editorIconHeight != null) Dic.Add("editorIconHeight", "editorIconHeight:" + int2JSON(editorIconHeight) + "");
            if (editorIconWidth != null) Dic.Add("editorIconWidth ", "editorIconWidth :" + int2JSON(editorIconWidth) + "");
            if (editorImageURLPrefix != null) Dic.Add("editorImageURLPrefix ", "editorImageURLPrefix :" + string2JSON(editorImageURLPrefix.ToString()) + "");
            if (editorImageURLSuffix != null) Dic.Add("editorImageURLSuffix ", "editorImageURLSuffix :" + string2JSON(editorImageURLSuffix.ToString()) + "");
            if (editorValueIconHeight != null) Dic.Add("editorValueIconHeight", "editorValueIconHeight:" + editorValueIconHeight.ToString());
            if (editorValueIcons != null) Dic.Add("editorValueIcons", "editorValueIcons:" + Object2JSON(editorValueIcons) + "");
            if (editorValueIconWidth != null) Dic.Add("editorValueIconWidth", "editorValueIconWidth:" + int2JSON(editorValueIconWidth) + "");
            if (emptyCellValue != null) Dic.Add("emptyCellValue", "emptyCellValue:" + enum2JSON(emptyCellValue) + "");
            if (enterKeyEditAction != null) Dic.Add("enterKeyEditAction", "enterKeyEditAction:" + enum2JSON(enterKeyEditAction) + "");
            if (escapeHTML != null) Dic.Add("escapeHTML", "escapeHTML:" + bool2JSON(escapeHTML));
            if (escapeKeyEditAction != null) Dic.Add("escapeKeyEditAction", "escapeKeyEditAction:" + enum2JSON(escapeKeyEditAction) + "");
            if (exportRawValues != null) Dic.Add("exportRawValues", "exportRawValues:" + bool2JSON(exportRawValues));
            if (filterEditorValueMap != null) Dic.Add("filterEditorValueMap", "filterEditorValueMap:" + Object2JSON(filterEditorValueMap) + "");
            if (filterOnKeypress != null) Dic.Add("filterOnKeypress", "filterOnKeypress:" + bool2JSON(filterOnKeypress));
            if (filterOperator != null) Dic.Add("filterOperator", "filterOperator:" + enum2JSON(filterOperator) + "");
            if (frozen != null) Dic.Add("frozen", "frozen:" + bool2JSON(frozen));
            if (groupGranularity != null) Dic.Add("groupGranularity", "groupGranularity:" + int2JSON(groupGranularity));
            if (groupingMode != null) Dic.Add("groupingMode", "groupingMode:" + string2JSON(groupingMode));
            if (groupPrecision != null) Dic.Add("groupPrecision", "groupPrecision:" + int2JSON(groupPrecision));
            if (headerBaseStyle != null) Dic.Add("headerBaseStyle", "headerBaseStyle:" + string2JSON(headerBaseStyle));
            if (headerTitle != null) Dic.Add("headerTitle", "headerTitle:" + headerTitle.ToString());
            if (headerTitleStyle != null) Dic.Add("headerTitleStyle", "headerTitleStyle:" + string2JSON(headerTitleStyle));
            if (hiliteIconHeight != null) Dic.Add("hiliteIconHeight", "hiliteIconHeight:" + int2JSON(hiliteIconHeight));
            if (hiliteIconLeftPadding != null) Dic.Add("hiliteIconLeftPadding", "hiliteIconLeftPadding:" + int2JSON(hiliteIconLeftPadding));
            if (hiliteIconPosition != null) Dic.Add("hiliteIconPosition", "hiliteIconPosition:" + enum2JSON(hiliteIconPosition) + "");
            if (hiliteIconRightPadding != null) Dic.Add("hiliteIconRightPadding", "hiliteIconRightPadding:" + int2JSON(hiliteIconRightPadding));
            if (hiliteIconSize != null) Dic.Add("hiliteIconSize", "hiliteIconSize:" + int2JSON(hiliteIconSize));
            if (icon != null) Dic.Add("icon", "icon:" + string2JSON(icon));
            if (hiliteIconWidth != null) Dic.Add("hiliteIconWidth", "hiliteIconWidth:" + int2JSON(hiliteIconWidth));
            if (iconHeight != null) Dic.Add("iconHeight", "iconHeight:" + int2JSON(iconHeight));
            if (iconOrientation != null) Dic.Add("iconOrientation", "iconOrientation:" + string2JSON(iconOrientation));
            if (iconSize != null) Dic.Add("iconSize ", "iconSize :" + int2JSON(iconSize));
            if (iconSpacing != null) Dic.Add("iconSpacing ", "iconSpacing :" + int2JSON(iconSpacing));
            if (iconVAlign != null) Dic.Add("iconVAlign ", "iconVAlign :" + string2JSON(iconVAlign));
            if (iconWidth != null) Dic.Add("iconWidth  ", "iconWidth  :" + int2JSON(iconWidth));
            if (ignoreKeyboardClicks != null) Dic.Add("ignoreKeyboardClicks", "ignoreKeyboardClicks:" + bool2JSON(ignoreKeyboardClicks));
            if (imageHeight != null) Dic.Add("imageHeight", "imageHeight:" + int2JSON(imageHeight));
            if (imageSize != null) Dic.Add("imageSize", "imageSize:" + int2JSON(imageSize));
            if (imageURLPrefix != null) Dic.Add("imageURLPrefix", "imageURLPrefix:" + string2JSON(imageURLPrefix));
            if (imageURLSuffix != null) Dic.Add("imageURLSuffix", "imageURLSuffix:" + string2JSON(imageURLSuffix));
            if (imageWidth != null) Dic.Add("imageWidth ", "imageWidth :" + int2JSON(imageWidth));
            if (includeFrom != null) Dic.Add("includeFrom ", "includeFrom :" + string2JSON(includeFrom));
            if (includeInRecordSummary != null) Dic.Add("includeInRecordSummary ", "includeInRecordSummary :" + bool2JSON(includeInRecordSummary));
            if (isRemoveField != null) Dic.Add("isRemoveField", "isRemoveField:" + bool2JSON(isRemoveField));
            if (leaveHeaderMenuButtonSpace != null) Dic.Add("leaveHeaderMenuButtonSpace", "leaveHeaderMenuButtonSpace:" + bool2JSON(leaveHeaderMenuButtonSpace));
            if (linkText != null) Dic.Add("linkText", "linkText:" + string2JSON(linkText) + "");
            if (linkTextProperty != null) Dic.Add("linkTextProperty", "linkTextProperty:" + string2JSON(linkTextProperty) + "");
            if (linkURLPrefix != null) Dic.Add("linkURLPrefix", "linkURLPrefix:" + string2JSON(linkURLPrefix) + "");
            if (linkURLSuffix != null) Dic.Add("linkURLSuffix", "linkURLSuffix:" + string2JSON(linkURLSuffix) + "");
            if (multiple != null) Dic.Add("multiple  ", "multiple  :" + bool2JSON(multiple));
            if (optionDataSource != null) Dic.Add("optionDataSource  ", "optionDataSource  :" + optionDataSource.ToString());
            if (optionOperationId != null) Dic.Add("optionOperationId ", "optionOperationId :" + string2JSON(optionOperationId) + "");
            if (optionTextMatchStyle != null) Dic.Add("optionTextMatchStyle", "optionTextMatchStyle:" + enum2JSON(optionTextMatchStyle) + "");
            if (partialSummary != null) Dic.Add("partialSummary  ", "partialSummary  :" + bool2JSON(partialSummary));
            if (prompt != null) Dic.Add("prompt", "prompt:" + string2JSON(prompt));
            if (required != null) Dic.Add("required  ", "required  :" + bool2JSON(required));
            if (shouldPrint != null) Dic.Add("shouldPrint  ", "shouldPrint  :" + bool2JSON(shouldPrint));
            if (showAlternateStyle != null) Dic.Add("showAlternateStyle  ", "showAlternateStyle  :" + bool2JSON(showAlternateStyle));
            if (showDefaultContextMenu != null) Dic.Add("showDefaultContextMenu  ", "showDefaultContextMenu  :" + bool2JSON(showDefaultContextMenu));
            if (showDisabledIcon != null) Dic.Add("showDisabledIcon   ", "showDisabledIcon   :" + bool2JSON(showDisabledIcon));
            if (showDownIcon != null) Dic.Add("showDownIcon   ", "showDownIcon   :" + bool2JSON(showDownIcon));
            if (showFileInline != null) Dic.Add("showFileInline   ", "showFileInline   :" + bool2JSON(showFileInline));
            if (showFocusedIcon != null) Dic.Add("showFocusedIcon   ", "showFocusedIcon   :" + bool2JSON(showFocusedIcon));
            if (showGridSummary != null) Dic.Add("showGridSummary   ", "showGridSummary   :" + bool2JSON(showGridSummary));
            if (showGroupSummary != null) Dic.Add("showGroupSummary  ", "showGroupSummary  :" + bool2JSON(showGroupSummary));
            if (showRollOverIcon != null) Dic.Add("showRollOverIcon  ", "showRollOverIcon  :" + bool2JSON(showRollOverIcon));
            if (showSelectedIcon != null) Dic.Add("showSelectedIcon   ", "showSelectedIcon   :" + bool2JSON(showSelectedIcon));
            if (showHover != null) Dic.Add("showHover   ", "showHover   :" + bool2JSON(showHover));
            if (showTitle != null) Dic.Add("showTitle   ", "showTitle   :" + bool2JSON(showTitle));
            if (showValueIconOnly != null) Dic.Add("showValueIconOnly   ", "showValueIconOnly   :" + bool2JSON(showValueIconOnly));
            if (sortByDisplayField != null) Dic.Add("sortByDisplayField    ", "sortByDisplayField    :" + bool2JSON(sortByDisplayField));
            if (sortByMappedValue != null) Dic.Add("sortByMappedValue    ", "sortByMappedValue    :" + bool2JSON(sortByMappedValue));
            if (sortDirection != null) Dic.Add("sortDirection", "sortDirection:" + enum2JSON(sortDirection) + "");
            if (summaryFunction != null) Dic.Add("summaryFunction", "summaryFunction:" + enum2JSON(summaryFunction) + "");
            if (summaryTitle != null) Dic.Add("summaryTitle", "summaryTitle:" + string2JSON(summaryTitle));
            if (summaryValue != null) Dic.Add("summaryValue", "summaryValue:" + enum2JSON(summaryValue));
            if (summaryValueTitle != null) Dic.Add("summaryValueTitle ", "summaryValueTitle :" + string2JSON(summaryValueTitle));
            if (suppressValueIcon != null) Dic.Add("suppressValueIcon   ", "suppressValueIcon   :" + bool2JSON(suppressValueIcon));
            if (validateOnChange != null) Dic.Add("validateOnChange   ", "validateOnChange   :" + bool2JSON(validateOnChange));

            if (target != null) Dic.Add("target ", "target :" + string2JSON(target));
            if (title != null) Dic.Add("title ", "title :" + string2JSON(title));
            if (valueField != null) Dic.Add("valueField ", "valueField :" + string2JSON(valueField));
            if (valueIconOrientation != null) Dic.Add("valueIconOrientation ", "valueIconOrientation :" + string2JSON(valueIconOrientation));

            if (valueIconHeight != null) Dic.Add("valueIconHeight ", "valueIconHeight :" + int2JSON(valueIconHeight));
            if (valueIconLeftPadding != null) Dic.Add("valueIconLeftPadding ", "valueIconLeftPadding :" + int2JSON(valueIconLeftPadding));
            if (valueIconRightPadding != null) Dic.Add("valueIconRightPadding ", "valueIconRightPadding :" + int2JSON(valueIconRightPadding));
            if (valueIconSize != null) Dic.Add("valueIconSize ", "valueIconSize :" + int2JSON(valueIconSize));
            if (valueIconWidth != null) Dic.Add("valueIconWidth ", "valueIconWidth :" + int2JSON(valueIconWidth));
            if (width != null) Dic.Add("width ", "width :" + int2JSON(width));
            if (timeFormatter != null) Dic.Add("timeFormatter", "timeFormatter:" + enum2JSON(timeFormatter));
               if (type != null) Dic.Add("type", "type:" + enum2JSON(type));
               if (valueIcons != null) Dic.Add("valueIcons", "valueIcons:" + Object2JSON(valueIcons));

               if (createDefaultTreeField != null) Dic.Add("createDefaultTreeField ", "createDefaultTreeField :" + bool2JSON(createDefaultTreeField));

               if (wrap != null)
                   Dic.Add("wrap", "wrap:" + bool2JSON(wrap));
    
    
      

            return Dic;
             

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