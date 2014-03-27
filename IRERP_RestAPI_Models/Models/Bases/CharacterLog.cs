using System.Collections.Generic;
using System.Text;
using System;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;
namespace IRERP_RestAPI.Models.Bases
{

public class CharacterLog :  IRERP_RestAPI.Bases.LogModelBase<CharacterLog>
{
public CharacterLog() {} 
 //Fields list
public virtual System.Guid CharacterName { get; set; }
public virtual string NickName { get; set; }
//public virtual System.Guid Role { get; set; }
public virtual Guid? AddBy { get; set; }
public virtual Guid? ModifiedID { get; set; }
public virtual DateTime? AddByDAte { get; set; }
public virtual DateTime? ModifiyDate { get; set; }
public virtual string Description { get; set; }
public virtual string CellNumber { get; set; }
public virtual string Email { get; set; }
public virtual string Address { get; set; }
public virtual string PostalCode { get; set; }
public virtual string TellNumber { get; set; }
public virtual System.Guid? Natinality { get; set; }

public virtual System.Nullable<System.DateTime> LogDate { get; set; }
}

}
