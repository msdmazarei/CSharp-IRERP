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
    public class MessagingInfoType_Repository : IRERPRepositoryBaseSimpleFilter<MessagingInfoType_Repository, MessagingInfoType, MessagingInfoTypeFilter>
    {
        public static IRERPVList<MessagingInfoType, MessagingInfoTypeFilter> GetAllMessagingInfoType()
        {
            return GetVList(new MessagingInfoTypeFilter() { });
        }
        public static MessagingInfoType GetMessagingInfoTypeByID(System.Guid MessagingInfoTypeID)
        {
            var lst = GetVList(new MessagingInfoTypeFilter() { MessagingInfoTypeID = MessagingInfoTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        
               public static bool GetMessagingInfoTypeByName(MessagingInfoType self)
        {
            var filter = new MessagingInfoTypeFilter() { MessagingInfoTypeName = self.MessagingType };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
    }
}
