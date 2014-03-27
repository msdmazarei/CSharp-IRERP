using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using System.Linq;
using IRERP_RestAPI.Bases.DataVirtualization;
namespace IRERP_RestAPI.Models.Bases
{
    public class CallInfoTypeLog : IRERP_RestAPI.Bases.LogModelBase<CallInfoTypeLog>
    {
       
        //Fields list
       
      
        public virtual string TypeName { get; set; }
       
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddByDAte { get; set; }
        public virtual DateTime? ModifiyDate { get; set; }
        public virtual System.Nullable<System.DateTime> LogDate { get; set; }
        public virtual string Description { get; set; }
        
        //public virtual System.Nullable<System.DateTime> LogDate { get; set; }
    }
}
