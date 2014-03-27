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
    public class MessagingInfo_Repository : IRERPRepositoryBaseSimpleFilter<MessagingInfo_Repository, IRERP_RestAPI.Models.Bases.MessagingInfo, IRERP_RestAPI.Filters.Bases.MessagingInfoFilter>
    {
        public static IRERPVList<IRERP_RestAPI.Models.Bases.MessagingInfo,IRERP_RestAPI.Filters.Bases.MessagingInfoFilter > GetAllMessagingInfo()
        {
            return GetVList(new IRERP_RestAPI.Filters.Bases.MessagingInfoFilter() { });
        }
        public static IRERP_RestAPI.Models.Bases.MessagingInfo GetMessagingInfoByID(System.Guid MessagingInfoID)
        {
            var lst = GetVList(new IRERP_RestAPI.Filters.Bases.MessagingInfoFilter() { MessagingInfoID = MessagingInfoID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IList<IRERP_RestAPI.Models.Bases.MessagingInfo> GetAllMessaginInfoByMessagingInfoTypeId<TParent>(Guid MessaginIfoTypeID)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new IRERP_RestAPI.Filters.Bases.MessagingInfoFilter() { MessaginIfoTypeID = MessaginIfoTypeID });

        }
        public static IList<IRERP_RestAPI.Models.Bases.MessagingInfo> GetAllMessaginInfoByCharacterID<TParent>(Guid CharacterID)
      where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new IRERP_RestAPI.Filters.Bases.MessagingInfoFilter() { CharacterID = CharacterID });

        }

        public static IList<IRERP_RestAPI.Models.Bases.MessagingInfo> GetAllMessaginInfoByMessagingInfoRelationTypeId<TParent>(Guid MessaginInfoRelationTypeID)
      where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new IRERP_RestAPI.Filters.Bases.MessagingInfoFilter() { MessaginInfoRelationTypeID = MessaginInfoRelationTypeID });

        }
        public static bool GetMessagingInfoByMessaginAddress(MessagingInfo self)
        {
            var filter = new MessagingInfoFilter() { MessagingAddress = self.MessagingAddress };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
     
        
        

    }
}
