using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters.Bases;
using MsdLib.CSharp.DataVirtualization;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class LegalBranch_Repository : IRERPRepositoryBaseSimpleFilter<LegalBranch_Repository, LegalBranch, LegalBranchFilter>
    {
        public static IRERPVList<LegalBranch, LegalBranchFilter> GetAllLegalBranch()
        {
            return GetVList(new LegalBranchFilter() { });
        }
        public static LegalBranch GetLegalBranchByID(System.Guid LegalBranchID)
        {
            var lst = GetVList(new LegalBranchFilter() { LegalBranchID = LegalBranchID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetLegalBranchByName(LegalBranch self)
        {
            var filter = new LegalBranchFilter() { Name = self.Name };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
    }
}
