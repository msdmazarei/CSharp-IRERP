using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{
    public enum DSFieldType
    {
        PrimaryType,
        ModelBase 
    }
    public class DSFieldProperty : IRERPProfileBaseAttribute
    {
        public bool Hidden { get; set; }
        public bool PrimaryKey { get; set; }
        public bool Require { get; set; }
        public string rootValue { get; set; }
        public DSFieldType Type { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string valueMap { get; set; }
        public IRERPControlTypes_FieldType ClientType { get; set; }
        public virtual  string serverPropertyPath{get;set;}

        public Func<dynamic, dynamic> ConvertToDSField { get; set; }
        public Func<dynamic, dynamic> ConvertFromDSField { get; set; }

        //Conver
        public static explicit operator IRERPControlTypes_DataSourceField(DSFieldProperty dsf)
        {
               var rtnval= new IRERPControlTypes_DataSourceField();
               rtnval.name = dsf.name;
               rtnval.title = dsf.title;
               rtnval.IsInInitializeTime = true;
               rtnval.hidden = dsf.Hidden;
               rtnval.primaryKey = dsf.PrimaryKey;
               rtnval.required = dsf.Require;
               rtnval.rootValue = dsf.rootValue;
               rtnval.type = dsf.ClientType;
               rtnval.valueMap = dsf.valueMap;
               return rtnval;
        }

    }
}