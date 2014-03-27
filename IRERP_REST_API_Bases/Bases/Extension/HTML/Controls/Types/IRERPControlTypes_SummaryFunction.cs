using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_SummaryFunction
    {
        sum,//	Iterates through the set of records, picking up and summing all numeric values for the specified field. Returns null to indicate invalid summary value if any non numeric field values are encountered.
        avg,//Iterates through the set of records, picking up all numeric values for the specified field and determining the mean value. Returns null to indicate invalid summary value if any non numeric field values are encountered.
        max,//Iterates through the set of records, picking up all values for the specified field and finding the maximum value. Handles numeric fields and date type fields only. Returns null to indicate invalid summary value if any non numeric/date field values are encountered.
        min,//	Iterates through the set of records, picking up all values for the specified field and finding the minimum value. Handles numeric fields and date type fields only. Returns null to indicate invalid summary value if any non numeric field values are encountered.
        multiplier,//Iterates through the set of records, picking up all numeric values for the specified field and multiplying them together. Returns null to indicate invalid summary value if any non numeric field values are encountered.
        count,//	Returns a numeric count of the total number of records passed in.
        title,//	Returns field.summaryValueTitle if specified, otherwise field.title


    }
}
