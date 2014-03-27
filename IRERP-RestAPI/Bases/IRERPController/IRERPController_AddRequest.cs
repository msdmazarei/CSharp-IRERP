using IRERP_RestAPI.Bases.ClientEngine;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.IRERPActionResults;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.Extension.Methods;
using MsdLib.ExtentionFuncs.Strings;
using NHibernate;
namespace IRERP_RestAPI.Bases.IRERPController
{
    partial class IRERPController : Controller
    {
        public IRERPAddResponseActionResult AddMethod(AddRequest AddReq)
        {
            IRERPAddResponseActionResult rtn = null;
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
                    FunctionResult<INHibernateEntity> rtn1 = null;
                    //#region "IRERPVList_ParentChildSpec"
                    //if (
                    //        IRERPApplicationUtilities.IsSubclassOfRawGeneric(
                    //        typeof(IRERPVList_ParentChildSpec<,,>), membervalue.GetType())
                    //    )
                    //{
                    //    IRERPProfile prof =
                    //        IRERPApplicationUtilities.GetMemberPropertyTypeProfile(
                    //        this.MetaModelInstance.GetType(),
                    //        this.DataSource_PassedProfile,
                    //        Members);
                    //    Type t = IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 1);//<TParent,TChild,TFilter>
                    //    IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(t, prof);
                    //    dynamic ModelInstance = IRERPApplicationUtilities.NewInstance(t);
                    //    ModelInstance.LoadFromStringDictionary(AddReq.PropertiesPassed);
                    //    ModelInstance.Profile = prof;

                    //    //Start Transaction
                    //    ISession session = ((INHibernateEntity)ModelInstance).Session;
                    //    ITransaction transaction = ((INHibernateEntity)ModelInstance).Transaction;
                    //    rtn1 = ((INHibernateEntity)ModelInstance).Save(session, transaction, false);
                    //    if (rtn1.Result)
                    //    {
                    //        rtn1 = membervalue.AddToCollection(membervalue.ParentInstance, ModelInstance);
                    //        if (rtn1.Result)
                    //        {
                    //            rtn1 = ModelInstance.RunTransaction(transaction);
                    //            if (rtn1.Result)
                    //                rtn1.ResultValue = ModelInstance;

                    //        }
                    //    }


                    //}
                    //#endregion
                    
                    #region "IRERPVList"

                    if
                        (
                        IRERPApplicationUtilities.IsSubclassOfRawGeneric
                        (
                        typeof(IRERPVList<,>),
                        membervalue.GetType()
                        )
                        )
                    {
                        bool isParentChild = IRERPApplicationUtilities.IsSubclassOfRawGeneric(
                                typeof(IRERPVList_ParentChildSpec<,,>), membervalue.GetType());
                        //Get Sent Profile
                        IRERPProfile prof =
                            IRERPApplicationUtilities.GetMemberPropertyTypeProfile(
                            this.MetaModelInstance.GetType(),
                            this.DataSource_PassedProfile,
                            Members);
                        Type t = isParentChild? 
                            IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 1): 
                            IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 0);
                        IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(t, prof);
                        dynamic ModelInstance = IRERPApplicationUtilities.NewInstance(t);
                        ModelInstance.Profile = prof;
                        if (isParentChild)
                        {
                            //Try To Load Object From DB if Exists in Db
                            //In Many-To-Many Mode some times need to load object from db
                            //Primary Values
                            Dictionary<string, object> primarykeyvalues = new Dictionary<string, object>();
                            ds.fields.ToList().ForEach(x =>
                            {
                                if (x.primaryKey) primarykeyvalues.Add(
                                    x.name,
                                    IRERPApplicationUtilities.GetObjectFromString(
                                        IRERPApplicationUtilities.GetClassPropertyType(ModelInstance.GetType(), x.name),
                                        IRERPApplicationUtilities.GetHttpParameter(x.name)
                                ));
                            }
                            );
                            var rtn11 = ((INHibernateEntity)ModelInstance).LoadByPrimaryKeys(primarykeyvalues);
                            if (rtn11 != null)
                                ModelInstance = rtn11;

                        }
                        
                            ModelInstance.LoadFromStringDictionary(AddReq.PropertiesPassed);

                        ModelInstance.Profile = prof;
                        try
                        {
                           
                            if (isParentChild)
                            {
                                //Start Transaction
                                ISession session =DAL.Session;
                                ITransaction transaction = DAL.Transaction;
                                //rtn1 = ((INHibernateEntity)ModelInstance).Save(session, transaction, false);
                                rtn1 = ((INHibernateEntity)ModelInstance).Save(session,transaction,false);
                                if (rtn1.Result)
                                {
                                    rtn1 = membervalue.AddToCollection(membervalue.ParentInstance, ModelInstance);
                                    if (rtn1.Result)
                                    {
                                        rtn1 = ModelInstance.RunTransaction(null);
                                        if (rtn1.Result)
                                            rtn1.ResultValue = ModelInstance;

                                    }
                                }
                                

                            } else
                                ////////////////WORKFLOW
                                if(
                                    IRERPApplicationUtilities
                                    .IsSubclassOfRawGeneric(typeof(Bases.ProcessModel<,>),ModelInstance.GetType()))

                                    rtn1 = ModelInstance.ProcessSave(null, null, true);
                                else 
                                    rtn1 = ((INHibernateEntity)ModelInstance).Save(null, null, true);


                            if (rtn1.Result)
                            {
                                //On Success
                                rtn = new IRERPAddResponseActionResult(new AddResponse() { data = rtn1.ResultValue, status = 0, dataProfile = prof.ToString() });
                            }
                            else
                            {
                                //On Error
                                switch (rtn1.ErrorType)
                                {
                                   
                                        
                                    case ErrorType.ValidationError:
                                        AddResponse resp = new AddResponse();
                                        resp.status = RESTDataSource_Status.ValidationError;
                                        foreach (var field in ds.fields)
                                        {
                                            string Error = ModelInstance[field.name.FromClientDsFieldName()];
                                            if (Error != null)
                                                if (Error.Trim() != "")
                                                    if (resp.ValidationErrors.Keys.Contains(field.name))
                                                    {
                                                        //Contains
                                                        resp.ValidationErrors[field.name].Add(Error);
                                                    }
                                                    else
                                                    {
                                                        //Not Contains
                                                        resp.ValidationErrors.Add(field.name, new List<string>());
                                                        resp.ValidationErrors[field.name].Add(Error);
                                                    }
                                                    
                                        }
                                        rtn = new IRERPAddResponseActionResult(resp);
                                        break;
                                    default:
                                        rtn = new IRERPAddResponseActionResult(new AddResponse() { Error = rtn1.Error.Message, status = RESTDataSource_Status.Error, dataProfile = prof.ToString() });
                                        break;
                                }

                            }

                        }
                        catch(Exception ex)
                        {
                            rtn = new IRERPAddResponseActionResult(new AddResponse() { Error = ex.Message, status = RESTDataSource_Status.Error, dataProfile = prof.ToString() });
                            
                        }
                        return rtn;
                    }
                    #endregion
                }
            }

            return new IRERPAddResponseActionResult(null);
        }
    }
}