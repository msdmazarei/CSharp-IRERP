using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    
    public class IRERP_SM_ListGridRecord : TIRERP_SM_ListGridRecord<IRERP_SM_ListGridRecord> { }
    public class TIRERP_SM_ListGridRecord<T> : TIRERP_SM_Record<T>
        where T:IRERPControlBase
   
    {
        bool? _isSeparator;
        public virtual bool? isSeparator { get { return _isSeparator; } set { if (IsInInitializeTime) _isSeparator = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();

                if (isSeparator != null) Parts.Add("isSeparator", "isSeparator:" + bool2JSON((bool)isSeparator) + "");
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