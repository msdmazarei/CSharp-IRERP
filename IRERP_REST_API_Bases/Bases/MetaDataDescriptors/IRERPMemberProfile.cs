using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Linq;
using System.Linq.Expressions;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPMemberProfile : IRERPFluentBase
    {
        //IRERPProfile[] DefProfiled { get; set; }
        public IRERPMemberProfile(IRERPProfile Profile, Type T, MemberInfo Member) : base(T, Member,Profile) { } //{ DefProfiled = Profiles; }


        public IRERPMemberProfile CriteriaConversion(Func<object, PCriteria, ICriterion> func)
        {
            STORECriteriaConversion.Add(meminfo, new CriteriaConversion() { /*Profiles = DefProfiled,*/ ConvertorMethod = func }
                );
            return this;
        }
        public IRERPMemberProfile UserAsProfile(IRERPProfile TargetProfile)
        {
            lock (this)
            {
                UseAsProfile ourclass = null;
                if (STOREUseAsProfile.ContainsKey(meminfo))
                    ourclass = STOREUseAsProfile[meminfo];
                else
                    ourclass = new UseAsProfile();
                ourclass.TargetProfile = TargetProfile;
                // ourclass.Profiles = DefProfiled;

                if (STOREUseAsProfile.ContainsKey(meminfo))
                    STOREUseAsProfile[meminfo] = ourclass;
                else
                    STOREUseAsProfile.Add(meminfo, ourclass);

            }
            return this;
        }
        public IRERPMemberProfile DataSourceFieldProperty(Nullable<bool> Hidden = null, Nullable<bool> PrimaryKey = null, Nullable<bool> Require = null,
            string rootValue = null, Nullable<DSFieldType> Type = null, Nullable<IRERPControlTypes_FieldType> ClientType = null,
            Func<dynamic, dynamic> ConvertToDataSourceField = null, Func<dynamic, dynamic> ConvertFromDataSourceField = null
            ,
            string title =null,
            string valueMap = null
            )
        {
            lock (this)
            {
                DSFieldProperty ourclass = null;
                if (STOREDSFieldProperty.ContainsKey(meminfo))
                    ourclass = STOREDSFieldProperty[meminfo];
                else
                    ourclass = new DSFieldProperty();

                if (Hidden != null) ourclass.Hidden = (bool)Hidden;
                if (PrimaryKey != null) ourclass.PrimaryKey = (bool)PrimaryKey;
                if (Require != null) ourclass.Require = (bool)Require;
                if (rootValue != null) ourclass.rootValue = rootValue;
                if (Type != null) ourclass.Type = (DSFieldType)Type;
                if (ConvertToDataSourceField != null) ourclass.ConvertToDSField = ConvertToDataSourceField;
                if (ConvertFromDataSourceField != null) ourclass.ConvertFromDSField = ConvertFromDataSourceField;
                if (ClientType != null) ourclass.ClientType = (IRERPControlTypes_FieldType)ClientType;
                if (title != null) ourclass.title = title;
                if (valueMap != null) ourclass.valueMap = valueMap;
                ourclass.name = this.expressionPath.ToClientDsFieldName();
                ourclass.serverPropertyPath = this.expressionPath;
                //ourclass.Profiles = this.DefProfiled;

                if (STOREDSFieldProperty.ContainsKey(meminfo))
                    STOREDSFieldProperty[meminfo] = ourclass;
                else
                    STOREDSFieldProperty.Add(meminfo, ourclass);
             
            }
            return this;
        }
        public IRERPMemberProfile AliasForProperty(string PropertyPath)
        {
            lock (this)
            {
                AliasForProperty ourclass = null;
                if (STOREAliasForProperty.ContainsKey(meminfo))
                    ourclass = STOREAliasForProperty[meminfo];
                else
                    ourclass = new  AliasForProperty();
                ourclass.PropertyPath = PropertyPath;
                // ourclass.Profiles = DefProfiled;

                if (STOREAliasForProperty.ContainsKey(meminfo))
                    STOREAliasForProperty[meminfo] = ourclass;
                else
                    STOREAliasForProperty.Add(meminfo, ourclass);

            }
            return this;
        }
        public IRERPMemberProfile Validate<T>(Func<T,string> Validator )
        {
            lock (this)
            {
                Validate<T> ourclass = null;
                if (STOREValidate.ContainsKey(meminfo))
                    ourclass =(Validate<T>) STOREValidate[meminfo];
                else
                    ourclass = new Validate<T>();
                ourclass.Validation= Validator;
                // ourclass.Profiles = DefProfiled;

                if (STOREValidate.ContainsKey(meminfo))
                    STOREValidate[meminfo] = ourclass;
                else
                    STOREValidate.Add(meminfo, ourclass);

            }
            return this;
        }
    }
}