using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IRERP_RestAPI.Bases;
using NHibernate.Criterion;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.ClientEngine;
using IRERP_RestAPI.Bases.Extension;
using System.Web;
using MsdLib.CSharp.BLLCore;
using System.Collections;
namespace IRERP_RestAPI.Controllers
{
    public class IRERPGeneralEntityController : ApiController
    {

        public IRERPGeneralEntityController()
            : base()
        {
            PassedParameters = new Dictionary<string, string>();
            MultiInstancePassedParameters = new Dictionary<string, List<string>>();
            HttpInfoParameters = new Dictionary<Bases.Informational_HTTP_Parameter, string>();
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.isc_dataFormat, "isc_dataFormat");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.isc_metaDataPrefix, "isc_metaDataPrefix");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.OperationType, "operationType");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.SortBy, "sortBy");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.StartRow, "startRow");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.EndRow, "endRow");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.DataSource, "dataSource");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.ComponentId, "componentId");
            HttpInfoParameters.Add(Bases.Informational_HTTP_Parameter.criteria, "criteria");

            

        }
        string baseurl = "/IRERP-api/DS-General/";
        protected string PassedProfile
        {
            get
            {
                int baseurlindex=this.Url.Request.RequestUri.AbsolutePath.IndexOf(baseurl) ;
                if (baseurlindex == 0)
                {
                    try { return this.Url.Request.RequestUri.Segments[3].Replace("/",""); }
                    catch { return ""; }
                }
                else return "";
            }
        }

        protected string PassedModel
        {
            get
            {
                int baseurlindex = this.Url.Request.RequestUri.AbsolutePath.IndexOf(baseurl);
                if (baseurlindex == 0)
                {
                    try { return this.Url.Request.RequestUri.Segments[4].Replace("/",""); }
                    catch { return ""; }
                }
                else return "";
            }
        }


        protected string PassedProperty
        {
            get
            {
                int baseurlindex = this.Url.Request.RequestUri.AbsolutePath.IndexOf(baseurl);
                if (baseurlindex == 0)
                {
                    try { return this.Url.Request.RequestUri.Segments[5].Replace("/",""); }
                    catch { return ""; }
                }
                else return "";
            }
        }

        protected Dictionary<string, string> PassedParameters { get; set; }
        protected Dictionary<string, List<string>> MultiInstancePassedParameters { get; set; } // Like sortBy or criteria

        protected Dictionary<Bases.Informational_HTTP_Parameter, string> HttpInfoParameters { get; set; }
        /**
         * Returns string or List<strin>
         */
        protected dynamic GetParameterValue(string ParameterName)
        {
            if (PassedParameters.Keys.Contains(ParameterName))
            {
                return PassedParameters[ParameterName];
            }
            if (MultiInstancePassedParameters.Keys.Contains(ParameterName))
                return MultiInstancePassedParameters[ParameterName];

            string[] param = this.ControllerContext.Request.RequestUri.Query.Replace("?","").Split(new string[] { "&" },StringSplitOptions.None);
            param=param.collect<string, string>(x => HttpUtility.UrlDecode(x)).ToArray();
            foreach (string p in param)
            {
                string[] tmp1 = p.Split(new string[] { "=" }, StringSplitOptions.None);
                if ((!PassedParameters.Keys.Contains(tmp1[0]) && !MultiInstancePassedParameters.Keys.Contains(tmp1[0])))
                    PassedParameters.Add(tmp1[0], tmp1[1]);
                else
                {
                    //Multi Instance Variable
                    if (MultiInstancePassedParameters.Keys.Contains(tmp1[0]))
                    {
                        MultiInstancePassedParameters[tmp1[0]].Add(tmp1[1]);
                    }
                    else
                    {
                        if (PassedParameters.Keys.Contains(tmp1[0]))
                            if (PassedParameters[tmp1[0]] == tmp1[1]) continue;

                        MultiInstancePassedParameters.Add(tmp1[0],new List<string>());
                        MultiInstancePassedParameters[tmp1[0]].Add(tmp1[1]);
                        MultiInstancePassedParameters[tmp1[0]].Add(PassedParameters[tmp1[0]]);
                        PassedParameters.Remove(tmp1[0]);
                    }
                }
            }

            if (!PassedParameters.Keys.Contains(ParameterName))
            {
                //Search In Post Data
            }

            if (PassedParameters.Keys.Contains(ParameterName))
                return PassedParameters[ParameterName];
            else if (MultiInstancePassedParameters.Keys.Contains(ParameterName))
                return MultiInstancePassedParameters[ParameterName];

                return null;
        }
        protected string SendErrorToClient(PException FalseRes)
        {
            return "";
        }
        // GET api/IRERPgeneralentity

        public ClientEngineDataCarrier Get(string profile = "", string classname = "", string propname = "")
        {
            string ModelProfile = this.PassedProfile;
            string ModelName = this.PassedModel;
            string PropertyName = this.PassedProperty;
            int StartRow=0,EndRow=100;
            
            string ParametersPrefix = this.GetParameterValue(HttpInfoParameters[Bases.Informational_HTTP_Parameter.isc_metaDataPrefix]);
            
            int.TryParse(this.GetParameterValue(ParametersPrefix + HttpInfoParameters[Bases.Informational_HTTP_Parameter.StartRow]),out StartRow);
            int.TryParse(this.GetParameterValue(ParametersPrefix + HttpInfoParameters[Bases.Informational_HTTP_Parameter.EndRow]),out EndRow);
            
            List<IRERPORMAlias> Aliases = new List<IRERPORMAlias>();

            //Get Order By
            dynamic sortby = this.GetParameterValue(ParametersPrefix+HttpInfoParameters[Bases.Informational_HTTP_Parameter.SortBy]);
            
            IList<OrderBy> Orders = new List<OrderBy>();
            if (sortby!=null)
                if (sortby.GetType() == typeof(string))
                {
                    // There is only 1 field order 
                    string fieldname = sortby;
                    Orders.Add(
                        fieldname.Substring(0, 1) == "-" ?
                            new OrderBy() { PropertyName = fieldname.Substring(1, fieldname.Length), SortType = SortType.Desc }
                            :
                            new OrderBy() { PropertyName = fieldname, SortType = SortType.Asc }
                            );
                }
                else if(sortby.GetType()== typeof(List<string>))
                {
                    // There are multi field order
                    Orders = ((List<string>)sortby).collect<string, OrderBy>
                        (x => x.Substring(0, 1) == "-" ?
                            new OrderBy() { PropertyName = x.Substring(1, x.Length - 1), SortType = SortType.Desc }
                            :
                            new OrderBy() { PropertyName = x, SortType = SortType.Asc }
                            );
                }
            
            Orders.ToList<OrderBy>().ForEach(x => {
                var _t = IRERPORMAlias.GetAliasList(x.PropertyName);
                if ((bool)_t)
                {
                    List<IRERPORMAlias> PropertyAliasList = _t.ResultValue;
                    Aliases.AddRange(
                        (from k in _t.ResultValue 
                             where !(
                             from l in Aliases select l.AliasName
                             ).Contains(k.AliasName)
                         select k
                             ).ToList()
                        );
                }
            });

            //Get Criteria
            dynamic criteria = this.GetParameterValue( HttpInfoParameters[Bases.Informational_HTTP_Parameter.criteria]);
            IList<PCriteria> Criterias= new List<PCriteria>();
            if (criteria != null)
                if (criteria.GetType() == typeof(string))
                {
                    // There is only 1 field order 
                    PCriteria _tmp = PCriteria.PCriteriaFromString(criteria);
                    if(_tmp!=null) Criterias.Add(_tmp);
                }
                else if (criteria.GetType() == typeof(List<string>))
                {
                    // There are multi field order
                    Criterias = ((List<string>)criteria).collect<string, PCriteria>
                                    (x=>PCriteria.PCriteriaFromString(x));
                }


            Criterias.ToList<PCriteria>().ForEach(x =>
            {
                var _t = IRERPORMAlias.GetAliasList(x.PropertyName);
                if ((bool)_t)
                {
                    List<IRERPORMAlias> PropertyAliasList = _t.ResultValue;
                    Aliases.AddRange(
                        (from k in _t.ResultValue
                         where !(
                         from l in Aliases select l.AliasName
                         ).Contains(k.AliasName)
                         select k
                             ).ToList()
                        );
                }
            });
 

            
            
            var t = this.PassedProfile;
            var t1 = this.PassedModel;
            var t2 = this.PassedProperty;
            string Prefix = this.GetParameterValue("isc_metaDataPrefix");
           
            FunctionResult<Object> res =Bases.IRERPReflectorHelper.GetInstance(ModelName);
            dynamic Model= null;

            if (res.Result)
                Model = res.ResultValue;
            else
                SendErrorToClient(res.Error);
            

            //Get Data Form Bank
            var query = Model.Session.CreateCriteria(Model.GetType())
                .SetFirstResult(StartRow)
                .SetMaxResults(EndRow - StartRow);

            /*
            Orders
                .ToList<OrderBy>()
                .ForEach(
                x =>query.AddOrder(new 
                        Order(x.AliasBaseName,x.SortType == SortType.Asc ? true : false)
                        )
                );
            */
            Criterias.ToList<PCriteria>().ForEach(x => {
                ICriterion ic = x.ToNICriteria(Model) ;
                if (ic != null)
                    query.Add(ic);
            });

            Aliases.ForEach(x => query.CreateAlias(x.association, x.AliasName, x.JoinType));

            


            IList Results = query.List();

     
//                 .List<ModelBase>();

            //Get Total Count Of Objects 

            long DbRecordCount = Convert.ToInt64(
                                    Model.Session.CreateCriteria(Model.GetType())
                                        .SetProjection(Projections.RowCountInt64())
                                        .UniqueResult()
                                        );
            Bases.ClientEngine.FetchResponse fr = new Bases.ClientEngine.FetchResponse()
            {
                dataProfile=profile,
                startRow = StartRow,
                endRow = EndRow,
                data = Results,
                status = 0,
                totalRows=DbRecordCount
            };
            
            return fr;
            
            //return new JsonResult() { Data = "Hello World"};
            
                //return new string[] { "value1", "value2" };
        }

        // POST api/IRERPgeneralentity
        public IEnumerable<string> Post()
        {
            return null;

                
        }

        // PUT api/IRERPgeneralentity/5
        public IEnumerable<string> Put()
        {
            return null;
        }

        // DELETE api/IRERPgeneralentity/5
        public IEnumerable<string> Delete()
        {
            return null;
        }
    }
}
