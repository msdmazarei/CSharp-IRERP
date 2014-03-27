using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Filters.Bases;
using IRERP_RestAPI.ModelRepositories.Bases;

namespace IRERP_RestAPI.Models.Bases
{
    public class Help : IRERP_RestAPI.Bases.ModelBaseLog<Help, HelpLog>
    {
        public Help() { }
        //Fields list
        public virtual string HelpText { get; set; }
        public virtual string HelpKey { get; set; }
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
                return Help_Repository.GetHelpByID(this.id);
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
        public override HelpLog CreateLog(ModelBaseLog<Help, HelpLog> input)
        {
            HelpLog l = new HelpLog();
            l.id = this.id;
            l.HelpText = this.HelpText;
            l.HelpKey = this.HelpKey;
            l.Version = this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.IsDeleted = this.IsDeleted;
            l.LogDate = DateTime.Now;
            return l;
        }
        LoadableVar<Language> _Language = new LoadableVar<Language>();
        public virtual Language _____Language { get; set; }
        public virtual Language Language
        {
            get
            {
                return LoadNHRelation<Language, Guid>
                (ref _Language,
                 x => x._____Language,
                ModelRepositories.Bases.Language_Repository.GetLanguageByID,
                 x => x._____Language.id);
            }

            set { SetRelationProperty(x => x.Language, x => x._____Language, _Language, value); }
            
        }

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.Language) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Language), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            //AssociationHere
            return base.GetAssociation(PropertyPath);
        }
        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            if (Dic.ContainsKey(_GPN(x => x.Language.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Language = ModelRepositories.Bases.Language_Repository.GetLanguageByID(Guid.Parse(Dic[_GPN(x => x.Language.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Language).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            base.LoadFromStringDictionary(Dic);
            //LoadFromStringHere
        }
        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.HelpText)] != null) return "ValidationError";
                if (this[_GPN(x => x.HelpKey)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.HelpKey) == columnName)
                {

                    if (HelpKey.NotEmpty())
                    {
                        if (HelpKey.Trim() != string.Empty && HelpKey.Trim() != "null")
                        {
                            this.HelpKey = HelpKey.Trim();
                            if (!ModelRepositories.Bases.Help_Repository.GetHelpByKey(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (HelpKey.Trim() == "null")
                                return "فیلد کلید اجباری است";
                    }
                    else
                    {
                        return "فیلد کلید اجباری است";
                    }

                }


                if (_GPN(x => x.HelpText) == columnName)
                {

                    if (HelpText.NotEmpty())
                    {
                        if (HelpText.Trim() != string.Empty && HelpText.Trim() != "null")
                        {
                            
                        }
                        else
                            if (HelpText.Trim() == "null")
                                return "فیلد متن رهنما اجباری است.";
                    }
                    else
                    {
                        return "فیلد متن رهنما اجباری است.";
                    }

                }

                if (_GPN(x => x.Language.id) == columnName
             || _GPN(x => x.Language) == columnName)
                {
                    if (Language != null)
                        if (!Language.LanguageName.NotEmpty())
                            return "فیلد زبان  اجباری است";
                    if (Language == null)
                        return "فیلد زبان اجباری است";
                }
                return null;
            }
        }  
    }
}
