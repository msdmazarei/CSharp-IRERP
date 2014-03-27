using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.ExtentionFuncs.Strings
{
    public static class StringExtension
    {
        public static string ToNumberFormatIn3Parts(this string s,string Spliter)
        {
            string input = s;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 3 == 0 && i!=0)
                    sb.Insert(0,(Spliter));
                sb.Insert(0,input[input.Length-1- i]);
            }
            string formatted = sb.ToString();
            return formatted;

        }
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = s.Length; i > 0; i -= partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public static bool NotEmpty(this string str)
        {
            return !(string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str));
        }
        public static string ToAliasName(this string str)
        {
            if (str != null)
                return str.Replace(".", "___");
            else
                return str;
        }
        public static string ToClientDsFieldName(this string str)
        {
            if (str != null)
                return str.Replace(".", "___");
            else
                return str;
        }
        public static string FromAliasName(this string str)
        {
            if (str != null)
                return str.Replace("___", ".");
            else
                return str;

        }
        public static string FromClientDsFieldName(this string str)
        {
            if (str != null)
                return str.Replace("___", ".");
            else
                return str;

        }

    }
}
