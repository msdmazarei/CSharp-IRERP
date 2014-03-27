
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_PersianDatePickerItem : IRERP_SM_TextItem
    {
        public IRERP_SM_PersianDatePickerItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.PersianDatePicker;
        }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            var rtn= base.GetOutPutParts();
            if (rtn.Keys.Contains("editorType"))
                rtn["editorType"] = @"editorType:""PersianDatePickerItem""";
            else
                rtn.Add("editorType", @"editorType:""PersianDatePickerItem""");
            return rtn;
        }
        public override string ToStringAsMemberOfOther()
        {
            return "isc.PersianDatePickerItem.create("+base.ToStringAsMemberOfOther()+")";
        }
    }
}
