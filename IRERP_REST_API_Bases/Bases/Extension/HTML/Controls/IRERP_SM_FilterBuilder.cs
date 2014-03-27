using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
   public class IRERP_SM_FilterBuilder:IRERP_SM_Layout
    {
       public IRERPControlBase dataSource { get; set; }


       protected override Dictionary<string, string> GetOutPutParts()
       {
           if (IsInInitializeTime)
           {
               var Parts = base.GetOutPutParts();
               if (dataSource != null) Parts.Add("dataSource", "dataSource:" + dataSource.ToStringAsMemberOfOther());
               return Parts;
           }

            else
            { return new Dictionary<string, string>(); }
             
       }

       public override string ToStringAsMemberOfOther()
       {
           if (IsInInitializeTime)
               return "isc.FilterBuilder.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
           else
               return "";
       }
       public override string ToString()
       {
           if (IsInInitializeTime)
               return "isc.FilterBuilder.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
           else
               return "";
       }
    }
}
