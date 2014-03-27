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
    public class MessagingInfoType : IRERP_RestAPI.Bases.ModelBaseLog<MessagingInfoType, MessagingInfoTypeLog>
    {
        public MessagingInfoType() { }
        //Fields list
        public virtual string MessagingType { get; set; }
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
                return ModelRepositories.Bases.MessagingInfoType_Repository.GetMessagingInfoTypeByID(this.id);
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
        public override MessagingInfoTypeLog CreateLog(ModelBaseLog<MessagingInfoType, MessagingInfoTypeLog> input)
        {
            MessagingInfoType ths = (MessagingInfoType)input;

            MessagingInfoTypeLog l = new MessagingInfoTypeLog();
            l.id = ths.id;
            l.MessagingType = ths.MessagingType;
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
        LoadableVar<IList<IRERP_RestAPI.Models.Bases.MessagingInfo>> _MessagingInfo = new LoadableVar<IList<IRERP_RestAPI.Models.Bases.MessagingInfo>>();
        public virtual IList<IRERP_RestAPI.Models.Bases.MessagingInfo> _____MessagingInfo { get; set; }
        public virtual IList<IRERP_RestAPI.Models.Bases.MessagingInfo> MessagingInfo
        {
            get
            {
                IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.MessagingInfoType, IRERP_RestAPI.Models.Bases.MessagingInfo, Filters.Bases.MessagingInfoFilter> rtn =
                     (IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.MessagingInfoType, IRERP_RestAPI.Models.Bases.MessagingInfo, Filters.Bases.MessagingInfoFilter>)
                     LoadNHRelation<IRERP_RestAPI.Models.Bases.MessagingInfo, Guid>(
                     ref _MessagingInfo, x => x._____MessagingInfo,
                     ModelRepositories.Bases.MessagingInfo_Repository.GetAllMessaginInfoByMessagingInfoTypeId<IRERP_RestAPI.Models.Bases.MessagingInfoType>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.MessagingInfoType = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _MessagingInfo.Value = value; _MessagingInfo.isLoaded = true; }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.MessagingInfo) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MessagingInfo), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.MessagingType)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.MessagingType) == columnName)
                {

                    if (MessagingType.NotEmpty())
                    {
                        if (MessagingType.Trim() != string.Empty && MessagingType.Trim() != "null")
                        {
                            this.MessagingType = MessagingType.Trim();
                            if (!ModelRepositories.Bases.MessagingInfoType_Repository.GetMessagingInfoTypeByName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (MessagingType.Trim() == "null")
                                return "فیلد نوع  اجباری است";
                    }
                    else
                    {
                        return "فیلد نام اجباری است";
                    }

                }

                return null;
            }
        }

    }
}
