using iLedge.Library35.Globalization.Attributes;
using Library35.Globalization;
using Library35.Globalization.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Library35.Helpers;
using System.Text;
using MsdLib.ExtensionFuncs.PersianDateTime;

namespace MsdLib.CSharp.Types
{
    public class PersianDate
    {
        #region CTor

        public PersianDate()
        {
        }
      
        public PersianDate(string persianDate)
        {
            string[] chunks = persianDate.Trim().Split('/', '\\', '-', ':');

            if (chunks.Count() != 3 && chunks.Count() != 7)
                throw new Exception("Invalid PersianDate Format...");

            this.Hour = 0;
            this.Minute = 0;
            this.Second = 0;
            this.Millisecond = 0;

            this.Year = GetExceptionFromStringToInt(chunks[0]);
            this.Month = GetExceptionFromStringToInt(chunks[1]);
            this.Day = GetExceptionFromStringToInt(chunks[2]);

            if (chunks.Count() == 7)
            {
                this.Hour = GetExceptionFromStringToInt(chunks[3]);
                this.Minute = GetExceptionFromStringToInt(chunks[4]);
                this.Second = GetExceptionFromStringToInt(chunks[5]);
                this.Millisecond = GetExceptionFromStringToInt(chunks[6]);
            }
        }

        public PersianDate(DateTime dateTime)
        {
            this.FormalDateTime = dateTime;
            if (dateTime < new DateTime(1753, 01, 02))
                throw new Exception("SQL Server Does Not Support Before 1753/01/02");
        }

        public PersianDate(int year, int month, int day)
            : this(year, month, day, 0, 0, 0, 0)
        {

        }

        public PersianDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
            this.Millisecond = millisecond;
        }

        #endregion

        #region Fields

        private string[] weeks = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };

        private string[] months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

        private System.Globalization.PersianCalendar persianCalendar = new PersianCalendar();

        #endregion

        #region Properties

        public static PersianDate Now
        {
            get
            {
                return new PersianDate(DateTime.Now);
            }
        }

        /// <summary>
        /// <para> Determines whether the specified date in the Persian era is a leap day.</para>
        /// <para>In Persian: روزآخراسفند</para>
        /// </summary>    
        public bool IsLeapDay
        {
            get
            {
                return persianCalendar.IsLeapDay(this.Year, this.Month, this.Day);
            }
        }

        /// <summary>
        /// <para> Determines whether the specified year in the Persian era is a leap year.</para>
        /// <para>In Persian: کبیسه</para>
        /// </summary>        
        public bool IsLeapYear
        {
            get
            {
                return persianCalendar.IsLeapYear(this.Year);
            }
        }

        /// <summary>
        /// Gets or sets equivalent to Syste.DateTime of the Persian date.
        /// </summary> 
        private DateTime _formalDateTime;
        public DateTime FormalDateTime
        {
            get
            {
                return _formalDateTime;
            }
            set
            {
                _formalDateTime = value;

                if (_formalDateTime < persianCalendar.MinSupportedDateTime || _formalDateTime > persianCalendar.MaxSupportedDateTime)
                    throw new Exception("Date can not be less that 01-01-622");
                int year = persianCalendar.GetYear(_formalDateTime);
                int month = persianCalendar.GetMonth(_formalDateTime);
                int day = persianCalendar.GetDayOfMonth(_formalDateTime);
                if (this.Year != year || this.Month != month || this.Day != day)
                {
                    this.Year = year;
                    this.Month = month;
                    this.Day = day;
                }
            }
        }

        private string _dateString;
        /// <summary>
        /// <para>Gets the Persian date as a string.</para>
        /// <para>For example: 1392/01/02.</para>
        /// </summary> 
        public string DateString
        {
            get { return _dateString; }
            private set { _dateString = value; }
        }

        private string _monthString;
        /// <summary>
        /// <para>Gets the month of the Persian Date is a native string</para>
        /// <para>For example: اردیبهشت</para>
        /// </summary> 
        public string MonthString
        {
            get { return _monthString; }
            private set { _monthString = value; }
        }

        private string _dayOfWeek;
        /// <summary>
        /// <para>Gets the day of the week of the Persian Date is a native string</para>
        /// <para>For example: جمعه</para>
        /// </summary> 
        public string DayOfWeek
        {
            get { return _dayOfWeek; }
            private set { _dayOfWeek = value; }
        }

        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                _year = value;
                SetDateTime();
            }
        }

        private int _month;
        public int Month
        {
            get { return _month; }
            set
            {
                _month = value;
                SetDateTime();
            }
        }

        private int _day;
        public int Day
        {
            get { return _day; }
            set
            {
                _day = value;
                SetDateTime();
            }
        }

        private int _hour;
        public int Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;
                SetDateTime();
            }
        }

        private int _minute;
        public int Minute
        {
            get { return _minute; }
            set
            {
                _minute = value;
                SetDateTime();
            }
        }

        private int _second;
        public int Second
        {
            get { return _second; }
            set
            {
                _second = value;
                SetDateTime();
            }
        }

        private int _millisecond;
        public int Millisecond
        {
            get { return _millisecond; }
            set
            {
                _millisecond = value;
                SetDateTime();
            }
        }

        public static PersianDate MaxValue
        {
            get
            {
                return new PersianDate((new PersianCalendar()).MaxSupportedDateTime);
            }
        }

        public static PersianDate MinValue
        {
            get
            {
                return new PersianDate((new PersianCalendar()).MinSupportedDateTime);
            }
        }



        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of days away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddDays(int days)
        {
            return new PersianDate(persianCalendar.AddDays(FormalDateTime, days));
        }

        /// <summary>
        /// <para>Returnes a PersianDate object that is offset the specified number of months away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddMonths(int months)
        {
            return new PersianDate(persianCalendar.AddMonths(FormalDateTime, months));
        }

        /// <summary>
        /// <para>Returnes a PersianDate object that is offset the specified number of years away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddYears(int years)
        {
            return new PersianDate(persianCalendar.AddYears(FormalDateTime, years));
        }

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of hours away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddHours(int hours)
        {
            return new PersianDate(persianCalendar.AddHours(FormalDateTime, hours));
        }

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of minutes away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddMinutes(int minutes)
        {
            return new PersianDate(persianCalendar.AddMinutes(FormalDateTime, minutes));
        }

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of seconds away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddSeconds(int seconds)
        {
            return new PersianDate(persianCalendar.AddSeconds(FormalDateTime, seconds));
        }

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of milliseconds away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddMilliseconds(int milliseconds)
        {
            return new PersianDate(persianCalendar.AddMilliseconds(FormalDateTime, milliseconds));
        }

        /// <summary>
        /// <para>Returnes a PersianDate that is specified number of weeks away from the specified PersianDate</para>
        /// </summary> 
        public PersianDate AddWeeks(int weeks)
        {
            return new PersianDate(persianCalendar.AddWeeks(FormalDateTime, weeks));
        }

        /// <summary>
        /// <para>Returnes a PersianDate objectthat is a new instance of PersianDate with the same values</para>
        /// </summary> 
        public PersianDate Clone()
        {
            return new PersianDate(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Millisecond);
        }

        /// <summary>
        /// Returnes a System.DateTime object equivalent to the Persian date
        /// </summary>
        /// <param name="Input">Persian year, month and day as int</param>

        public static DateTime ToDate(int year, int month, int day)
        {
            return ToDate(year, month, day, 0, 0, 0, 0);
        }
        /// <summary>
        /// Returnes a System.DateTime object equivalent to the Persian date
        /// </summary>
        /// <param name="Input">Persian year, month and day and times as int</param>
        public static DateTime ToDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            PersianDate persianDate = new PersianDate(year, month, day, hour, minute, second, millisecond);
            return persianDate.FormalDateTime;
        }

        /// <summary>
        /// Compares two instances of PersianDate and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.
        /// </summary>
        public static int Compare(PersianDate firstPersianDate, PersianDate secondPersianDate)
        {
            return DateTime.Compare(firstPersianDate.FormalDateTime, secondPersianDate.FormalDateTime);
        }

        /// <summary>
        /// Compares the value of this instance to a specified PersianDate value and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified PersianDate value.
        /// </summary>
        public int CompareTo(PersianDate persianDate)
        {
            return DateTime.Compare(this.FormalDateTime, persianDate.FormalDateTime);
        }



        /// <summary>
        /// <para>An Static method, returnes a PersianDate</para>
        /// <para>Converts a System.DateTime to PersianDate</para>
        /// </summary>
        public static PersianDate Convert(DateTime date)
        {
            return new PersianDate(date);
        }

        #endregion

        #region Private

        private int GetExceptionFromStringToInt(string number)
        {
            int convertedNumber = 0;

            if (!int.TryParse(number, out convertedNumber))
                throw new Exception("Can not convert string to PersianDate");

            return convertedNumber;
        }

        private void SetDateTime()
        {
            if (this.Day == 0 || this.Month == 0 || this.Year == 0)
                return;

            this.DateString = string.Format("{0}/{1}/{2}", this.Year.ToString().PadLeft(3, '0'), this.Month.ToString().PadLeft(2, '0'), this.Day.ToString().PadLeft(2, '0'));

            this.FormalDateTime = persianCalendar.ToDateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second, this.Millisecond);

            this.MonthString = months[this.Month - 1];

            this.DayOfWeek = weeks[(int)(this.FormalDateTime.DayOfWeek)];
        }

        #endregion


        #endregion

    }
    [Serializable]
    public class PersianDateTime : ICloneable, IComparable<PersianDateTime>, IEquatable<PersianDateTime>, IConvertible, ISerializable
    {
        public PersianDateTime()
        {

        }
        internal static PersianCalendar PersianCalendar = new PersianCalendar();
        internal PersianDateTimeData Data;

        public PersianDateTime(DateTime dateTime)
        {
            this.Data = new PersianDateTimeData();
            this.Data.Init();
            this.Data.Year = PersianCalendar.GetYear(dateTime);
            this.Data.Month = PersianCalendar.GetMonth(dateTime);
            this.Data.Day = PersianCalendar.GetDayOfMonth(dateTime);
            this.Data.Hour = PersianCalendar.GetHour(dateTime);
            this.Data.Minute = PersianCalendar.GetMinute(dateTime);
            this.Data.Second = PersianCalendar.GetSecond(dateTime);
        }

        public PersianDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            this.Data = new PersianDateTimeData();
            this.Data.Init();
            this.Data.Year = year;
            this.Data.Month = month;
            this.Data.Day = day;
            this.Data.Hour = hour;
            this.Data.Minute = minute;
            this.Data.Second = second;
        }

        public int Year
        {
            get { return this.Data.Year; }
        }

        public int Month
        {
            get { return this.Data.Month; }
        }

        public int Day
        {
            get { return this.Data.Day; }
        }

        public int Hour
        {
            get { return this.Data.Hour; }
        }

        public int Minute
        {
            get { return this.Data.Minute; }
        }

        public int Second
        {
            get { return this.Data.Second; }
        }

        public static PersianDateTime Now
        {
            get { return DateTime.Now.ToPersianDateTime(); }
        }

        public long Ticks
        {
            get { return ((DateTime)this).Ticks; }
        }

        public static ReadOnlyCollection<string> MonthNames
        {
            get
            {
                var monthNames = new List<string>
				{
					PersianMonth.Farvardin.GetItemDescription(),
					PersianMonth.Ordibehesht.GetItemDescription(),
					PersianMonth.Khordad.GetItemDescription(),
					PersianMonth.Tir.GetItemDescription(),
					PersianMonth.Mordad.GetItemDescription(),
					PersianMonth.Sharivar.GetItemDescription(),
					PersianMonth.Mehr.GetItemDescription(),
					PersianMonth.Aban.GetItemDescription(),
					PersianMonth.Azar.GetItemDescription(),
					PersianMonth.Dey.GetItemDescription(),
					PersianMonth.Bahman.GetItemDescription(),
					PersianMonth.Esfand.GetItemDescription()
				};
                return new ReadOnlyCollection<string>(monthNames);
            }
        }

        public PersianDayOfWeek DayOfWeek
        {
            get { return (PersianDayOfWeek)PersianCalendar.GetDayOfWeek(this); }
        }

        public string DayOfWeekTitle
        {
            get { return this.DayOfWeek.GetItemDescription(); }
        }

        #region ICloneable Members
        public object Clone()
        {
            return new PersianDateTime(this.Year, this.Month, this.Day, this.Hour, this.Minute, this.Second);
        }
        #endregion

        #region IComparable<PersianDateTime> Members
        public int CompareTo(PersianDateTime other)
        {
            return DateTime.Compare(this, other);
        }
        #endregion

        #region IConvertible Members
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return this;
        }

        TypeCode IConvertible.GetTypeCode()
        {
            throw new NotSupportedException();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            throw RaiseInvalidTypeCastException();
        }
        #endregion

        #region IEquatable<PersianDateTime> Members
        public bool Equals(PersianDateTime other)
        {
            return this.CompareTo(other) == 0;
        }
        #endregion

        #region ISerializable Members
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
        #endregion

        public static int Compare(string persianDateTime1, string persianDateTime2)
        {
            PersianDateTime p1, p2;
            if (!TryParsePersian(persianDateTime1, out p1))
                throw new InvalidCastException("cannot cast persianDateTime1 to PersianDateTime");
            if (!TryParsePersian(persianDateTime2, out p2))
                throw new InvalidCastException("cannot cast persianDateTime2 to PersianDateTime");
            return p1.CompareTo(p2);
        }

        public static implicit operator string(PersianDateTime persianDateTime)
        {
            return string.Format(CultureInfo.CurrentCulture,
                "{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00}",
                persianDateTime.Data.Year,
                persianDateTime.Data.Month,
                persianDateTime.Data.Day,
                persianDateTime.Data.Hour,
                persianDateTime.Data.Minute,
                persianDateTime.Data.Second);
        }

        public static implicit operator PersianDateTime(string persianDateTimeString)
        {
            return ParsePersian(persianDateTimeString);
        }

        public static implicit operator PersianDateTime(DateTime dateTime)
        {
            return dateTime.ToPersianDateTime();
        }

        public static implicit operator DateTime(PersianDateTime persiandateTime)
        {
            return PersianCalendar.ToDateTime(persiandateTime.Year,
                persiandateTime.Month,
                persiandateTime.Day,
                persiandateTime.Hour,
                persiandateTime.Minute,
                persiandateTime.Second,
                0);
        }

        public static PersianDateTime operator +(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            DateTime dateTime1 = persiandateTime1;
            DateTime dateTime2 = persiandateTime2;
            return dateTime1.Add(new TimeSpan(dateTime2.Ticks)).ToPersianDateTime();
        }

        public static PersianDateTime operator -(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            DateTime dateTime1 = persiandateTime1;
            DateTime dateTime2 = persiandateTime2;
            return dateTime1.Subtract(new TimeSpan(dateTime2.Ticks)).ToPersianDateTime();
        }

        public static bool operator ==(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1.Equals(persiandateTime2);
        }

        public static bool operator !=(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return !persiandateTime1.Equals(persiandateTime2);
        }

        public static PersianDateTime Add(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1 + persiandateTime2;
        }

        public static PersianDateTime Subtract(PersianDateTime persiandateTime1, PersianDateTime persiandateTime2)
        {
            return persiandateTime1 - persiandateTime2;
        }

        public static PersianDateTime ParsePersian(string dateTimeString)
        {
            var result = new PersianDateTime { Data = { HasDate = (dateTimeString.IndexOf("/") > 0), HasTime = (dateTimeString.IndexOf(":") > 0) } };
            if (result.Data.HasDate)
            {
                string datePart = result.Data.HasTime ? dateTimeString.Substring(0, dateTimeString.IndexOf(" ")) : dateTimeString;
                if (!int.TryParse(datePart.Substring(0, datePart.IndexOf("/")), out result.Data.Year))
                    throw new ArgumentException("not valid date", "dateTimeString");
                datePart = datePart.Remove(0, datePart.IndexOf("/") + 1);
                if (!int.TryParse(datePart.Substring(0, datePart.IndexOf("/")), out result.Data.Month))
                    throw new ArgumentException("not valid date", "dateTimeString");
                datePart = datePart.Remove(0, datePart.IndexOf("/") + 1);
                if (!int.TryParse(datePart, out result.Data.Day))
                    throw new ArgumentException("not valid date", "dateTimeString");

                if (result.Data.Year < 1300)
                    result.Data.Year += 1300;
            }
            if (result.ToString().Equals("00:00:00 0000/00/00"))
                throw new ArgumentException("not valid date", "dateTimeString");
            return result;
        }

        public static PersianDateTime ParseEnglish(string dateTimeString)
        {
            return DateTime.Parse(dateTimeString, CultureInfo.CurrentCulture).ToPersianDateTime();
        }

        public string ToString(string format)
        {
            format = format.Trim().Replace("yyyy", this.Year.ToString("0000", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("MMMM", MonthNames[this.Month - 1]);
            format = format.Trim().Replace("MM", this.Month.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("dd", this.Day.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("HH", this.Hour.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("mm", this.Minute.ToString("00", CultureInfo.CurrentCulture));
            format = format.Trim().Replace("ss", this.Second.ToString("00", CultureInfo.CurrentCulture));
            return format;
        }

        public override string ToString()
        {
            return this.ToString("HH:mm:ss yyyy/MM/dd");
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PersianDateTime))
                return false;
            var target = (PersianDateTime)obj;
            return this.CompareTo(target) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ToDateString()
        {
            return this.ToDateString('/');
        }

        public string ToDateString(char separator)
        {
            return string.Concat(this.Year.ToString("0000", CultureInfo.CurrentCulture),
                separator,
                this.Month.ToString("00", CultureInfo.CurrentCulture),
                separator,
                this.Day.ToString("00", CultureInfo.CurrentCulture));
        }

        public DateTime ToDateTime()
        {
            return this;
        }

        private static InvalidCastException RaiseInvalidTypeCastException()
        {
            return new InvalidCastException(string.Format("Unable to cast {0} to the target type", "PersianDateTime"));
        }

        public PersianDateTime Add(PersianDateTime persiandateTime)
        {
            return Add(this, persiandateTime);
        }

        public static bool TryParsePersian(string str, out PersianDateTime result)
        {
            result = Now;
            try
            {
                result = ParsePersian(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    internal static class Extensions
    {
        internal static string ParseName(this string name)
        {
            name.Replace(" ", "");
            var parserResult = new StringBuilder();
            foreach (var currChar in name)
            {
                if (!char.IsDigit(currChar) && ((currChar.ToString().CompareTo("_") == 0) || (currChar.ToString().CompareTo(currChar.ToString().ToUpper()) == 0)))
                    parserResult.Append(' ');
                parserResult.Append(currChar);
            }
            return parserResult.ToString().Trim();
        }

        internal static string GetItemDescription(this Enum value)
        {
            return value.GetItemDescription(true);
        }

        internal static string GetItemDescription(this Enum value, bool parseNameIfNoDescription)
        {
            var descriptionAttribute = value.GetItemAttribute<DescriptionAttribute>();
            return ((descriptionAttribute == null) ? value.ToString().ParseName() : descriptionAttribute.Description);
        }

        internal static TAttribute GetItemAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            if (value == null)
                return default(TAttribute);
            var attributes = (TAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(TAttribute), false);
            return ((attributes.Length > 0) ? attributes[0] : default(TAttribute));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct PersianDateTimeData
    {
        internal int Year;
        internal int Month;
        internal int Day;
        internal int Hour;
        internal int Minute;
        internal int Second;

        internal bool HasDate;
        internal bool HasTime;

        internal void Init()
        {
            this.Year = this.Month = this.Day = this.Hour = this.Minute = this.Second = -1;
            this.HasDate = true;
            this.HasTime = true;
        }
    }

    public enum PersianMonth
    {
        [LocalizedDescription(cultureName: "fa-IR", description: "فررودين")]
        [LocalizedDescription(cultureName: "en-US", description: "Farvardin")]
        Farvardin,
        [LocalizedDescription(cultureName: "fa-IR", description: "ارديبهشت")]
        [LocalizedDescription(cultureName: "en-US", description: "Ordibehesht")]
        Ordibehesht,
        [LocalizedDescription(cultureName: "fa-IR", description: "خرداد")]
        [LocalizedDescription(cultureName: "en-US", description: "Khordad")]
        Khordad,
        [LocalizedDescription(cultureName: "fa-IR", description: "تير")]
        [LocalizedDescription(cultureName: "en-US", description: "Tir")]
        Tir,
        [LocalizedDescription(cultureName: "fa-IR", description: "مرداد")]
        [LocalizedDescription(cultureName: "en-US", description: "Mordad")]
        Mordad,
        [LocalizedDescription(cultureName: "fa-IR", description: "شهريور")]
        [LocalizedDescription(cultureName: "en-US", description: "Shahrivar")]
        Sharivar,
        [LocalizedDescription(cultureName: "fa-IR", description: "مهر")]
        [LocalizedDescription(cultureName: "en-US", description: "Mehr")]
        Mehr,
        [LocalizedDescription(cultureName: "fa-IR", description: "آبان")]
        [LocalizedDescription(cultureName: "en-US", description: "Aban")]
        Aban,
        [LocalizedDescription(cultureName: "fa-IR", description: "آذر")]
        [LocalizedDescription(cultureName: "en-US", description: "Azar")]
        Azar,
        [LocalizedDescription(cultureName: "fa-IR", description: "دي")]
        [LocalizedDescription(cultureName: "en-US", description: "Dey")]
        Dey,
        [LocalizedDescription(cultureName: "fa-IR", description: "بهمن")]
        [LocalizedDescription(cultureName: "en-US", description: "Bahman")]
        Bahman,
        [LocalizedDescription(cultureName: "fa-IR", description: "اسفند")]
        [LocalizedDescription(cultureName: "en-US", description: "Esfand")]
        Esfand
    }

    public enum PersianDayOfWeek
    {
        [LocalizedDescription(cultureName: "fa-IR", description: "يکشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "YekShanbeh")]
        YekShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "دوشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "DoShanbeh")]
        DoShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "سه‏شنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "SehShanbeh")]
        SeShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "چهارشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "ChaharShanbeh")]
        ChaharShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "پنجشنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "PanjShanbeh")]
        PanjShanbeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "جمعه")]
        [LocalizedDescription(cultureName: "en-US", description: "Jomeh")]
        Jomeh,
        [LocalizedDescription(cultureName: "fa-IR", description: "شنبه")]
        [LocalizedDescription(cultureName: "en-US", description: "Shanbeh")]
        Shanbeh,
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    internal sealed class LocalizedDescriptionAttribute : Attribute
    {
        public LocalizedDescriptionAttribute(string cultureName)
            : this(cultureName, string.Empty)
        {
        }

        public LocalizedDescriptionAttribute(string cultureName, string description)
        {
            if (cultureName == null)
                throw new ArgumentNullException("cultureName");
            this.CultureName = cultureName;
            this.Description = description;
        }

        public string CultureName { get; set; }
        public string Description { get; set; }
    }
}


namespace Library35.Helpers
{
   
}

namespace Library35
{
   
}

namespace Library35.Globalization
{
    // Programmer: Mohammad
    // Description: PersianDateTime
    // Date: 1385/10/6 10:33:14 AM
  
}

namespace Library35.Globalization.DataTypes
{
 
}

namespace iLedge.Library35.Globalization.Attributes
{
   
}
