using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension
{
    public static class Collections
    {
        public static IList<T2> collect<T1, T2>(this IEnumerable<T1> src, Func<T1, T2> func)
        {
            IList<T2> rtn = new List<T2>();
            foreach (var t in src) rtn.Add(func(t));
            return rtn;
        }

        public static void each<T>(this IList<T> src, Func<T, T> func)
        {
            for (int i = 0; i < src.Count; i++) src[i] = func(src[i]);
        }

    }
}