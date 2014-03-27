using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class RightFulCharacterLog : IRERP_RestAPI.Bases.LogModelBase<RightFulCharacterLog>
    {
        public RightFulCharacterLog() { }
        //Fields list
        public virtual string Fname { get; set; }
        public virtual string LName { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string BirthCertificateSerial { get; set; }

        public virtual System.Nullable<System.Guid> Gender { get; set; }
        public virtual string BrithDayYear { get; set; }
        public virtual System.Nullable<System.Guid> BrithdayPlaceId { get; set; }
    
        public virtual string BirthCertificateNumber { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
    }
}
