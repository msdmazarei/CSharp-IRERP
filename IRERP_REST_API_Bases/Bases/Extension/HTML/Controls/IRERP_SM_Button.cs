using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Button : IRERP_SM_StatefulCanvas/* TIRERP_SM_Button<IRERP_SM_Button> { }
    public class TIRERP_SM_Button <T>: TIRERP_SM_StatefulCanvas<T>
        where T : IRERPControlBase*/
    {
        public virtual string radioGroup { get; set; }
        public virtual Types.IRERPControlTypes_SelectionType? actionType { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (radioGroup != null) Parts.Add("radioGroup", "radioGroup:" + string2JSON(radioGroup.ToString()) + "");
                if (actionType != null) Parts.Add("actionType", "actionType:" + enum2JSON(actionType) + "");
               
                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.Button.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.Button.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
        
    }
}