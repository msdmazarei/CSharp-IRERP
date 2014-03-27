using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_TEXTAREA_WRAP
    {
        OFF,//	don't allow wrapping at all
        SOFT,//	when the entered text reaches the edge of the text area, wrap visibly but don't include line breaks in the textarea value
        HARD,//	when the entered text reaches the edge of the text area, insert a line break
    }
}