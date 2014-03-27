using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_TimeDisplayFormat
    {
        toTime,//	String will display with seconds and am/pm indicator:[H]H:MM:SS am|pm.Example: 3:25:15 pm
        to24HourTime,//	String will display with seconds in 24 hour time: [H]H:MM:SS.Example: 15:25:15
        toPaddedTime,//	String will display with seconds, with a 2 digit hour and am/pm indicator: HH:MM:SS am|pmExample: 03:25:15 pm
        toPadded24HourTime,//	String will display with seconds, with a 2 digit hour in 24 hour format: HH:MM:SSExamples: 15:25:15, 03:16:45
        toShortTime,//	String will have no seconds and be in 12 hour format:[H]H:MM am|pmExample: 3:25 pm
        toShort24HourTime,//	String will have no seconds and be in 24 hour format: [H]H:MMExample:15:25
        toShortPaddedTime,//	String will have no seconds and will display a 2 digit hour, in 12 hour clock format: HH:MM am|pmExample: 03:25 pm
        toShortPadded24HourTime,//String will have no seconds and will display with a 2 digit hour in 24 hour clock format: HH:MMExamples: 15:25, 03:16
    }
}