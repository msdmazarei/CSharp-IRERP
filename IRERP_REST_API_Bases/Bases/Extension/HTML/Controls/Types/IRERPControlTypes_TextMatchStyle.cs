using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
   public enum IRERPControlTypes_TextMatchStyle
    {
        exact,//	test for exact match
        substring,//	test for case-insenstive substring match
        startsWith,//test for the beginning of the value matching the search criteria
    }
}
