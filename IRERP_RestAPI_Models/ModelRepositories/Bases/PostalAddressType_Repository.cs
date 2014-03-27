using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters.Bases;
using MsdLib.CSharp.DataVirtualization;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class PostalAddressType_Repository : IRERPRepositoryBaseSimpleFilter<PostalAddressType_Repository, PostalAddressType, PostalAddressTypeFilter>
    {
        public static IRERPVList<PostalAddressType, PostalAddressTypeFilter> GetAllPostalAddressType()
        {
            return GetVList(new PostalAddressTypeFilter() { });
        }
        public static PostalAddressType GetPostalAddressTypeByID(System.Guid PostalAddressTypeID)
        {
            var lst = GetVList(new PostalAddressTypeFilter() { PostalAddressTypeID = PostalAddressTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetPostalAddressTypeByName(PostalAddressType self)
        {
            var filter = new PostalAddressTypeFilter() { Name = self.Name };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
    }
}
