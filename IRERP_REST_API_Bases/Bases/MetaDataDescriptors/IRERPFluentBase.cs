using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPFluentBase
    {
        protected  Dictionary<MemberInfo, CriteriaConversion>
            STORECriteriaConversion
        {
            get
            {
                return IRERPDescriptorVars.STORECriteriaConversion[new IRERPTypeName(T)][this.Profile];
            }
        }

        protected Dictionary<MemberInfo, UseInDataSource>
            STOREUseInDataSource
        {
            get
            {
                return IRERPDescriptorVars.STOREUseInDataSource[new IRERPTypeName(T)][this.Profile];
            }
        }

        protected Dictionary<MemberInfo, DSFieldProperty> 
            STOREDSFieldProperty
        {
            get
            {
                return IRERPDescriptorVars.STOREDSFieldProperty[new IRERPTypeName(T)][this.Profile];
            }
        }
        protected Dictionary<MemberInfo, UseAsProfile> 
            STOREUseAsProfile
        {
            get { return IRERPDescriptorVars.STOREUseAsProfile[new IRERPTypeName(T)][this.Profile]; }
        }

        protected Dictionary<MemberInfo, AliasForProperty>
          STOREAliasForProperty
        {
            get { return IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(T)][this.Profile]; }
        }

        protected Dictionary<MemberInfo, Validate>
                STOREValidate
        {
            get { return IRERPDescriptorVars.STOREValidate[new IRERPTypeName(T)][this.Profile]; }
        }

        protected MemberInfo meminfo;
        protected Type T;
        public virtual IRERPProfile Profile { get; set; }
        public virtual string expressionPath { get; set; }
        public IRERPFluentBase(Type T, MemberInfo Member,IRERPProfile _Profile)
        {
            
            this.T = T;
            meminfo = Member;
            this.Profile = _Profile;
        }



    }
}