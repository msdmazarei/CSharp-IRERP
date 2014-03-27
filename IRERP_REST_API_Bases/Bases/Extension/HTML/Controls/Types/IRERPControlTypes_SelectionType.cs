using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_SelectionType
    {
        button,//	object moves to "down" state temporarily (normal button)
        checkbox,//object remains in "down" state until clicked again (checkbox)
        radio,//object moves to "down" state, causing another object to go up (radio)
    }
}