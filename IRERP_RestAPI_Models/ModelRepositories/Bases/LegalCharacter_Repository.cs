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
    public class LegalCharacter_Repository : IRERPRepositoryBaseSimpleFilter<LegalCharacter_Repository, LegalCharacter, LegalCharacterFilter>
    {
        public static IRERPVList<LegalCharacter, LegalCharacterFilter> GetAllLegalCharacter()
        {
            return GetVList(new LegalCharacterFilter() { });
        }
        public static LegalCharacter GetLegalCharacterByID(System.Guid LegalCharacterID)
        {
            var lst = GetVList(new LegalCharacterFilter() { LegalCharacterID = LegalCharacterID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static IList<LegalCharacter> GetlegalCharachterByBranchId<TParent>(Guid BranchId)
       where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new LegalCharacterFilter() { BranchId = BranchId });

        }


        public static IList<LegalCharacter> GetlegalCharachterByLegalCharacterTypeId<TParent>(Guid LegalCharacterTypeId)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new LegalCharacterFilter() { LegalCharacterTypeId = LegalCharacterTypeId });

        }

        public static IList<LegalCharacter> GetlegalCharachterByPlacesId<TParent>(Guid PlacesId)
 where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new LegalCharacterFilter() { PlacesId = PlacesId });

        }



        public static IList<LegalCharacter> GetlegalCharachterByCharacterId<TParent>(Guid CharacterId)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new LegalCharacterFilter() { CharacterId = CharacterId });

        }


        public static bool GetLegalCharacterByEconomicNumber(LegalCharacter self)
        {
            var filter = new LegalCharacterFilter() { EconomicNumber = self.EconomicNumber };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        public static bool GetLegalCharacterByRegistrationNumber(LegalCharacter self)
        {
            var filter = new LegalCharacterFilter() { RegistrationNumber = self.RegistrationNumber };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        public static bool GetLegalCharacterByNationalIdentifier(LegalCharacter self)
        {
            var filter = new LegalCharacterFilter() { NationalIdentifier = self.NationalIdentifier };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        public static bool GetLegalCharacterByCharacterName(LegalCharacter self)
        {
            var filter = new LegalCharacterFilter() { NickName = self.Characters.NickName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
        
    }
}
