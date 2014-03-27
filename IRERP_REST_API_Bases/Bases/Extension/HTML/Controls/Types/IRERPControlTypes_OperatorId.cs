using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_OperatorId
    {
        equals, //	exactly equal to
        notEqual, //	not equal to
        iEquals,//	exactly equal to, if case is disregarded
        iNotEqual,//	not equal to, if case is disregarded
        greaterThan,//	Greater than
        lessThan,//	Less than
        greaterOrEqual,//	Greater than or equal to
        lessOrEqual,//	Less than or equal to
        contains,//	Contains as sub-string (match case)
        startsWith,//	Starts with (match case)
        endsWith,//	Ends with (match case)
        iContains,//	Contains as sub-string (case insensitive)
        iStartsWith,//	Starts with (case insensitive)
        iEndsWith//	Ends with (case insensitive)

    }
}