using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class LegalBranchFilter : IRERPFilter<LegalBranchFilter, LegalBranch>
    {
        public virtual System.Guid? LegalBranchID { get; set; }
        public virtual string Name { get; set; }
        public override NHibernate.IQueryOver<LegalBranch, LegalBranch> Query
        {
            get
            {
                var q = base.Query;
                if (LegalBranchID != null)
                {
                    q.And((x => x.id == LegalBranchID));
                }

                if (Name != null)
                {
                    AddSimpleCriteria(x => x.Name, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, Name);

                }
                q.And(x=>x.IsDeleted==false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
