using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{
    public class IRERPProfileBaseAttribute : IRERPAttributeBaseClass
    {
        public IRERPProfile[] Profiles { get; set; }
        public IRERPProfileBaseAttribute()
        {
            Profiles = new IRERPProfile[]{};
        }
    }
    
}