using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_ListGrid : IRERP_SM_VLayout
    {
        public IRERP_SM_ListGrid()
        {
            //defaultLayoutAlign = "left";
        }
        public IRERPControlTypes_StringMethods IRERP_SummaryMsg_CallBack { get; set; }
        public bool? wrapCells { get; set; }
        public IRERPControltypes_listgrid_selectionType? selectionType { get; set; }
        public string baseStyle { get; set; }
        public IRERPControlBase dataSource { get; set; }
        bool? _allowFilterExpressions;
        public virtual bool? allowFilterExpressions { get { return _allowFilterExpressions; } set { if (IsInInitializeTime) _allowFilterExpressions = value; else throw NotImplementerdForIR(); } }
        public virtual string defaultLayoutAlign { get; set; }

        bool _allowRowSpanning;
        public virtual bool allowRowSpanning { get { return _allowRowSpanning; } set { if (IsInInitializeTime) _allowRowSpanning = value; else throw NotImplementerdForIR(); } }

        public virtual int alternateRecordFrequency { get; set; }
        public virtual bool? alternateRecordStyles { get; set; }

        bool _alwaysShowEditors;
        public virtual bool alwaysShowEditors { get { return _alwaysShowEditors; } set { if (IsInInitializeTime) _alwaysShowEditors = value; else throw NotImplementerdForIR(); } }


        Types.IRERPControlTypes_Criteria _initialCriteria;
        public virtual Types.IRERPControlTypes_Criteria initialCriteria { get { return _initialCriteria; } set { if (IsInInitializeTime) _initialCriteria = value; else throw NotImplementerdForIR(); } }


        string _recordEnabledProperty;
        public virtual string recordEnabledProperty { get { return _recordEnabledProperty; } set { if (IsInInitializeTime) _recordEnabledProperty = value; else throw NotImplementerdForIR(); } }

        public virtual string titleField { get; set; }


        bool _showGroupTitleColumn;
        public virtual bool showGroupTitleColumn { get { return _showGroupTitleColumn; } set { if (IsInInitializeTime) _showGroupTitleColumn = value; else throw NotImplementerdForIR(); } }

        public virtual bool reverseRTLAlign { get; set; }


        bool _body;
        public virtual bool body { get { return _body; } set { if (IsInInitializeTime) _body = value; else throw NotImplementerdForIR(); } }

        public virtual string recordCustomStyleProperty { get; set; }
        public virtual bool showSelectedStyle { get; set; }

        bool _canSelectCells;
        public virtual bool canSelectCells { get { return _canSelectCells; } set { if (IsInInitializeTime) _canSelectCells = value; else throw NotImplementerdForIR(); } }

        public virtual bool useCopyPasteShortcuts { get; set; }

        public virtual string detailDS { get; set; }
        public virtual string recordDetailDSProperty { get; set; }
        public virtual bool filterLocalData { get; set; }
        bool _useRowSpanStyling;
        public virtual bool useRowSpanStyling { get { return _useRowSpanStyling; } set { if (IsInInitializeTime) _useRowSpanStyling = value; else throw NotImplementerdForIR(); } }
        public virtual bool? showGridSummary { get; set; }
        public virtual string summaryRowFetchRequestProperties { get; set; }
        public virtual string summaryRowCriteria { get; set; }
        public virtual IRERPControlBase summaryRowDataSource { get; set; }
        public virtual bool? showIRERP_SummaryMsg { get; set; }
        public virtual bool canMultiSort { get; set; }
        public virtual int resizeBarSize { get; set; }
        public virtual bool? showFilterEditor { get; set; }
        public virtual bool? autoSaveEdits { get; set; }
        public virtual bool? filterOnKeypress { get; set; }
        public virtual int? fetchDelay { get; set; }
        public virtual IRERPControlTypes_StringMethods selectionChanged { get; set; }

        public virtual bool? showAllRecords { get; set; }

        public virtual IRERPControlTypes_StringMethods rowContextClick { get; set; }
        public virtual IRERPControlTypes_StringMethods cellContextClick { get; set; }

        public virtual IRERPControlTypes_StringMethods rowDoubleClick { get; set; }


        public Types.IRERPControlTypes_Autofit? _autoFitData;
        public virtual Types.IRERPControlTypes_Autofit? autoFitData { get { return _autoFitData; } set { if (IsInInitializeTime) _autoFitData = value; else throw NotImplementerdForIR(); } }
        public virtual IRERPControlTypes_StringMethods rowEditorExit { get; set; }
        bool? _autoFetchData;
        public virtual bool? autoFetchData { get { return _autoFetchData; } set { if (IsInInitializeTime) _autoFetchData = value; else throw NotImplementerdForIR(); } }

        public virtual Types.IRERPControlTypes_ListGridFiled[] fields { get; set; }
        public virtual string bodyBackgroundColor { get; set; }
        public virtual bool? canAddFormulaFields { get; set; }
        public virtual bool? canAddSummaryFields { get; set; }
        public virtual bool? useAllDataSourceFields { get; set; }
        public virtual Types.IRERPControlTypes_editEvent? editEvent { get; set; }
        public virtual bool? canEdit { get; set; }
        public virtual Types.IREREPControlTypes_listEndEditAction? listEndEditAction { get; set; }
        public virtual bool? showCellContextMenus { get; set; }
        public virtual bool? canSort { get; set; }


        public virtual bool? canResizeFields { get; set; }
        public virtual bool? showRecordComponents { get; set; }
        public virtual bool? showRecordComponentsByCell { get; set; }
        bool? _canRemoveRecords;
        public virtual bool? canRemoveRecords { get { return _canRemoveRecords; } set { if (IsInInitializeTime) _canRemoveRecords = value; else throw NotImplementerdForIR(); } }
        public virtual bool? fixedRecordHeights { get; set; }
        public virtual IRERPControlTypes_StringMethods createRecordComponent { get; set; }
        public virtual IRERPControlBase irerpListGridSummaryMsg { get; set; }
        public virtual IRERPControlBase IRERP_SummaryMsg_DataSource { get; set; }
        public virtual string IRERP_SummaryMsg_Url { get; set; }
        public virtual bool? showHover { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (autoFitData != null) Parts.Add("autoFitData", "autoFitData:" + enum2JSON(autoFitData) + "");
                if (autoFetchData != null) Parts.Add("autoFetchData", "autoFetchData:" + bool2JSON((bool)autoFetchData) + "");
                if (dataSource != null) Parts.Add("dataSource", "dataSource:" + dataSource.ToStringAsMemberOfOther());
                

                if (baseStyle != null) Parts.Add("baseStyle", "baseStyle:" + string2JSON(baseStyle));
                if (bodyBackgroundColor != null) Parts.Add("bodyBackgroundColor", "bodyBackgroundColor:" + string2JSON(bodyBackgroundColor));
                if (alternateRecordStyles != null) Parts.Add("alternateRecordStyles", "alternateRecordStyles:" + bool2JSON(alternateRecordStyles));

                if (selectionChanged != null) Parts.Add("selectionChanged", "selectionChanged:" + selectionChanged.ToString() + "");
                if (rowContextClick != null) Parts.Add("rowContextClick", "rowContextClick:" + selectionChanged.ToString() + "");
                if (cellContextClick != null) Parts.Add("cellContextClick", "cellContextClick:" + cellContextClick.ToString() + "");
                if (rowDoubleClick != null) Parts.Add("rowDoubleClick", "rowDoubleClick:" + rowDoubleClick.ToString() + "");

                if (showFilterEditor != null) Parts.Add("showFilterEditor", "showFilterEditor:" + bool2JSON(showFilterEditor));
                if (filterOnKeypress != null) Parts.Add("filterOnKeypress", "filterOnKeypress:" + bool2JSON(filterOnKeypress));
                if (fetchDelay != null) Parts.Add("fetchDelay", "fetchDelay:" + int2JSON(fetchDelay));
                if (allowFilterExpressions != null) Parts.Add("allowFilterExpressions", "allowFilterExpressions:" + bool2JSON(allowFilterExpressions));
                if (canAddFormulaFields != null) Parts.Add("canAddFormulaFields", "canAddFormulaFields:" + bool2JSON(canAddFormulaFields));
                if (canAddSummaryFields != null) Parts.Add("canAddSummaryFields", "canAddSummaryFields:" + bool2JSON(canAddSummaryFields));
                if (useAllDataSourceFields != null) Parts.Add("useAllDataSourceFields", "useAllDataSourceFields:" + bool2JSON(useAllDataSourceFields));
                if (canEdit != null) Parts.Add("canEdit", "canEdit:" + bool2JSON(canEdit));
                if (editEvent != null) Parts.Add("editEvent", "editEvent:" + enum2JSON(editEvent) + "");
                if (listEndEditAction != null) Parts.Add("listEndEditAction", "listEndEditAction:" + enum2JSON(listEndEditAction) + "");
                if (showCellContextMenus != null) Parts.Add("showCellContextMenus", "showCellContextMenus:" + bool2JSON(showCellContextMenus));
                if (autoSaveEdits != null) Parts.Add("autoSaveEdits", "autoSaveEdits:" + bool2JSON(autoSaveEdits));
                if (canSort != null) Parts.Add("canSort", "canSort:" + bool2JSON(canSort));

                if (rowEditorExit != null) Parts.Add("rowEditorExit", "rowEditorExit:" + rowEditorExit.ToString());

                if (showRecordComponents != null) Parts.Add("showRecordComponents ", "showRecordComponents :" + bool2JSON(showRecordComponents));
                if (showRecordComponentsByCell != null) Parts.Add("showRecordComponentsByCell ", "showRecordComponentsByCell :" + bool2JSON(showRecordComponentsByCell));
                if (canRemoveRecords != null) Parts.Add("canRemoveRecords", "canRemoveRecords:" + enum2JSON(canRemoveRecords) + "");
                if (createRecordComponent != null) Parts.Add("createRecordComponent", "createRecordComponent:" + createRecordComponent.ToString() + "");

                if (canResizeFields != null) Parts.Add("canResizeFields", "canResizeFields:" + bool2JSON(canResizeFields));
                if (defaultLayoutAlign != null) Parts.Add("defaultLayoutAlign", "defaultLayoutAlign:" + string2JSON(defaultLayoutAlign));
                if (showAllRecords != null) Parts.Add("showAllRecords", "showAllRecords:" + bool2JSON(filterOnKeypress));
                if (wrapCells != null) Parts.Add("wrapCells", "wrapCells:" + bool2JSON(wrapCells));
                if (selectionType != null) Parts.Add("selectionType", "selectionType:" + enum2JSON(selectionType));
                if (fixedRecordHeights != null) Parts.Add("fixedRecordHeights", "fixedRecordHeights:" + bool2JSON(fixedRecordHeights));
                if (summaryRowFetchRequestProperties != null) Parts.Add("summaryRowFetchRequestProperties", "summaryRowFetchRequestProperties:" + summaryRowFetchRequestProperties);
                if (showGridSummary != null) Parts.Add("showGridSummary", "showGridSummary:" + bool2JSON(showGridSummary));
                if (summaryRowCriteria != null) Parts.Add("summaryRowCriteria", "summaryRowCriteria:" + summaryRowCriteria);
                if (summaryRowDataSource != null) Parts.Add("summaryRowDataSource", "summaryRowDataSource:" + summaryRowDataSource.ToStringAsMemberOfOther());
                if (showIRERP_SummaryMsg != null) Parts.Add("showIRERP_SummaryMsg", "showIRERP_SummaryMsg:" + bool2JSON(showIRERP_SummaryMsg));
                if (irerpListGridSummaryMsg != null) Parts.Add("irerpListGridSummaryMsg", "irerpListGridSummaryMsg:" + irerpListGridSummaryMsg.ToStringAsMemberOfOther());
                if (IRERP_SummaryMsg_DataSource != null) Parts.Add("IRERP_SummaryMsg_DataSource", "IRERP_SummaryMsg_DataSource:" + IRERP_SummaryMsg_DataSource.ToStringAsMemberOfOther());
                if (IRERP_SummaryMsg_CallBack != null) Parts.Add("IRERP_SummaryMsg_CallBack", "IRERP_SummaryMsg_CallBack:" + IRERP_SummaryMsg_CallBack.ToString());
                if (IRERP_SummaryMsg_Url != null) Parts.Add("IRERP_SummaryMsg_Url", "IRERP_SummaryMsg_Url:" + string2JSON(IRERP_SummaryMsg_Url));
                if (showHover != null)
                    Parts.Add("showHover", "showHover:" + bool2JSON(showHover));
                List<string> _fi = new List<string>();

                if (fields != null) foreach (var a in fields) _fi.Add(a.ToStringAsMemberOfOther());



                if (fields != null) Parts.Add("fields", "fields:[" + string.Join(",", _fi) + "]");
                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.irerpListGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.irerpListGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
        public override string ToStringWithoutConstructor()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "}";
            else
                return "";
        }




    }
}