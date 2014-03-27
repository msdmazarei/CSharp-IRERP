using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_RadioGroupItem:IRERP_SM_FormItem
    {
        public virtual bool? wrap { get; set; }
        public virtual bool? vertical { get; set; }

        string[] _disabledValues;
        public virtual string[] disabledValues { get { return _disabledValues; } set { if (IsInInitializeTime) _disabledValues = value; else throw NotImplementerdForIR(); } }

        IRERP_SM_RadioItem _itemProperties;
        public virtual IRERP_SM_RadioItem itemProperties { get { return _itemProperties; } set { if (IsInInitializeTime) _itemProperties = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (wrap != null) Parts.Add("wrap", "wrap:" + bool2JSON((bool)wrap) + "");

                if (vertical != null) Parts.Add("vertical", "vertical:" + bool2JSON((bool)vertical) + "");
                if (disabledValues != null) Parts.Add("disabledValues", "disabledValues:" + stringArray2JSON(disabledValues) + "");
                if (itemProperties != null) Parts.Add("itemProperties", "itemProperties:" + itemProperties.ToStringAsMemberOfOther() + "");
                

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