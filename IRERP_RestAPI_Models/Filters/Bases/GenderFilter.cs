using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class GenderFilter : IRERPFilter<GenderFilter, Gender>
    {
        public virtual System.Guid? GenderID { get; set; }
        public virtual string GenderName { get; set; }
        public override NHibernate.IQueryOver<Gender, Gender> Query
        {
            get
            {
                var q = base.Query;
                if (GenderID != null)
                {
                    q.And((x => x.id == GenderID));
                }
                if (GenderName != null)
                {
                    q.And((x => x.GenderName == GenderName));
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
