using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.ClientEngine
{
    public class DeleteRequest : ClientEngineDataCarrier
    {
        public virtual string dataSource { get; set; }
        public virtual isc_dataFormat isc_dataFormat { get; set; }
        public virtual string isc_metaDataPrefix { get; set; }
        public virtual string componentId { get; set; }

        Dictionary<string, string> _proppass = null;
        public virtual Dictionary<string,string>
            PropertiesPassed { get {
                if (_proppass != null) return _proppass;
                _proppass = new Dictionary<string, string>();
                System.Web.HttpContext.Current.Request.Params.AllKeys.ToList().ForEach(
                    x => _proppass.Add(x, System.Web.HttpContext.Current.Request.Params[x]
                        )
                        );
                return _proppass;
            }
            }

        public DeleteRequest()
        {
            //AddRequest rtn = new AddRequest();
            isc_metaDataPrefix = IRERPApplicationUtilities.GetHttpParameter("isc_metaDataPrefix");
            dataSource = IRERPApplicationUtilities.GetHttpParameter(isc_metaDataPrefix + "dataSource");

            isc_dataFormat =
                IRERPApplicationUtilities.GetHttpParameter("isc_dataFormat") == isc_dataFormat.json.ToString()
                ? isc_dataFormat.json : isc_dataFormat.xml;
            componentId = IRERPApplicationUtilities.GetHttpParameter(isc_dataFormat + "componentId");
        }
        public static DeleteRequest GetRequest()
        {
            return new DeleteRequest();
        }
    }
}