using System.Collections.Generic;
using System.Text;
using System;
using MsdLib.CSharp.DALCore;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.CSharp.Types;
using MsdLib.CSharp.BLLCore;

namespace  IRERP_RestAPI.Models  {

    public class GroupMenu : IRERP_RestAPI.Bases.ModelBase<GroupMenu>
    {
        public GroupMenu() { }
        public virtual bool WithChildren { get; set; }

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            return ModelRepositories.GroupMenu_Repository.GetGroupMenuByID((Guid)primarykeys_value["id"]);
        }

        public override void LoadFromStringDictionary
            (Dictionary<string, string> Dic)
        {
         
            if (Dic.ContainsKey(_GPN(x => x.Menu.id).ToClientDsFieldName()))
            {
                try { this.Menu = ModelRepositories.IrerpMenu_Repository.GetMenuItemById(Guid.Parse(Dic[_GPN(x => x.Menu.id).ToClientDsFieldName()])); }
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
            base.LoadFromStringDictionary(Dic);
        }

        public virtual Group Group
        {
            get { return _____Group; }
            set { _____Group = value; }
        }
        public virtual MenuItem Menu
        {
            get
            {
                return _____MenuItem;
            }
            set
            {
                _____MenuItem = value;
            }
        }
      
        public virtual MenuItem _____MenuItem { get; set; }
        public virtual Group _____Group { get; set; }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.Menu) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MenuItem), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            if (_GPN(x => x.Group) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Group), NHibernate.SqlCommand.JoinType.InnerJoin, null);

            return base.GetAssociation(PropertyPath);
        }
    }
}
