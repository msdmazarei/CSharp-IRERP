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
    public class PostalAddress_Repository : IRERPRepositoryBaseSimpleFilter<PostalAddress_Repository, PostalAddress, PostalAddressFilter>
    {
        public static IRERPVList<PostalAddress, PostalAddressFilter> GetAllPostalAddress()
        {
            return GetVList(new PostalAddressFilter() { });
        }
        public static PostalAddress GetPostalAddressByID(System.Guid PostalAddressID)
        {
            var lst = GetVList(new PostalAddressFilter() { PostalAddressID = PostalAddressID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
         public static IList<IRERP_RestAPI.Models.Bases.PostalAddress> GetAllPostalAddressByPostalAddressTypeId<TParent>(Guid PostalAddressTypeID)
       where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new PostalAddressFilter() { PostalAddressTypeID = PostalAddressTypeID });

        }
         public static IList<IRERP_RestAPI.Models.Bases.PostalAddress> GetAllPostalAddressByCharacterId<TParent>(Guid CharacterID)
     where TParent : MsdLib.CSharp.DALCore.ModelBase
         {
             return GetVList<TParent>(new PostalAddressFilter() { CharacterID = CharacterID });

         }
         public static bool GetPostalAddressByAddress(PostalAddress self)
        {
            var filter = new PostalAddressFilter() { GetPostalAddressByAddress = self.Address };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

         public static bool GetPostalAddressByPostalCode(PostalAddress self)
        {
            var filter = new PostalAddressFilter() { PostalCode = self.PostalCode };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

         public static IList<PostalAddress> GetPostalAddressByPostalAddressIdANDCharacterID(Character ch, PostalAddress ci)
        {
            var filter = new PostalAddressFilter() { PostalCode1 = ci.PostalCode, CharacterID1 = ch.id };
        return GetVList(filter);

         
        }
    }
}
