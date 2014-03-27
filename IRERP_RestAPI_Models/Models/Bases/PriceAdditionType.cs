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
    public class PriceAdditionType : IRERP_RestAPI.Bases.ModelBaseLog<PriceAdditionType, PriceAdditionTypeLog>
    {
        public PriceAdditionType() { }
        //Fields list
        public virtual string Name { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual int? Value { get; set; }
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
                return ModelRepositories.Bases.PriceAdditionType_Repository.GetPriceAdditionTypeByID(this.id);
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
        public override PriceAdditionTypeLog CreateLog(ModelBaseLog<PriceAdditionType, PriceAdditionTypeLog> input)
        {
            PriceAdditionType ths = (PriceAdditionType)input;

            PriceAdditionTypeLog l = new PriceAdditionTypeLog();
            l.id = ths.id;
            l.Name = ths.Name;
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

                            if (!ModelRepositories.Bases.PriceAdditionType_Repository.GetPriceAdditionByName(this))
                            {
                                return "در بانک اطلاعاتی موجود است";
                            }
                        }
                        else
                            if (Name.Trim() == "null")
                                return "فیلد نام اجباری است";
                    }
                    else
                    {
                        return "فیلد نام اجباری است";
                    }

                }

                if (_GPN(x => x.Value) == columnName)
                {

                    if (Value.ToString().NotEmpty())
                    {
                        if (Value.ToString().Trim() != string.Empty && Value.ToString().Trim() != "null")
                        {
                            this.Value = Value;

                           
                        }
                        else
                            if (Value.ToString().Trim() == "null")
                                return "فیلد نوع اثر گذاری اجباری است";
                    }
                    else
                    {
                        return "فیلد اثرگذاری اجباری است";
                    }

                }
                return null;
            }
        }
    }
}
