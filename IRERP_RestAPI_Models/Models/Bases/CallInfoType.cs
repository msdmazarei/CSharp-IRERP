using System.Collections.Generic;
using System.Text;
using System;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.DataVirtualization;
using System.Linq;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases

{
    public class CallInfoType : IRERP_RestAPI.Bases.ModelBaseLog<CallInfoType,CallInfoTypeLog>
    {
        public CallInfoType() { }
        //Fields list
        public virtual string TypeName { get; set; }
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
                return ModelRepositories.Bases.CallInfoType_Repository.GetCallInfoTypeByID(this.id);
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
        public override CallInfoTypeLog CreateLog(ModelBaseLog<CallInfoType, CallInfoTypeLog> input)
        {
            CallInfoType ths = (CallInfoType)input;

            CallInfoTypeLog l = new CallInfoTypeLog();
            l.id = ths.id;
            l.TypeName = ths.TypeName;
            l.IsDeleted = ths.IsDeleted;
            l.Version = ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDAte = ths.AddByDAte;
            l.ModifiyDate = ths.ModifiyDate;
            l.Description = ths.Description;
            l.LogDate = DateTime.Now;
           // l.LogId = Guid.NewGuid();
           
            return l;
        }
        LoadableVar<IList<CallInfo>> _CallInfo = new LoadableVar<IList<CallInfo>>();
        public virtual IList<CallInfo> _____CallInfo { get; set; }
        public virtual IList<CallInfo> CallInfo
        {
            get
            {
                IRERPVList_ParentChildSpec<CallInfoType, CallInfo, Filters.Bases.CallInfoFilter> rtn =
                     (IRERPVList_ParentChildSpec<CallInfoType, CallInfo, Filters.Bases.CallInfoFilter>)
                     LoadNHRelation<CallInfo, Guid>(
                     ref _CallInfo, x => x._____CallInfo,
                     ModelRepositories.Bases.CallInfo_Repository.GetCallInfoByCallInfoTypeId<CallInfoType>,
                     x => x.id,
                     (x, y) =>
                     {
                         y.CallInfoType = x;
                         return y.Save();
                     },
                     (x, y) => { return y.Remove(CommitTransaction: false); }
                   );
                rtn.ParentInstance = this;
                return rtn;
            }
            set { _CallInfo.Value = value; _CallInfo.isLoaded = true; }
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

            if (_GPN(x => x.CallInfo) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____CallInfo), NHibernate.SqlCommand.JoinType.LeftOuterJoin, null);

            return base.GetAssociation(PropertyPath);
        }

        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.TypeName)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.TypeName) == columnName)
                {

                    if (TypeName.NotEmpty())
                    {
                        if (TypeName.Trim() != string.Empty && TypeName.Trim() != "null")
                        {
                            this.TypeName = TypeName.Trim();
                            if (!ModelRepositories.Bases.CallInfoType_Repository.GetCallInfoTypeByName(this))

                                return ApplicationStatics.T("IsinDataBase");
                        }
                        else
                            if (TypeName.Trim() == "null")
                                return "فیلد نوع اطلاعات اجباری است";
                    }
                    else
                    {
                        return "فیلد نوع اطلاعات اجباری است";
                    }

                }

                return null;
            }
        }

    }
}
