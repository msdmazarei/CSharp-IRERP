using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.CSharp.BLLCore;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Bases.ClientEngine
{
    public enum operationType
    {
        fetch
    }
    public enum isc_dataFormat
    {
        json,
        xml
    }

    public class FetchRequest : ClientEngineDataCarrier
    {
        public FetchRequest()
        {
            ServerCriterias = new List<MsdCriteria>();
            Criterias = new List<MsdCriteria>();
            SortBy = new List<string>();
        }
        public virtual string dataSource { get; set; }
        public virtual operationType operationType { get; set; }
        public virtual isc_dataFormat isc_dataFormat { get; set; }
        public virtual string isc_metaDataPrefix { get; set; }
        public virtual int startRow { get; set; }
        public virtual int endRow { get; set; }
        public virtual List<string> SortBy {get;set;}
        public virtual List<MsdCriteria> Criterias { get; set; }
        public virtual List<MsdCriteria> ServerCriterias { get; set; }

        public virtual MsdCriteria GetCriteriaByPropName(string propertyname)
        {
            var q = (from x in Criterias where x.PropertyName == propertyname select x).ToList();
            if (q.Count > 0) return q[0];
            return null;
        }
        public static FetchRequest GetRequest()
        {
            FetchRequest rtn = new FetchRequest();
            rtn.isc_metaDataPrefix = IRERPApplicationUtilities.GetHttpParameter("isc_metaDataPrefix");
            rtn.dataSource = IRERPApplicationUtilities.GetHttpParameter(rtn.isc_metaDataPrefix + "dataSource");
            
            rtn.isc_dataFormat =
                IRERPApplicationUtilities.GetHttpParameter("isc_dataFormat") == isc_dataFormat.json.ToString()
                ? isc_dataFormat.json : isc_dataFormat.xml;
            int _var;
            int.TryParse(IRERPApplicationUtilities.GetHttpParameter(rtn.isc_metaDataPrefix + "startRow"), out _var);
            rtn.startRow = _var;

            int.TryParse(IRERPApplicationUtilities.GetHttpParameter(rtn.isc_metaDataPrefix + "endRow"), out _var);
            rtn.endRow = _var;

            
            var _opty = IRERPApplicationUtilities.GetHttpParameter(rtn.isc_metaDataPrefix + "operationType");
            if (_opty == "fetch") rtn.operationType = operationType.fetch;

            rtn.SortBy = new List<string>();
            string _sortby = IRERPApplicationUtilities.GetHttpParameter(rtn.isc_metaDataPrefix + "sortBy");
            if (_sortby != null)
                if (_sortby.Length > 0)
                {
                    _sortby = _sortby.FromClientDsFieldName()/*.Replace("___",".")*/;
                    rtn.SortBy.AddRange(_sortby.Split(','));
                }

            string _crit = IRERPApplicationUtilities.GetHttpParameter("criteria");
            // Pattern is : {fieldname:"jhjhjk",operator:"kjhjk",value:"jh"},{fieldname:"nnn",....}
             
            if(_crit!=null)
                if (_crit.Length > 0)
                {
                    rtn.Criterias.AddRange(
                        Newtonsoft.Json.JsonConvert.DeserializeObject<MsdCriteria[]>("[" + _crit + "]")
                        );
                    string _operator = IRERPApplicationUtilities.GetHttpParameter("operator") ?? "and";
                    if (_operator == "or")
                    {
                        var totcrit = new MsdCriteria()
                        {
                             Operator = MsdCriteriaOperator.or,
                             criteria = rtn.Criterias.ToArray()
                        };
                        rtn.Criterias = new List<MsdCriteria>();
                        rtn.Criterias.Add( totcrit);
                    }
                }

            //Get Other Criterias
            string[] knownkeys = new string[]{
                "isc_metaDataPrefix",rtn.isc_metaDataPrefix + "dataSource",
                "isc_dataFormat",
                rtn.isc_metaDataPrefix + "startRow",
                rtn.isc_metaDataPrefix + "endRow",
                rtn.isc_metaDataPrefix + "operationType",
                rtn.isc_metaDataPrefix + "sortBy",
                "criteria"
            };
            var otherkeys = (from x in System.Web.HttpContext.Current.Request.Params.AllKeys where !knownkeys.Contains(x) select x).ToList();
            //We Consider that othere keys criterias 
        /*    foreach (var key in otherkeys)
                rtn.Criterias.Add(new MsdCriteria() { fieldName = key, value = System.Web.HttpContext.Current.Request.Params[key],@operator="contains" });
            */
            return rtn;
        }
    }
}