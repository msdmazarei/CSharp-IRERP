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
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.ModelRepositories.Bases
{
    public class Help_Repository : IRERPRepositoryBaseSimpleFilter<Help_Repository, Help, HelpFilter>
    {
        public static Help GetHelpByID(System.Guid HelpID)
        {
            var lst = GetVList(new HelpFilter() { HelpID = HelpID });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        public static IRERPVList<Help, HelpFilter> GetAllHelp()
        {
            return GetVList(new HelpFilter() { });
        }
        public static bool GetHelpByKey(Help self)
        {
            var filter = new HelpFilter() { key=self.HelpKey};
            filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.notEqual, self.id.ToString());
            var rtn = GetVList(filter);

            return rtn.Count == 0;
        }
        public static Help GetHelpByKey(string key)
        {
            var lst = GetVList(new HelpFilter() { key = key });
            if (lst.Count > 0) return lst[0];
            return null;
        }
        
        public static IList<Help> GetAllHelpsByLanguageID<TParent>(System.Guid LanguageID)
where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new HelpFilter() { LanguageID = LanguageID });
        }
    }
}
