using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class IdentificationTypeFilter : IRERPFilter<IdentificationTypeFilter, IdentificationType>
    {
        public virtual System.Guid? IdentificationTypeID { get; set; }
        public override NHibernate.IQueryOver<IdentificationType, IdentificationType> Query
        {
            get
            {
                var q = base.Query;
                if (IdentificationTypeID != null)
                {
                    q.And((x => x.id == IdentificationTypeID));
                }
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
