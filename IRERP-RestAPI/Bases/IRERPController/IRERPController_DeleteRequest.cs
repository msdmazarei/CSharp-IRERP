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
using NHibernate;

namespace IRERP_RestAPI.Bases.IRERPController
{
	partial class IRERPController : Controller
	{
		public IRERPDeleteResponseActionResult DeleteRequest(DeleteRequest DeleteRequest)
		{
			IRERPDeleteResponseActionResult rtn = null;
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
                           IRERPApplicationUtilities.GetGenericTypeConstructor(membervalue.GetType(), 0) ;

						IRERP_SM_DataSource ds = IRERP_SM_DataSource.GetDataSource(t, prof);
						dynamic ModelInstance = IRERPApplicationUtilities.NewInstance(t);

						//Primary Values
						Dictionary<string, object> primarykeyvalues = new Dictionary<string, object>();


						ds.fields.ToList().ForEach(x =>
						{
							if (x.primaryKey) 
                                primarykeyvalues.Add(
                                        x.name,
	                                    IRERPApplicationUtilities.GetObjectFromString(
			                                IRERPApplicationUtilities.GetClassPropertyType(ModelInstance.GetType(), x.name),
			                                IRERPApplicationUtilities.GetHttpParameter(x.name)
			                            ));
						}
						);
						ModelInstance = ((INHibernateEntity)ModelInstance).LoadByPrimaryKeys(primarykeyvalues);
                        /// if Object not Exists in Bank
                        /// if Object not Exists in Bank
                        if (ModelInstance == null)
                        {
                            return new  IRERPDeleteResponseActionResult(new DeleteResponse 
                            {
                                status = RESTDataSource_Status.Error,
                                Error = "رکورد مورد نظر در بانک موجود نیست"
                            });
                        }
                        // Version Check
                        if (IRERPApplicationUtilities.GetHttpParameter("Version") != null)
                        {
                            int ModelVersion = ModelInstance.Version;
                            int SentItemVersion = int.Parse(IRERPApplicationUtilities.GetHttpParameter("Version"));
                            if (SentItemVersion != ModelVersion)
                            {
                                // Object Changed In Bank Before Your Change Occure, Refresh Record
                                return new IRERPDeleteResponseActionResult(new DeleteResponse { status = RESTDataSource_Status.Error, Error = "رکورد مورد نظر قبل از درخواست شما ویرایش شده است. رکرود خود را بروزآوری کنید" }
                                    );
                            }
                        }
                            
                            
						//ModelInstance.LoadFromStringDictionary(DeleteRequest.PropertiesPassed);
						ModelInstance.Profile = prof;
						try
						{
                            FunctionResult<INHibernateEntity> rtn1 = null;
                               if (isParentChild)
                            {
                                //Start Transaction
                                ISession session =((INHibernateEntity) ModelInstance).Session;
                                ITransaction transaction = ((INHibernateEntity) ModelInstance).Transaction;
                                rtn1 = membervalue.RemoveFromCollection(membervalue.ParentInstance, ModelInstance);
                                if (rtn1.Result)
                                    {
                                        rtn1 = ModelInstance.RunTransaction(transaction);
                                        if (rtn1.Result)
                                            rtn1.ResultValue = ModelInstance;

                                    }
                                
                                

                            } else 
                                   rtn1 = ((INHibernateEntity)ModelInstance).Remove(null,true);

							if (rtn1.Result)
							{
								//On Success
								rtn = new IRERPDeleteResponseActionResult(new DeleteResponse() { data = rtn1.ResultValue, status = 0, dataProfile = prof.ToString() });
							}
							else
							{
								//On Error
								rtn = new IRERPDeleteResponseActionResult(new DeleteResponse() { Error = rtn1.Error.Message, status = RESTDataSource_Status.Error, dataProfile = prof.ToString() });
							}

						}
						catch 
						{
						}
						return rtn;
					}
				}
			}

			return new IRERPDeleteResponseActionResult(null);
		}
	}
}