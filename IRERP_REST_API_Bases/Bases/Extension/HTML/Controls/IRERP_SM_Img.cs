using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Img  : IRERP_SM_StatefulCanvas
    {
        public string src { get; set; }
        public bool? usePNGFix { get; set; }
        public Types.IRERPControlTypes_imageType? imageType { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            var Parts = base.GetOutPutParts();
            if (src != null) Parts.Add("src", "src:" + string2JSON(src));
            if (usePNGFix != null) Parts.Add("usePNGFix", "usePNGFix:" + bool2JSON(usePNGFix));
            if (imageType != null) Parts.Add("imageType", "imageType:" + enum2JSON(imageType));
            return Parts;
        }

        public override string ToString()
        {
            string rtn = "";
            rtn = "isc.Img.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            return rtn;
        }
        public override string ToStringAsMemberOfOther()
        {
            string rtn = "";
            rtn = "isc.Img.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            return rtn;
        }
    }
}