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
    public class CallInfo_Repository : IRERPRepositoryBaseSimpleFilter<CallInfo_Repository, CallInfo, CallInfoFilter>
    {
        public static IRERPVList<CallInfo, CallInfoFilter> GetAllCallInfo()
        {
            return GetVList(new CallInfoFilter() { });
        }
        public static CallInfo GetCallInfoByID(System.Guid CallInfoID)
        {
            var lst = GetVList(new CallInfoFilter() { CallInfoID = CallInfoID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IList<CallInfo> GetCallInfoByCallInfoTypeId<TParent>(Guid CallInfoTypeID)
       where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new CallInfoFilter() { CallInfoTypeID = CallInfoTypeID });

        }

        public static IList<CallInfo> GetCallInfoByCharacterId<TParent>(Guid CharacterID)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new CallInfoFilter() { CharacterID = CharacterID });


        }
        public static bool GetCallInfoByCallNumber(CallInfo self)
        {
            var filter = new CallInfoFilter() { CallNumber = self.CallNumber/*, CharacterID=self.Characters.id*/};
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
        public static IList<CallInfo> GetCallInfoByCallinfoIdANDCharacterID(Character ch, CallInfo ci)
        {
            var filter = new CallInfoFilter() { CallNumber1 = ci.CallNumber.Trim(),CharacterID1=ch.id};
        return GetVList(filter);

         
        }
        

        
    }
}
