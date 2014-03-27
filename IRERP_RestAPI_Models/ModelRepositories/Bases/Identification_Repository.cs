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
    public class Identification_Repository : IRERPRepositoryBaseSimpleFilter<Identification_Repository, Identification, IdentificationFilter>
    {
        public static IRERPVList<Identification, IdentificationFilter> GetAllIdentification()
        {
            return GetVList(new IdentificationFilter() { });
        }
        public static Identification GetIdentificationByID(System.Guid IdentificationID)
        {
            var lst = GetVList(new IdentificationFilter() { IdentificationID = IdentificationID });
            if (lst.Count > 0) return lst[0];
            return null;
        }


        public static IList<Identification> GetIdentificationByCharacterId<TParent>(Guid CharacterID)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new IdentificationFilter() { CharacterID = CharacterID });


        }
    }
}
