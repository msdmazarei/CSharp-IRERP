using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.ClientEngine
{
    
     [Serializable]
    public class AddResponse:ClientEngineDataCarrier
    {
         public RESTDataSource_Status status { get; set; }
         public INHibernateEntity data { get; set; }
         public string dataProfile { get; set; }

         public Dictionary<string, List<string>> ValidationErrors { get; set; }
         public string Error { get; set; }
         public AddResponse()
         {
             ValidationErrors = new Dictionary<string, List<string>>();
         }
         public override string ToJson()
         {
             Func<string, string> CreateErr = x => "{" + IRERPApplicationUtilities.ToJson("errorMessage") + ":" + IRERPApplicationUtilities.ToJson(x) + "}";

             if (status ==  RESTDataSource_Status.Success)
             {
                 string resp = "{" +
                            "status:" + ((int)status).ToString() + "," +
                            "data:[";
                 IList<string> datastr = new List<string>();
                 datastr.Add("{" + string.Join(",", data.SerializeToJSON(null).ResultValue) + "}");
                 resp += string.Join(",", datastr) + "]}";
                 resp = "{ response:" + resp + "}";
                 return resp;
             } else
             if (status == RESTDataSource_Status.Error)
             {
                 string resp = "{" +
                           "status:" + ((int)status).ToString() + "," +
                           "data:" + IRERPApplicationUtilities.ToJson(Error) + "}";
                 resp = "{ response:" + resp + "}";
                 return resp;
             } else 
             if (status == RESTDataSource_Status.ValidationError)
             {
                 //Validation Error


                 /*
                  *  {    "response":
                             {   "status": -4,
                                    "errors":
                                    {   "field1": [
                                        {"errorMessage": "First error on field1"},
                                        {"errorMessage": "Second error on field1"}
                                        ]
                                    }
                        }
                    }
                  * 
                  * 
                    {    "response":
                                {   "status": -4,
                                    "errors":
                                                {   "field1": {"errorMessage": "A validation error on field1"},
                                                    "field2": {"errorMessage": "A validation error on field2"}
                                                }
                                }
                    }
  
                  * */
                 string resp = "{" +
                           "status:" + ((int)status).ToString() + "," +
                           "errors:{";
                 List<string> Errors = new List<string>();
                 

                 ValidationErrors.Keys.ToList().ForEach(x => { 
                     if(ValidationErrors[x]!=null)
                         if (ValidationErrors[x].Count == 1)
                         {
                             //Simple Error Mode
                             Errors.Add(
                                 IRERPApplicationUtilities.ToJson(x) +":"+ CreateErr(ValidationErrors[x][0])
                                 );
                         }
                         else
                         {
                             //List Mode
                             List<string> FieldErrors = new List<string>();
                             foreach (var err in ValidationErrors[x])
                                 FieldErrors.Add(CreateErr(err));
                             Errors.Add(IRERPApplicationUtilities.ToJson(x) + ":[" + string.Join(",", FieldErrors) + "]");
                         }
                 });
                resp+= string.Join(",", Errors);
                 resp += "}";
                 resp = "{ response:" + resp + "}}";
                 return resp;

             }
             return "";
         }
    }
}