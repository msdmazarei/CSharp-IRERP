using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Filters;
using MsdLib.CSharp.DataVirtualization;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Filters.Bases;
using IRERP_RestAPI.Bases.DataVirtualization;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class RolsOfCharacter_Repository : IRERPRepositoryBaseSimpleFilter<RolsOfCharacter_Repository, RolsOfCharacter, RolsOfCharacterFilter>
    {
        public static IRERPVList<RolsOfCharacter, RolsOfCharacterFilter> GetAllRolsOfCharacter()
        {
            return GetVList(new RolsOfCharacterFilter() { });
        }
        public static RolsOfCharacter GetRolsOfCharacterByID(System.Guid RolsOfCharacterID)
        {
            var lst = GetVList(new RolsOfCharacterFilter() { RolsOfCharacterID = RolsOfCharacterID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IList<RolsOfCharacter> GetAllRolesOfCharacterByCharacterId<TParent>(Guid CharacterID)
      where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            
            
            return GetVList<TParent>(new RolsOfCharacterFilter() { CharacterID = CharacterID });

        }
        public static IList<RolsOfCharacter> GetAllRolesOfCharacterByCharacterRoleId<TParent>(Guid CharacterRoleID)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {


            return GetVList<TParent>(new RolsOfCharacterFilter() { CharacterRoleID = CharacterRoleID });

        }
        public static IList<RolsOfCharacter> GetRolsOfCharacterByCharacterANDRols<TParent>(Character ch,RolsOfCharacter rc)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {


            return GetVList<TParent>(new RolsOfCharacterFilter() { CharacterID1 = ch.id,CharacterRoleID1=rc.CharacterRole.id });

        }
        
    }
}
