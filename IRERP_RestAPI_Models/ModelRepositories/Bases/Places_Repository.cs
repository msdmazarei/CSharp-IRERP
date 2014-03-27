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
    public class Places_Repository : IRERPRepositoryBaseSimpleFilter<Places_Repository, Places, PlacesFilter>
    {
        public static IRERPVList<Places, PlacesFilter> GetAllPlaces()
        {
            return GetVList(new PlacesFilter() { });
        }
        public static Places GetPlacesByID(System.Guid PlacesID)
        {
            var lst = GetVList(new PlacesFilter() { PlacesID = PlacesID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool Valid_LocationName(Places self)
        {
            var filter = new PlacesFilter() { LocationName = self.LocationName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;

        }
    }
}
