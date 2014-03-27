using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters;
using MsdLib.CSharp.DataVirtualization;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.ModelRepositories.Bases;
using IRERP_RestAPI.Mappings.Bases;
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class Language_Repository : IRERPRepositoryBaseSimpleFilter<Language_Repository, Language, LanguageFilter>
    {
        public static Language GetLanguageByID(System.Guid LanguageID)
        {
            var lst = GetVList(new LanguageFilter() { LanguageID = LanguageID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IRERPVList<Language, LanguageFilter> GetAllLanguage()
        {
            return GetVList(new LanguageFilter() { });
        }
        public static bool GetLanguageByName(Language self)
        {
            var filter = new LanguageFilter() { LanguageName = self.LanguageName };
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }

        
    }
}
