using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.ModelRepositories.Bases;
using IRERP_RestAPI.Mappings.Bases;
using IRERP_RestAPI.Filters.Bases;
using IRERP_RestAPI.Bases.DataVirtualization;
namespace IRERP_RestAPI.Models.Bases
{
    public class Language : IRERP_RestAPI.Bases.ModelBaseLog<Language, LanguageLog>
    {
        public Language() { }
        //Fields list
        public virtual string LanguageName { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        //LoadByPrimaryKeys
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
            && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.Language_Repository.GetLanguageByID(this.id);
            }
            else
                return null;
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
        public override LanguageLog CreateLog(ModelBaseLog<Language, LanguageLog> input)
        {
            LanguageLog l = new LanguageLog();
            l.id = this.id;
            l.LanguageName = this.LanguageName;
            l.Version = this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.IsDeleted = this.IsDeleted;
            l.Description = this.Description;
            l.LogDate = DateTime.Now;
            return l;
        }
        LoadableVar<IList<Help>> _Help = new LoadableVar<IList<Help>>();
        public virtual IList<Help> _____Help { get; set; }
        public virtual IList<Help> Help
        {
            get
            {
                IRERPVList_ParentChildSpec<Language, Help, Filters.Bases.HelpFilter> rtn =
                (IRERPVList_ParentChildSpec<Language, Help, Filters.Bases.HelpFilter>)
                LoadNHRelation<Help, Guid>(
                 ref _Help, x => x._____Help,
                 ModelRepositories.Bases.Help_Repository.GetAllHelpsByLanguageID<Language>,
                x => x.id,
                (x, y) =>
                {
                    y.Language = x;
                    return y.Save();
                },
                (x, y) => { return y.Remove(CommitTransaction: false); }
                );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _Help.Value = value; _Help.isLoaded = true; }
        }

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.Help) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Help), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            //AssociationHere
            return base.GetAssociation(PropertyPath);
        }
        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            base.LoadFromStringDictionary(Dic);
            //LoadFromStringHere
        }
        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.LanguageName)] != null) return "ValidationError";
               
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.LanguageName) == columnName)
                {

                    if (LanguageName.NotEmpty())
                    {
                        if (LanguageName.Trim() != string.Empty && LanguageName.Trim() != "null")
                        {
                            this.LanguageName = LanguageName.Trim();
                            if (!ModelRepositories.Bases.Language_Repository.GetLanguageByName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (LanguageName.Trim() == "null")
                                return "فیلد نام زبان اجباری است";
                    }
                    else
                    {
                        return "فیلد نام زبان اجباری است";
                    }

                }


              
                return null;
            }
        } 
    }
}
