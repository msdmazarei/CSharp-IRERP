using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_DetailViewer : IRERP_SM_Canvas
    {
        public virtual IRERPControlBase data { get; set; }
        public virtual Types.IRERPControlTypes_DataSourceField[] fields { get; set; }

        string _name;
        public virtual string name { get { return _name; } set { if (IsInInitializeTime) _name = value; else throw NotImplementerdForIR(); } }

        public virtual string cellStyle { get; set; }
        public virtual string type { get; set; }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                List<string> _da = new List<string>();
                //if (data != null) foreach (var a in data) _da.Add(a.ToStringAsMemberOfOther());
                if (data != null) Parts.Add("data", "data:" +  data.ToStringAsMemberOfOther() + "");
                if (name != null) Parts.Add("name", "name:" + string2JSON(name));
                if (type != null) Parts.Add("type", "type:" + string2JSON(type));
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