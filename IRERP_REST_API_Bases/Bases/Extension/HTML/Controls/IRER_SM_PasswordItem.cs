using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_PasswordItem : IRERP_SM_TextItem/* TIRERP_SM_PasswordItem<IRERP_SM_PasswordItem> { }
    public class TIRERP_SM_PasswordItem<T>: TIRERP_SM_TextItem<T>
        where T: TIRERP_SM_TextItem<T>*/
        
   
    {
        public IRERP_SM_PasswordItem()
        {
            type = IRERPControlTypes_FormItemType.password;
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