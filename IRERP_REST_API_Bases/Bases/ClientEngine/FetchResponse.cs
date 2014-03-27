using MsdLib.CSharp.DALCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.ClientEngine
{
 
    
    [Serializable]
    public class FetchResponse: ClientEngineDataCarrier
    {
        public int status { get; set; }

        public int startRow { get; set; }

        public int endRow { get; set; }

        public long totalRows { get; set; }

        public IList data { get; set; }
        public virtual string rawdata { get; set; }
        public string dataProfile { get; set; }

        public override string ToJson()
        {
            string resp = "{" +
                       "startRow:" + startRow.ToString() + "," +
                       "endRow:" + endRow.ToString() + "," +
                       "totalRows:" + totalRows.ToString() + "," +
                       "status:" + status.ToString() + "," +
                       "data:[";
            IList<string> datastr = new List<string>();
            if (this.totalRows > 0)
            {
                if (rawdata != null)
                    datastr.Add(rawdata);
                else 
                foreach (dynamic m1 in this.data)
                {
                    INHibernateEntity a = m1;
                    datastr.Add("{" + string.Join(",", a.SerializeToJSON(null).ResultValue) + "}");
                }
            }
            else datastr.Add("{}");
            resp += string.Join(",", datastr) + "]}";
            resp = "{ response:" + resp + "}";
            return resp;
        }
    }

   

}