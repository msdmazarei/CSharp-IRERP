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
    public class CharacterRole_Repository : IRERPRepositoryBaseSimpleFilter<CharacterRole_Repository, CharacterRole, CharacterRoleFilter>
    {
        public static IRERPVList<CharacterRole, CharacterRoleFilter> GetAllCharacterRole()
        {
            return GetVList(new CharacterRoleFilter() { });
        }
        public static CharacterRole GetCharacterRoleByID(System.Guid CharacterRoleID)
        {
            var lst = GetVList(new CharacterRoleFilter() { CharacterRoleID = CharacterRoleID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static bool GetCharacterRoleByCharacterRoleName(CharacterRole self)
        {
            var filter = new CharacterRoleFilter() { RoleName = self.RoleName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
        public static CharacterRole GetCharacterRoleByCharacterRoleName(string  RoleName)
        {
            var filter = new CharacterRoleFilter() { RoleName = RoleName.Trim() };
            if (GetVList(filter).Count > 0)
            {
                var rtn = GetVList(filter).First();
                return rtn;
            }
            else
                return null;
        }
    }
}
