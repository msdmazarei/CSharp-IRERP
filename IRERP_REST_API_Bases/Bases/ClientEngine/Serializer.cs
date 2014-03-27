using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.IO;

namespace IRERP_RestAPI.Bases.ClientEngine
{
    public class IRERPSerializerFormatter : MediaTypeFormatter
    {
        public IRERPSerializerFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }
        public override bool CanReadType(Type type)
        {
            if (type == typeof(ClientEngineDataCarrier))
                return true;
            else
                return false;

        }
        public override bool CanWriteType(Type type)
        {
            if (type == typeof(ClientEngineDataCarrier))
                return true;
            else
                return false;

        }


        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, System.Net.TransportContext transportContext)
        {
            var task = Task.Factory.StartNew(() =>
            {

                if (value.GetType() == typeof(FetchResponse))
                {
                    FetchResponse tmp = (FetchResponse) value;
                    string resp = "{" +
                        "startRow:" + tmp.startRow.ToString() + "," +
                        "endRow:" + tmp.endRow.ToString() + "," +
                        "totalRows:" + tmp.totalRows.ToString() + "," +
                        "status:" + tmp.status.ToString() + "," +
                        "data:[";
                    IList<string> data = new List<string>();

                    foreach (dynamic m1 in tmp.data)
                    {
                        data.Add("{"+string.Join(",", m1.SerializeToJSON(tmp.dataProfile).ResultValue)+"}");
                    }
                    resp += string.Join(",", data) + "]}";
                    resp = "{ response:" + resp + "}";
                    byte[] buf = System.Text.Encoding.UTF8.GetBytes(resp);
                    writeStream.Write(buf, 0, buf.Length);
                    writeStream.Flush();
                            
                }
            });

            return task;
            //return base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            return base.ReadFromStreamAsync(type, readStream, content, formatterLogger);
        }

        
    }
}