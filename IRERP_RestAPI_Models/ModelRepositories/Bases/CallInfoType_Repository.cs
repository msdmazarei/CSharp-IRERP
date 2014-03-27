using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.DataVirtualization;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class CallInfoType_Repository : IRERPRepositoryBaseSimpleFilter<CallInfoType_Repository, CallInfoType, CallInfoTypeFilter>
    {
        public static IRERPVList<CallInfoType, CallInfoTypeFilter> GetAllCallInfoType()
        {
            return GetVList(new CallInfoTypeFilter() { });
        }
        public static CallInfoType GetCallInfoTypeByID(System.Guid CallInfoTypeID)
        {
            var lst = GetVList(new CallInfoTypeFilter() { CallInfoTypeID = CallInfoTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static bool GetCallInfoTypeByName(CallInfoType self)
        {
            var filter = new CallInfoTypeFilter() { CallInfoTypeName = self.TypeName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
      
    }
}
