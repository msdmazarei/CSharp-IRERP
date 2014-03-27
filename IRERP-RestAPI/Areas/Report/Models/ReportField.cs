using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class ReportField : ModelBase<ReportField>
    {
        public virtual string stiName { get; set; }
        public virtual string stiDisplayName { get; set; }
        public virtual string FullPath { get; set; }
        public virtual string TypeName { get; set; }
        public virtual Type Type
        {
            get { return IRERPApplicationUtilities.GetTypeFromString(TypeName); }
            set { TypeName = value.FullName; }
        }
        public virtual Report Report { get { return _____Report; } set { _____Report = value; } }
        public virtual Report _____Report { get; set; }

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (
                primarykeys_value.Keys.Contains(_GPN(x => x.id))
                )
                return ModelRepositories.Report_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);
            return base.LoadByPrimaryKeys(primarykeys_value);
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (PropertyPath == _GPN(x => x.Report))
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Report), NHibernate.SqlCommand.JoinType.InnerJoin, null);

            return base.GetAssociation(PropertyPath);
        }
    }
}