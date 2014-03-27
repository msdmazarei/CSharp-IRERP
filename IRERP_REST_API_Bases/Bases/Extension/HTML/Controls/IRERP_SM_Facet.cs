using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Facet:IRERPControlBase
    {
        string _id;
        public virtual string id { get { return _id; } set { if (IsInInitializeTime) _id = value; else throw NotImplementerdForIR(); } }
        public virtual string title { get; set; }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (id != null) Parts.Add("id", "id:" + string2JSON(id.ToString()) + "");

                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");


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