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
    public class RightFulCharacter_Repository : IRERPRepositoryBaseSimpleFilter<RightFulCharacter_Repository, RightFulCharacter, RightFulCharacterFilter>
    {
        public static IRERPVList<RightFulCharacter, RightFulCharacterFilter> GetAllRightFulCharacter()
        {
            return GetVList(new RightFulCharacterFilter() { });
        }
        public static RightFulCharacter GetRightFulCharacterByID(System.Guid RightFulCharacterID)
        {
            var lst = GetVList(new RightFulCharacterFilter() { RightFulCharacterID = RightFulCharacterID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IList<RightFulCharacter> GetAllRightFullCharacterByGenderId<TParent>(Guid GenderID)
      where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new RightFulCharacterFilter() { GenderID = GenderID });

        }

        public static bool GetRightFulCharacterByFName(RightFulCharacter self)
        {
            var filter = new RightFulCharacterFilter() { FName = self.Fname };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        public static bool GetRightFulCharacterByLName(RightFulCharacter self)
        {
            var filter = new RightFulCharacterFilter() { LName = self.LName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        public static bool GetRightFulCharacterByChracterName(RightFulCharacter self)
        {
            var filter = new RightFulCharacterFilter() { NickName = self.Character.NickName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }


        public static bool GetRightFulCharacterByNatinalCode(RightFulCharacter self)
        {
            var filter = new RightFulCharacterFilter() { NationalCode = self.NationalCode };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
        public static bool Valid_NationalCode(RightFulCharacter self)
        {
            var filter = new RightFulCharacterFilter() { NationalCode = self.NationalCode };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;

        }
        public static IList<RightFulCharacter> GetAllRanzerMan()
        {
            var filter = new RightFulCharacterFilter();
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.RoleName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, "رانژه کار");
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

            return GetVList(filter);
        }
        public static IList<RightFulCharacter> GetAllallManager()
        {
            var filter = new RightFulCharacterFilter();
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.RoleName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, "مدیر بخش فنی");
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

            return GetVList(filter);
        }
        public static IList<RightFulCharacter> GetAllMarketer()
        {
            var filter = new RightFulCharacterFilter();
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.RoleName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, "بازاریاب");
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].CharacterRole.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.Character.RolsOfCharacter[0].IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());
            filter.AddSimpleCriteria(x => x.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

            return GetVList(filter);
        }
        
    }
}
