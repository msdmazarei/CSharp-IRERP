using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using System.Linq;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.Types;

namespace IRERP_RestAPI.Models.Bases
{
    public class Charactertype : IRERP_RestAPI.Bases.ModelBaseLog<Charactertype,Charactertypelog>
    {
        //public virtual System.Guid id { get; set; }
        public virtual string Charactertypename { get; set; }
        //public virtual bool? Isdeleted { get; set; }
       // public virtual int? Version { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddBydate { get; set; }
        public virtual DateTime? Modifiydate { get; set; }
        public virtual string Description { get; set; }

        public virtual PersianDateTime PersianAddByDAte { get { PersianDateTime dt = AddBydate; return dt; } set { AddBydate = value; } }
        public virtual PersianDateTime PersianModifiyDate { get { PersianDateTime dt = Modifiydate; return dt; } set { Modifiydate = value; } }

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {

            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
            && primarykeys_value[_GPN(x => x.id)] != null)
            {
                

                this.id = (Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByID(this.id);
            }
            else
                return null;

        }
        public override MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
        {
            if (!IsSaved)
            {
                AddBy = InstanceStatics.LoggedUser.id;
                AddBydate = DateTime.Now;
            }
            else
            {
                Modifiydate = DateTime.Now;
                ModifiedID = InstanceStatics.LoggedUser.id;
            }
            return base.Save(session, transaction, CommitTran);
        }
        public override Charactertypelog CreateLog(ModelBaseLog<Charactertype, Charactertypelog> input)
        {
            Charactertype ths = (Charactertype)input;

            Charactertypelog l = new Charactertypelog();
            l.Charactertypename = ths.Charactertypename;
            l.id = id;
            l.Description = ths.Description;

            l.AddBy = ths.AddBy;
            l.AddBydate = ths.AddBydate;
            l.ModifiedID = ths.ModifiedID;
            l.Modifiydate = ths.Modifiydate;

            l.Version = (int)ths.Version;
            l.IsDeleted =ths.IsDeleted;
            l.Logdate = DateTime.Now;
        

            return l;
        }


        //LoadableVar<IList<Character>> _Character = new LoadableVar<IList<Character>>();
        //public virtual IList<Character> _____Character { get; set; }
        //public virtual IList<Character> Characters
        //{
        //    get
        //    {
        //        return
        //            LoadNHRelation<Character, Guid>(ref _Character, x => x._____Character,
        //            ModelRepositories.Bases.Character_Repository.GetlegalCharachterByCharacterTypeId<Charactertype>,
        //            x => x.id,
        //            (x, y) => { throw new NotImplementedException(); }, (x, y) => { throw new NotImplementedException(); }
        //          );
        //    }
        //    set { _Character.Value = value; _Character.isLoaded = true; }
        //}
        //public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        //{

        //    if (_GPN(x => x.Characters) == PropertyPath)
        //        return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
        //    return base.GetAssociation(PropertyPath);
        //}

        LoadableVar<IList<Character>> _Character = new LoadableVar<IList<Character>>();
        public virtual IList<Character> _____Character { get; set; }
        public virtual IList<Character> Character
        {
            get
            {
                IRERPVList_ParentChildSpec<Charactertype, Character, Filters.Bases.CharacterFilter> rtn =
                     (IRERPVList_ParentChildSpec<Charactertype, Character, Filters.Bases.CharacterFilter>)
                     LoadNHRelation<Character, Guid>(
                     ref _Character, x => x._____Character,
                     ModelRepositories.Bases.Character_Repository.GetAllCharacterByCharacterTypeID<Charactertype>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.Characterstype = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _Character.Value = value; _Character.isLoaded = true; }
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
                if (this[_GPN(x => x.Charactertypename)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.Charactertypename) == columnName)
                {

                    if (Charactertypename.NotEmpty())
                    {
                        if (Charactertypename.Trim() != string.Empty && Charactertypename.Trim() != "null")
                        {
                            this.Charactertypename = Charactertypename.Trim();
                            if (!ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByCharacterTypeName(this))

                                return ApplicationStatics.T("IsinDataBase");
                        }
                        else
                            if(Charactertypename.Trim() == "null")
                                return "فیلد نام اجباری است";
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
