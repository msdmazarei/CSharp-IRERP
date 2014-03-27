using System.Collections.Generic; 
using System.Text; 
using System;
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore; 


namespace  IRERP_RestAPI.Models  {

    public class MenuItem : IRERP_RestAPI.Bases.ModelBase<MenuItem>
    {
        public MenuItem()
        {
            _____GroupMenu = new List<GroupMenu>();
        }
        
        public virtual string EnName { get; set; }
        public virtual string Title { get; set; }
        public virtual bool HasChild { get; set; }
        public virtual string Description { get; set; }
        public virtual string MenuItem_Url { get; set; }
        public virtual System.Nullable<System.Guid> ParentID { get; set; }
        public virtual string MethodToCall { get; set; }

        
        public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string,object> primarykeys_value)
        {
            this.id = (Guid)primarykeys_value["id"];
            return ModelRepositories.IrerpMenu_Repository.GetMenuItemById(this.id);
        }
        IList<MenuItem> _Children = null;
        public virtual IList<MenuItem> Children
        {
            get
            {

                if (_Children == null)
                    _Children = ModelRepositories.IrerpMenu_Repository.GetByParentId((Guid)this.id);
                return _Children;
            }
            set
            {
                _Children = value;
            }
        }


        IList<MenuItem> _Childrenuser = null;
        public virtual IList<MenuItem> UserSpec_Children
        {
            get
            {

                if (_Childrenuser == null)
                    _Childrenuser = ModelRepositories.IrerpMenu_Repository.GetByParentId((Guid)this.id,InstanceStatics.LoggedUser);
                return _Childrenuser;
            }
            set
            {
                _Childrenuser = value;
            }
        }


        IList<MenuItem> _usrChildren = null;
        public virtual IList<MenuItem> usrChildren
        {
            get
            {
                if (_usrChildren == null) 
                    _usrChildren = ModelRepositories.IrerpMenu_Repository.GetByParentId((Guid)this.id, InstanceStatics.LoggedUser);
                return _Children;
            }
            set { _usrChildren = value; }

        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        public override string Error
        {
            get
            {
                return "";
            }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.GroupMenus) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____GroupMenu), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            return base.GetAssociation(PropertyPath);
        }
        public virtual IList<GroupMenu> GroupMenus { get { return _____GroupMenu; } set { _____GroupMenu = value; } }
        public virtual IList<GroupMenu> _____GroupMenu { get; set; }
        
    }
}
