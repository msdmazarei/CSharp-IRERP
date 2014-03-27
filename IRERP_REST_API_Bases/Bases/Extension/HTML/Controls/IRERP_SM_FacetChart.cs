using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_FacetChart:IRERP_SM_Canvas
    {
        IRERP_SM_Facet _facets;
        public virtual IRERP_SM_Facet facets { get { return _facets; } set { if (IsInInitializeTime) _facets = value; else throw NotImplementerdForIR(); } }

        IRERPControlBase _data;
        public virtual IRERPControlBase data { get { return _data; } set { if (IsInInitializeTime) _data = value; else throw NotImplementerdForIR(); } }

        string _valueProperty;
        public virtual string valueProperty { get { return _valueProperty; } set { if (IsInInitializeTime) _valueProperty = value; else throw NotImplementerdForIR(); } }
        public virtual Types.IRERPControlTypes_ChartType? chartType {get;set;}
        public virtual string title {get;set;}

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");
                if (facets != null) Parts.Add("facets", "facets:" + facets.ToStringAsMemberOfOther() + "");
                if (data != null) Parts.Add("data", "data:" + data.ToStringAsMemberOfOther() + "");
                if (valueProperty != null) Parts.Add("valueProperty", "valueProperty:" + string2JSON(valueProperty.ToString()) + "");
                if (chartType != null) Parts.Add("chartType", "chartType:" + enum2JSON(chartType) + "");


                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.FacetChart.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.FacetChart.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}