using Newtonsoft.Json;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public enum CriteriaOperators
    {
        lessThan,
        greaterThan,
        lessThanOrEqual,
        greaterThanOrEqual,
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
        isNotNull,

    }
    public class PCriteria 
    {
        public string PropertyName { get; set; }
        public CriteriaOperators Operator { get; set; }
        public string Value { get; set; }
        public string AliasBaseName { get { return IRERPORMAlias.PropertyName2AliasBase(this.PropertyName); } }


        public static PCriteria PCriteriaFromString(string str)
        {
            // String Instance:
            //	{"fieldName":"LastName","operator":"lessThan","value":"19","_constructor":"AdvancedCriteria"}
            jsonCriteria crit = JsonConvert.DeserializeObject<jsonCriteria>(str);
            PCriteria rtn = new PCriteria();

            rtn.Operator = (CriteriaOperators)Enum.Parse(typeof(CriteriaOperators), crit.Operator);
            rtn.PropertyName = crit.FieldName;
            rtn.Value = crit.Value;
            return rtn;
        }

        public ICriterion ToNICriteria(object Model , bool GenericConversion=false)
        {
                //Conversion base On model - A.B.C.D we should get Type of C and get Attributes of D
                var parts = PropertyName.Split('.');
                var TargetClassType = parts.Length > 1 ?    /*regard to above example return C*/
                    IRERPReflectorHelper.GetPropertyTypeUsingPropertyName(Model,string.Join(".",parts,0,parts.Length-1))
                    :
                    Model.GetType();

                var TargetProperty = parts.Length > 1 ? parts[parts.Length - 1] : PropertyName; //  reageds to above example is D

            //Get 





            ICriterion crit = null;

            //try To Convert PCriteria To ICriteria
            if (Model != null)
            {


            }
            else
            {
                //General Conversion
            }
            return crit;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    class jsonCriteria
    {
        [JsonProperty("fieldName")]
        public string FieldName=null;

        [JsonProperty("operator")]
        public string Operator=null;

        [JsonProperty("value")]
        public string Value=null;

    }
}