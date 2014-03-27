using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class IRERPControlTypes_URL
    {
        public IRERPControlTypes_URL(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}