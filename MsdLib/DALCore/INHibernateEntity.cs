using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.BLLCore;

namespace MsdLib.CSharp.DALCore
{
    public interface INHibernateEntity : IMsdCore
    {
        ITransaction Transaction { get; set; }
        ISession Session { get; set; }
        FunctionResult<INHibernateEntity> Get(INHibernateEntity Obj);
        FunctionResult<INHibernateEntity> Save(ISession session, ITransaction transaction, Boolean CommitTransaction);
        FunctionResult<INHibernateEntity> Remove(INHibernateEntity Obj, Boolean CommitTransaction);

        FunctionResult<IList<T>> FetchList<T>(int startRow, int EndRow, IList<ICriterion> Criterias, IList<OrderBy> Orders);

        FunctionResult<IEnumerable<String>> SerializeToJSON(string Profile);
        FunctionResult<IEnumerable<String>> DeSerializeFromJSON(string Profile);
        IList<INHibernateEntity> GetSampleList();
        INHibernateEntity GetSampleObject();
        Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath);
        INHibernateEntity LoadByPrimaryKeys(Dictionary<string,object> primarykeys_value);
    }
}
