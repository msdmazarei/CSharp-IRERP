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
    public class PostalAddress : IRERP_RestAPI.Bases.ModelBaseLog<PostalAddress, PostalAddressLog>
    {
        public PostalAddress() { }
        //Fields list
        //public virtual System.Guid CharacterID { get; set; }
       // public virtual System.Guid PostalAddressType { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Address { get; set; }
        public virtual string KMZ { get; set; }
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

                return ModelRepositories.Bases.PostalAddress_Repository.GetPostalAddressByID(this.id);

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
        public override PostalAddressLog CreateLog(ModelBaseLog<PostalAddress, PostalAddressLog> input)
        {
            PostalAddress ths = (PostalAddress)input;

            PostalAddressLog l = new PostalAddressLog();
            l.id = ths.id;
            l.CharacterID = ths.Character != null ? ths.Character.id : Guid.Empty;
            l.PostalAddressType = ths.PostalAddressType != null ? ths.PostalAddressType.id : Guid.Empty;
            l.PostalCode = ths.PostalCode;
            l.Address = ths.Address;
            l.KMZ = ths.KMZ;
            l.Description = ths.Description;
            l.IsDeleted = ths.IsDeleted;
            l.Version = ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            return l;
        }
        LoadableVar<IRERP_RestAPI.Models.Bases.PostalAddressType> _PostalAddressType = new LoadableVar<IRERP_RestAPI.Models.Bases.PostalAddressType>();
        public virtual IRERP_RestAPI.Models.Bases.PostalAddressType _____PostalAddressType { get; set; }
        public virtual IRERP_RestAPI.Models.Bases.PostalAddressType PostalAddressType
        {
            get
            {
                return LoadNHRelation<IRERP_RestAPI.Models.Bases.PostalAddressType, Guid>
                    (ref _PostalAddressType,
                    x => x._____PostalAddressType,
                    ModelRepositories.Bases.PostalAddressType_Repository.GetPostalAddressTypeByID,
                    x => x._____PostalAddressType.id);
            }
            set
            {
                SetRelationProperty(x => x.PostalAddressType, x => x._____PostalAddressType, _PostalAddressType, value);

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
                SetRelationProperty(x => x.Character, x => x._____Character, _Character, value);

            }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.PostalAddressType) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____PostalAddressType), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);
            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);



            if (_GPN(x => x.Character) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Character), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {

            if (Dic.ContainsKey(_GPN(x => x.PostalAddressType.id).ToClientDsFieldName()))
            {
                try
                {
                    this.PostalAddressType = ModelRepositories.Bases.PostalAddressType_Repository.GetPostalAddressTypeByID(Guid.Parse(Dic[_GPN(x => x.PostalAddressType.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.PostalAddressType).ToClientDsFieldName(), ref Dic);
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
            base.LoadFromStringDictionary(Dic);

        }
        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.Address)] != null) return "ValidationError";
               if (this[_GPN(x => x.PostalCode)] != null) return "ValidationError";
                if (this[_GPN(x => x.PostalAddressType)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.Address) == columnName)
                {

                    if (Address.NotEmpty())
                    {
                        if (Address.Trim() != string.Empty && Address.Trim() != "null")
                        {
                            this.Address = Address.Trim();
                          
                        }
                        else
                            if (Address.Trim() == "null")
                                return "فیلد آدرس اجباری است";
                    }
                    else
                    {
                        return "فیلد آدرس اجباری است";
                    }

                }
                if (_GPN(x => x.PostalCode) == columnName)
                {

                    if (PostalCode.NotEmpty())
                    {
                        if (PostalCode.Trim() != string.Empty && PostalCode.Trim() != "null")
                        {
                            this.PostalCode = PostalCode.Trim();
                            if (!IRERP_RestAPI.Bases.Skins.AbbasiValidator.PostalCode(PostalCode.Trim()))
                            {
                                return "فرمت کد پستی صحیح نمی باشد.";
                            }


                        }
                        else
                            if (PostalCode.Trim() == "null")
                                return "فیلد کد پستی اجباری است";
                    }
                    else
                    {
                        return "فیلد کد پستی اجباری است";
                    }

                }
                if (_GPN(x => x.PostalAddressType.id) == columnName
              || _GPN(x => x.PostalAddressType) == columnName)
                {
                    if (PostalAddressType == null)

                        return "فیلد نوع اطلاعات پستی اجباری است";
                    if (PostalAddressType.id==null)

                        return "فیلد نوع اطلاعات پستی اجباری است";

                }
           
                return null;
            }
        }  


    }
}
