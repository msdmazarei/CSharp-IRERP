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
    public class MessagingRelationType_Repository : IRERPRepositoryBaseSimpleFilter<MessagingRelationType_Repository, MessagingRelationType, MessagingRelationTypeFilter>
    {
        public static IRERPVList<MessagingRelationType, MessagingRelationTypeFilter> GetAllMessagingRelationType()
        {
            return GetVList(new MessagingRelationTypeFilter() { });
        }
        public static MessagingRelationType GetMessagingRelationTypeByID(System.Guid MessagingRelationTypeID)
        {
            var lst = GetVList(new MessagingRelationTypeFilter() { MessagingRelationTypeID = MessagingRelationTypeID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetMessagingInfoRelationTypeByName(MessagingRelationType self)
        {
            var filter = new MessagingRelationTypeFilter() { RelationName = self.RelationName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
      
    }
}
