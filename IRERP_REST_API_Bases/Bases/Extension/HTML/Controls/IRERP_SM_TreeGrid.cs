using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_TreeGrid : IRERP_SM_ListGrid
    {
        public virtual string treeRootValue { get; set; }
        public virtual string treeFieldTitle { get; set; }
        public virtual bool? sortFoldersBeforeLeaves { get; set; }
        public virtual bool? showRoot { get; set; }
        public virtual bool? showPartialSelection { get; set; }
        public virtual bool? showOpenIcons { get; set; }
        public virtual bool? showOpener { get; set; }
        public virtual bool? showFullConnectors { get; set; }
        public virtual bool? showDropIcons { get; set; }
        public virtual bool? showDisabledSelectionCheckbox { get; set; }
        public virtual bool? showCustomIconOpen { get; set; }
        
        public virtual bool? separateFolders { get; set; }
        public virtual string selectionProperty { get; set; }
        public virtual bool? canAcceptDroppedRecords { get; set; }

        public virtual bool? canDragRecordsOut { get; set; }

        public virtual bool? canReorderRecords { get; set; }
        public virtual bool? canReparentNodes { get; set; }

        public virtual string dropIconSuffix { get; set; }


        public virtual Types.IRERPControlTypes_DragDataAction? dragDataAction { get; set; }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (treeRootValue != null) Parts.Add("treeRootValue", "treeRootValue:" + string2JSON(treeRootValue) + "");
                if (treeFieldTitle != null) Parts.Add("treeFieldTitle", "treeFieldTitle:" + string2JSON(treeFieldTitle) + "");
                if (sortFoldersBeforeLeaves != null) Parts.Add("sortFoldersBeforeLeaves", "sortFoldersBeforeLeaves:" + bool2JSON(sortFoldersBeforeLeaves));
                if (showRoot != null) Parts.Add("showRoot", "showRoot:" + bool2JSON(showRoot));
                if (showPartialSelection != null) Parts.Add("showPartialSelection", "showPartialSelection:" + bool2JSON(showPartialSelection));
                if (showOpenIcons != null) Parts.Add("showOpenIcons", "showOpenIcons:" + bool2JSON(showOpenIcons));

                if (showOpener != null) Parts.Add("showOpener", "showOpener:" + bool2JSON(showOpener)+ "");

                if (showFullConnectors != null) Parts.Add("showFullConnectors", "showFullConnectors:" + bool2JSON(showFullConnectors));
                if (showDropIcons != null) Parts.Add("showDropIcons", "showDropIcons:" + bool2JSON(showDropIcons));
                if (showDisabledSelectionCheckbox != null) Parts.Add("showDisabledSelectionCheckbox", "showDisabledSelectionCheckbox:" + bool2JSON(showDisabledSelectionCheckbox));
                if (showCustomIconOpen != null) Parts.Add("showCustomIconOpen", "showCustomIconOpen:" + bool2JSON(showCustomIconOpen));
                if (separateFolders != null) Parts.Add("separateFolders", "separateFolders:" + bool2JSON(separateFolders));
                if (selectionProperty != null) Parts.Add("selectionProperty", "selectionProperty:" + string2JSON(selectionProperty));
                if (canAcceptDroppedRecords != null) Parts.Add("canAcceptDroppedRecords", "canAcceptDroppedRecords:" + bool2JSON(canAcceptDroppedRecords));
                if (canDragRecordsOut != null) Parts.Add("canDragRecordsOut", "canDragRecordsOut:" + bool2JSON(canDragRecordsOut));
                if (canReorderRecords != null) Parts.Add("canReorderRecords", "canReorderRecords:" + bool2JSON(canReorderRecords));
                if (canReparentNodes != null) Parts.Add("canReparentNodes", "canReparentNodes:" + bool2JSON(canReparentNodes));
                if (dropIconSuffix != null) Parts.Add("dropIconSuffix", "dropIconSuffix:" + string2JSON(dropIconSuffix));
                if (dragDataAction != null) Parts.Add("dragDataAction", "dragDataAction:" + enum2JSON(dragDataAction) + "");


                return Parts;
            }
            else
            { return new Dictionary<string, string>(); }
        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.TreeGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.TreeGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
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