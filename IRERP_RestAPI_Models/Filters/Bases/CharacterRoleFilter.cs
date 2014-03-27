using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class CharacterRoleFilter : IRERPFilter<CharacterRoleFilter, CharacterRole>
    {
        public virtual System.Guid? CharacterRoleID { get; set; }
        public virtual string RoleName {get;set; }
        public override NHibernate.IQueryOver<CharacterRole, CharacterRole> Query
        {
            get
            {
                var q = base.Query;
                if (CharacterRoleID != null)
                {
                    q.And((x => x.id == CharacterRoleID));
                }
                if (RoleName != null)
                {
                    q.And((x => x.RoleName == RoleName));
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
