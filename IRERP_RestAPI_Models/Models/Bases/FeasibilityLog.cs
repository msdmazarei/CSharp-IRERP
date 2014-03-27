using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class FeasibilityLog : LogModelBase<FeasibilityLog>
    {
        public FeasibilityLog() { }
        //Fields list
        //public virtual System.Guid id { get; set; }
        public virtual DateTime RegisterationDate { get; set; }
        public virtual DateTime? ResultDate { get; set; }
        public virtual System.Guid Installer { get; set; }
        public virtual System.Guid FeasibilityMan { get; set; }
        public virtual int? AddBy { get; set; }
        public virtual int? ModifiedID { get; set; }
        public virtual DateTime? AddByDate { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Guid OrderId { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
        //public virtual bool AcceptingState { get; set; }
        //public virtual bool InstallingState { get; set; }
        public virtual double TowerHeight { get; set; }
        public virtual int FloorCount { get; set; }

    }
}
