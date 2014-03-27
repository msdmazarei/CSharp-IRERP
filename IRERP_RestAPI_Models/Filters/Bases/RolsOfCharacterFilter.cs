using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class RolsOfCharacterFilter : IRERPFilter<RolsOfCharacterFilter, RolsOfCharacter>
    {
        public virtual System.Guid? RolsOfCharacterID { get; set; }
        public virtual System.Guid? CharacterID { get; set; }
        public virtual System.Guid? CharacterRoleID { get; set; }
        public virtual System.Guid? CharacterID1 { get; set; }
        public virtual System.Guid? CharacterRoleID1 { get; set; }
        public override NHibernate.IQueryOver<RolsOfCharacter, RolsOfCharacter> Query
        {
            get
            {
                var q = base.Query;
                if (RolsOfCharacterID != null)
                {
                    q.And((x => x.id == RolsOfCharacterID));
                }
                if (CharacterID != null)
                {
                    AddSimpleCriteria(x => x.Character.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID.ToString());

                }
                if (CharacterRoleID != null)
                {
                    AddSimpleCriteria(x => x.CharacterRole.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterRoleID.ToString());

                }

                if (CharacterRoleID1 != null && CharacterID1!=null)
                {
                    AddSimpleCriteria(x => x.CharacterRole.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterRoleID1.ToString());
                    AddSimpleCriteria(x => x.Character.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID1.ToString());

                   
                }
                q.And(x => x.IsDeleted == false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
