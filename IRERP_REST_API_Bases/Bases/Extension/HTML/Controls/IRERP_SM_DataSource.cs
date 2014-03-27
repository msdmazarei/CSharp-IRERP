using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.BLLCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_DataSource : TIRERP_SM_DataSource<IRERP_SM_DataSource> { }

    public class TIRERP_SM_DataSource<T>:IRERPControlBase
        where T:IRERPControlBase
    {
        
        public virtual IRERPControlTypes_StringMethods
            handleError { get; set; }

        public virtual void ChangeFieldByName(string Name, Func<IRERPControlTypes_DataSourceField, IRERPControlTypes_DataSourceField> act)
        {
            for (int i = 0; i < (fields != null ? fields.Length : 0); i++)
                if (fields[i].name == Name)
                    fields[i] = act(fields[i]);
        }

        public TIRERP_SM_DataSource()
        {
            autoCacheAllData = false;
            cacheAllData = false;
            handleError = new IRERPControlTypes_StringMethods("IRERPDS_handleError", true);
            operationBindings = @"[
     {operationType:""fetch"", dataProtocol:""getParams""},
     {operationType:""add"", dataProtocol:""postParams""},
     {operationType:""remove"", dataProtocol:""getParams"", requestProperties:{httpMethod:""DELETE""}},
     {operationType:""update"", dataProtocol:""postParams"", requestProperties:{httpMethod:""PUT""}}
   ]";
        }
        public string requestProperties { get; set; }
        /*
         * 
         * addGlobalId [IR] [Advanced]	type:Boolean, defaultValue: true
            Whether to make this DataSource available as a global variable for convenience.
         */
        private Nullable< bool> _addGlobalId;
        public Nullable<bool> addGlobalId { get { return _addGlobalId; } set { if (IsInInitializeTime) _addGlobalId = value; else throw new NotImplementedException("Can Not Set [IR] Type Propety"); } }

        public string operationBindings {get;set;}
        public string dataFormat { get; set; }
        //allowAdvancedCriteria [IRW] [Advanced]
        public Nullable<bool> allowAdvancedCriteria { get; set; }

        //autoCacheAllData [IRW]
        public Nullable<bool> autoCacheAllData { get; set; }

        //cacheAllData [IRW]
        public Nullable<bool> cacheAllData { get; set; }

        //cacheMaxAge [IRW]
        public Nullable<bool> cacheMaxAge { get; set; }

        //dataURL [IR]
        Types.IRERPControlTypes_URL _dataURL;
        public Types.IRERPControlTypes_URL dataURL
        {
            get { return _dataURL; }
            set
            {
                if (IsInInitializeTime) _dataURL = value; else throw NotImplementerdForIR();
            } 
        }

        Types.IRERPControlTypes_DataSourceField[] _fields;
        public virtual Types.IRERPControlTypes_DataSourceField[] fields { get { return _fields; } set { if (IsInInitializeTime) _fields = value; else throw NotImplementerdForIR(); } }

        string _ID;
        public string ID { get { return _ID; } set { if (IsInInitializeTime) _ID = value; else throw NotImplementerdForIR(); } }

        public string title { get; set; }

        //jsonPrefix [IR]
        string _jsonPrefix;
        public string jsonPrefix { get { return _jsonPrefix; } set { if (IsInInitializeTime) _jsonPrefix = value; else throw NotImplementerdForIR(); } }

        //jsonSuffix [IR] [Advanced]
        string _jsonSuffix;
        public string jsonSuffix { get { return _jsonSuffix; } set { if (IsInInitializeTime) _jsonSuffix = value; else throw NotImplementerdForIR(); } }

        Nullable<bool> _preventHTTPCaching;
        public Nullable<bool> preventHTTPCaching { get { return _preventHTTPCaching; } set { if (IsInInitializeTime) _preventHTTPCaching = value; else throw NotImplementerdForIR(); } }

        //progressiveLoading [IRW]
        public Nullable<bool> progressiveLoading { get; set; }
        
        //progressiveLoadingThreshold [IRW]
        //Indicates the dataset size that will cause SmartClient Server to automatically switch into progressive loading mode for this DataSource. To prevent automatic switching to progressive loading, set this property to -1.
        public Nullable<bool> progressiveLoadingThreshold { get; set; }

        //sendExtraFields [IR]
        Nullable<bool> _sendExtraFields;
        public Nullable<bool> sendExtraFields { get { return _sendExtraFields; } set { if (IsInInitializeTime) _sendExtraFields = value; else throw NotImplementerdForIR(); } }

        //showPrompt [IRW]
        public Nullable<bool> showPrompt { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            var parts=base.GetOutPutParts();
            if (title != null) parts.Add("title", "title:"+string2JSON(title));
            if (showPrompt != null) parts.Add("showPrompt","showPrompt:"+ bool2JSON((bool)showPrompt));
            if(sendExtraFields!=null) parts.Add("sendExtraFields","sendExtraFields:"+bool2JSON((bool)sendExtraFields));
            if (dataURL != null) parts.Add("dataURL", "dataURL:" + string2JSON(dataURL.Url));
            if (ID != null) parts.Add("ID", "ID:" + string2JSON(ID));
            if (dataFormat != null) parts.Add("dataFormat", "dataFormat:" + string2JSON(dataFormat));
            if (requestProperties != null) parts.Add("requestProperties", "requestProperties:" + requestProperties);
            if (operationBindings != null) parts.Add("operationBindings", "operationBindings:" + operationBindings);
            if (handleError != null) parts.Add("handleError", "handleError:" + handleError.ToString());
            List<string> _fi = new List<string>();

            if (fields != null) foreach (var a in fields) _fi.Add(a.ToStringAsMemberOfOther());

            if (fields != null) parts.Add("fields", "fields:[" + string.Join(",", _fi) + "]");

            return parts;
        }

        //public T FromModel(IRERPProfile Profile, object Model)
        //{
        //    var m = new IRERP_RestAPI.Mappings.UserMap();
        //    if (!IRERPDescriptorVars.STOREUseInDataSource.Keys.Contains(
        //        new IRERPTypeName(
        //        Model.GetType()
        //        )
        //        ))
        //        throw new Exception(Res.NODESCRIPTORFOR + Model.GetType().ToString());

        //    var UseInDS = IRERPDescriptorVars.STOREUseInDataSource[
        //        new IRERPTypeName(
        //        Model.GetType()
        //        )
                
        //        ];
        //    (
        //     from keys in UseInDS
        //     where keys.Value.Profiles.Contains(Profile) || keys.Value.Profiles.Contains(IRERPProfile.Any)
        //     select keys.Key
        //    ).ToList()
        //     .ForEach(MemberInfo =>
        //     {
        //         var r = GetDSField(MemberInfo);

        //         //if (r.Result) fields.Add(r.ResultValue);
        //         if (!r.Result && r.Error.Message.Equals(Res.NDGENANOTHERDATASRC))
        //         {
        //             //Test Relation , if relation is One To One
        //         }

        //     }
        //         );

        //    return (T)(IRERPControlBase)this;
        //}
        public override string ToString()
        {
            string rtn = "";
            rtn = "irerp.RestDataSource.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            return rtn;
        }
        public override string ToStringAsMemberOfOther()
        {
            string rtn = "";
            rtn = "irerp.RestDataSource.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            return rtn;
        }
        protected
            Tuple<List<Types.IRERPControlTypes_DataSourceField>, Type, IRERPProfile>

            GetAnotherDs(System.Reflection.MemberInfo MemInfo)
        {
            return new Tuple<List<Types.IRERPControlTypes_DataSourceField>, Type, IRERPProfile>(null, null,IRERPProfile.Unknown);
        }
            


        //protected 
        //    FunctionResult<Types.IRERPControlTypes_DataSourceField> 

        //    GetDSField

        //    (System.Reflection.MemberInfo Meminfo)
        //{
        //    var rtn = new FunctionResult<Types.IRERPControlTypes_DataSourceField>();
        //    rtn.Result = true;
        //    var rtnval = new Types.IRERPControlTypes_DataSourceField();
        //    if (Meminfo.MemberType == System.Reflection.MemberTypes.Property ||
        //        Meminfo.MemberType == System.Reflection.MemberTypes.Field)
        //    {
        //        //Data Source Property
        //        var dsf = IRERPDescriptorVars.STOREDSFieldProperty[new IRERPTypeName(Meminfo.DeclaringType)][Meminfo];

        //        if (dsf.Type == Attribute.ProfileBase.DSFieldType.ModelBase)
        //        {
        //            rtn.Result = false;
        //            rtn.Error = new PException(Res.NDGENANOTHERDATASRC, null);
        //            return rtn;
        //        }
        //        rtnval = (Types.IRERPControlTypes_DataSourceField)dsf;
        //        rtnval.name = Meminfo.Name;
        //        rtnval.IsInInitializeTime = false;
        //        rtn.ResultValue = rtnval;
        //    }
        //    else
        //        throw new NotImplementedException(Res.OTHRTYCLSMEMNOIMPL);

        //    return rtn;
        //}

        public static IRERP_SM_DataSource GetDataSource(Type ModelType, IRERPProfile Profile)
        {
            var Model = IRERPApplicationUtilities.NewInstance(ModelType);
            var rtn = Model.MyCustomDataSource(Profile);
            if (rtn != null) return rtn;
            rtn = new IRERP_SM_DataSource();

            //==========================================================================
            //------------------- c# types
            /*
            var DSFieldProperties = IRERPDescriptorVars.STOREDSFieldProperty[new IRERPTypeName(Model.GetType())];
            //Filter By Profile
            var validkeys = (
                             from x in DSFieldProperties.Keys
                             where
                             DSFieldProperties[x].Profiles != null
                             &&
                             (
                             DSFieldProperties[x].Profiles.Contains(Profile)
                             ||
                             DSFieldProperties[x].Profiles.Contains(IRERPProfile.Any)
                             )
                             select x
                             ).ToList();
            */
            Dictionary<MemberInfo, DSFieldProperty> DSFieldProperties = IRERPApplicationUtilities.GetDSFieldPropetyByModelAndProfile(Model.GetType(), Profile);
            List<IRERPControlTypes_DataSourceField> CliDsFields = new List<IRERPControlTypes_DataSourceField>();
            foreach (var key in DSFieldProperties.Keys)
            {
                /////////////////////////Get Type Of Key
                if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(Bases.NHComponents.IRERPGAddress), ((PropertyInfo)key).PropertyType))
                {
                    CliDsFields.AddRange(
                    NHComponents.IRERPGAddress.GetFields(key.Name)
                    );
                    continue;
                }
                if (DSFieldProperties[key].name == null)
                {
                    DSFieldProperties[key].name = key.Name;
                }
                if (DSFieldProperties[key].title == null)
                {
                    DSFieldProperties[key].title = key.Name;
                }
                CliDsFields.Add((IRERPControlTypes_DataSourceField)DSFieldProperties[key]);
            }
            //==========================================================================
            //------------------------------- ModelBase types Members
            //Other members 
            var _tmp = new IRERPTypeName(Model.GetType());
            var useasprofiles = IRERPDescriptorVars.STOREUseAsProfile[_tmp];

            Dictionary<MemberInfo, UseAsProfile>  useasprofilefields = IRERPApplicationUtilities.Get_DSUseAsProfile_Fields_ByModelAndProfile(Model.GetType(), Profile);
                //(
                //from x in useasprofiles.Keys
                //where
                //useasprofiles[x].Profiles != null
                //&&
                //(
                //useasprofiles[x].Profiles.Contains(Profile)
                //||
                //useasprofiles[x].Profiles.Contains(IRERPProfile.Any)
                //)
                //select x
                //)
                //.ToList();
            foreach (var useasprofilememinfo in useasprofilefields.Keys)
            {
                if (IRERPApplicationUtilities.IsMemberImplementedIListFamilyInterfaces(useasprofilememinfo))
                    continue;
                if(
                    IRERPApplicationUtilities.IsSubclassOfRawGeneric(
                    typeof(ModelBase<>),
                    ((PropertyInfo)useasprofilememinfo).PropertyType)
                    )
                {
                    var tmpds = IRERP_SM_DataSource.GetDataSource(
                        ((PropertyInfo)useasprofilememinfo).PropertyType,
                        useasprofilefields[useasprofilememinfo].TargetProfile
                        );
                   // add tmpds fields to current cliDsFielfs
                    var addingFields = tmpds.fields;
                    
                    addingFields.ToList().ForEach(x =>
                        { 
                            //Cancel Primary Key property of x
                            x.name = useasprofilememinfo.Name + "___" + x.name;
                            if (x.primaryKey) x.primaryKey = false;
                        });
                    CliDsFields.AddRange(addingFields);
                }

            }



            //////////////////////////////////////////////
            ///////////
            rtn.fields = CliDsFields.ToArray();

            rtn.dataFormat = "json";
            return rtn;
        }
        public static IRERP_SM_DataSource GetDataSource<T1>(IRERPProfile Profile)
            where T1: ModelBase<T1>
        {
            return IRERP_SM_DataSource.GetDataSource(typeof(T1), Profile);
        }

        public static IRERP_SM_DataSource GetDataSource<T2,T1>(IRERPProfile Profile, Expression<Func<T2, IList<T1>>> Member)
            where T2 : ModelBase<T2>
            where T1: ModelBase<T1>
        {
            var Model = IRERPApplicationUtilities.NewInstance<T2>();
            var rtn = Model.MyCustomDataSource(Profile, Member);
            if (rtn != null)
                return rtn;
            rtn = new IRERP_SM_DataSource();
            //Check UseAsProfile Defined For Member
            var useasprofile = IRERPDescriptorVars.STOREUseAsProfile[new IRERPTypeName(Model.GetType())][Profile];
            var meminfo = IRERPApplicationUtilities.GetClassMember(Member);
            if (useasprofile != null)
                if (useasprofile.Count > 0)
                    if (
                        useasprofile.Keys.Contains(meminfo))
                    {
                        var ins = IRERPApplicationUtilities.NewInstance<T1>();
                        var ds = IRERP_SM_DataSource.GetDataSource<T1>(useasprofile[meminfo].TargetProfile);
                        return ds;
                    }
            return null;
        }


    }
}