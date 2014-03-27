using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;

namespace IRERP_RestAPI.Filters.Bases
{
   public  class CharactertypeFilter : IRERPFilter<CharactertypeFilter, Charactertype>
    {
        public virtual Guid? ID { get; set; }
        public virtual string Charactertypename { get; set; }
        public override NHibernate.IQueryOver<Charactertype, Charactertype> Query
        {
            get
            {
                var q = base.Query;
                if (ID != null)
                {
                    AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, ID.ToString());

                   // q.And(x => x.id == id);
                }
                if (Charactertypename != null)
                {
                    q.And((x => x.Charactertypename == Charactertypename));
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
