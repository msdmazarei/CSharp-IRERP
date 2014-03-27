using NHibernate.Dialect;
using NHibernate.Dialect.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.DALCore.SqlFunctions
{
    public class MsSql2008Dialects : MsSql2008Dialect  
    {
        public MsSql2008Dialects() : base()
        {
            
            RegisterFunction("CONVERTTOSTRING", new SQLFunctionTemplate(NHibernate.NHibernateUtil.String,"convert(varchar,?1)"));
            RegisterFunction("DATETIMETOSTRING", new SQLFunctionTemplate(NHibernate.NHibernateUtil.String, "convert(varchar,?1)"));
            RegisterFunction("TOFULLPERSIANDATETIME", new SQLFunctionTemplate(NHibernate.NHibernateUtil.String, "dbo.FullPersianDate(?1)"));
            RegisterFunction("TOPUREDATE", new SQLFunctionTemplate(NHibernate.NHibernateUtil.Date, "cast(?1 as DATE)"));
        }

    }
    /*
    public class MyLinqtoHqlGeneratorsRegistry :
    NHibernate.Linq.Functions.DefaultLinqToHqlGeneratorsRegistry
    {
        public MyLinqtoHqlGeneratorsRegistry()
        {
            //this.
        //    this.Merge(new AddHoursGenerator());
        }
    }

    public class AddHoursGenerator : BaseHqlGeneratorForMethod
    {
        public AddHoursGenerator()
        {
            SupportedMethods = new[] {  
            ReflectionHelper.GetMethodDefinition<DateTime?>(d =>        
                    d.Value.AddHours((double)0))  
              };
        }

        public override HqlTreeNode BuildHql(MethodInfo method,
          System.Linq.Expressions.Expression targetObject,
          ReadOnlyCollection<System.Linq.Expressions.Expression> arguments,
          HqlTreeBuilder treeBuilder, IHqlExpressionVisitor visitor)
        {
            return treeBuilder.MethodCall("AddHours",
                    visitor.Visit(targetObject).AsExpression(),
                    visitor.Visit(arguments[0]).AsExpression()
                );
        }
    }  */
}
