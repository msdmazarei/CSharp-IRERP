using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_NativeCheckboxItem : IRERP_SM_FormItem/* TIRER_SM_NativeCheckboxItem<IRER_SM_NativeCheckboxItem> { }
    public class TIRER_SM_NativeCheckboxItem <T>: TIRERP_SM_FormItem<T>
        where T : IRERPControlBase*/
   
    {
        public IRERP_SM_NativeCheckboxItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.boolean;

        }
        public virtual bool? showLabel { get; set; }
        public virtual string MsdHelpMessage { get; set; }

         protected override Dictionary<string, string> GetOutPutParts()
            {
                if (IsInInitializeTime)
                {
                    var Parts = base.GetOutPutParts();
                    if (showLabel != null) Parts.Add("showLabel", "showLabel:" + bool2JSON((bool)showLabel) + "");
                    if (MsdHelpMessage != null) Parts.Add("MsdHelpMessage", "MsdHelpMessage:" + string2JSON(MsdHelpMessage));

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