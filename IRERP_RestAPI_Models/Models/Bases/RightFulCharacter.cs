using System.Collections.Generic;
using System.Text;
using System;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.DataVirtualization;
using System.Linq;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class  RightFulCharacter : IRERP_RestAPI.Bases.ModelBaseLog<RightFulCharacter, RightFulCharacterLog>
    {
        public RightFulCharacter() { }
        //Fields list
        public virtual string Fname { get; set; }
        public virtual string LName { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string BirthCertificateSerial { get; set; }

       // public virtual System.Nullable<System.Guid> Gender { get; set; }
        public virtual string BrithDayYear { get; set; }
       // public virtual System.Nullable<System.Guid> BrithdayPlaceId { get; set; }
  
        public virtual string BirthCertificateNumber { get; set; }
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
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID(this.id);
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
                if(this.Character==null)
                this.Character = new Bases.Character();
                this.Character.AddBy = AddBy;
                id = Guid.NewGuid();
                Character.id = this.id;

                this.Character.Characterstype = ModelRepositories.Bases.Charactertype_Repository.GetCharacterTypeByID(Guid.Parse("db94368d-5380-42f6-be3c-97747262ffa7"));
           
                Character.Save(session,transaction,false);
            }
            else
            {
                ModifiedID = InstanceStatics.LoggedUser.id;
                ModifiyDate = DateTime.Now;
            }
            return base.Save(session, transaction, CommitTran);
        }

        public override RightFulCharacterLog CreateLog(ModelBaseLog<RightFulCharacter, RightFulCharacterLog> input)
        {
            RightFulCharacter tis = (RightFulCharacter)input;
            RightFulCharacterLog l = new RightFulCharacterLog();
            l.id = tis.id;
            l.Fname = tis.Fname;
            l.LName = tis.LName;
            l.NationalCode = tis.NationalCode;
            l.FatherName = tis.FatherName;
            l.BirthCertificateSerial = tis.BirthCertificateSerial;
            l.Gender = tis.Gender!=null? tis.Gender.id:Guid.Empty;
            l.BrithDayYear =  tis.BrithDayYear;
            l.BrithdayPlaceId = tis.BirthPlace != null ? tis.BirthPlace.id : Guid.Empty;
            l.BirthCertificateNumber = tis.BirthCertificateNumber;
            l.IsDeleted = tis.IsDeleted;
            l.Version = tis.Version;
            l.AddBy = tis.AddBy;
            l.ModifiedID = tis.ModifiedID;
            l.AddByDAte = tis.AddByDAte;
            l.ModifiyDate = tis.ModifiyDate;
            l.Description = tis.Description;
            l.LogDate = DateTime.Now;
            return l;
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
                SetRelationProperty(x => x.Character, x => x._____Character, _Character, value);

            }
        }
        LoadableVar<Gender> _Gender = new LoadableVar<Gender>();
        public virtual Gender _____Gender { get; set; }
        public virtual Gender Gender
        {
            get
            {
                return LoadNHRelation<Gender, Guid>
                    (ref _Gender,
                    x => x._____Gender,
                    ModelRepositories.Bases.Gender_Repository.GetGenderByID,
                    x => x._____Gender.id);
            }
            set
            {
                SetRelationProperty(x => x.Gender, x => x._____Gender, _Gender, value);

            }
        }
        LoadableVar<Places> _BirthPlace = new LoadableVar<Places>();
        public virtual Places _____BirthPlace { get; set; }
        public virtual Places BirthPlace
        {
            get
            {
                return LoadNHRelation<Places, Guid>
                    (ref _BirthPlace,
                    x => x._____BirthPlace,
                    ModelRepositories.Bases.Places_Repository.GetPlacesByID,
                    x => x._____BirthPlace.id);
            }
            set
            {
                SetRelationProperty(x => x.BirthPlace, x => x._____BirthPlace, _BirthPlace, value);

            }
        }

       
        
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.Gender) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Gender), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.BirthPlace) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____BirthPlace), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
        
                      return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x.Character.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Character = ModelRepositories.Bases.Character_Repository.GetCharacterByID(Guid.Parse(Dic[_GPN(x => x.Character.id).ToClientDsFieldName()]));
                    var q =
               (from x in Dic.Keys.ToList() where x.IndexOf(_GPN(y => y.Character).ToClientDsFieldName()) == 0 select x).ToList();

                    Dictionary<string, string> newdic = new Dictionary<string, string>();
                    q.ForEach(x => newdic.Add(x.Substring((_GPN(y => y.Character).ToClientDsFieldName()).Length + 3), Dic[x]));
                    q.ForEach(x => Dic.Remove(x));
                    Character.LoadFromStringDictionary(newdic);
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Character).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            if (Character == null)
            {
                Character = new Character();
                var q =
                   (from x in Dic.Keys.ToList() where x.IndexOf(_GPN(y => y.Character).ToClientDsFieldName()) == 0 select x).ToList();
                Dictionary<string, string> newdic = new Dictionary<string, string>();
                q.ForEach(x => newdic.Add(x.Substring((_GPN(y => y.Character).ToClientDsFieldName()).Length + 3), Dic[x]));
                q.ForEach(x => Dic.Remove(x));
                Character.LoadFromStringDictionary(newdic);
            }
            if (Dic.ContainsKey(_GPN(x => x.Gender.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Gender = ModelRepositories.Bases.Gender_Repository.GetGenderByID(Guid.Parse(Dic[_GPN(x => x.Gender.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Gender).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
            if (Dic.ContainsKey(_GPN(x => x.BirthPlace.id).ToClientDsFieldName()))
            {
                try
                {
                    this.BirthPlace = ModelRepositories.Bases.Places_Repository.GetPlacesByID(Guid.Parse(Dic[_GPN(x => x.BirthPlace.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.BirthPlace).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }

          
      
            base.LoadFromStringDictionary(Dic);

        }


        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.Fname)] != null) return "ValidationError";
                if (this[_GPN(x => x.LName)] != null) return "ValidationError";
                if (this[_GPN(x => x.Character.NickName)] != null) return "ValidationError";
                if (this[_GPN(x => x.Character.PostalCode)] != null) return "ValidationError";
                if (this[_GPN(x => x.FatherName)] != null) return "ValidationError";
                if (this[_GPN(x => x.NationalCode)] != null) return "ValidationError";
                if (this[_GPN(x => x.BrithDayYear)] != null) return "ValidationError";
                if (this[_GPN(x => x.BirthCertificateSerial)] != null) return "ValidationError";
                if (this[_GPN(x => x.BirthCertificateNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.Character.TellNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.Character.CellNumber)] != null) return "ValidationError";
                if (this[_GPN(x => x.Character.Email)] != null) return "ValidationError";
              //  if (this[_GPN(x => x.NationalCode)] != null) return "ValidationError";




                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {


                if (_GPN(x => x.BirthCertificateSerial) == columnName)
                {
                    
                      if (BirthCertificateSerial.NotEmpty())
                    {
                        if (BirthCertificateSerial.Trim() != string.Empty && BirthCertificateSerial.Trim() != "null")
                        {
                            this.BirthCertificateSerial = BirthCertificateSerial.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.BirthCertificateSerial(BirthCertificateSerial.Trim()))
                            {
                                  return "فرمت سریال شناسنامه صحیح نمی باشد.";
                               
                            }
                           
                           
                        }
                 
                    }
                }

                if (_GPN(x => x.Character.TellNumber) == columnName)
                {

                    if (Character.TellNumber.NotEmpty())
                    {
                        if (Character.TellNumber.Trim() != string.Empty && Character.TellNumber.Trim() != "null")
                        {
                            this.Character.TellNumber = Character.TellNumber.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.CallNumber(Character.TellNumber.Trim()))
                            {
                                return "فرمت شماره تلفن صحیح نمی باشد.";

                            }


                        }

                    }
                }
                if (_GPN(x => x.Character.CellNumber) == columnName)
                {

                    if (Character.CellNumber.NotEmpty())
                    {
                        if (Character.CellNumber.Trim() != string.Empty && Character.CellNumber.Trim() != "null")
                        {
                            this.Character.CellNumber = Character.CellNumber.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.mobile(Character.CellNumber.Trim()))
                            {
                                return "فرمت شماره موبایل صحیح نمی باشد.";

                            }


                        }

                    }
                }
                if (_GPN(x => x.NationalCode) == columnName)
                {

                    if (NationalCode.NotEmpty())
                    {


                        if (NationalCode.Trim() != string.Empty && NationalCode.Trim() != "null")
                        {
                            this.NationalCode = NationalCode.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.NatinalCodeValidator(NationalCode.Trim()))
                            {
                                return "کد ملی وارد شده معتبر نمی باشد.";

                            }
                            else
                            {

                                if (!ModelRepositories.Bases.RightFulCharacter_Repository.Valid_NationalCode(this))
                                {
                                    return "در بانک اطلاعاتی موجود است";
                                }
                            }




                        }

                    }
                }

       

                if (_GPN(x => x.BirthCertificateNumber) == columnName)
                {

                    if (BirthCertificateNumber.NotEmpty())

                    {
                        if (BirthCertificateNumber.Trim() != string.Empty && BirthCertificateNumber.Trim() != "null")
                        {
                            this.BirthCertificateNumber = BirthCertificateNumber.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.BirthCertificateNumber(BirthCertificateNumber.Trim()))
                            {
                                return "فرمت شماره شناسنامه صحیح نمی باشد.";

                            }


                        }

                    }


                }


                if (_GPN(x => x.Character.PostalCode) == columnName)
                {

                    if (Character.PostalCode.NotEmpty())
                    {
                        if (Character.PostalCode.Trim() != string.Empty && Character.PostalCode.Trim() != "null")
                        {
                            this.Character.PostalCode = Character.PostalCode.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.PostalCode(Character.PostalCode.Trim()))
                            {
                                return "فرمت کد پستی صحیح نمی باشد.";

                            }


                        }

                    }


                }



                if (_GPN(x => x.FatherName) == columnName)
                {

                    if (FatherName.NotEmpty())
                    {

                            if (FatherName.Trim() == "null")
                                return "فیلد نام پدر اجباری است";
                    }
                    else
                    {
                        return "فیلد نام پدر اجباری است";
                    }
                }



                if (_GPN(x => x.BrithDayYear) == columnName)
                {

                    if (BrithDayYear.NotEmpty())
                    {
                        if (BrithDayYear.Trim() != string.Empty && BrithDayYear.Trim() != "null")
                        {
                            this.BrithDayYear = BrithDayYear.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.KhorshidyDate(BrithDayYear.Trim()))
                            {
                                return "فرمت تاریخ تولد صحیح نمی باشد.";

                            }


                        }

                    }


                }




                if (_GPN(x => x.Fname) == columnName)
                {

                    if (Fname.NotEmpty())
                    {
                       


                            if (Fname.Trim() == "null")
                                return "فیلد نام اجباری است";
                       
                    }
                    else
                    {
                        return "فیلد نام اجباری است";
                    }
                }



                    if (_GPN(x => x.LName) == columnName)
                    {
                        if (LName.NotEmpty())
                        {
                           
                               
                                    if (LName.Trim() == "null")
                                        return "فیلد نام خانوادگی اجباری است";
                           
                    }
                    else
                    {
                        return "فیلد نام خانوادگی اجباری است";
                    }
            }


                if (_GPN(x => x.Character.NickName) == columnName)
                {

                    if (Character.NickName.NotEmpty())
                    {
                        if (Character.NickName.Trim() != string.Empty && Character.NickName.Trim() != "null")
                        {

                        }
                        else
                            if (Character.NickName.Trim() == "null")
                                return "فیلد نام نمایشی اجباری است";
                    }
                    else
                    {
                        return "فیلد نام نمایشی اجباری است";
                    }
                }




                if (_GPN(x => x.Gender.id) == columnName
                    || _GPN(x => x.Gender) == columnName)
                {
                    if (Gender != null)
                        if (!Gender.GenderName.NotEmpty())
                            return "فیلد جنسیت اجباری است";
                    if (Gender == null)
                        return "فیلد جنسیت اجباری است";
                }

                if (_GPN(x => x.Character.Email) == columnName)
                {

                    if (Character.Email.NotEmpty())
                    {
                        if (Character.Email.Trim() != string.Empty && Character.Email.Trim() != "null")
                        {
                            this.Character.Email = Character.Email.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.EmailValidator(Character.Email.Trim()))
                            {
                                return "فرمت ایمیل  صحیح نمی باشد.";

                            }

                        }

                    }
                }

                return null;

            }
        }

    }
}
                
