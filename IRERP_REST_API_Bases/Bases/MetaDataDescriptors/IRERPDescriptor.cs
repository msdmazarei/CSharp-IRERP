using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPDescriptor<T> : MsdLib.CSharp.DALCore.MsdClassMap<T> //ClassMap<T>
       where T : MsdLib.CSharp.DALCore.ModelBase
    {
        protected string MsdTableName(string spliter = null, params string[] parts)
        {
            if(spliter==null)
            switch (MsdLib.CSharp.DALCore.DBFactory.DbType)
            {
                case dbtype.MsSql:
                    spliter = ".";
                    break;
                case dbtype.MySql:
                    spliter = "__";
                    break;
            }
            return string.Join(spliter, parts);
        }
        protected void AddNewTypeToDescriptors(Type T,IRERPProfile Profile)
        {
            lock (this)
            {
                IRERPTypeName tyname = new IRERPTypeName(T);
                IRERPDescriptorVars.STOREUseInDataSource.Add(tyname, new Dictionary<IRERPProfile, Dictionary<MemberInfo, UseInDataSource>>()
                );

                IRERPDescriptorVars.STOREUseInDataSource[tyname].Add(Profile, new Dictionary<MemberInfo, UseInDataSource>());

                IRERPDescriptorVars.
                STORECriteriaConversion.Add(tyname, new Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>());
                IRERPDescriptorVars.
                STORECriteriaConversion[tyname].Add(Profile, new Dictionary<MemberInfo, CriteriaConversion>());

                IRERPDescriptorVars.
                STOREDSFieldProperty.Add(new IRERPTypeName(T), new Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>());
                IRERPDescriptorVars.
                STOREDSFieldProperty[tyname].Add(Profile, new Dictionary<MemberInfo, DSFieldProperty>());

                IRERPDescriptorVars.
                STOREUseAsProfile.Add(new IRERPTypeName(T), new Dictionary<IRERPProfile, Dictionary<MemberInfo, UseAsProfile>>());
                IRERPDescriptorVars.
                STOREUseAsProfile[tyname].Add(Profile, new Dictionary<MemberInfo, UseAsProfile>());


                IRERPDescriptorVars.
                  STOREAliasForProperty.Add(new IRERPTypeName(T),new Dictionary<IRERPProfile,Dictionary<MemberInfo,AliasForProperty>>());
                IRERPDescriptorVars.
                    STOREAliasForProperty[tyname].Add(Profile, new Dictionary<MemberInfo, AliasForProperty>());

                IRERPDescriptorVars.
                STOREValidate.Add(new IRERPTypeName(T), new Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>());
                IRERPDescriptorVars.
                    STOREValidate[tyname].Add(Profile, new Dictionary<MemberInfo, Validate>());


            }
        }

        protected void AddNewProfileToDescriptors(Type T,IRERPProfile Profile)
        {
            lock (this)
            {
                IRERPTypeName tyname = new IRERPTypeName(T);
                IRERPDescriptorVars.STOREUseInDataSource[tyname].Add(Profile, new Dictionary<MemberInfo, UseInDataSource>());
                IRERPDescriptorVars.STORECriteriaConversion[tyname].Add(Profile, new Dictionary<MemberInfo, CriteriaConversion>());
                IRERPDescriptorVars.STOREDSFieldProperty[tyname].Add(Profile, new Dictionary<MemberInfo, DSFieldProperty>());
                IRERPDescriptorVars.STOREUseAsProfile[tyname].Add(Profile, new Dictionary<MemberInfo, UseAsProfile>());
                IRERPDescriptorVars.STOREAliasForProperty[tyname].Add(Profile,new Dictionary<MemberInfo,AliasForProperty>());
                IRERPDescriptorVars.STOREValidate[tyname].Add(Profile, new Dictionary<MemberInfo, Validate>());
                
            }
        }
        protected IRERPMemberProfile DescribeMember(Expression<Func<T, Object>> Elem, IRERPProfile Profile)
        {

            if (!
                
                (
                IRERPDescriptorVars.
                STOREUseInDataSource.Keys.Contains(new IRERPTypeName(typeof(T)))
                )
                )
                AddNewTypeToDescriptors(
                    typeof(T),Profile
                    );

            if (
                (
                IRERPDescriptorVars.
                STOREUseInDataSource.Keys.Contains(new IRERPTypeName(typeof(T)))
                )
                )
                if
                    (
                    !
                    IRERPDescriptorVars.
                STOREUseInDataSource[new IRERPTypeName(typeof(T))].Keys.Contains(Profile)
                    )
                    AddNewProfileToDescriptors(
                    typeof(T), Profile
                    );
            /*Dictionary<string, object> a = new Dictionary<string, object>();
            a.Add("STOREUseInDataSource", IRERPDescriptorVars.STOREUseInDataSource[typeof(T)]);
            a.Add("STORECriteriaConversion", IRERPDescriptorVars.STORECriteriaConversion[typeof(T)]);
            */
            var rtn =  new IRERPMemberProfile(Profile, typeof(T), IRERPApplicationUtilities.GetClassMember<T>(Elem));
            rtn.expressionPath = IRERPApplicationUtilities.GPN(Elem);
            return rtn;
            //return new IRERPMember(typeof(T),
            //    IRERPApplicationUtilities.GetClassMember<T>(Elem),Profile
            //    );
        }
        protected IRERPMemberProfile<T> DescribeMemberGeneric(Expression<Func<T, Object>> Elem, IRERPProfile Profile)
        {
            return (IRERPMemberProfile<T>)DescribeMember(Elem, Profile);
        }
    }


}