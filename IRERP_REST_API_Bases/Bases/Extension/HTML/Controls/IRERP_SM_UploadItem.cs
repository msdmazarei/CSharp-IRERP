using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_UploadItem : IRERP_SM_TextItem/* TIRERP_SM_UploadItem<IRERP_SM_UploadItem> { }
    public class TIRERP_SM_UploadItem <T>: TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/

    {
        string _accept;
        public virtual string accept { get { return _accept; } set { if (IsInInitializeTime) _accept = value; else throw NotImplementerdForIR(); } }
        bool? _multiple;
        public virtual bool? multiple { get { return _multiple; } set { if (IsInInitializeTime) _multiple = value; else throw NotImplementerdForIR(); } }
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (multiple != null) Parts.Add("multiple", "multiple:" + bool2JSON((bool)multiple) + "");
                if (accept != null) Parts.Add("accept", "accept:" +string2JSON(accept.ToString()) + "");


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