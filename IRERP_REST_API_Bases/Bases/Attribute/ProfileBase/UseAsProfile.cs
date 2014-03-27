using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{
    public class UseAsProfile : IRERPProfileBaseAttribute
    {
        public IRERPProfile TargetProfile { get; set; }
    }
}