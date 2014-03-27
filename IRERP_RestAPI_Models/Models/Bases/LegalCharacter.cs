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
    public class LegalCharacter : IRERP_RestAPI.Bases.ModelBaseLog<LegalCharacter, LegalCharacterLog>
    {
        public LegalCharacter() { }
        //Fields list
        public virtual string NationalIdentifier { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string EconomicNumber { get; set; }
        public virtual string ChairMan { get; set; }
       // public virtual System.Nullable<System.Guid> DependentCompany { get; set; }
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
                return ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByID(this.id);
            }
            else
                return null;
            //save 
        }
        public override MsdLib.CSharp.BLLCore.FunctionResult<INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
        {
            var tr = this.Transaction;
            if (!IsSaved)
            {
                AddBy = InstanceStatics.LoggedUser.id;
                AddByDAte = DateTime.Now;
                if (MainCharacters == null)
                    MainCharacters = new Character();
               
                this.MainCharacters.AddBy = AddBy;
                id = Guid.NewGuid();
                this.MainCharacters.id = id;
                this.MainCharacters.Characterstype = ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByID(Guid.Parse("1bdc5f85-70ca-48b7-a6fe-fc0b8cd1523f"));
                
                MainCharacters.Save(session, transaction, false);
            }
            else
            {
                ModifiedID = InstanceStatics.LoggedUser.id;
                ModifiyDate = DateTime.Now;
            }
            return base.Save(session, transaction, CommitTran);
        }
        public override LegalCharacterLog CreateLog(ModelBaseLog<LegalCharacter, LegalCharacterLog> input)
        {
            LegalCharacter ths = (LegalCharacter)input;

            LegalCharacterLog l = new LegalCharacterLog();
            l.id = ths.id;
            l.NationalIdentifier = ths.NationalIdentifier;
            l.RegistrationNumber = ths.RegistrationNumber;
            l.EconomicNumber = ths.EconomicNumber;
            l.AgentId = ths.Characters!=null?ths.Characters.id:Guid.Empty;
            l.LegalCharacterTypeId = ths.LegalCharactersType != null ? ths.LegalCharactersType.id : Guid.Empty;
            l.ChairMan = ths.ChairMan;
            l.RegistrationPlace = ths.Places != null ? ths.Places.id : Guid.Empty;
            l.LegalBranchId = ths.LegalBranchs != null ? ths.LegalBranchs.id : Guid.Empty;
            l.DependentCompany = ths.Dependent!=null?ths.Dependent.id:Guid.Empty;
            l.IsDeleted = ths.IsDeleted;
            l.Version = (int)ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.Description = ths.Description;
            l.LogDate = DateTime.Now;
            return l;
        }





        LoadableVar<LegalCharacter> _Dependent = new LoadableVar<LegalCharacter>();
        public virtual LegalCharacter _____Dependent { get; set; }
        public virtual LegalCharacter Dependent
        {
            get
            {
                return LoadNHRelation<LegalCharacter, Guid>
                    (ref _Dependent,
                    x => x._____Dependent,
                    ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByID,
                    x => x._____Dependent.id);
            }
            set
            {
                SetRelationProperty(x => x.Dependent, x => x._____Dependent, _Dependent, value);

            }
        }




        LoadableVar<Character> _MainCharacter = new LoadableVar<Character>();
        public virtual Character _____MainCharacter { get; set; }
        public virtual Character MainCharacters
        {
            get
            {
                return LoadNHRelation<Character, Guid>
                    (ref _MainCharacter,
                    x => x._____MainCharacter,
                    ModelRepositories.Bases.Character_Repository.GetCharacterByID,
                    x => x._____MainCharacter.id);
            }
            set
            {
                SetRelationProperty(x => x.MainCharacters, x => x._____MainCharacter, _MainCharacter, value);

            }
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
            set
            {
                SetRelationProperty(x => x.Characters, x => x._____Character, _Character, value);

            }
        }

        LoadableVar<LegalCharacterType> _LegalCharacterType = new LoadableVar<LegalCharacterType>();
        public virtual LegalCharacterType _____LegalCharacterType { get; set; }
        public virtual LegalCharacterType LegalCharactersType
        {
            get
            {
                return LoadNHRelation<LegalCharacterType, Guid>
                    (ref _LegalCharacterType,
                    x => x._____LegalCharacterType,
                    ModelRepositories.Bases.LegalCharacterType_Repository.GetLegalCharacterTypeByID,
                    x => x._____LegalCharacterType.id);
            }

                         set { SetRelationProperty(x => x.LegalCharactersType, x => x._____LegalCharacterType, _LegalCharacterType, value); }

        

        }

        LoadableVar<Places> _Place = new LoadableVar<Places>();
        public virtual Places _____Place { get; set; }
        public virtual Places Places
        {
            get
            {
                return LoadNHRelation<Places, Guid>
                    (ref _Place,
                    x => x._____Place,
                    ModelRepositories.Bases.Places_Repository.GetPlacesByID,
                    x => x._____Place.id);
            }

        set { SetRelationProperty(x => x.Places, x => x._____Place, _Place, value); }

        }

        LoadableVar<LegalBranch> _LegalBranch = new LoadableVar<LegalBranch>();
        public virtual LegalBranch _____LegalBranch { get; set; }
        public virtual LegalBranch LegalBranchs
        {
            get
            {
                return LoadNHRelation<LegalBranch, Guid>
                    (ref _LegalBranch,
                    x => x._____LegalBranch,
                    ModelRepositories.Bases.LegalBranch_Repository.GetLegalBranchByID,
                    x => x._____LegalBranch.id);
            }

            set { SetRelationProperty(x => x.LegalBranchs, x => x._____LegalBranch, _LegalBranch, value); }
         

        }

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.LegalCharactersType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____LegalCharacterType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.Places) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Place), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.LegalBranchs) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____LegalBranch), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.Characters) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.MainCharacters) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MainCharacter), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            if (_GPN(x => x.Dependent) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Dependent), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

           
            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            if (Dic.ContainsKey(_GPN(x => x.LegalBranchs.id).ToClientDsFieldName()))
            {
                try
                {
                    this.LegalBranchs = ModelRepositories.Bases.LegalBranch_Repository.GetLegalBranchByID(Guid.Parse(Dic[_GPN(x => x.LegalBranchs.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.LegalBranchs), ref Dic);

                }
                catch { }
            }

            if (Dic.ContainsKey(_GPN(x => x.LegalCharactersType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.LegalCharactersType = ModelRepositories.Bases.LegalCharacterType_Repository.GetLegalCharacterTypeByID(Guid.Parse(Dic[_GPN(x => x.LegalCharactersType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.LegalCharactersType).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            if (Dic.ContainsKey(_GPN(x => x.Places.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Places = ModelRepositories.Bases.Places_Repository.GetPlacesByID(Guid.Parse(Dic[_GPN(x => x.Places.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Places).ToClientDsFieldName(), ref Dic);
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

            if (Dic.ContainsKey(_GPN(x => x.MainCharacters.id).ToClientDsFieldName()))
            {
                try
                {
                    this.MainCharacters = ModelRepositories.Bases.Character_Repository.GetCharacterByID(Guid.Parse(Dic[_GPN(x => x.MainCharacters.id).ToClientDsFieldName()]));

                    var q =
                 (from x in Dic.Keys.ToList() where x.IndexOf(_GPN(y => y.MainCharacters).ToClientDsFieldName()) == 0 select x).ToList();

                    Dictionary<string, string> newdic = new Dictionary<string, string>();
                    q.ForEach(x => newdic.Add(x.Substring((_GPN(y => y.MainCharacters).ToClientDsFieldName()).Length + 3), Dic[x]));
                    q.ForEach(x => Dic.Remove(x));
                    MainCharacters.LoadFromStringDictionary(newdic);
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.MainCharacters).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            if (MainCharacters == null)
            {
                MainCharacters = new Character();
                var q =
                  (from x in Dic.Keys.ToList() where x.IndexOf(_GPN(y => y.MainCharacters).ToClientDsFieldName()) == 0 select x).ToList();
                Dictionary<string, string> newdic = new Dictionary<string, string>();
                q.ForEach(x => newdic.Add(x.Substring((_GPN(y => y.MainCharacters).ToClientDsFieldName()).Length + 3), Dic[x]));
                q.ForEach(x => Dic.Remove(x));
                MainCharacters.LoadFromStringDictionary(newdic);
            }


            if (Dic.ContainsKey(_GPN(x => x.Dependent.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Dependent = ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByID(Guid.Parse(Dic[_GPN(x => x.Dependent.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Dependent).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }

          
             base.LoadFromStringDictionary(Dic);
            

        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.RegistrationNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.NationalIdentifier)] != null) return "ValidationError";
                if (this[_GPN(x => x.EconomicNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.MainCharacters)] != null) return "ValidationError";
                if (this[_GPN(x => x.MainCharacters.Email)] != null) return "ValidationError";
                if (this[_GPN(x => x.MainCharacters.PostalCode)] != null) return "ValidationError";

                if (this[_GPN(x => x.MainCharacters.TellNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.MainCharacters.CellNumber)] != null) return "ValidationError";

                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.RegistrationNumber) == columnName)
                {

                    if (RegistrationNumber.NotEmpty())
                    {
                        if (RegistrationNumber.Trim() != string.Empty && RegistrationNumber.Trim() != "null")
                        {
                            this.RegistrationNumber = RegistrationNumber.Trim();
                            if (!ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByRegistrationNumber(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (RegistrationNumber.Trim() == "null")
                                return "فیلد شماره ثبت اجباری است";
                    }
                    else
                    {
                        return "فیلد شماره ثبت اجباری است";
                    }
                }



                if (_GPN(x => x.NationalIdentifier) == columnName)
                {

                    if (NationalIdentifier.NotEmpty())
                    {
                        if (NationalIdentifier.Trim() != string.Empty && NationalIdentifier.Trim() != "null")
                        {
                            this.NationalIdentifier = NationalIdentifier.Trim();
                            if (!ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByNationalIdentifier(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (NationalIdentifier.Trim() == "null")
                                return "فیلد شماره ملی اجباری است";
                    }
                    else
                    {
                        return "فیلد شماره ملی اجباری است";
                    }

                }


                if (_GPN(x => x.MainCharacters.NickName) == columnName)
                {
                    if (MainCharacters != null)
                        if (MainCharacters.NickName.NotEmpty())
                        {
                            if (MainCharacters.NickName.Trim() != string.Empty && MainCharacters.NickName.Trim() != "null")
                            {
                                this.MainCharacters.NickName = MainCharacters.NickName.Trim();
                                if (!ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByCharacterName(this))

                                    return "در بانک اطلاعاتی موجود است";
                            }
                            else
                                if (MainCharacters.NickName.Trim() == "null")
                                    return "فیلد نام نمایشی اجباری است";
                        }
                        else
                        {
                            return "فیلد نام نمایشی اجباری است";
                        }
                    else
                        return "کاراکتر تهی است و ین حالتی غیر ممکن است";
                }

                if (_GPN(x => x.MainCharacters.Email) == columnName)
                {
                    if (MainCharacters != null)
                        if (MainCharacters.Email.NotEmpty())
                        {
                            if (MainCharacters.Email.Trim() != string.Empty && MainCharacters.Email.Trim() != "null")
                            {
                                this.MainCharacters.Email = MainCharacters.Email.Trim();
                                if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.EmailValidator(MainCharacters.Email.Trim()))

                                    return "فرمت ایمیل وارد شده صحیح نمی باشد.";
                            }
                            
                        }
                       
             
                }

                if (_GPN(x => x.MainCharacters.PostalCode) == columnName)
                {
                    if (MainCharacters != null)
                        if (MainCharacters.PostalCode.NotEmpty())
                        {
                            if (MainCharacters.PostalCode.Trim() != string.Empty && MainCharacters.PostalCode.Trim() != "null")
                            {
                                this.MainCharacters.PostalCode = MainCharacters.PostalCode.Trim();
                                if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.PostalCode(MainCharacters.PostalCode.Trim()))

                                    return "فرمت کد پستی وارد شده صحیح نمی باشد.";
                            }

                        }


                }
                if (_GPN(x => x.EconomicNumber) == columnName)
                {

                    if (EconomicNumber.NotEmpty())
                    {
                        if (EconomicNumber.Trim() != string.Empty && EconomicNumber.Trim() != "null")
                        {
                            this.EconomicNumber = EconomicNumber.Trim();
                            if (!ModelRepositories.Bases.LegalCharacter_Repository.GetLegalCharacterByEconomicNumber(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (EconomicNumber.Trim() == "null")
                                return "فیلد نام نمایشی اجباری است";
                    }
                    else
                    {
                        return "فیلد نام نمایشی اجباری است";
                    }

                }


                if (_GPN(x => x.MainCharacters.TellNumber) == columnName)
                {

                    if (MainCharacters.TellNumber.NotEmpty())
                    {
                        if (MainCharacters.TellNumber.Trim() != string.Empty && MainCharacters.TellNumber.Trim() != "null")
                        {
                            this.MainCharacters.TellNumber = MainCharacters.TellNumber.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.CallNumber(MainCharacters.TellNumber.Trim()))
                            {
                                return "فرمت شماره تلفن صحیح نمی باشد.";

                            }


                        }

                    }
                }
                if (_GPN(x => x.MainCharacters.CellNumber) == columnName)
                {

                    if (MainCharacters.CellNumber.NotEmpty())
                    {
                        if (MainCharacters.CellNumber.Trim() != string.Empty && MainCharacters.CellNumber.Trim() != "null")
                        {
                            this.MainCharacters.CellNumber = MainCharacters.CellNumber.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.mobile(MainCharacters.CellNumber.Trim()))
                            {
                                return "فرمت شماره موبایل صحیح نمی باشد.";

                            }


                        }

                    }
                }



                return base[columnName];

            }
        }

       


    }
}
