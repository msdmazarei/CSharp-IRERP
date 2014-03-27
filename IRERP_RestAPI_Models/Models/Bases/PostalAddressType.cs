using System.Collections.Generic; 
using System.Text; 
using System;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.DataVirtualization;
using System.Linq;
using MsdLib.CSharp.DALCore;
using IRERP_RestAPI.Filters;
using MsdLib.CSharp.Types;


namespace IRERP_RestAPI.Models.Bases
{

    public class PostalAddressType : IRERP_RestAPI.Bases.ModelBaseLog<PostalAddressType,PostalAddressTypeLog>
    {

        //Fields list
        //public virtual System.Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        //public virtual bool? IsDeleted { get; set; }
        //public virtual int? Version { get; set; }
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


                this.id = (Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.PostalAddressType_Repository.GetPostalAddressTypeByID(this.id);
            }
            else
                return null;

        }
        //save 
        public override MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
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
        public override PostalAddressTypeLog CreateLog(ModelBaseLog<PostalAddressType, PostalAddressTypeLog> input)
        {
            PostalAddressTypeLog l = new PostalAddressTypeLog();
            l.id = this.id;
            l.Name = this.Name;
            l.IsDeleted = this.IsDeleted;
            l.Version = this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.Description = this.Description;
            l.LogDate = DateTime.Now;
            // l.LogId = Guid.NewGuid();

            return l;
        }
        LoadableVar<IList<IRERP_RestAPI.Models.Bases.PostalAddress>> _PostalAddress = new LoadableVar<IList<IRERP_RestAPI.Models.Bases.PostalAddress>>();
        public virtual IList<IRERP_RestAPI.Models.Bases.PostalAddress> _____PostalAddress { get; set; }
        public virtual IList<IRERP_RestAPI.Models.Bases.PostalAddress> PostalAddress
        {
            get
            {
                IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.PostalAddressType, IRERP_RestAPI.Models.Bases.PostalAddress, Filters.Bases.PostalAddressFilter> rtn =
                     (IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.PostalAddressType, IRERP_RestAPI.Models.Bases.PostalAddress, Filters.Bases.PostalAddressFilter>)
                     LoadNHRelation<IRERP_RestAPI.Models.Bases.PostalAddress, Guid>(
                     ref _PostalAddress, x => x._____PostalAddress,
                     ModelRepositories.Bases.PostalAddress_Repository.GetAllPostalAddressByPostalAddressTypeId<IRERP_RestAPI.Models.Bases.PostalAddressType>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.PostalAddressType = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _PostalAddress.Value = value; _PostalAddress.isLoaded = true; }
        }

      
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.PostalAddress) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____PostalAddress), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.Name)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.Name) == columnName)
                {

                    if (Name.NotEmpty())
                    {
                        if (Name.Trim() != string.Empty && Name.Trim() != "null")
                        {
                            this.Name = Name.Trim();
                            if (!ModelRepositories.Bases.PostalAddressType_Repository.GetPostalAddressTypeByName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                        {
                            return "فیلد نوع اطلاعات پستی اجباری است";
                        }
                    }
                    else
                    {
                        return "فیلد نوع اطلاعات پستی اجباری است";
                    }

                }

                return null;
            }
        }
    }
}

