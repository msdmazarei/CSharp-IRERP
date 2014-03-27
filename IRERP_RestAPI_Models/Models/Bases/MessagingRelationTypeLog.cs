using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{
    public class MessagingRelationTypeLog : IRERP_RestAPI.Bases.LogModelBase<MessagingRelationTypeLog>
    {
        public MessagingRelationTypeLog() { }
        //Fields list
        public virtual string RelationName { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual string Description { get; set; }
        //public virtual System.Guid LogId { get; set; }
        public virtual System.DateTime? LogDate { get; set; }
    }
}
