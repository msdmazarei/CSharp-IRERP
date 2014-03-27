using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters.Bases;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;

namespace IRERP_RestAPI.ModelRepositories.Bases
{
  public  class Charactertype_Repository : IRERPRepositoryBaseSimpleFilter<Charactertype_Repository, Charactertype, CharactertypeFilter>
    {
      
      public static IRERPVList<Charactertype, CharactertypeFilter> GetAllCharacterType()
        {
            return GetVList(new CharactertypeFilter());
        }
      public static Charactertype GetCharacterTypeByID(Guid id)
        {
            return First(new CharactertypeFilter() { ID = id });

        }
      public static bool GetCharacterTypeByCharacterTypeName(Charactertype self)
      {
          var filter = new CharactertypeFilter() { Charactertypename = self.Charactertypename };
          filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
          var rtn = GetVList(filter);

          return rtn.Count == 0;
      }
    }
}
