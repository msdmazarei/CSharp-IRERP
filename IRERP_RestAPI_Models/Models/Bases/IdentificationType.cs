using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
namespace IRERP_RestAPI.Models.Bases
{
    public class IdentificationType : IRERP_RestAPI.Bases.ModelBaseLog<IdentificationType, IdentificationTypeLog>
    {
        public IdentificationType() { }
        //Fields list
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        //LoadByPrimaryKeys
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                        && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.IdentificationType_Repository.GetIdentificationTypeByID(this.id);
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
        public override IdentificationTypeLog CreateLog(ModelBaseLog<IdentificationType, IdentificationTypeLog> input)
        {
            IdentificationTypeLog l = new IdentificationTypeLog();
            l.id = this.id;
            l.Name = this.Name;
            l.Description = this.Description;
            l.IsDeleted = this.IsDeleted;
            l.Version = (int)this.Version;
            l.AddBy = this.AddBy;
            l.ModifiedID = this.ModifiedID;
            l.AddByDAte = this.AddByDAte;
            l.ModifiyDate = this.ModifiyDate;
            l.LogDate = DateTime.Now;
            return l;
        }
    }
}
