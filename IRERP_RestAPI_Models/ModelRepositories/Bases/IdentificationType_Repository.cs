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
    public class IdentificationType_Repository : IRERPRepositoryBaseSimpleFilter<IdentificationType_Repository, IdentificationType, IdentificationTypeFilter>
    {
        public static IRERPVList<IdentificationType, IdentificationTypeFilter> GetAllIdentificationType()
        {
            return GetVList(new IdentificationTypeFilter() { });
        }
        public static IdentificationType GetIdentificationTypeByID(System.Guid IdentificationTypeID)
        {
            var lst = GetVList(new IdentificationTypeFilter() { IdentificationTypeID = IdentificationTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
    }
}
