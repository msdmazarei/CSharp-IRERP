using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_SliderItem : IRERP_SM_CanvasItem/* TIRERP_SM_SliderItem<IRERP_SM_SliderItem> { }

    public class TIRERP_SM_SliderItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
 
    {
        public virtual bool? changeOnDrag { get; set; }
        public virtual float? maxValue { get; set; }
        public virtual float? minValue { get; set; }
        public virtual int? numValues { get; set; }

        int? _roundPrecision;
        public virtual int? roundPrecision { get { return _roundPrecision; } set { if (IsInInitializeTime) _roundPrecision = value; else throw NotImplementerdForIR(); } }

        bool? _roundValues;
        public virtual bool? roundValues { get { return _roundValues; } set { if (IsInInitializeTime) _roundValues = value; else throw NotImplementerdForIR(); } }

        bool? _vertical;
        public virtual bool? vertical { get { return _vertical; } set { if (IsInInitializeTime) _vertical = value; else throw NotImplementerdForIR(); } }


        Types.IRERPControlTypes_OperatorId? _operator;
        public virtual  Types.IRERPControlTypes_OperatorId?  operator_  { get { return _operator; } set { if (IsInInitializeTime) _operator = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (maxValue != null) Parts.Add("maxValue", "maxValue:" + float2JSON((float)maxValue) + "");
                if (changeOnDrag != null) Parts.Add("changeOnDrag", "changeOnDrag:" + bool2JSON((bool)changeOnDrag) + "");
                if (roundValues != null) Parts.Add("roundValues", "roundValues:" + bool2JSON((bool)roundValues) + "");
                if (vertical != null) Parts.Add("vertical", "vertical:" + bool2JSON((bool)vertical) + "");
                if (roundPrecision != null) Parts.Add("roundPrecision", "roundPrecision:" + int2JSON((int)roundPrecision) + "");
                if (numValues != null) Parts.Add("numValues", "numValues:" + int2JSON((int)numValues) + "");
                if (minValue != null) Parts.Add("minValue", "minValue:" + float2JSON((float)minValue) + "");
                if (operator_ != null) Parts.Add("operator", "operator:" + enum2JSON(operator_) + "");

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