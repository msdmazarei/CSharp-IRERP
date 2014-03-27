using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPMember<T> : IRERPMember
    {
        public IRERPMember(MemberInfo member,IRERPProfile Profile) : base(typeof(T), member,Profile) { }
    }
}