using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Label : IRERP_SM_Button/* TIRERP_SM_Label<IRERP_SM_Label> { }

    public class TIRERP_SM_Label <T>: TIRERP_SM_Button<T>
        where T: IRERPControlBase*/
    {
        public Types.IRERPControlTypes_HTMLString contents { get; set; }

        public Nullable< Types.IRERPControlTypes_Overflow> overflow { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if(contents!=null)  Parts.Add("contents", "contents:" + string2JSON(contents.ToString())+ "");
                if (overflow != null) Parts.Add("overflow", "overflow:" + enum2JSON(overflow));
                return Parts;
            }
            else
            { return new Dictionary<string, string>(); }

        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.Label.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.Label.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
        


    }
}