using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.ClientEngine
{
    public class DeleteResponse:ClientEngineDataCarrier
    {
         public RESTDataSource_Status status { get; set; }
         public INHibernateEntity data { get; set; }
         public string dataProfile { get; set; }
         public string Error { get; set; }
         public DeleteResponse()
         {
            
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
            
             return "";
         }
    }
}