using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class NationalityFilter : IRERPFilter<NationalityFilter, Nationality>
    {
        public virtual System.Guid? NationalityID { get; set; }
        public virtual System.String  Name { get; set; }
        
        public override NHibernate.IQueryOver<Nationality, Nationality> Query
        {
            get
            {
                var q = base.Query;
                if (NationalityID != null)
                {
                    q.And((x => x.id == NationalityID));
                }
                if (Name != null)
                {
                    q.And((x => x.Name == Name));
                }
                q.And(x=>x.IsDeleted==false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
