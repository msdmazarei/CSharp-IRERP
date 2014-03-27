using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class HelpFilter : IRERPFilter<HelpFilter, Help>
    {
        public virtual System.Guid? HelpID { get; set; }
        public virtual string  key { get; set; }
        public virtual System.Guid? LanguageID { get; set; }
        public override NHibernate.IQueryOver<Help, Help> Query
        {
            get
            {
                var q = base.Query;
                if (HelpID != null)
                {
                    AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, HelpID.ToString());
                }
                if (key != null)
                {
                    AddSimpleCriteria(x => x.HelpKey, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, key.ToString());
                }
                if (LanguageID != null)
                {
                    AddSimpleCriteria(x => x.Language.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, LanguageID.ToString());
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
