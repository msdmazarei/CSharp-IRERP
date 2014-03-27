using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using MsdLib.CSharp.DALCore;
using System.Linq;
using System.Diagnostics;
using MsdLib.CSharp.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class Feasibility : IRERP_RestAPI.Bases.ProcessModel<Feasibility, FeasibilityLog>
    {
        public Feasibility() { }
        //Fields list
        public virtual DateTime RegisterationDate { get; set; }
        public virtual DateTime? ResultDate { get; set; }
        //public virtual System.Guid Character { get; set; }
        public virtual int? AddBy { get; set; }
        public virtual int? ModifiedID { get; set; }
        public virtual DateTime? AddByDate { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        //public virtual bool AcceptingState { get; set; }
        //public virtual bool InstallingState { get; set; }
        public virtual double TowerHeight { get; set; }
        public virtual int FloorCount { get; set; }


        public virtual PersianDateTime PersianAddByDAte { get { PersianDateTime dt = AddByDate; return dt; } set { AddByDate = value; } }
        public virtual PersianDateTime PersianModifiyDate { get { PersianDateTime dt = ModifiyDate; return dt; } set { ModifiyDate = value; } }


        public virtual PersianDateTime PersianRegisterationDate { get { PersianDateTime dt = RegisterationDate; return dt; } set { RegisterationDate = value; } }
        public virtual PersianDateTime PersianResultDate { get { PersianDateTime dt = ResultDate; return dt; } set { ResultDate = value; } }

      

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                        && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Bases.Feasibility_Repository.GetFeasibilityByID(this.id);
            }
            else
                return null;
            //save 
        }
        public override MsdLib.CSharp.BLLCore.FunctionResult<INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
        {

          
            if (!IsSaved)
            {
                AddBy = InstanceStatics.LoggedUser.UserID;
                AddByDate = DateTime.Now;
                RegisterationDate = DateTime.Now;
            }
            else
            {
                ModifiedID = InstanceStatics.LoggedUser.UserID;
                ModifiyDate = DateTime.Now;
               //  Order.Save(session, transaction, false);
            }
            return base.Save(session, transaction, CommitTran);
        }
        public override FeasibilityLog CreateLog(ModelBaseLog<Feasibility, FeasibilityLog> input)

        {
            Feasibility ths = (Feasibility)input;


 
            FeasibilityLog l = new FeasibilityLog();
            l.id = ths.id;
            l.RegisterationDate = ths.RegisterationDate;
            l.ResultDate = ths.ResultDate;
            if (ths.FeasibilityMan != null)
                l.FeasibilityMan = ths.FeasibilityMan.id;
            else
                l.FeasibilityMan = Guid.Empty;
            if (ths.Installer != null)
                l.Installer = ths.Installer.id;
            else
                l.Installer = Guid.Empty;
            l.IsDeleted = ths.IsDeleted;
            l.Version = (int)ths.Version;
            l.AddBy = ths.AddBy;
            l.ModifiedID = ths.ModifiedID;
            l.AddByDate = ths.AddByDate;
            l.ModifiyDate = ths.ModifiyDate;
            l.Description = ths.Description;
            l.OrderId = ths.Order.id;
            l.LogDate = DateTime.Now;
            l.FloorCount = ths.FloorCount;
            l.TowerHeight = ths.TowerHeight;
            return l;
        }


        
        LoadableVar<RightFulCharacter> _Installer = new LoadableVar<RightFulCharacter>();
        public virtual RightFulCharacter _____Installer { get; set; }
        public virtual RightFulCharacter Installer
        {
            get
            {


                return LoadNHRelation<RightFulCharacter, Guid>
                    (ref _Installer,
                    x => x._____Installer,
                    ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID,
                    x => x._____Installer.id);
            }
            set
            {
                SetRelationProperty(x => x.Installer, x => x._____Installer, _Installer, value);

            }
        }
        LoadableVar<RightFulCharacter> _FeasibilityMan = new LoadableVar<RightFulCharacter>();
        public virtual RightFulCharacter _____FeasibilityMan { get; set; }
        public virtual RightFulCharacter FeasibilityMan
        {
            get
            {


                return LoadNHRelation<RightFulCharacter, Guid>
                    (ref _FeasibilityMan,
                    x => x._____FeasibilityMan,
                    ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID,
                    x => x._____FeasibilityMan.id);
            }
            set
            {
                SetRelationProperty(x => x.FeasibilityMan, x => x._____FeasibilityMan, _FeasibilityMan, value);

            }
        }
       public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {

           
            
            return base.GetAssociation(PropertyPath);
        }



        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {


        
            if (Dic.ContainsKey(_GPN(x => x.FeasibilityMan.id).ToClientDsFieldName()))
            {
                try
                {
                    this.FeasibilityMan = ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID(Guid.Parse(Dic[_GPN(x => x.FeasibilityMan.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.FeasibilityMan).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }

            if (Dic.ContainsKey(_GPN(x => x.Installer.id).ToClientDsFieldName()))
            {
                try
                {
                    this.Installer = ModelRepositories.Bases.RightFulCharacter_Repository.GetRightFulCharacterByID(Guid.Parse(Dic[_GPN(x => x.Installer.id).ToClientDsFieldName()]));
                    IRERPApplicationUtilities.RemoveAllKeysStartWith(_GPN(x => x.Installer).ToClientDsFieldName(), ref Dic);
                }
                catch { }
            }
         
            base.LoadFromStringDictionary(Dic);


        }
     

    }
}
