using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
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
    public class LegalCharacterType_Repository : IRERPRepositoryBaseSimpleFilter<LegalCharacterType_Repository, LegalCharacterType, LegalCharacterTypeFilter>
    {
        public static IRERPVList<LegalCharacterType, LegalCharacterTypeFilter> GetAllLegalCharacterType()
        {
            return GetVList(new LegalCharacterTypeFilter() { });
        }
        public static LegalCharacterType GetLegalCharacterTypeByID(System.Guid LegalCharacterTypeID)
        {
            var lst = GetVList(new LegalCharacterTypeFilter() { LegalCharacterTypeID = LegalCharacterTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetLegalCharacterTypeByName(LegalCharacterType self)
        {
            var filter = new LegalCharacterTypeFilter() { Name = self.Name };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
    }
}
