using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_TimeItem : IRERP_SM_TextItem /*TIRERP_SM_TimeItem<IRERP_SM_TimeItem> { }
    public class TIRERP_SM_TimeItem <T>: TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/
    
    {
        public virtual IRERPControlTypes_TimeDisplayFormat? displayFormat { get; set; }
     
        public virtual IRERPControlTypes_TimeDisplayFormat? timeFormatter { get; set; }
        bool? _useMask;
        public virtual bool? useMask { get { return _useMask; } set { if (IsInInitializeTime) _useMask = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                
                if (useMask != null) Parts.Add("useMask", "useMask:" + bool2JSON((bool)useMask) + "");
                if (timeFormatter != null) Parts.Add("timeFormatter", "timeFormatter:" + enum2JSON(timeFormatter) + "");
                if (displayFormat != null) Parts.Add("displayFormat", "displayFormat:" + enum2JSON(displayFormat) + "");

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