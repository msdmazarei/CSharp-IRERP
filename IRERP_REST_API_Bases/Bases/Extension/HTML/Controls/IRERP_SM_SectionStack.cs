using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_SectionStack : IRERP_SM_VLayout/* TIRERP_SM_SectionStack<IRERP_SM_SectionStack> { }
    public class TIRERP_SM_SectionStack<T> : TIRERP_SM_VLayout<T>
        where T : IRERPControlBase*/
    {
        public virtual Types.IRERPControlTypes_visibilityMode? visibilityMode { get; set; }

       IRERP_SM_SectionStackSection[] _sections;
       public virtual IRERP_SM_SectionStackSection[] sections { get { return _sections; } set { if (IsInInitializeTime) _sections = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (visibilityMode != null) Parts.Add("visibilityMode", "visibilityMode:" + enum2JSON(visibilityMode) + "");
                List<string> _fi = new List<string>();

                if (sections != null) foreach (var a in sections) _fi.Add(a.ToStringAsMemberOfOther());



                if (sections != null) Parts.Add("sections", "sections:[" + string.Join(",", _fi) + "]");
                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.SectionStack.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.SectionStack.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
        

    }
}