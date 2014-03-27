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
    public class RolsOfCharacter : IRERP_RestAPI.Bases.ModelBaseLog<RolsOfCharacter,RolsOfCharacterLog>
    {
        public RolsOfCharacter() { }
        //Fields list
        //public virtual System.Guid CharacterID { get; set; }
        //public virtual System.Guid RoleID { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }

        public virtual PersianDateTime PersianAddByDAte { get { PersianDateTime dt = AddByDAte; return dt; } set { AddByDAte = value; } }
        public virtual PersianDateTime PersianModifiyDate { get { PersianDateTime dt = ModifiyDate; return dt; } set { ModifiyDate = value; } }

        //LoadByPrimaryKeys
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                        && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.RolsOfCharacter_Repository.GetRolsOfCharacterByID(this.id);
            }
            else
                return null;
            //save 
        }
        //save 
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
        LoadableVar<Character> _Character = new LoadableVar<Character>();
        public virtual Character _____Character { get; set; }
        public virtual Character Character
        {
            get
            {
                return LoadNHRelation<Character, Guid>
                    (ref _Character,
                    x => x._____Character,
                    ModelRepositories.Bases.Character_Repository.GetCharacterByID,
                    x => x._____Character.id);
            }
           
                            set { SetRelationProperty(x => x.Character, x => x._____Character, _Character, value); }

          
          
        }
        LoadableVar<CharacterRole> _CharacterRole = new LoadableVar<CharacterRole>();
        public virtual CharacterRole _____CharacterRole { get; set; }
        public virtual CharacterRole CharacterRole
        {
            get
            {
                return LoadNHRelation<CharacterRole, Guid>
                    (ref _CharacterRole,
                    x => x._____CharacterRole,
                    ModelRepositories.Bases.CharacterRole_Repository.GetCharacterRoleByID,
                    x => x._____CharacterRole.id);
            }
            set
            {
                SetRelationProperty(x => x.CharacterRole, x => x._____CharacterRole, _Character, value);
            }
        }

        public override RolsOfCharacterLog CreateLog(ModelBaseLog<RolsOfCharacter, RolsOfCharacterLog> input)
        {
            RolsOfCharacter ths = (RolsOfCharacter)input;

            RolsOfCharacterLog l = new RolsOfCharacterLog();
            l.id = ths.id;
            l.CharacterID = ths.Character != null ? ths.Character.id : Guid.Empty;
            l.RoleID = ths.CharacterRole.id;
            l.Description = ths.Description;
            l.IsDeleted = ths.IsDeleted;
            l.Version = ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.LogDate = DateTime.Now;
        
            return l;
        }


        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


            if (_GPN(x => x.CharacterRole) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____CharacterRole), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x.Character.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Character = ModelRepositories.Bases.Character_Repository.GetCharacterByID(Guid.Parse(Dic[_GPN(x => x.Character.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Character).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
           
            if (Dic.ContainsKey(_GPN(x => x.CharacterRole.id).ToClientDsFieldName()))
            {
                try
                {
                    this.CharacterRole = ModelRepositories.Bases.CharacterRole_Repository.GetCharacterRoleByID(Guid.Parse(Dic[_GPN(x => x.CharacterRole.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.CharacterRole).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            base.LoadFromStringDictionary(Dic);

        }
        public override string Error
        {
            get
            {

                if (this[_GPN(x => x.CharacterRole)] != null) return "ValidationError";

                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {

                if (_GPN(x => x.CharacterRole) == columnName
                || _GPN(x => x.CharacterRole.id) == columnName)
                {
                    if (CharacterRole == null)

                        return ApplicationStatics.T("RolsOfCharacterCharacterRoleValidation");
                    if (CharacterRole.id == null)

                        return ApplicationStatics.T("RolsOfCharacterCharacterRoleValidation");
                    
                        
                }
                return null;
            }
        }  
    }
}
