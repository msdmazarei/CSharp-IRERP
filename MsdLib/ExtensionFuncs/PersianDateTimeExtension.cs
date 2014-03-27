using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.Types;

namespace MsdLib.ExtensionFuncs.PersianDateTime
{
    public static class PersianDateTimeHelper
    {

        public static MsdLib.CSharp.Types.PersianDateTime PersianToPersianDateTime(this string persianDateTimeString)
        {
            return MsdLib.CSharp.Types.PersianDateTime.ParsePersian(persianDateTimeString);
        }

        public static MsdLib.CSharp.Types.PersianDateTime EnglishToPersianDateTime(this string englishDateTimeString)
        {
            return MsdLib.CSharp.Types.PersianDateTime.ParseEnglish(englishDateTimeString);
        }

        public static MsdLib.CSharp.Types.PersianDateTime ToPersianDateTime(this DateTime dateTime)
        {
            return new MsdLib.CSharp.Types.PersianDateTime(dateTime);
        }

        public static int GetDayOfMonth(this PersianMonth persianMonth, int year)
        {
            switch (persianMonth)
            {
                case PersianMonth.Farvardin:
                case PersianMonth.Ordibehesht:
                case PersianMonth.Khordad:
                case PersianMonth.Tir:
                case PersianMonth.Mordad:
                case PersianMonth.Sharivar:
                    return 31;
                case PersianMonth.Mehr:
                case PersianMonth.Aban:
                case PersianMonth.Azar:
                case PersianMonth.Dey:
                case PersianMonth.Bahman:
                    return 30;
                case PersianMonth.Esfand:
                    return MsdLib.CSharp.Types.PersianDateTime.PersianCalendar.IsLeapYear(year) ? 30 : 29;
            }
            return 0;
        }

        public static int GetDayOfMonth(this PersianMonth persianMonth)
        {
            switch (persianMonth)
            {
                case PersianMonth.Farvardin:
                case PersianMonth.Ordibehesht:
                case PersianMonth.Khordad:
                case PersianMonth.Tir:
                case PersianMonth.Mordad:
                case PersianMonth.Sharivar:
                    return 31;
                case PersianMonth.Mehr:
                case PersianMonth.Aban:
                case PersianMonth.Azar:
                case PersianMonth.Dey:
                case PersianMonth.Bahman:
                    return 30;
                case PersianMonth.Esfand:
                    return 29;
            }
            return 0;
        }

        public static bool IsPersianDateTime(this string s)
        {
            //TODO: تصحیح شود برای تاریخ 01/01/1390 اشتباه تبدیل می کند لذا قالب را ز این روش استفاده نکن دستی چک کنپ
            MsdLib.CSharp.Types.PersianDateTime persianDateTime;
            return MsdLib.CSharp.Types.PersianDateTime.TryParsePersian(s, out persianDateTime);
        }
    }
}
