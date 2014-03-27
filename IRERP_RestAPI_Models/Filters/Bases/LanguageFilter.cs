using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.ModelRepositories.Bases;
using IRERP_RestAPI.Mappings.Bases;
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class LanguageFilter : IRERPFilter<LanguageFilter, Language>
    {
        public virtual System.Guid? LanguageID { get; set; }
        public virtual string LanguageName { get; set; }
        
        public override NHibernate.IQueryOver<Language, Language> Query
        {
            get
            {
                var q = base.Query;
                if (LanguageID != null)
                {
                    q.And((x => x.id == LanguageID));
                }
                if (LanguageName != null)
                {
                    q.And((x => x.LanguageName == LanguageName));
                }
                q.And(x => x.IsDeleted == false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
