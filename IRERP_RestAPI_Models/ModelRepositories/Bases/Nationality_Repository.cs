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
    public class Nationality_Repository : IRERPRepositoryBaseSimpleFilter<Nationality_Repository, Nationality, NationalityFilter>
    {
        public static IRERPVList<Nationality, NationalityFilter> GetAllNationality()
        {
            return GetVList(new NationalityFilter() { });
        }
        public static Nationality GetNationalityByID(System.Guid NationalityID)
        {
            var lst = GetVList(new NationalityFilter() { NationalityID = NationalityID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static bool GetNationalityByName(Nationality self)
        {
            var filter = new NationalityFilter() { Name = self.Name/*, CharacterID=self.Characters.id*/};
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
     
        
    }
}
