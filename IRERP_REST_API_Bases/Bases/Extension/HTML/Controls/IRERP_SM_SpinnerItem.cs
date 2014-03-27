using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_SpinnerItem : IRERP_SM_TextItem/* TIRERP_SM_SpinnerItem<IRERP_SM_SpinnerItem> { }
    public class TIRERP_SM_SpinnerItem<T> : TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/

    {

        public virtual int? max { get; set; }
        public virtual int? min { get; set; }
        public virtual int? step { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (max != null) Parts.Add("max", "max:" + int2JSON((int)max) + "");
                if (min != null) Parts.Add("min", "min:" + int2JSON((int)min) + "");
                if (step != null) Parts.Add("step", "step:" + int2JSON((int)step) + "");


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