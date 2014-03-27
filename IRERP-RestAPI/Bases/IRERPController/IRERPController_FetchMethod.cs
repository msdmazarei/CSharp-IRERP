using IRERP_RestAPI.Bases.ActionFilters;
using IRERP_RestAPI.Bases.ClientEngine;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.IRERPActionResults;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.Extension.Methods;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Bases.IRERPController
{
    partial class IRERPController : Controller
    {
        public virtual List<OrderBy> GetOrders(IRERP_SM_DataSource ds,FetchRequest req)
        {
            List<OrderBy> rtn = new List<OrderBy>();
            foreach (string sort in req.SortBy)
            {
                if (sort != null)
                    if (sort.Length > 0)
                        if (sort.Substring(0, 1) == "-")
                            rtn.Add(new OrderBy() { PropertyName= sort.Substring(1,sort.Length-1), SortType= SortType.Desc });
                        else
                            rtn.Add(new OrderBy() { PropertyName=sort,SortType= SortType.Asc});
            }

            
            return rtn;
        }
        public virtual List<MsdCriteria> GetCriterias(IRERP_SM_DataSource ds,FetchRequest req)
        {
            List<MsdCriteria> rtn = new List<MsdCriteria>();
            rtn.AddRange(req.Criterias);
            if (ds.fields != null)
                ds.fields.ToList().ForEach(x => {
                    var value = IRERPApplicationUtilities.GetHttpParameter(x.name);
                    if (value != null)
                    {
                        rtn.Add(new MsdCriteria() { fieldName = x.name, @operator = MsdCriteriaOperator.equals.ToString(), value = value }); 
                    }
                        
                });
            return rtn;
        }
        public virtual IRERPFetchResponseActionResult FetchMethod(FetchRequest req) 
        {
            FetchResponse Fetch = new FetchResponse();
            if (Members.Length > 0)
            {
                var _modinst = MetaModelInstance;
                dynamic membervalue = _modinst;
                foreach (var member in Members)
                {
                    membervalue = IRERPApplicationUtilities.GetProperty(membervalue, member);
                    if (membervalue == null) break;
                }
                if (membervalue != null)
                {
                    if
                        (
                        IRERPApplicationUtilities.IsSubclassOfRawGeneric
                        (
                        typeof(IRERPVList<,>),
                        membervalue.GetType()
                        )
                        )
                    {
                        //Get Sent Profile
                        IRERPProfile prof =
                            IRERPApplicationUtilities.GetMemberPropertyTypeProfile(
                            this.MetaModelInstance.GetType(),
                            this.DataSource_PassedProfile,
                            Members);
                        Type t =null;
                         if
                        (
                        IRERPApplicationUtilities.IsSubclassOfRawGeneric
                        (
                        typeof(IRERPVList_ParentChildSpec<,,>),
                        membervalue.GetType()
                        )
                        )
                             t = IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 1);
                        else
                        t= IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 0);

                        IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(t, prof);
                        List<OrderBy> orders = GetOrders(ds, req);
                        List<MsdCriteria> criterias = GetCriterias(ds, req);

                        dynamic ClonedMemberValue = ((ICloneable)membervalue).Clone();
                        //Remove Fields that not in DS
                        criterias.ForEach(x =>
                        {
                            if (x.Operator == MsdCriteriaOperator.not ||
                                x.Operator == MsdCriteriaOperator.and ||
                                x.Operator == MsdCriteriaOperator.or)
                                return;
                            var isvalidf = (from y in ds.fields where y.name == x.fieldName select y).Count();
                            if (isvalidf < 1) criterias.Remove(x);
                        });
                        orders.ForEach(x =>
                        {
                            if ((from y in ds.fields where y.name == x.PropertyName.ToClientDsFieldName() select y).Count() < 1)
                                orders.Remove(x);
                        }
                        );
                        if (ds.fields != null)
                            ds.fields.ToList().ForEach(x =>
                            {
                                string propname = x.name.FromClientDsFieldName();
                                if (propname.IndexOf(".") > -1)
                                {
                                     //Need To Join
                                    //To Reduce Bank Traffic,
                                    //SomeTimes Need To Check That This Join is allowed By Model Or Not
                                    string[] props = propname.Split('.');

                                    string propertypath = string.Join(".", props, 0, props.Length - 1);
                                    //Some Properties has Forced Join 
                                    //Detect them  and add them to 
                                    //Get Propertypath Type 
                                    string prop = "";
                                    Type startType = IRERPApplicationUtilities.GetGenericTypeConstructor(ClonedMemberValue.GetType(), 0);
                                    foreach (var p in props)
                                    {
                                        if (prop != "") prop += "." + p; else prop = p;
                                        var proptyp = IRERPApplicationUtilities.GetClassPropertyType(startType, prop);
                                        if (!IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(ModelBase<>), proptyp))
                                            continue;
                                        var propins = IRERPApplicationUtilities.NewInstance(proptyp);
                                        List<string> additionalforcejointable = propins.ForcedJoinTables();
                                        additionalforcejointable.ForEach(q => {
                                            if (!ClonedMemberValue.Filter.AdditionalJoinTables.Contains(prop+"."+q))
                                                ClonedMemberValue.Filter.AdditionalJoinTables.Add(prop+"."+q);
                                        });
                                        
                                    }
                                    if (!ClonedMemberValue.Filter.AdditionalJoinTables.Contains(propertypath))
                                        ClonedMemberValue.Filter.AdditionalJoinTables.Add(propertypath);
                                }
                            });
                        
                        //Add Server Criterias
                        criterias.AddRange(req.ServerCriterias);
                        criterias.ForEach(x =>
                        {
                            x.ClassName = IRERPApplicationUtilities.GetGenericTypeConstructor(typeof(IRERPVList<,>), 0).FullName;
                        });
                        ClonedMemberValue.Filter.Orders.AddRange(orders);
                        ClonedMemberValue.Filter.Criterias.AddRange(criterias);
                        ClonedMemberValue.Count = -1; //Reset Counter and Force To Try Again With New Filter

                        Fetch.totalRows = ((IList)ClonedMemberValue).Count;
                        if (req.endRow == 0) req.endRow = 100;
                        if (req.endRow >= Fetch.totalRows)
                            Fetch.endRow = (int)Fetch.totalRows - 1;
                        else
                            Fetch.endRow = req.endRow;

                        Fetch.startRow = req.startRow;


                        Fetch.data = new List<INHibernateEntity>();
                        IRERPProfile memberprofile = IRERPApplicationUtilities.GetMemberPropertyTypeProfile(MetaModelInstance.GetType(), this.DataSource_PassedProfile, Members);

                        for (int i = Fetch.startRow; i <= Fetch.endRow; i++)
                        {
                            var member = ClonedMemberValue[i];
                            member.Profile = memberprofile;
                            Fetch.data.Add(member);
                        }

                    }
                    else if
                        (
                        IRERPApplicationUtilities.IsSubclassOfRawGeneric
                        (
                        typeof(List<>),
                        membervalue.GetType()
                        )
                        )
                    {
                        IList lst = membervalue;
                        Fetch.totalRows = lst.Count;
                        if (req.endRow == 0) req.endRow = 100;
                        if (req.endRow >= Fetch.totalRows)
                            Fetch.endRow = (int)Fetch.totalRows - 1;
                        else
                            Fetch.endRow = req.endRow;

                        Fetch.startRow = req.startRow;
                        Fetch.data = new List<INHibernateEntity>();
                        IRERPProfile memberprofile = IRERPApplicationUtilities.GetMemberPropertyTypeProfile(MetaModelInstance.GetType(), this.DataSource_PassedProfile, Members);
                        for (int i = Fetch.startRow; i <= Fetch.endRow; i++)
                        {
                            dynamic member = lst[i];
                            member.Profile = memberprofile;
                            Fetch.data.Add(member);
                        }
                    }
                    
                    
                }
            }
            return new IRERPFetchResponseActionResult(Fetch);
        }
    }
}