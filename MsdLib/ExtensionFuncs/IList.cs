using NHibernate;
using NHibernate.Engine;
using NHibernate.Persister.Entity;
using NHibernate.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MsdLib.ExtensionFuncs.IListExtension
{
   public static class IList
    {
       public static IList<T> GetRange<T>(this IList<T> list, int from, int Count)
       {
           IList<T> rtn = new List<T>();
           if (list.Count > 0)
           {
               if (list.Count > from && list.Count>= from+Count)
               {
                   for (int i = from; i <= from+Count-1; i++)
                       rtn.Add(list[i]);
               }
           }
           return rtn;

       }

    }
}
