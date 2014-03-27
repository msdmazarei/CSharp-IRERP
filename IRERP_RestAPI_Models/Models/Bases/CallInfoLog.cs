using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class CallInfoLog : IRERP_RestAPI.Bases.LogModelBase<CallInfoLog>
    {
        public CallInfoLog() { }
        //Fields list
        public virtual string CallNumber { get; set; }
        public virtual System.Guid Type { get; set; }
        public virtual System.Guid CharacterID { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
    }
}
