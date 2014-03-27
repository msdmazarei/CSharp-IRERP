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
    public class  MessagingRelationType : IRERP_RestAPI.Bases.ModelBaseLog<MessagingRelationType, MessagingRelationTypeLog>
    {
        public MessagingRelationType() { }
        //Fields list
        public virtual string RelationName { get; set; }
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
                return ModelRepositories.Bases.MessagingRelationType_Repository.GetMessagingRelationTypeByID(this.id);
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
        public override MessagingRelationTypeLog CreateLog(ModelBaseLog<MessagingRelationType, MessagingRelationTypeLog> input)
        {
            MessagingRelationType ths = (MessagingRelationType)input;

            MessagingRelationTypeLog l = new MessagingRelationTypeLog();
            l.id = ths.id;
            l.RelationName = ths.RelationName;
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

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.MessagingInfo) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____MessagingInfo), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        LoadableVar<IList<IRERP_RestAPI.Models.Bases.MessagingInfo>> _MessagingInfo = new LoadableVar<IList<IRERP_RestAPI.Models.Bases.MessagingInfo>>();
        public virtual IList<IRERP_RestAPI.Models.Bases.MessagingInfo> _____MessagingInfo { get; set; }
        public virtual IList<IRERP_RestAPI.Models.Bases.MessagingInfo> MessagingInfo
        {
            get
            {
                IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.MessagingRelationType, IRERP_RestAPI.Models.Bases.MessagingInfo, Filters.Bases.MessagingInfoFilter> rtn =
                     (IRERPVList_ParentChildSpec<IRERP_RestAPI.Models.Bases.MessagingRelationType, IRERP_RestAPI.Models.Bases.MessagingInfo, Filters.Bases.MessagingInfoFilter>)
                     LoadNHRelation<IRERP_RestAPI.Models.Bases.MessagingInfo, Guid>(
                     ref _MessagingInfo, x => x._____MessagingInfo,
                     ModelRepositories.Bases.MessagingInfo_Repository.GetAllMessaginInfoByMessagingInfoRelationTypeId<IRERP_RestAPI.Models.Bases.MessagingRelationType>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.MessagingRelationType = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _MessagingInfo.Value = value; _MessagingInfo.isLoaded = true; }

        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.RelationName)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.RelationName) == columnName)
                {

                    if (RelationName.NotEmpty())
                    {
                        if (RelationName.Trim() != string.Empty && RelationName.Trim() != "null")
                        {
                            this.RelationName = RelationName.Trim();
                            if (!ModelRepositories.Bases.MessagingRelationType_Repository.GetMessagingInfoRelationTypeByName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (RelationName.Trim() == "null")
                                return "فیلد نوع ارتباط است";
                    }
                    else
                    {
                        return "فیلد نوع ارتباط است";
                    }

                }

                return null;
            }
        }
    }
}
