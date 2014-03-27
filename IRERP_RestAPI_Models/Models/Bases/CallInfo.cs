using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using System.Linq;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class CallInfo : IRERP_RestAPI.Bases.ModelBaseLog<CallInfo, CallInfoLog>
    { 
        public CallInfo() { }
        //Fields list
        public virtual string CallNumber { get; set; }
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


                this.id = (Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.CallInfo_Repository.GetCallInfoByID(this.id);
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
                ModifiyDate = DateTime.Now;
                ModifiedID = InstanceStatics.LoggedUser.id;
            }
            return base.Save(session, transaction, CommitTran);
        }

        public override CallInfoLog CreateLog(ModelBaseLog<CallInfo, CallInfoLog> input)
        {
            CallInfo ths = (CallInfo)input;

            CallInfoLog l = new CallInfoLog();

            l.id = ths.id;
            l.CallNumber = ths.CallNumber;
            l.CharacterID = ths.Characters != null ? ths.Characters.id : Guid.Empty;
            l.Type = ths.CallInfoType.id;
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

        LoadableVar<CallInfoType> _CallInfoType = new LoadableVar<CallInfoType>();
        public virtual CallInfoType _____CallInfoType { get; set; }
        public virtual CallInfoType CallInfoType
        {
            get
            {
                return LoadNHRelation<CallInfoType, Guid>
                    (ref _CallInfoType,
                    x => x._____CallInfoType,
                    ModelRepositories.Bases.CallInfoType_Repository.GetCallInfoTypeByID,
                    x => x._____CallInfoType.id);
            }

            set { SetRelationProperty(x => x.CallInfoType, x => x._____CallInfoType, _CallInfoType, value); }



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

            if (_GPN(x => x.CallInfoType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____CallInfoType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


            if (_GPN(x => x.Characters) == PropertyPath)

                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x.CallInfoType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.CallInfoType = ModelRepositories.Bases.CallInfoType_Repository.GetCallInfoTypeByID(Guid.Parse(Dic[_GPN(x => x.CallInfoType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.CallInfoType).ToClientDsFieldName(), ref Dic);
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

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.CallNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.CallInfoType)] != null) return "ValidationError";

                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {

    
                if (_GPN(x => x.CallNumber) == columnName)
                {

                    if (CallNumber.NotEmpty())
                    {
                        if (CallNumber.Trim() != string.Empty && CallNumber.Trim() != "null")
                        {
                            this.CallNumber = CallNumber.Trim();
                            if (IRERP_RestAPI.Bases.Skins.AbbasiValidator.IntField(CallNumber.Trim()))
                            {

                                if (!ModelRepositories.Bases.CallInfo_Repository.GetCallInfoByCallNumber(this))
                                {
                                    return ApplicationStatics.T("IsinDataBase");
                                }


                            }
                            else
                            {
                                return "فرمت شماره تماس صحیح نمی باشد.";
                            }

                        }
                        else
                            if (CallNumber.Trim() == "null")
                                return "فیلد شماره تماس اجباری است";
                    }
                    else
                    {
                        return "فیلد شماره تماس اجباری است";
                    }

                }
                    

                if (_GPN(x => x.CallInfoType.id) == columnName
         || _GPN(x => x.CallInfoType) == columnName)
                {
                    if (CallInfoType == null)

                        return "فیلد نوع اطلاعات تماس  الزامی  است";
                    if (CallInfoType.id == null)

                        return "فیلد نوع اطلاعات تماس  الزامی  است";

                }

                return base[columnName];
            }
        }



    }
}
