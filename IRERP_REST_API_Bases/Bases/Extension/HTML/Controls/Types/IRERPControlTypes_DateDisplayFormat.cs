using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_DateDisplayFormat
    {
        toString,//	Default native browser 'toString()' implementation. May vary by browser.
        toLocaleString,//	Default native browser 'toLocaleString()' implementation. May vary by browser. Example: Friday, November 04, 2005 11:03:00 AM
        toUSShortDate,//	Short date in format MM/DD/YYYY.
        toUSShortDatetime,//	Short date with time in format MM/DD/YYYY HH:MM
        toEuropeanShortDate,//	Short date in format DD/MM/YYYY.
        toEuropeanShortDatetime,//	Short date with time in format DD/MM/YYYY HH:MM
        toJapanShortDate,//	Short date in format YYYY/MM/DD.
        toJapanShortDatetime,//	Short date with time in format YYYY/MM/DD HH:MM
        toSerializeableDate,//	Date in the format YYYY-MM-DD HH:MM:SS
        toDateStamp,//	Date in the format <YYYYMMDD>T<HHMMSS>Z Example: 20051104T111001Z
    }
}
