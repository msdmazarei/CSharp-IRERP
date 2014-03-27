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
    public class Gender_Repository : IRERPRepositoryBaseSimpleFilter<Gender_Repository, Gender, GenderFilter>
    {
        public static IRERPVList<Gender, GenderFilter> GetAllGender()
        {
            return GetVList(new GenderFilter() { });
        }
        public static Gender GetGenderByID(System.Guid GenderID)
        {
            var lst = GetVList(new GenderFilter() { GenderID = GenderID });
            if (lst.Count > 0) return lst[0];
            return null;
        }

        public static bool GetGenderByGenderName(Gender self)
        {
            var filter = new GenderFilter() { GenderName = self.GenderName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
    }
}
