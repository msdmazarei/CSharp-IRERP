using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class LegalCharacterLog : LogModelBase<LegalCharacterLog>
    {
        public LegalCharacterLog() { }
        //Fields list
        //public virtual System.Guid id { get; set; }
        public virtual string NationalIdentifier { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string EconomicNumber { get; set; }
        public virtual System.Guid AgentId { get; set; }
        public virtual System.Guid LegalCharacterTypeId { get; set; }
        public virtual string ChairMan { get; set; }
        public virtual System.Guid RegistrationPlace { get; set; }
        public virtual System.Guid LegalBranchId { get; set; }
        public virtual System.Nullable<System.Guid> DependentCompany { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
    }
}
