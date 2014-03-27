using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class IdentificationLog : LogModelBase<IdentificationLog>
    {
        public IdentificationLog() { }
        //Fields list
        public virtual System.Guid id { get; set; }
        public virtual System.Nullable<System.Guid> IdentificationType { get; set; }
        public virtual string fileuploadtest { get; set; }
        public virtual string TestFile_FiN { get; set; }
        public virtual long? TestFile_FiS { get; set; }
        public virtual DateTime? TestFile_FiC { get; set; }
        public virtual string TestFile_FiR { get; set; }
        public virtual string TestFile_FiT { get; set; }
        public virtual string TestFile_FiCC { get; set; }
        public virtual string TestAddress_Addr { get; set; }
        public virtual string TestAddress_AptNo { get; set; }
        public virtual string TestAddress_GAddr { get; set; }
        public virtual float? TestAddress_Lat { get; set; }
        public virtual float? TestAddress_Lng { get; set; }
        public virtual string TestAddress_Roof { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
    }
}
