using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Portlets:IRERP_SM_Portlet
    {
        public virtual IRERPControlBase[] Portlets {get; set;}
        public static IRERP_SM_Portlets GetRow(params IRERPControlBase[] a)
        {
            IRERP_SM_Portlets rtn = new IRERP_SM_Portlets();
            rtn.Portlets = a;
            return rtn;
        }

         protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                if (Portlets == null)
                {
                    var Parts = base.GetOutPutParts();
                    return Parts;
                }
                else
                {
                    Dictionary<string, string> Parts = new Dictionary<string, string>();
                    List<string> _fi = new List<string>();

                    if (Portlets != null) foreach (var a in Portlets) _fi.Add(a.ToStringAsMemberOfOther());
                    if (Portlets != null) Parts.Add("Portlets", "[" + string.Join(",", _fi) + "]");
                    return Parts;
                }
            }

            else
            { return new Dictionary<string, string>(); }


        }

         public override string ToStringAsMemberOfOther()
         {
             if (Portlets != null)
             {
                 if (IsInInitializeTime)
                     return "" + string.Join(",", GetOutPutParts().Values.ToArray()) + "";
                 else
                     return "";
             }
             else
             {
                 return base.ToStringAsMemberOfOther();
             }
         }
         public override string ToString()
         {
             if (IsInInitializeTime)
                 return "" + string.Join(",", GetOutPutParts().Values.ToArray()) + "";
             else
                 return "";
         }

    }
    
}