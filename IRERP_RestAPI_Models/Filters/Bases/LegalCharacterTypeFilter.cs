using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class LegalCharacterTypeFilter : IRERPFilter<LegalCharacterTypeFilter, LegalCharacterType>
    {
        public virtual System.Guid? LegalCharacterTypeID { get; set; }
        public virtual string Name { get; set; }

        public override NHibernate.IQueryOver<LegalCharacterType, LegalCharacterType> Query
        {
            get
            {
                var q = base.Query;
                if (LegalCharacterTypeID != null)
                {
                    q.And((x => x.id == LegalCharacterTypeID));
                }

                if (Name != null)
                {
                    AddSimpleCriteria(x => x.Name, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, Name.ToString());

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
