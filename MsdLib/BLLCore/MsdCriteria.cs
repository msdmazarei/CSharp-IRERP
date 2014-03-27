using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.ExtensionFuncs.PersianDateTime;
using MsdLib.Types.NH;
using MsdLib.Types;
using MsdLib.CSharp.Types;
namespace MsdLib.CSharp.BLLCore
{
    /*
     * 
     * <	lessThan
>	greaterThan
<=	lessThanOrEqual
>=	greaterThanOrEqual
someValue...someValue	betweenInclusive
!	notEqual
^	startsWith
|	endsWith
!^	notStartsWith
!@	notEndsWith
~	contains
!~	notContains
=(value1|value2)	inSet
!=(value1|value2)	notInSet
#	isNull
!#	isNotNull
==	exact match (for fields where 'contains' is the default)
=.	matches other field-name or title

     */

    public enum MsdCriteriaOperator
    {
        lessThan,
        greaterThan,
        lessThanOrEqual,
        lessOrEqual,
        greaterThanOrEqual,
        greaterOrEqual,
        betweenInclusive,
        notEqual,
        startsWith,
        endsWith,
        notStartsWith,
        notEndsWith,
        contains,
        notContains,
        inSet,
        notInSet,
        isNull,
        NotNull,
        exactmatch,
        equals,
        iContains,
        or,
        not,
        and,
        Unknown
    }
    public class MsdCriteria
    {
        public MsdCriteria()
        {
            @operator = MsdCriteriaOperator.Unknown.ToString();
            
        }
        public string getCriteriaPropName()
        {
            string CriteriaPropName = "";
            string alias = "";
                string[] propparts = PropertyName.Split('.');

                if (propparts.Length > 1)
                    alias = string.Join(".", propparts, 0, propparts.Length - 1).ToClientDsFieldName();

                if (Alias != null)
                    if (Alias.Length > 0)
                        alias = Alias;

                CriteriaPropName = alias.Length > 0 ? alias + "." + propparts[propparts.Length - 1] : PropertyName;
                return CriteriaPropName;
        }
        public virtual NHibernate.Criterion.ICriterion Criterion { get; set; }
        public virtual string fieldName { get; set; }
        string __op=null;
        public virtual string @operator { get {
            if (__op != null)
                if (__op[0] == 'i' && (!Enum.GetNames(typeof(MsdCriteriaOperator)).Contains(__op)) ) // Smart Client Send Operatoes with 'i' in their start like iEquals,iContains,iEndWith
                    return __op.Substring(1, __op.Length - 1);
            return __op; } set {
                __op = value; 
            } }
        public virtual dynamic value { get; set; }
        public virtual dynamic start { get; set; }
        public virtual dynamic end { get; set; }

        public virtual string ClassName
        {
            get;
            set;
        }
        public virtual string ClassPropertyName { get; set; }
        public virtual string PropertyName { get {
            string rtn = null;
            if (fieldName != null) 
                rtn = fieldName.Replace("___", "."); 
            return rtn; } 
        }
        public virtual MsdCriteriaOperator Operator { get {
            var strs = Enum.GetNames(typeof(MsdCriteriaOperator));
            var qw = (from x in strs where x.ToLower() == @operator.ToLower() select x).ToList()[0];

            var m = (MsdCriteriaOperator)Enum.Parse(typeof(MsdCriteriaOperator), qw);
            if (m == MsdCriteriaOperator.equals) m = MsdCriteriaOperator.exactmatch;
            if ((m == MsdCriteriaOperator.exactmatch || m == MsdCriteriaOperator.equals) && value == null) m = MsdCriteriaOperator.isNull;
            if ((m == MsdCriteriaOperator.exactmatch || m == MsdCriteriaOperator.equals) )
                if( value!=null)
                    if (((string)value).ToLower().Trim() == "null")
                        m = MsdCriteriaOperator.isNull;
            return m;
            }

            set { @operator = value.ToString(); }

        }
        public virtual string Alias { get; set; }
        public virtual MsdCriteria[] criteria { get; set; }
        public virtual string _constructor { get; set; }

        public virtual NHibernate.Criterion.ICriterion ToCriterion(string _criteriaprop= null,Type proptype=null)
        {
             NHibernate.Criterion.ICriterion rtn = null;
             if (this.Criterion != null)
                 return this.Criterion;
            ///For DBVar Proptype
            ///
            //if (MsdLib.CSharp.Utils.AppUtils.IsSubclassOfRawGeneric(typeof(CSharp.BLLCore.DBVar<>), proptype))
            //    proptype = Utils.AppUtils.GetGenericTypeConstructor(proptype, 0);
            string CriteriaPropName ="";
            string alias = "";
            if (_criteriaprop == null)
            {
                string[] propparts = PropertyName.Split('.');
                
                if (propparts.Length > 1)
                    alias = string.Join(".", propparts, 0, propparts.Length - 1).ToClientDsFieldName();
                
                if (Alias != null)
                    if (Alias.Length > 0)
                        alias = Alias;

                CriteriaPropName = alias.Length > 0 ? alias+"."+ propparts[propparts.Length - 1] : PropertyName;
            }
            else
                CriteriaPropName = _criteriaprop;

           //var critproj = NHibernate.Criterion.Projections.Alias(NHibernate.Criterion.Projections.Property("GroupName"), "GroupMenus_Group");
            object VALUE = value;
            
            if (
                proptype != null && proptype != typeof(string) && proptype != typeof(String)
                && proptype!=typeof(PersianDateTime) // PersianDateTime is string Type
              /*  && proptype != typeof(DBVar<string>) && proptype != typeof(DBVar<String>)*/
                )
            {
                VALUE = MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype,value);
            } 
            
            //General Compare
            if (Operator == MsdCriteriaOperator.NotNull || Operator == MsdCriteriaOperator.isNull)
            {
                switch (Operator)
                {
                    case MsdCriteriaOperator.NotNull:
                        rtn = NHibernate.Criterion.Restrictions.IsNotNull(CriteriaPropName);
                        break;
                    case MsdCriteriaOperator.isNull:
                        rtn = NHibernate.Criterion.Restrictions.IsNull(CriteriaPropName);
                        break;
                }
            }
            //Set Compares
            if (Operator == MsdCriteriaOperator.inSet || Operator == MsdCriteriaOperator.notInSet)
            {
                IList sets = null;
                if (proptype == typeof(string) || proptype == typeof(String))
                    sets = new List<string>();
                else
                    if (proptype == typeof(Guid))
                        sets = new List<Guid>();
                    else
                        if (proptype == typeof(Guid?))
                            sets = new List<Guid?>();
                        else
                            if (proptype == typeof(int))
                                sets = new List<int>();

                foreach(var a in (IList)VALUE)
                    sets.Add(MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype, a));
                
                rtn = NHibernate.Criterion.Restrictions.In(CriteriaPropName, sets);
                if (Operator == MsdCriteriaOperator.notInSet)
                    rtn = NHibernate.Criterion.Restrictions.Not(rtn);
                        
            }
            else
            {


                //string Compare
                #region "string Compares"
                if (proptype == typeof(string) || proptype == typeof(String))
                {
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(CriteriaPropName, "%" + VALUE);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(CriteriaPropName, "%" + VALUE + "%");
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            //rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.inSet:
                            rtn = NHibernate.Criterion.Restrictions.In(CriteriaPropName, (ICollection)VALUE);
                            break;

                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(CriteriaPropName, "%" + VALUE + "%")
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(CriteriaPropName, "%" + VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notInSet:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.In(CriteriaPropName, (ICollection)VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(CriteriaPropName, VALUE + "%")
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(CriteriaPropName, VALUE + "%");
                            break;
                    }
                }
                #endregion
                #region "PersianDateTime Compares"
                if (proptype == typeof(PersianDateTime))
                {
                    NHibernate.Criterion.IProjection projection =
                  NHibernate.Criterion.Projections.SqlFunction(
                  "TOFULLPERSIANDATETIME",
                  NHibernate.NHibernateUtil.String,
                  NHibernate.Criterion.Projections.Property(CriteriaPropName));
                    string projValue = (string)value.ToString();
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere);
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(projection, projValue);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(projection, projValue);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case  MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(projection, projValue);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(projection, projValue);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(projection, projValue);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere)
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(projection, projValue)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start)
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start);
                            break;
                    }
                }
                #endregion


                //number Compare
                #region "Numeric"
                Type[] NumericTypes = new Type[] {typeof(double),typeof(double?),typeof(int),typeof(int?),typeof(float),typeof(float?),typeof(Int64),typeof(Int64?)
                ,typeof(byte),typeof(byte?),typeof(Byte),typeof(Byte?),typeof(sbyte),typeof(sbyte?),typeof(SByte),typeof(SByte?)

            };
                if (NumericTypes.Contains(proptype))
                {
                    VALUE = MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype, value);

                    NHibernate.Criterion.IProjection projection =
                    NHibernate.Criterion.Projections.SqlFunction(
                    "CONVERTTOSTRING",
                    NHibernate.NHibernateUtil.String,
                        //NHibernate.Criterion.Projections.("varchar"),
                    NHibernate.Criterion.Projections.Property(CriteriaPropName));
                    string projValue = (string)value;
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere);
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere)
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start)
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start);
                            break;
                            
                    }

                }
                #endregion
                #region "Booleans"
                Type[] BooleanTypes = new Type[] {typeof(bool),typeof(bool?),typeof(Boolean),typeof(Boolean?)
            };
                if (BooleanTypes.Contains(proptype))
                {
                    VALUE = MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype, value);

                    NHibernate.Criterion.IProjection projection =
                    NHibernate.Criterion.Projections.SqlFunction(
                    "CONVERTTOSTRING",
                    NHibernate.NHibernateUtil.String,
                        //NHibernate.Criterion.Projections.("varchar"),
                    NHibernate.Criterion.Projections.Property(CriteriaPropName));
                    string projValue = (string)value;
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere);
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere)
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start)
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start);
                            break;
                    }

                }
                #endregion
                //Guid
                #region"Guid"
                Type[] GuidTypes = new Type[] { typeof(Guid), typeof(Guid?) };
                if (GuidTypes.Contains(proptype))
                {
                    VALUE = MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype, value);


                    NHibernate.Criterion.IProjection projection =
                    NHibernate.Criterion.Projections.SqlFunction(
                    "CONVERTTOSTRING",
                    NHibernate.NHibernateUtil.String,
                        //NHibernate.Criterion.Projections.("varchar"),
                    NHibernate.Criterion.Projections.Property(CriteriaPropName));
                    string projValue = (string)value;
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere);
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere)
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start)
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start);
                            break;
                    }
                }

                #endregion
                #region "DateTime"
                Type[] DateTimeTypes = new Type[] {
                typeof(DateTime),typeof(DateTime?)
            };
                if (DateTimeTypes.Contains(proptype))
                {
                    VALUE = MsdLib.CSharp.Utils.AppUtils.GetObjectFromString(proptype, value);

                    NHibernate.Criterion.IProjection projection =
                    NHibernate.Criterion.Projections.SqlFunction(
                    "DATETIMETOSTRING",
                    NHibernate.NHibernateUtil.String,
                        //NHibernate.Criterion.Projections.("varchar"),
                    NHibernate.Criterion.Projections.Property(CriteriaPropName));
                    string projValue = (string)value;
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.endsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End);
                            break;
                        case MsdCriteriaOperator.contains:
                        case MsdCriteriaOperator.iContains:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere);
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notContains:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Anywhere)
                                );
                            break;
                        case MsdCriteriaOperator.notEndsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.End)
                                );
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.notStartsWith:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                               NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start)
                               );
                            break;
                        case MsdCriteriaOperator.startsWith:
                            rtn = NHibernate.Criterion.Restrictions.Like(projection, projValue, NHibernate.Criterion.MatchMode.Start);
                            break;
                    }

                }

                #endregion
                //Enums
                #region "Enums"
                if (proptype.IsSubclassOf(typeof(Enum)))
                {
                    switch (Operator)
                    {
                        case MsdCriteriaOperator.equals:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.notEqual:
                            rtn = NHibernate.Criterion.Restrictions.Not(
                                NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE)
                                );
                            break;
                        case MsdCriteriaOperator.exactmatch:
                            rtn = NHibernate.Criterion.Restrictions.Eq(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThan:
                            rtn = NHibernate.Criterion.Restrictions.Gt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.greaterThanOrEqual:
                        case MsdCriteriaOperator.greaterOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Ge(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThan:
                            rtn = NHibernate.Criterion.Restrictions.Lt(CriteriaPropName, VALUE);
                            break;
                        case MsdCriteriaOperator.lessThanOrEqual:
                        case MsdCriteriaOperator.lessOrEqual:
                            rtn = NHibernate.Criterion.Restrictions.Le(CriteriaPropName, VALUE);
                            break;


                    }
                }
                #endregion
            }
            return rtn;
        }
        
        
    }
}
