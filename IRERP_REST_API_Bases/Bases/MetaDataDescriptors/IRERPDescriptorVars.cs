using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    /// <summary>
    /// ////////////////////////////////
    /// --------------------------------------------------------------------
    /// | Type      | Profile        | Member        | Descriptor            |
    /// --------------------------------------------------------------------
    /// </summary>
    /// 
    public abstract class IRERPDescriptorVars
    {
        const string STOREUseInDataSourceKey = "MSD_STOREUseInDataSource_KEY";
        //[ThreadStatic]
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseInDataSource>>>
    STOREUseInDataSource
        {
            get
            {
                string key = STOREUseInDataSourceKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseInDataSource>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseInDataSource>>>)
                    HttpContext.Current.Items[key];
                ;
            }
            set
            {
                string key = STOREUseInDataSourceKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseInDataSource>>>());
                HttpContext.Current.Items[key] = value;
            }
        }

        //[ThreadStatic]
        const string STORECriteriaConversionKey = "Msd_STORECriteriaConversion_KEY";
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>>
            STORECriteriaConversion
        {
            get
            {
                string key = STORECriteriaConversionKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>>)
                    HttpContext.Current.Items[key];

            }
            set
            {
                string key = STORECriteriaConversionKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>>());
                HttpContext.Current.Items[key] = value;
            }
        }
        //  STORECriteriaConversion = new Dictionary<IRERPTypeName,Dictionary<IRERPProfile, Dictionary<MemberInfo, CriteriaConversion>>>();
        //[ThreadStatic]
        const string STOREDSFieldPropertyKey = "Msd_STOREDSFieldProperty_KEY";
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>
            STOREDSFieldProperty
        {
            get
            {
                string key = STOREDSFieldPropertyKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>)
                    HttpContext.Current.Items[key];
            }
            set
            {
                string key = STOREDSFieldPropertyKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>());
                HttpContext.Current.Items[key] = value;
            }
        }
            
            //= new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>();
        //[ThreadStatic]
        const string STOREUseAsProfileKey = "Msd_STOREUseAsProfile_KEY";
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseAsProfile>>>
            STOREUseAsProfile
        {
             get
            {
                string key = STOREUseAsProfileKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseAsProfile>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseAsProfile>>>)
                    HttpContext.Current.Items[key];
            }
            set
            {
                string key = STOREUseAsProfileKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, DSFieldProperty>>>());
                HttpContext.Current.Items[key] = value;
            }
        }
           // = new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, UseAsProfile>>>();
        //[ThreadStatic]
        const string STOREAliasForPropertyKey = "Msd_STOREAliasForProperty_KEY";
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, AliasForProperty>>>
            STOREAliasForProperty 
        {
            get
            {
                string key = STOREAliasForPropertyKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, AliasForProperty>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, AliasForProperty>>>)
                    HttpContext.Current.Items[key];
            }
            set
            {
                string key = STOREAliasForPropertyKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, AliasForProperty>>>());
                HttpContext.Current.Items[key] = value;
            }
        }
        //= new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, AliasForProperty>>>();

        //[ThreadStatic]
        const string STOREValidateKey = "Msd_STOREValidate_KEY";
        public static Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>>
             STOREValidate
        {
            get
            {
                string key = STOREValidateKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>>());
                return (Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>>)
                    HttpContext.Current.Items[key];
            }
            set
            {
                string key = STOREValidateKey + "_" + HttpContext.Current.GetHashCode().ToString();
                var stored = HttpContext.Current.Items[key];
                if (stored == null)
                    HttpContext.Current.Items.Add(key, new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>>());
                HttpContext.Current.Items[key] = value;
            }
        
        }
             //= new Dictionary<IRERPTypeName, Dictionary<IRERPProfile, Dictionary<MemberInfo, Validate>>>();


    }
}

///How To Add Descriptor
///-----------------------------
///Define Your New Descriptor in IRERP_RestAPI.Bases.Attribute.ProfileBase NameSpace
///Add New Dictionary To IRERPDescriptorVars class
/// Add Proper Lines To 
/// IRERPDescriptor<T>.AddNewTypeToDescriptors Method and .AddNewProfileToDescriptors Method
/// Add variable to STOREVariable To IRERPFluentBase class like others
/// Add proper Method To IRERPMemberProfile class