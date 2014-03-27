using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Models.Bases
{
    public class PostalAddressTypeLog : IRERP_RestAPI.Bases.LogModelBase<PostalAddressTypeLog>
{
public PostalAddressTypeLog() {} 
 //Fields list
//public virtual System.Guid id { get; set; }
public virtual string Name { get; set; }
public virtual string Description { get; set; }
public virtual Guid? AddBy { get; set; }
public virtual Guid? ModifiedID { get; set; }
public virtual DateTime? AddByDAte { get; set; }
public virtual DateTime? ModifiyDate { get; set; }
//public virtual System.Guid LogId { get; set; }
public virtual System.Nullable<System.DateTime> LogDate { get; set; }
}
}
