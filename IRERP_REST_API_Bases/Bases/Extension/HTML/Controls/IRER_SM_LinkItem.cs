using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRER_SM_LinkItem : IRERP_SM_TextItem /*TIRER_SM_LinkItem<IRER_SM_LinkItem> { }
    public class TIRER_SM_LinkItem <T>: TIRERP_SM_TextItem<T>
        where T : TIRERP_SM_TextItem<T>*/
   
    {
       
        public virtual string linkTitle { get; set; }
        public virtual string target { get; set; }

        public IRER_SM_LinkItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.link;
        }
        
        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (linkTitle != null) Parts.Add("linkTitle", "linkTitle:" + string2JSON(linkTitle.ToString()) + "");
                if (target != null) Parts.Add("target", "target:" + string2JSON(target.ToString()) + "");

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