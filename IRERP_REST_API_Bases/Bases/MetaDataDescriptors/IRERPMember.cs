using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPMember : IRERPFluentBase
    {
        public IRERPMember(Type T, MemberInfo Member,IRERPProfile Profile ) :
            base(T, Member,Profile) { }

       /* public IRERPMemberProfile ForProfiles(IRERPProfile[] Profiles)
        {
            return new IRERPMemberProfile(Profiles, T, meminfo);
        }*/
        public IRERPMemberProfile ForProfile(IRERPProfile Profile)
        {
            //return new IRERPMemberProfile(new IRERPProfile[] { Profile }, T, meminfo);
            return new IRERPMemberProfile(Profile, T, meminfo);
        }
    }
}