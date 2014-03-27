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
    public class Gender : IRERP_RestAPI.Bases.ModelBaseLog<Gender,GenderLog>
    {
        public Gender() { }
        //Fields list
        public virtual string GenderName { get; set; }
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
                return ModelRepositories.Bases.Gender_Repository.GetGenderByID(this.id);
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
        public override GenderLog CreateLog(ModelBaseLog<Gender, GenderLog> input)
        {
            Gender ths = (Gender)input;

            GenderLog l = new GenderLog();
            l.id = ths.id;
            l.GenderName = ths.GenderName;
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
        public override string Error
        {
            get
            {
                if (this[_GPN(x => x.GenderName)] != null) return "ValidationError";
                return base.Error;
            }
        }
        public override string this[string columnName]
        {
            get
            {
                if (_GPN(x => x.GenderName) == columnName)
                {

                    if (GenderName.NotEmpty())
                    {
                        if (GenderName.Trim() != string.Empty && GenderName.Trim() != "null")
                        {
                            this.GenderName = GenderName.Trim();
                            if (!ModelRepositories.Bases.Gender_Repository.GetGenderByGenderName(this))

                                return "در بانک اطلاعاتی موجود است";
                        }
                        else
                            if (GenderName.Trim() == "null")
                                return "فیلد جنسیت اجباری است";
                    }
                    else
                    {
                        return "فیلد جنسیت اجباری است";
                    }

                }

                return null;
            }
        }  



        
    }
}
