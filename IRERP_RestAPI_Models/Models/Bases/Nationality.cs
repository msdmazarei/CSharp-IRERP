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
    public class Nationality : IRERP_RestAPI.Bases.ModelBaseLog<Nationality, NationalityLog>
    {
        public Nationality() { }
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
                return ModelRepositories.Bases.Nationality_Repository.GetNationalityByID(this.id);
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
        public override NationalityLog CreateLog(ModelBaseLog<Nationality, NationalityLog> input)
        {
            NationalityLog l = new NationalityLog();
            l.id = this.id;
            l.Name = this.Name;
            l.Description = this.Description;
            l.IsDeleted = this.IsDeleted;
            l.Version = (int)this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.LogDate = DateTime.Now;
            return l;
        }


        LoadableVar<IList<Character>> _Character = new LoadableVar<IList<Character>>();
        public virtual IList<Character> _____Character { get; set; }
        public virtual IList<Character> Character
        {
            get
            {
                IRERPVList_ParentChildSpec<Nationality, Character, Filters.Bases.CharacterFilter> rtn =
                     (IRERPVList_ParentChildSpec<Nationality, Character, Filters.Bases.CharacterFilter>)
                     LoadNHRelation<Character, Guid>(
                     ref _Character, x => x._____Character,
                     ModelRepositories.Bases.Character_Repository.GetCharacterByNatinalId<Nationality>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.Nationality = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { SetRelationProperty(x => x.Character, x => x._____Character, _Character, value); }

        }



        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

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
                           
                                if (!ModelRepositories.Bases.Nationality_Repository.GetNationalityByName(this))
                                {
                                    return "در بانک اطلاعاتی موجود است";
                                }

                           

                        }
                        else
                            if (Name.Trim() == "null")
                                return "فیلد نام  اجباری است";
                    }
                    else
                    {
                        return "فیلد نام اجباری است";
                    }

                }

                return null;

            }
        }
    }
}
