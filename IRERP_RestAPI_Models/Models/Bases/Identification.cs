using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
namespace IRERP_RestAPI.Models.Bases
{
    public class  Identification : IRERP_RestAPI.Bases.ModelBaseLog<Identification, IdentificationLog>
    {
        public Identification() { }
        //Fields list
       // public virtual System.Nullable<System.Guid> IdentificationType { get; set; }
        public virtual string fileuploadtest { get; set; }
        public virtual IRERP_RestAPI.Bases.NHComponents.IRERPFile TestFile { get; set; }
        public virtual IRERP_RestAPI.Bases.NHComponents.IRERPGAddress TestAddress { get; set; }
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
                return ModelRepositories.Bases.Identification_Repository.GetIdentificationByID(this.id);
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
        public override IdentificationLog CreateLog(ModelBaseLog<Identification, IdentificationLog> input)
        {
            IdentificationLog l = new IdentificationLog();
            l.id = this.id;
            l.IdentificationType = this.IdentificationType!=null?this.IdentificationType.id:Guid.Empty;
            l.IsDeleted = this.IsDeleted;
            l.Version = (int)this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.Description = this.Description;
            l.LogDate = DateTime.Now;
            return l;
        }

        LoadableVar<IdentificationType> _IdentificationType = new LoadableVar<IdentificationType>();
        public virtual IdentificationType _____IdentificationType { get; set; }
        public virtual IdentificationType IdentificationType
        {
            get
            {
                return LoadNHRelation<IdentificationType, Guid>
                    (ref _IdentificationType,
                    x => x._____IdentificationType,
                    ModelRepositories.Bases.IdentificationType_Repository.GetIdentificationTypeByID,
                    x => x._____IdentificationType.id);
            }

            set { SetRelationProperty(x => x.IdentificationType, x => x._____IdentificationType, _IdentificationType, value); }



        }


        LoadableVar<Character> _Character = new LoadableVar<Character>();
        public virtual Character _____Character { get; set; }
        public virtual Character Characters
        {
            get
            {
                return LoadNHRelation<Character, Guid>
                    (ref _Character,
                    x => x._____Character,
                    ModelRepositories.Bases.Character_Repository.GetCharacterByID,
                    x => x._____Character.id);
            }
            set { SetRelationProperty(x => x.Characters, x => x._____Character, _Character, value); }

        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.IdentificationType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____IdentificationType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            if (_GPN(x => x.Characters) == PropertyPath)

                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
          
            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {



            if (Dic.ContainsKey(_GPN(x => x.IdentificationType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.IdentificationType = ModelRepositories.Bases.IdentificationType_Repository.GetIdentificationTypeByID(Guid.Parse(Dic[_GPN(x => x.IdentificationType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.IdentificationType).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }

            if (Dic.ContainsKey(_GPN(x => x.Characters.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Characters = ModelRepositories.Bases.Character_Repository.GetCharacterByID(Guid.Parse(Dic[_GPN(x => x.Characters.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Characters).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            base.LoadFromStringDictionary(Dic);

        }
    }
}
