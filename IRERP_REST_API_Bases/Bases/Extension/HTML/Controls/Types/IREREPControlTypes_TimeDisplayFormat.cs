using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IREREPControlTypes_TimeDisplayFormat
    {
        toTime,//String will display with seconds and am/pm indicator:[H]H:MM:SS am|pm.

        to24HourTime,//	String will display with seconds in 24 hour time: [H]H:MM:SS.

        toPaddedTime,//	String will display with seconds, with a 2 digit hour and am/pm indicator: HH:MM:SS am|pm

        toPadded24HourTime,//String will display with seconds, with a 2 digit hour in 24 hour format: HH:MM:SS

        toShortTime,//String will have no seconds and be in 12 hour format:[H]H:MM am|pm

        toShort24HourTime,//	String will have no seconds and be in 24 hour format: [H]H:MM

        toShortPaddedTime,//	String will have no seconds and will display a 2 digit hour, in 12 hour clock format: HH:MM am|pm

        toShortPadded24HourTime,//String will have no seconds and will display with a 2 digit hour in 24 hour clock format: HH:MM



    }
}
