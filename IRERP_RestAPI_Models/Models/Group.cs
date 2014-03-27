using System.Collections.Generic; 
using System.Text; 
using System;
using IRERP_RestAPI.Bases; 


namespace  IRERP_RestAPI.Models  {

    public class Group : ModelBase<Group>
    {
        public Group() { }

        public virtual string GroupName { get; set; }
        public virtual string Description { get; set; }

        public virtual IList<GroupUser> _____GroupUsers { get; set; }
        
        public virtual IList<GroupUser> GroupUsers { get; set; }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.GroupUsers) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____GroupUsers), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            return base.GetAssociation(PropertyPath);
        }
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            return ModelRepositories.Group_Repository.GetGroupByID((Guid)primarykeys_value["id"]);
            // base.LoadByPrimaryKeys(primarykeys_value);
        }
    }
}
