using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class PriceAdditionTypeFilter : IRERPFilter<PriceAdditionTypeFilter, PriceAdditionType>
    { 
        public virtual System.Guid? PriceAdditionTypeID { get; set; }
        public virtual string Name { get; set; }

        public override NHibernate.IQueryOver<PriceAdditionType, PriceAdditionType> Query
        {
            get
            {
                var q = base.Query;
                if (PriceAdditionTypeID != null)
                {
                    q.And((x => x.id == PriceAdditionTypeID));
                }

                if (Name != null)
                {
                    AddSimpleCriteria(x => x.Name, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, Name);
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
