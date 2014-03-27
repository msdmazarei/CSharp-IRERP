using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class LegalCharacterType : IRERP_RestAPI.Bases.ModelBaseLog<LegalCharacterType, LegalCharacterTypeLog>
    {
        public LegalCharacterType() { }
        //Fields list
        public virtual string Name { get; set; }
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
                return ModelRepositories.Bases.LegalCharacterType_Repository.GetLegalCharacterTypeByID(this.id);
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
        public override LegalCharacterTypeLog CreateLog(ModelBaseLog<LegalCharacterType, LegalCharacterTypeLog> input)
        {
            LegalCharacterType ths = (LegalCharacterType)input;

            LegalCharacterTypeLog l = new LegalCharacterTypeLog();
            l.id = ths.id;
            l.Name = ths.Name;
            l.Description = ths.Description;
            l.IsDeleted = ths.IsDeleted;
            l.Version = (int)ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.LogDate = DateTime.Now;
            return l;
        }


        LoadableVar<IList<LegalCharacter>> _LegalCharacter = new LoadableVar<IList<LegalCharacter>>();
        public virtual IList<LegalCharacter> _____LegalCharacter { get; set; }
        public virtual IList<LegalCharacter> LegalCharacters
        {
            get
            {
                return
                    LoadNHRelation<LegalCharacter, Guid>(ref _LegalCharacter, x => x._____LegalCharacter,
                    ModelRepositories.Bases.LegalCharacter_Repository.GetlegalCharachterByLegalCharacterTypeId<LegalCharacterType>,
                    x => x.id,
                    (x, y) => { throw new NotImplementedException(); }, (x, y) => { throw new NotImplementedException(); }
                  );
            }
            set { _LegalCharacter.Value = value; _LegalCharacter.isLoaded = true; }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.LegalCharacters) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____LegalCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            return base.GetAssociation(PropertyPath);
        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.Name)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.Name) == columnName)
                {

                    if (Name.NotEmpty())
                    {
                        if (Name.Trim() != string.Empty && Name.Trim() != "null")
                        {
                            this.Name = Name.Trim();
                            if (!ModelRepositories.Bases.LegalCharacterType_Repository.GetLegalCharacterTypeByName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (Name.Trim() == "null")
                                return "فیلد نوع اجباری است";
                    }
                    else
                    {
                        return "فیلد نوع اجباری است";
                    }

                }

                return null;
            }
        }
    }
}
