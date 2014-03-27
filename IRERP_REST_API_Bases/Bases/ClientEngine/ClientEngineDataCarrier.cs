using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IRERP_RestAPI.Bases.ClientEngine
{
    public enum ClientEngineDataCarrierType
    {
        fetch,
        put,
        delete,
        post
    }
    public enum RESTDataSource_Status
    {
        Success=0,
        Error=-1,
        ValidationError=-4
    }
  
    [Serializable]
    public class ClientEngineDataCarrier
    {
        public ClientEngineDataCarrierType type { get; set; }
        public virtual string ToJson()
        {
            return "";
        }
        public static ClientEngineDataCarrier ClientRequest()
        {
            //Need Other Requests
            // This is only to test

            ClientEngineDataCarrier rtn = null;
            switch (System.Web.HttpContext.Current.Request.HttpMethod)
            {
                case "GET":
                    rtn = IRERP_RestAPI.Bases.ClientEngine.FetchRequest.GetRequest();
                    rtn.type = ClientEngineDataCarrierType.fetch;
                    break;
                case "POST":
                    rtn = IRERP_RestAPI.Bases.ClientEngine.AddRequest.GetRequest();
                    rtn.type = ClientEngineDataCarrierType.post;
                    break;
                case "PUT":
                    rtn = IRERP_RestAPI.Bases.ClientEngine.UpdateRequest.GetRequest();
                    rtn.type = ClientEngineDataCarrierType.put;
                    break;
                case "DELETE":
                    rtn = IRERP_RestAPI.Bases.ClientEngine.DeleteRequest.GetRequest();
                    rtn.type = ClientEngineDataCarrierType.delete;
                    break;

            }
            return rtn;
        }
    }
}