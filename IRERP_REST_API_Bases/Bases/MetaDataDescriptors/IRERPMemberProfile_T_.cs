using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPMemberProfile<T> : IRERPMemberProfile
    {
        public IRERPMemberProfile(IRERPProfile Profile, MemberInfo Member) : base(Profile, typeof(T), Member) { }

    }

}