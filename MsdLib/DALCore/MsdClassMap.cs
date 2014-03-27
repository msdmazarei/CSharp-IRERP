using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using System.Linq.Expressions;
namespace MsdLib.CSharp.DALCore
{
    public class MsdClassMap<T> : ClassMap<T>
        where T : ModelBase
        
    {
      
        public string _GPN(Expression<Func<T,object>> exp,bool cancelindex=true)
        {
            return MsdLib.CSharp.Utils.AppUtils.GPN<T>(exp, cancelindex);
        }
    }
}
