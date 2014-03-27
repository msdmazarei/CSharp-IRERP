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
    public class Charactertypelog : IRERP_RestAPI.Bases.LogModelBase<Charactertypelog>
    {
        //public virtual System.Guid Logid { get; set; }
       // public virtual System.Guid id { get; set; }
        public virtual string Charactertypename { get; set; }
       // public virtual bool? Isdeleted { get; set; }
        //public virtual int? Version { get; set; }
        public virtual Guid? AddBy { get; set; }
        public virtual Guid? ModifiedID { get; set; }
        public virtual DateTime? AddBydate { get; set; }
        public virtual DateTime? Modifiydate { get; set; }
       public virtual DateTime? Logdate { get; set; }
        public virtual string Description { get; set; }
    }
}
