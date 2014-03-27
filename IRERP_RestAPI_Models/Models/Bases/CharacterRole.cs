using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class CharacterRole : IRERP_RestAPI.Bases.ModelBaseLog<CharacterRole,CharacterRoleLog>
    {
        public CharacterRole() { }
        //Fields list
        public virtual string RoleName { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual PersianDateTime PersianAddByDAte { get { PersianDateTime dt = AddByDAte; return dt; } set { AddByDAte = value; } }
        public virtual PersianDateTime PersianModifiyDate { get { PersianDateTime dt = ModifiyDate; return dt; } set { ModifiyDate = value; } }

        //LoadByPrimaryKeys
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                        && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.CharacterRole_Repository.GetCharacterRoleByID(this.id);
            }
            else
                return null;
            //save 
        }
        public override MsdLib.CSharp.BLLCore.FunctionResult<INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
        {
            if (!IsSaved)
            {
                AddBy = InstanceStatics.LoggedUser.id;
                AddByDAte = DateTime.Now;
            }
            else
            {
                ModifiedID = InstanceStatics.LoggedUser.id;
                ModifiyDate = DateTime.Now;
            }
            return base.Save(session, transaction, CommitTran);
        }
        public override CharacterRoleLog CreateLog(ModelBaseLog<CharacterRole, CharacterRoleLog> input)
        {
            CharacterRole ths = (CharacterRole)input;

            CharacterRoleLog l = new CharacterRoleLog();
            l.id = ths.id;
            l.RoleName = ths.RoleName;
            l.IsDeleted = ths.IsDeleted;
            l.Version = ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.Description = ths.Description;
            l.LogDate = DateTime.Now;
            return l;
        }
        LoadableVar<IList<RolsOfCharacter>> _RolsOfCharacter = new LoadableVar<IList<RolsOfCharacter>>();
        public virtual IList<RolsOfCharacter> _____RolsOfCharacter { get; set; }
        public virtual IList<RolsOfCharacter> RolsOfCharacter
        {
            get
            {
                IRERPVList_ParentChildSpec<CharacterRole, RolsOfCharacter, Filters.Bases.RolsOfCharacterFilter> rtn =
                     (IRERPVList_ParentChildSpec<CharacterRole, RolsOfCharacter, Filters.Bases.RolsOfCharacterFilter>)
                     LoadNHRelation<RolsOfCharacter, Guid>(
                     ref _RolsOfCharacter, x => x._____RolsOfCharacter,
                     ModelRepositories.Bases.RolsOfCharacter_Repository.GetAllRolesOfCharacterByCharacterRoleId<CharacterRole>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.CharacterRole = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _RolsOfCharacter.Value = value; _RolsOfCharacter.isLoaded = true; }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.RolsOfCharacter) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____RolsOfCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            return base.GetAssociation(PropertyPath);
        }
           public override string Error
        {
            get
            {
                if (this[_GPN(x => x.RoleName)] != null) return "ValidationError";
                return base.Error;
            }
        }
           public override string this[string columnName]
           {
               get
               {
                   if (_GPN(x => x.RoleName) == columnName)
                   {

                       if (RoleName.NotEmpty())
                       {
                           if (RoleName.Trim() != string.Empty && RoleName.Trim() != "null")
                           {
                               this.RoleName = RoleName.Trim();
                               if (!ModelRepositories.Bases.CharacterRole_Repository.GetCharacterRoleByCharacterRoleName(this))

                                   return ApplicationStatics.T("IsinDataBase");
                           }
                           else
                               if (RoleName.Trim() == "null")
                                   return "فیلد نقش شخصیت اجباری است";
                       }
                       else
                       {
                           return "فیلد نقش شخصیت اجباری است";
                       }

                   }

                   return null;
               }
           }
    }
}
