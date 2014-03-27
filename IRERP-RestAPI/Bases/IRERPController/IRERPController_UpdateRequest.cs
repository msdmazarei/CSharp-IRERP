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
namespace IRERP_RestAPI.Bases.IRERPController
{
    partial class IRERPController : Controller
    {
        public virtual IRERPUpdateResponseActionResult UpdateRequest(UpdateRequest UpdateRequest)
        {
            IRERPUpdateResponseActionResult rtn = null;
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
                        bool isParentChild = IRERPApplicationUtilities.IsSubclassOfRawGeneric(
                             typeof(IRERPVList_ParentChildSpec<,,>), membervalue.GetType());

                        //Get Sent Profile
                        IRERPProfile prof =
                            IRERPApplicationUtilities.GetMemberPropertyTypeProfile(
                            this.MetaModelInstance.GetType(),
                            this.DataSource_PassedProfile,
                            Members);
                        Type t = isParentChild ?
                           IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 1) :
                           IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 0);
                        IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(t, prof);

                        
                        dynamic ModelInstance = IRERPApplicationUtilities.NewInstance(t); 
                       
                        //Primary Values
                        Dictionary<string,object> primarykeyvalues = new  Dictionary<string,object>();
                         
                        
                        ds.fields.ToList().ForEach(x => {if(x.primaryKey) primarykeyvalues.Add(
                            x.name,
                                IRERPApplicationUtilities.GetObjectFromString(
                                        IRERPApplicationUtilities.GetClassPropertyType(ModelInstance.GetType(), x.name),
                                        IRERPApplicationUtilities.GetHttpParameter(x.name) 
                                        ));
                        }
                        );
                        ModelInstance = ((INHibernateEntity)ModelInstance).LoadByPrimaryKeys(primarykeyvalues);
                        /// if Object not Exists in Bank
                        if (ModelInstance == null)
                        {
                            return new IRERPUpdateResponseActionResult(new UpdateResponse() { 
                                status = RESTDataSource_Status.Error, Error = "رکورد مورد نظر یافت نشد." });
                        }
                        // Version Check
                        if (IRERPApplicationUtilities.GetHttpParameter("Version") != null)
                        {
                            long ModelVersion = ModelInstance.Version;
                            int SentItemVersion = int.Parse(IRERPApplicationUtilities.GetHttpParameter("Version"));
                            if (SentItemVersion != ModelVersion)
                            {
                                // Object Changed In Bank Before Your Change Occure, Refresh Record
                                return new IRERPUpdateResponseActionResult(new UpdateResponse(){ status= RESTDataSource_Status.Error, Error="رکورد قبل از ویرایش توسط شما در سرور تغییر کرده است. داده ی خود را بروزآوری کنید"}
                                    );
                            }
                        }
                            

                        ModelInstance.LoadFromStringDictionary(UpdateRequest.PropertiesPassed);
                        ModelInstance.Profile = prof;
                        try
                        {
                            ////////////////WORKFLOW
                            FunctionResult<INHibernateEntity> rtn1 = null;
                            if (
                                  IRERPApplicationUtilities
                                  .IsSubclassOfRawGeneric(typeof(Bases.ProcessModel<,>), ModelInstance.GetType()))

                                rtn1 = ModelInstance.ProcessSave(null, null, true);
                            else 
                                rtn1 = ((INHibernateEntity)ModelInstance).Save(DAL.Session, DAL.Transaction, true);

                            if (rtn1.Result)
                            {
                                //On Success
                                rtn = new  IRERPUpdateResponseActionResult(new UpdateResponse() { data = rtn1.ResultValue, status = 0, dataProfile = prof.ToString() });
                            }
                            else
                            {
                                //On Error
                                switch (rtn1.ErrorType)
                                {


                                    case ErrorType.ValidationError:
                                        UpdateResponse resp = new  UpdateResponse();
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
                                        rtn = new  IRERPUpdateResponseActionResult(resp);
                                        break;
                                    default:
                                        rtn = new  IRERPUpdateResponseActionResult(new UpdateResponse() { Error = rtn1.Error.Message, status = RESTDataSource_Status.Error, dataProfile = prof.ToString() });
                                        break;
                                }

                            }

                        }
                        catch (Exception ex)
                        {
                            rtn = new IRERPUpdateResponseActionResult(new UpdateResponse() { Error = ex.Message, status = RESTDataSource_Status.Error, dataProfile = prof.ToString() });
                        }
                        return rtn;
                    }
                }
            }

            return new  IRERPUpdateResponseActionResult(null);
        }
    }
}