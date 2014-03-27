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
    public class PriceAdditionType_Repository : IRERPRepositoryBaseSimpleFilter<PriceAdditionType_Repository, PriceAdditionType, PriceAdditionTypeFilter>
    {
        public static IRERPVList<PriceAdditionType, PriceAdditionTypeFilter> GetAllPriceAdditionType()
        {
            return GetVList(new PriceAdditionTypeFilter() { });
        }
        public static PriceAdditionType GetPriceAdditionTypeByID(System.Guid PriceAdditionTypeID)
        {
            var lst = GetVList(new PriceAdditionTypeFilter() { PriceAdditionTypeID = PriceAdditionTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetPriceAdditionByName(PriceAdditionType self)
        {
            var filter = new PriceAdditionTypeFilter() { Name = self.Name };

            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());

            var lst = GetVList(filter);
            return lst.Count == 0;




        }
    }
}
