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
using MsdLib.CSharp.BLLCore;
namespace IRERP_RestAPI.Models.Bases
{
    public class Character : IRERP_RestAPI.Bases.ModelBaseLog<Character,CharacterLog>
    {
        public Character() { }
        //Fields list

        public virtual string NickName { get; set; }
        //public virtual System.Guid Role { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string CellNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string TellNumber { get; set; }
        //public virtual System.Guid Natinality { get; set; }
        //public virtual System.Guid Identification { get; set; }

        public virtual PersianDateTime PersianAddByDAte { get { PersianDateTime dt = AddByDAte; return dt; } set { AddByDAte = value; } }
        public virtual PersianDateTime PersianModifiyDate { get { PersianDateTime dt = ModifiyDate; return dt; } set { ModifiyDate = value; } }

     
        //LoadByPrimaryKeys
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                        && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.Character_Repository.GetCharacterByID(this.id);
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
       

        LoadableVar<RightFulCharacter> _RightFulCharacter = new LoadableVar<RightFulCharacter>();
        public virtual RightFulCharacter _____RightFulCharacter { get; set; }
        public virtual RightFulCharacter RightFulCharacter
        {
            get
            {
                return LoadNHRelation<RightFulCharacter, Guid>
                    (ref _RightFulCharacter,
                    x => x._____RightFulCharacter,
                    ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID,
                    x => x._____RightFulCharacter.id);
            }

             set { SetRelationProperty(x => x.RightFulCharacter, x => x._____RightFulCharacter, _RightFulCharacter, value); }
           

        }
        protected MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Valid_AddMessagingInfoTOCharacter(Character b, MessagingInfo u)
        {

            var rtn = new MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>();
            if (b.id.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                rtn.Result = false;
                rtn.ResultValue = null;
                rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterNotSelectedError"), null);
                rtn.Time = DateTime.Now;
                return rtn;
            }
            else
                rtn.Result = true;

            return rtn;
        }
     
        LoadableVar<IList<MessagingInfo>> _MessagingInfo = new LoadableVar<IList<MessagingInfo>>();
        public virtual IList<MessagingInfo> _____MessagingInfo { get; set; }
        public virtual IList<MessagingInfo> MessagingInfo
        {
            get
            {
                return
                    LoadNHRelation<MessagingInfo, Guid>(ref _MessagingInfo, x => x._____MessagingInfo,
                    ModelRepositories.Bases.MessagingInfo_Repository.GetAllMessaginInfoByCharacterID<Character>,
                    x => x.id,
                    (x, y) =>
                    {

                        if (Valid_AddMessagingInfoTOCharacter(x, y).Result)
                        {

                            y.Character = x;
                            return y.Save();
                        }
                        else
                        {
                            return Valid_AddMessagingInfoTOCharacter(x, y);

                        }

                        
                    },
                    (x, y) => { return y.Remove(CommitTransaction: false); }
               );
             
            }


            set { SetRelationProperty(x => x.MessagingInfo, x => x._____MessagingInfo, _MessagingInfo, value); }
        }

    
        protected MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Valid_AddPostalAddressTOCharacter(Character b, PostalAddress u)
        {

            var rtn = new MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>();
            if (b.id.ToString() == "00000000-0000-0000-0000-000000000000")
            {

                rtn.Result = false;
                rtn.ResultValue = null;
                rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterNotSelectedError"), null);
                rtn.Time = DateTime.Now;
                return rtn;

            }
            else
            {
                int count = IRERP_RestAPI.ModelRepositories.Bases.PostalAddress_Repository.GetPostalAddressByPostalAddressIdANDCharacterID(b, u).Count;
                if (count >= 1)
                {
                    rtn.Result = false;
                    rtn.ResultValue = null;
                    rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterInformationAreInsertedError"), null);
                    rtn.Time = DateTime.Now;
                    return rtn;
                }
                else
                    rtn.Result = true;
            }

            return rtn;
        }
        LoadableVar<IList<PostalAddress>> _PostalAddress = new LoadableVar<IList<PostalAddress>>();
        public virtual IList<PostalAddress> _____PostalAddress { get; set; }
        public virtual IList<PostalAddress> PostalAddress
        {
            get
            {
                return
                    LoadNHRelation<PostalAddress, Guid>(ref _PostalAddress, x => x._____PostalAddress,
                    ModelRepositories.Bases.PostalAddress_Repository.GetAllPostalAddressByCharacterId<Character>,
                    x => x.id,
                    (x, y) =>
                    {

                        if (Valid_AddPostalAddressTOCharacter(x, y).Result)
                        {

                            y.Character = x;
                            return y.Save();
                        }
                        else
                        {
                            return Valid_AddPostalAddressTOCharacter(x, y);

                        }


                    },
                    (x, y) => { return y.Remove(CommitTransaction: false); }
               );
            }
            set { SetRelationProperty(x => x.PostalAddress, x => x._____PostalAddress, _PostalAddress, value); }
        }
        protected MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Valid_AddCallInfoTOCharacter(Character b, CallInfo u)
        {

            var rtn = new MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>();
            if (b.id.ToString() == "00000000-0000-0000-0000-000000000000")
            {

                rtn.Result = false;
                rtn.ResultValue = null;
                rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterNotSelectedError"), null);
                rtn.Time = DateTime.Now;
                return rtn;
                
            }
            else
            {
                int count = IRERP_RestAPI.ModelRepositories.Bases.CallInfo_Repository.GetCallInfoByCallinfoIdANDCharacterID(b, u).Count;
                if (count >= 1)
                {
                    rtn.Result = false;
                    rtn.ResultValue = null;
                    rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterInformationAreInsertedError"), null);
                    rtn.Time = DateTime.Now;
                    return rtn;
                }
                else
                    rtn.Result = true;
            }

            return rtn;
        }
        LoadableVar<IList<CallInfo>> _CallInfo = new LoadableVar<IList<CallInfo>>();
        public virtual IList<CallInfo> _____CallInfo { get; set; }
        public virtual IList<CallInfo> CallInfo
        {
            get
            {
                IRERPVList_ParentChildSpec<Character, CallInfo, Filters.Bases.CallInfoFilter> rtn =
                     (IRERPVList_ParentChildSpec<Character, CallInfo, Filters.Bases.CallInfoFilter>)
                     LoadNHRelation<CallInfo, Guid>(
                     ref _CallInfo, x => x._____CallInfo,
                     ModelRepositories.Bases.CallInfo_Repository.GetCallInfoByCharacterId<Character>,
                     x => x.id,
                     (x, y) =>
                     {
                         if (Valid_AddCallInfoTOCharacter(x, y).Result)
                         {

                             y.Characters = x;
                             return y.Save();
                         }
                         else
                         {
                             return Valid_AddCallInfoTOCharacter(x, y);

                         }
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { SetRelationProperty(x => x.CallInfo, x => x._____CallInfo, _CallInfo, value); }

        }

        protected MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Valid_AddRolsOfCharacterTOCharacter(Character b, RolsOfCharacter u)
        {

            var rtn = new MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity>();
            if (b.id.ToString() == "00000000-0000-0000-0000-000000000000")
            {

                rtn.Result = false;
                rtn.ResultValue = null;
                rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterNotSelectedError"), null);
                rtn.Time = DateTime.Now;
                return rtn;

            }
            else
            {
                int count=IRERP_RestAPI.ModelRepositories.Bases.RolsOfCharacter_Repository.GetRolsOfCharacterByCharacterANDRols<RolsOfCharacter>(b,u).Count;
                if (count >= 1)
                {
                    rtn.Result = false;
                    rtn.ResultValue = null;
                    rtn.Error = new PException(ApplicationStatics.T("characterModelCharacterInformationAreInsertedError"), null);
                    rtn.Time = DateTime.Now;
                    return rtn;
                }
                else
                    rtn.Result = true;
            }

            return rtn;
        }
        LoadableVar<IList<RolsOfCharacter>> _RolsOfCharacter = new LoadableVar<IList<RolsOfCharacter>>();
        public virtual IList<RolsOfCharacter> _____RolsOfCharacter { get; set; }
        public virtual IList<RolsOfCharacter> RolsOfCharacter
        {



            get
            {



                IRERPVList_ParentChildSpec<Character, RolsOfCharacter, Filters.Bases.RolsOfCharacterFilter> rtn =
                     (IRERPVList_ParentChildSpec<Character, RolsOfCharacter, Filters.Bases.RolsOfCharacterFilter>)
                     LoadNHRelation<RolsOfCharacter, Guid>(
                     ref _RolsOfCharacter, x => x._____RolsOfCharacter,
                     ModelRepositories.Bases.RolsOfCharacter_Repository.GetAllRolesOfCharacterByCharacterId<Character>,
                     x => x.id,
                     (x, y) =>
                     {
                         if (Valid_AddRolsOfCharacterTOCharacter(x, y).Result)
                         {

                             y.Character = x;
                             return y.Save();
                         }
                         else
                         {
                             return Valid_AddRolsOfCharacterTOCharacter(x, y);

                         }
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;

            }
            set { SetRelationProperty(x => x.RolsOfCharacter, x => x._____RolsOfCharacter, _RolsOfCharacter, value); }

        }

        public override CharacterLog CreateLog(ModelBaseLog<Character, CharacterLog> input)
        {
            Character ths = (Character)input;

            CharacterLog l = new CharacterLog();
            l.id = ths.id;
            l.CharacterName = ths.Characterstype!=null? ths.Characterstype.id:Guid.Empty;
            l.NickName = ths.NickName;
            l.CellNumber = ths.CellNumber;
            l.TellNumber = ths.TellNumber;
            l.Address = ths.Address;
            l.Email = ths.Email;
            l.PostalCode = ths.PostalCode;
            l.IsDeleted = ths.IsDeleted;
            l.Version = ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.Description = ths.Description;
            l.LogDate = DateTime.Now;
            l.Natinality = this.Nationality != null ? ths.Nationality.id : Guid.Empty;
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
                    ModelRepositories.Bases.LegalCharacter_Repository.GetlegalCharachterByCharacterId<Character>,
                    x => x.id,
                    (x, y) => { throw new NotImplementedException(); }, (x, y) => { throw new NotImplementedException(); }
                  );
            }
            set { _LegalCharacter.Value = value; _LegalCharacter.isLoaded = true; }
        }


        LoadableVar<LegalCharacter> _LegalCharacterMain = new LoadableVar<LegalCharacter>();
        public virtual LegalCharacter _____LegalCharacterMain { get; set; }
        public virtual LegalCharacter LegalCharacterMain
        {
            get
            {
                return LoadNHRelation<LegalCharacter, Guid>
                    (ref _LegalCharacterMain,
                    x => x._____LegalCharacterMain,
                    ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByID,
                    x => x._____LegalCharacterMain.id);
            }
            set
            {
                SetRelationProperty(x => x.LegalCharacterMain, x => x._____LegalCharacterMain, _LegalCharacterMain, value); 
                //_LegalCharacterMain.SetValue(value);
                //_____LegalCharacterMain = value;
            }
        }

        LoadableVar<Charactertype> _Charactertype = new LoadableVar<Charactertype>();
        public virtual Charactertype _____Charactertype { get; set; }
        public virtual Charactertype Characterstype
        {
            get
            {
                return LoadNHRelation<Charactertype, Guid>
                    (ref _Charactertype,
                    x => x._____Charactertype,
                    ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByID,
                    x => x._____Charactertype.id);
            }
            set
            {
                SetRelationProperty(x => x.Characterstype, x => x._____Charactertype, _Charactertype, value);
                //_Charactertype.SetValue(value);
                //_____Charactertype = value;
            }
        }


         LoadableVar<Nationality> _Nationality = new LoadableVar<Nationality>();
        public virtual Nationality _____Nationality { get; set; }
        public virtual Nationality Nationality
        {
            get
            {
                return LoadNHRelation<Nationality, Guid>
                    (ref _Nationality,
                    x => x._____Nationality,
                    ModelRepositories.Bases.Nationality_Repository.GetNationalityByID,
                    x => x._____Nationality.id);
            }

            set { SetRelationProperty(x => x.Nationality, x => x._____Nationality, _Nationality, value); }


        }


        LoadableVar<IList<Identification>> _Identification = new LoadableVar<IList<Identification>>();
        public virtual IList<Identification> _____Identification { get; set; }
        public virtual IList<Identification> Identification
        {
            get
            {
                IRERPVList_ParentChildSpec<Character, Identification, Filters.Bases.IdentificationFilter> rtn =
                     (IRERPVList_ParentChildSpec<Character, Identification, Filters.Bases.IdentificationFilter>)
                     LoadNHRelation<Identification, Guid>(
                     ref _Identification, x => x._____Identification,
                     ModelRepositories.Bases.Identification_Repository.GetIdentificationByCharacterId<Character>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.Characters = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { SetRelationProperty(x => x.Identification, x => x._____Identification, _Identification, value); }
        }

      
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.LegalCharacters) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____LegalCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);



        

            if (_GPN(x => x.Characterstype) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Charactertype), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            if (_GPN(x => x.RightFulCharacter) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____RightFulCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


            if (_GPN(x => x.LegalCharacterMain) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____RightFulCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


         
            if (_GPN(x => x.MessagingInfo) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MessagingInfo), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            if (_GPN(x => x.PostalAddress) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____PostalAddress), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


            if (_GPN(x => x.CallInfo) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____CallInfo), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);



            if (_GPN(x => x.RolsOfCharacter) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____RolsOfCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);



            if (_GPN(x => x.Nationality) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Nationality), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);


            if (_GPN(x => x.Identification) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Identification), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

          
            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x._____Charactertype.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Characterstype = ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByID(Guid.Parse(Dic[_GPN(x => x.Characterstype.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Characterstype).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }


            if (Dic.ContainsKey(_GPN(x => x.Nationality.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Nationality = ModelRepositories.Bases.Nationality_Repository.GetNationalityByID(Guid.Parse(Dic[_GPN(x => x.Nationality.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Nationality).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }


           
            base.LoadFromStringDictionary(Dic);
             

        }



        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.Email)] != null) return "ValidationError";



                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.Email) == columnName)
                {

                    if (Email.NotEmpty())
                    {


                        if (Email.Trim() != string.Empty && Email.Trim() != "null")
                        {
                            this.Email = Email.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.EmailValidator(Email.Trim()))
                            {
                                return "ایمیل وارد شده معتبر نمی باشد.";

                            }
                            else
                            {

                                if (!ModelRepositories.Bases.Character_Repository.Valid_Email(this))
                                {
                                    return "در بانک اطلاعاتی موجود است";
                                }
                            }

                        }

                    }
                }


                return base[columnName];

            }
        }
    }
}
