using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class TIRERPControlTypes_Criteria<T> : TIRERPControlTypes_Base<T>
    where T : IRERPControlTypes_Base
    {
    }
    public class IRERPControlTypes_Criteria:TIRERPControlTypes_Criteria<IRERPControlTypes_Criteria>
    {
    }
}