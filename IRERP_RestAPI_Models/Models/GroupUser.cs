using System.Collections.Generic;
using System.Text;
using System;
using MsdLib.CSharp.DALCore;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.CSharp.Types;
using MsdLib.CSharp.BLLCore;

namespace  IRERP_RestAPI.Models  {

    public class GroupUser : IRERP_RestAPI.Bases.ModelBase<GroupUser>
    { 
       
        public GroupUser(object[] pars)
        {
            System.Diagnostics.Trace.WriteLine("Test");
        }
        public GroupUser() { }
        //public virtual System.Guid GroupId { get; set; }
        //public virtual int UserID { get; set; }
        public virtual User _____User { get; set; }

        

        public virtual Group _____Group { get; set; }
        
        


        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            return ModelRepositories.GroupUser_Repository.GetGroupUserByID((Guid)primarykeys_value["id"]);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            //base.LoadFromStringDictionary(Dic);
            if (Dic.ContainsKey(_GPN(x => x.User.id).ToClientDsFieldName()))
            {
                try { this.User = ModelRepositories.UserRepository.GetUserById(Guid.Parse(Dic[_GPN(x => x.User.id).ToClientDsFieldName()])); }
                catch { }
            }
            if (Dic.ContainsKey(_GPN(x => x.Group.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Group = ModelRepositories.Group_Repository.GetGroupByID(Guid.Parse(Dic[_GPN(x => x.Group.id).ToClientDsFieldName()]));
                }
                catch { }
            }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.User) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____User) , NHibernate.SqlCommand.JoinType.InnerJoin, null);
            if (_GPN(x => x.Group) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Group), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            return base.GetAssociation(PropertyPath);
        }

        public virtual Group Group
        {
            get { return _____Group; }
            set { _____Group = value; }
        }
        public virtual User User
        {
            get
            {
                return _____User;
            }
            set
            {
                _____User = value;
            }
        }
        //User _user = null;
        //public virtual User User
        //{
        //    get
        //    {
        //        //
        //        if (_user == null) _user = ModelRepositories.UserRepository.GetUserById((int)UserID);
        //        if (_user == null) return new User();
        //        if (_user.id != this.id) _user = ModelRepositories.UserRepository.GetUserById((int)UserID);
        //        return _user;
        //    }
        //    set
        //    {
        //        _user = value;


        //    }
        //}

        //Group _Group = null;
        //public virtual Group Group
        //{
        //    get
        //    {
                
        //        if (_Group == null) _Group = ModelRepositories.Group_Repository.GetGroupByID((Guid)GroupId);
        //        if (_Group == null) return new Group();
        //        if (_Group.id != this.GroupId) _Group = ModelRepositories.Group_Repository.GetGroupByID((Guid)GroupId);
        //        return _Group;
        //    }
        //    set
        //    {
        //        _Group = value;


        //    }
        //}
    }
}
