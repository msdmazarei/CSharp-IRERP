using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_IRERPPickTreeItem : IRERP_SM_PickTreeItem/* TIRERP_SM_PickTreeItem<IRERP_SM_PickTreeItem> { }

    public class TIRERP_SM_PickTreeItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
  
    {
        public IRERP_SM_IRERPPickTreeItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.irerpPickTree;
        }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            var rtn = base.GetOutPutParts();
            if (rtn.Keys.Contains("editorType"))
                rtn["editorType"] = @"editorType:""irerpPickTreeItem""";
            else
                rtn.Add("editorType", @"editorType:""irerpPickTreeItem""");
            return rtn;
        }
        public override string ToStringAsMemberOfOther()
        {
            return "isc.irerpPickTreeItem.create(" + base.ToStringAsMemberOfOther() + ")";
        }

    }
}