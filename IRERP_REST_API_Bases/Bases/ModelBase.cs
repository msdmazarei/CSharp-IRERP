using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using System.Reflection;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System.Linq.Expressions;
using IRERP_RestAPI.Bases.Extension.Methods;
using MsdLib.Types.NH;
using MsdLib.ExtentionFuncs.Strings;
using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using MsdLib.Types;
namespace IRERP_RestAPI.Bases
{
    public class ModelBase<T>: MsdLib.CSharp.DALCore.ModelBase<T>
        where T : MsdLib.CSharp.DALCore.ModelBase
    {
        public virtual IRERPProfile Profile { get; set; }
        public virtual IList<T1> GetByNHibernateRelationProprty<T1>(Expression<Func<T, IList<T1>>> exp)
            where T1:ModelBase
        { 
            return null; 
        }


        public virtual LoadableVar<IList<T1>> GetByNHibernateRelationProprty_LoadableVar<T1>(Expression<Func<T, IList<T1>>> exp)
           where T1 : ModelBase
        { return new LoadableVar<IList<T1>>() { isLoaded = false }; }


        public virtual LoadableVar<T1> GetByNHibernateRelationProprty_LoadableVar<T1>(Expression<Func<T, T1>> exp,object obj =null)
         where T1 : ModelBase
        {
            string path = IRERPApplicationUtilities.GPN(exp);
            //Get Property Type
            Type propertyType = IRERPApplicationUtilities.GetClassPropertyType(this.GetType(), path);
            object value = IRERPApplicationUtilities.GetProperty(this, path);
            if (value != null)
                if (value.GetType() == propertyType)
                {
                    return new LoadableVar<T1>() { Value = (T1)value, isLoaded = true };
                }
            if (value == null)
                return new LoadableVar<T1>() { isLoaded = true, Value = null };
            
            return new LoadableVar<T1>() { isLoaded =false }; }

        public virtual T1 GetByNHibernateRelationProprty<T1>(Expression<Func<T, T1>> exp)
            where T1 : ModelBase<T1>
        { return null; }
        
        public virtual IList<T1> LoadListFromDbToVar<T1, PKType>(ref LoadableVar<IList<T1>> localVariable, Func<PKType, IList<T1>> GetByQueryFunc, Expression<Func<T, PKType>> PKPath)
        {

            if (localVariable.isLoaded)
                return localVariable.Value;
            dynamic obj = this;
            PKType pk = PKPath.Compile()(obj);
            localVariable.SetValue(GetByQueryFunc(pk));
            return localVariable.Value;
        }

        public virtual T1 LoadFromDbToVariable<T1, PKType>(ref LoadableVar<T1> localVariable, Func<PKType, T1> GetByQueryFunc, Expression<Func<T, PKType>> PKPath)
        {
            if (localVariable.isLoaded)
                return localVariable.Value;
            dynamic obj = this;
            PKType pk = PKPath.Compile()(obj);
            localVariable.SetValue(GetByQueryFunc(pk));
            return localVariable.Value;
        }
        public virtual T1 LoadNHRelation<T1,PKType>(ref T1 localVariable, Expression<Func<T, T1>> relexp, Func<PKType,T1> GetByQueryFunc,Expression<Func<T,PKType>> PKPath)
               where T1 : ModelBase<T1>
                
        {
            if (localVariable != null) return localVariable;
            localVariable= GetByNHibernateRelationProprty<T1>(relexp);
            if (localVariable != null) return localVariable;
            //Retrive From Db
            dynamic obj = this;
            PKType pk = PKPath.Compile()(obj);

            localVariable = GetByQueryFunc(pk);
            return localVariable;
        }

        public virtual T1 LoadNHRelation<T1, PKType>(ref LoadableVar<T1> localVariable, Expression<Func<T, T1>> relexp, Func<PKType, T1> GetByQueryFunc, Expression<Func<T, PKType>> PKPath)
              where T1 : ModelBase
        {
            
            if (localVariable.isLoaded) 
                return localVariable.Value;
            string path = IRERPApplicationUtilities.GPN(relexp);
            
            localVariable = GetByNHibernateRelationProprty_LoadableVar<T1>(relexp);
            
            if (localVariable.isLoaded)
                return localVariable.Value;

            //Retrive From Db
            dynamic obj = this;
           try
            {
                PKType pk = PKPath.Compile()(obj);
                localVariable.Value = GetByQueryFunc(pk);
            }catch{}

            localVariable.isLoaded = true;
            return localVariable.Value;
        }
        public virtual IList<T1> LoadNHRelation<T1, PKType>(ref IList<T1> localVariable, Expression<Func<T, IList<T1>>> relexp, Func<PKType, IList<T1>> GetByQueryFunc, Expression<Func<T, PKType>> PKPath,
            Func<T,T1,MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>> AddToCollection =null ,
            Func<T,T1,MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>> RemoveFromCollection =null 
            )
          where T1 : ModelBase
        {
            if (localVariable != null) return localVariable;
            dynamic rtn = LoadNHRelation<T1, PKType>(ref localVariable,relexp, GetByQueryFunc, PKPath);
            dynamic obj = this;
            rtn.ParentInstance =obj;
            if (AddToCollection != null)
                rtn.AddToCollection = AddToCollection;
            if (RemoveFromCollection != null)
                rtn.RemoveFromCollection = RemoveFromCollection;
            return rtn;

        }

        public virtual IList<T1> LoadNHRelation<T1, PKType>(ref LoadableVar<IList<T1>> localVariable, Expression<Func<T, IList<T1>>> relexp, Func<PKType, IList<T1>> GetByQueryFunc, Expression<Func<T, PKType>> PKPath,
           Func<T, T1, MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>> AddToCollection = null,
           Func<T, T1, MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>> RemoveFromCollection = null
           )
         where T1 : ModelBase
        {
            if (localVariable.isLoaded) return localVariable.Value;
            dynamic rtn = LoadNHRelation<T1, PKType>(ref localVariable, relexp, GetByQueryFunc, PKPath);
            dynamic obj = this;
            rtn.ParentInstance = obj;
            if (AddToCollection != null)
                rtn.AddToCollection = AddToCollection;
            if (RemoveFromCollection != null)
                rtn.RemoveFromCollection = RemoveFromCollection;
            return rtn;

        }
        public virtual IList<T1> LoadNHRelation<T1, PKType>(ref IList<T1> localVariable, Expression<Func<T, IList<T1>>> relexp, Func<PKType, IList<T1>> GetByQueryFunc, Expression<Func<T, PKType>> PKPath)
             where T1 : ModelBase
        {
            if (localVariable != null) return localVariable;
            localVariable = GetByNHibernateRelationProprty<T1>(relexp);
            if (localVariable != null) return localVariable;
            //Retrive From Db
            dynamic obj = this;
            PKType pk = PKPath.Compile()(obj);

            localVariable = GetByQueryFunc(pk);
            return localVariable;
        }
        public virtual IList<T1> LoadNHRelation<T1, PKType>(ref LoadableVar<IList<T1>> localVariable, Expression<Func<T, IList<T1>>> relexp, Func<PKType, IList<T1>> GetByQueryFunc, Expression<Func<T, PKType>> PKPath)
     where T1 : ModelBase
        {
  
            if (localVariable.isLoaded) return localVariable.Value;
            localVariable = GetByNHibernateRelationProprty_LoadableVar<T1>(relexp);
            if (localVariable.isLoaded ) return localVariable.Value;
            //Retrive From Db
            dynamic obj = this;
            PKType pk = PKPath.Compile()(obj);

            localVariable .Value = GetByQueryFunc(pk);
            if (localVariable.Value == null) localVariable.Value = new List<T1>();
            localVariable.isLoaded = true;
            return localVariable.Value;
        }



        public virtual IList<ICriterion> PrimaryKeyCriterion(INHibernateEntity Obj)
        {
            return new List<ICriterion>();
        }

        public virtual IRERP_SM_DataSource MyCustomDataSource(IRERPProfile Profile)
        {
            return null;
        }
        public virtual IRERP_SM_DataSource MyCustomDataSource<T1>(IRERPProfile Profile, Expression<Func<T, IList<T1>>> Member)
        {
            return null;
                
        }
        public override FunctionResult<IEnumerable<string>> SerializeToJSON(string Profile)
        {
            List<string> rtnparts = new List<string>();
            
            IRERPProfile _Profile = IRERPProfile.Unknown;
            if (Profile == null || Profile == "")

                _Profile = this.Profile;
            else
                _Profile = IRERPApplicationUtilities.GetProfileFromString(Profile);
            //generate specific Datasource
            IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(this.GetType(), _Profile);
            foreach (var field in ds.fields)
            {
                //Get FieldName
                var PropertyName = field.name;
                
                var value = IRERPApplicationUtilities.GetProperty(this, PropertyName.FromClientDsFieldName() /* .Replace("___",".")*/);
                rtnparts.Add(PropertyName + ":" + IRERPApplicationUtilities.ToJson(value));
            }
            return new FunctionResult<IEnumerable<string>>()
            {
                Result = true,
                ResultValue = rtnparts.AsEnumerable()

            };
        }
        public override ICriterion GetCritertion(MsdCriteria crit)
        {
            ICriterion rtn = null;
            if(crit.Operator== MsdCriteriaOperator.not || crit.Operator == MsdCriteriaOperator.and || crit.Operator== MsdCriteriaOperator.or)
                {
                    IList<NHibernate.Criterion.ICriterion> parts = new List<NHibernate.Criterion.ICriterion>();
                    if (crit.criteria != null)
                        crit.criteria.ToList().ForEach(x => parts.Add(
                                                        GetCritertion(x)));
                    if (crit.Operator == MsdCriteriaOperator.and)
                        if (parts.Count > 1)
                        {
                            rtn = NHibernate.Criterion.Restrictions.And(parts[0], parts[1]);
                            for (int i = 2; i < parts.Count; i++)
                                rtn = NHibernate.Criterion.Restrictions.And(rtn, parts[i]);
                            return rtn;
                        }
                        else
                        {
                            if (parts.Count == 1) return parts[0];
                            return null;
                        }
                    if (crit.Operator == MsdCriteriaOperator.or)
                        if (parts.Count > 1)
                        {
                            rtn = NHibernate.Criterion.Restrictions.Or(parts[0], parts[1]);
                            for (int i = 2; i < parts.Count; i++)
                                rtn = NHibernate.Criterion.Restrictions.Or(rtn, parts[i]);
                            return rtn;
                        }
                        else
                        {
                            if (parts.Count == 1) return parts[0];
                            return null;
                        }
                    if (crit.Operator == MsdCriteriaOperator.not)
                        if (parts.Count > 1)
                        {
                            rtn = NHibernate.Criterion.Restrictions.And(parts[0], parts[1]);
                            for (int i = 2; i < parts.Count; i++)
                                rtn = NHibernate.Criterion.Restrictions.And(rtn, parts[i]);
                            return NHibernate.Criterion.Restrictions.Not(rtn);
                        }
                        else
                        {
                            if (parts.Count == 1) return NHibernate.Criterion.Restrictions.Not(parts[0]);
                            return null;
                        }

                }

            if (crit.PropertyName == null)
                return crit.Criterion;

            if (crit.PropertyName.IndexOf(".") > -1)
            {
                //nested Property
                string[] proppath = crit.PropertyName.Split('.');
                string[] beforelastprop = new string[proppath.Length - 1];
                Array.Copy(proppath, beforelastprop, beforelastprop.Length);
                //Get Instance Of model
                Type ModelType = IRERPApplicationUtilities.GetClassPropertyType(typeof(T), beforelastprop);

                while (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>), ModelType)) //Extract Model From IList
                    ModelType = IRERPApplicationUtilities.GetGenericTypeConstructor(ModelType, 0);

                MsdCriteria newcrit = (MsdCriteria)crit.Clone();
                newcrit.Alias = string.Join(".", beforelastprop).ToClientDsFieldName();
                newcrit.fieldName = proppath[proppath.Length - 1];
                //Check For Alias Property
                /////////////////////////////////////////////////////////
                MemberInfo meminfo = IRERPApplicationUtilities.GetClassMember(ModelType, newcrit.fieldName);
                AliasForProperty aliasforproperty = AliasForProperty.GetForSpecType(ModelType, this.Profile, meminfo);
                if (aliasforproperty != null)
                    newcrit.fieldName = aliasforproperty.PropertyPath;
                /////////////////////////////////////////////////////////
                return newcrit.ToCriterion(proptype: IRERPApplicationUtilities.GetClassPropertyType(typeof(T), crit.PropertyName));
                
            }
            else
            {
                //Check For Alias Property
                /////////////////////////////////////////////////////////
                MemberInfo meminfo=IRERPApplicationUtilities.GetClassMember(typeof(T),crit.PropertyName);
                AliasForProperty aliasforproperty = AliasForProperty.GetForSpecType<T>(this.Profile,meminfo);
                if (aliasforproperty != null)
                {
                    MsdCriteria newcrit = (MsdCriteria)crit.Clone();// To Avoid Changing fieldName
                    newcrit.fieldName = aliasforproperty.PropertyPath;
                    var proptyp =  IRERPApplicationUtilities.GetClassPropertyType(typeof(T),crit.PropertyName);
                    //crit.fieldName = aliasforproperty.PropertyPath;
                    return newcrit.ToCriterion(proptype:proptyp);
                    //return rtn;
                }

                   
                /////////////////////////////////////////////////////////
            
                return crit.ToCriterion(proptype: IRERPApplicationUtilities.GetClassPropertyType(typeof(T), crit.PropertyName));
            }
            //Get property Type :

            /*
            MSDOLD WARNING
            Type proptype = 
                IRERPApplicationUtilities
                .GetClassPropertyType(
                    typeof(T),
                    crit.PropertyName.Split('.')
                );
            return crit.ToCriterion(proptype: proptype);
            */
            //return base.GetCritertion(crit);
        }
        public override Type GetNHType(Expression<Func<T, object>> Property)
        {
            Type proptype= IRERPApplicationUtilities.GetClassPropertyType(typeof(T), _GPN(Property));
            return proptype;
        }
        public virtual void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            Dic.Keys.ToList()
                .ForEach(x =>
                    {
                        string propname = x.FromClientDsFieldName()/*.Replace("___", ".")*/;
                        if(propname==null) return;
                            //Class Property
                            Type PropertyType = IRERPApplicationUtilities.GetClassPropertyType(this.GetType(), propname);
                        if(PropertyType==null) return;

                            if (new Type[] { 
                                typeof(int),typeof(Int32),typeof(Int16),typeof(Int64),typeof(long),typeof(double),typeof(string),typeof(char),
                                typeof(DateTime),
                                typeof(int?),typeof(Int32?),typeof(Int16?),typeof(Int64?),typeof(long?),typeof(double?),typeof(char?),
                                typeof(DateTime?),typeof(Guid),typeof(Guid?),typeof(bool),typeof(bool?),typeof(Boolean),typeof(Boolean?),typeof(Single?),typeof(Single)
                            }.Contains(PropertyType))
                            {
                                //Check if property Exists
                                if(IRERPApplicationUtilities.GetClassPropertyType(this.GetType(),propname)!=null)
                                    if(((PropertyInfo)IRERPApplicationUtilities.GetClassMember(this.GetType(),propname)).CanWrite)
                                        MsdLib.CSharp.Utils.AppUtils.ResumeNext(
                                            ()=>
                                             IRERPApplicationUtilities.SetProperty(this, propname, IRERPApplicationUtilities.GetObjectFromString(PropertyType, Dic[x]))
                                );
                            }
                            else if (PropertyType.IsSubclassOf(typeof(Enum)))
                            {
                                if (IRERPApplicationUtilities.GetClassPropertyType(this.GetType(), propname) != null)
                                    if (((PropertyInfo)IRERPApplicationUtilities.GetClassMember(this.GetType(), propname)).CanWrite)
                                        MsdLib.CSharp.Utils.AppUtils.ResumeNext(
                                            () =>
                                             IRERPApplicationUtilities.SetProperty(this, propname, IRERPApplicationUtilities.GetObjectFromString(PropertyType, Dic[x]))
                                );
                            }
                            
                    }
            );
        }
        public override string this[string columnName]
        {
            get
            {
                string rtn = base[columnName];
                if (rtn != null)
                    return rtn;
                //Check Validates Defined in Mappings
                var columnMemberInfo = IRERPApplicationUtilities.GetClassMember(typeof(T), columnName);
                var columnType = IRERPApplicationUtilities.GetClassPropertyType(typeof(T), columnName);
               
                var validatordefines = IRERPApplicationUtilities.Get_ValidateDescriptors_ByModelAndProfile(typeof(T), this.Profile);
                if(validatordefines.Keys.Count>0)
                    if(validatordefines.Keys.Contains(columnMemberInfo))
                    {
                        Validate<T> vld = (Validate<T>)validatordefines[columnMemberInfo];
                        rtn  = vld.doValidate(this);
                        if (rtn != null)
                        {
                            setColumnError(columnName, rtn);
                            if(IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(ModelBase),typeof(T)))
                                setColumnError(columnName+".id",rtn);
                        }
                    }

                return rtn;
            }
        }
      
        public static implicit operator T(ModelBase<T> model)
        {
            object rtn = model;
            return (T)rtn;
        }
        public static implicit operator ModelBase<T>(T model)
        {
            ModelBase<T> rtn = model;
            return rtn;
        }
        public virtual void CompleteFileProperties()
        {
            this.GetType().GetProperties().ToList().ForEach(x => {
                if (x.PropertyType == typeof(NHComponents.IRERPFile))
                {
                    NHComponents.IRERPFile fileProperty = (NHComponents.IRERPFile)x.GetValue(this,null);
                    if (fileProperty != null)
                    {
                        fileProperty.CompleteOtherProperties();
                        x.SetValue(this, fileProperty, null);
                    }
                }
            });
        }
        public override FunctionResult<INHibernateEntity> Save(ISession session = null, ITransaction transaction = null, bool CommitTran = false)
        {
            CompleteFileProperties();
            return base.Save(session, transaction, CommitTran);
        }
        
    }
}