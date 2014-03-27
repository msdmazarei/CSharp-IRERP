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
    public class MessagingInfo : IRERP_RestAPI.Bases.ModelBaseLog<MessagingInfo, MessagingInfoLog>
    {
        public MessagingInfo() { }
        //Fields list
        //public virtual System.Nullable<System.Guid> CharacterID { get; set; }
        public virtual string MessagingAddress { get; set; }
        //public virtual System.Guid RelationType { get; set; }
        //public virtual System.Guid Type { get; set; }
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
                return ModelRepositories.Bases.MessagingInfo_Repository.GetMessagingInfoByID(this.id);
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
        public override MessagingInfoLog CreateLog(ModelBaseLog<MessagingInfo, MessagingInfoLog> input)
        {
            MessagingInfo ths = (MessagingInfo)input;

            MessagingInfoLog l = new MessagingInfoLog();
            l.id = this.id;
            l.CharacterID = ths.Character != null ? ths.Character.id : Guid.Empty;
            l.MessagingAddress = ths.MessagingAddress;
            l.RelationType = ths.MessagingRelationType != null ? ths.MessagingRelationType.id : Guid.Empty;
            l.Type = ths.MessagingInfoType != null ? ths.MessagingInfoType.id : Guid.Empty;
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
        LoadableVar<IRERP_RestAPI.Models.Bases.MessagingInfoType> _MessagingInfoType = new LoadableVar<IRERP_RestAPI.Models.Bases.MessagingInfoType>();
        public virtual IRERP_RestAPI.Models.Bases.MessagingInfoType _____MessagingInfoType { get; set; }
        public virtual IRERP_RestAPI.Models.Bases.MessagingInfoType MessagingInfoType
        {
            get
            {
                return LoadNHRelation<IRERP_RestAPI.Models.Bases.MessagingInfoType, Guid>
                    (ref _MessagingInfoType,
                    x => x._____MessagingInfoType,
                    ModelRepositories.Bases.MessagingInfoType_Repository.GetMessagingInfoTypeByID,
                    x => x._____MessagingInfoType.id);
            }
            set
            {
                SetRelationProperty(x => x.MessagingInfoType, x => x._____MessagingInfoType, _MessagingInfoType, value);

            }
        }




    
        LoadableVar<IRERP_RestAPI.Models.Bases.MessagingRelationType> _MessagingRelationType = new LoadableVar<IRERP_RestAPI.Models.Bases.MessagingRelationType>();
        public virtual IRERP_RestAPI.Models.Bases.MessagingRelationType _____MessagingRelationType { get; set; }
        public virtual IRERP_RestAPI.Models.Bases.MessagingRelationType MessagingRelationType
        {
            get
            {
                return LoadNHRelation<IRERP_RestAPI.Models.Bases.MessagingRelationType, Guid>

                    (ref _MessagingRelationType,
                    x => x._____MessagingRelationType,
                    ModelRepositories.Bases.MessagingRelationType_Repository.GetMessagingRelationTypeByID,
                    x => x._____MessagingRelationType.id);
            }

            set
            {
                _MessagingRelationType.Value = value;
                _MessagingRelationType.isLoaded = true;
                _____MessagingRelationType = value;
            }
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
            set
            {
                _Character.Value = value;
                _Character.isLoaded = true;
                _____Character = value;
            }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.MessagingInfoType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MessagingInfoType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            if (_GPN(x => x.MessagingRelationType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MessagingRelationType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x.MessagingInfoType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.MessagingInfoType = ModelRepositories.Bases.MessagingInfoType_Repository.GetMessagingInfoTypeByID(Guid.Parse(Dic[_GPN(x => x.MessagingInfoType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.MessagingInfoType).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            if (Dic.ContainsKey(_GPN(x => x.Character.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Character = ModelRepositories.Bases.Character_Repository.GetCharacterByID(Guid.Parse(Dic[_GPN(x => x.Character.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Character).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }

            if (Dic.ContainsKey(_GPN(x => x.MessagingRelationType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.MessagingRelationType = ModelRepositories.Bases.MessagingRelationType_Repository.GetMessagingRelationTypeByID(Guid.Parse(Dic[_GPN(x => x.MessagingRelationType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.MessagingRelationType).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            base.LoadFromStringDictionary(Dic);

        }
        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.MessagingAddress)] != null) return "ValidationError";
                if (this[_GPN(x => x.MessagingInfoType)] != null) return "ValidationError";
                if (this[_GPN(x => x.MessagingRelationType)] != null) return "ValidationError";
             
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                


                if (_GPN(x => x.MessagingAddress) == columnName)
                {
            
                    if (MessagingAddress.NotEmpty())
                    {
                        if (MessagingAddress.Trim() != string.Empty && MessagingAddress.Trim() != "null")
                        {
                            this.MessagingAddress = MessagingAddress.Trim();
                            //if (!ModelRepositories.Bases.MessagingInfo_Repository.GetMessagingInfoByMessaginAddress(this))

                            //    return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (MessagingAddress.Trim() == "null")
                                return "فیلد آدرس اجباری است";
                    }
                    else
                    {
                        return "فیلد آدرس اجباری است";
                    }

                }

                if (_GPN(x => x.MessagingInfoType.id) == columnName
     || _GPN(x => x.MessagingInfoType) == columnName)
                {
                    if (MessagingInfoType == null)

                        return "فیلد نوع تماس پیامی اجباری است";
                    if (MessagingInfoType.id == null)

                        return "فیلد نوع تماس پیامی اجباری است";

                }
                if (_GPN(x => x.MessagingRelationType.id) == columnName
      || _GPN(x => x.MessagingRelationType) == columnName)
                {
                    if (MessagingRelationType == null)

                        return "فیلد نوع  ارتباط تماس پیامی اجباری است";
                    if (MessagingRelationType.id == null)

                        return "فیلد نوع  ارتباط تماس پیامی اجباری است";

                }
             
                return null;
            }
        }  
    }
}
