using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class HelpLog : IRERP_RestAPI.Bases.LogModelBase<HelpLog>
    {
        public HelpLog() { }
        //Fields list
        public virtual string HelpText { get; set; }
        public virtual string HelpKey { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
        public virtual string Description { get; set; }
    }
}
