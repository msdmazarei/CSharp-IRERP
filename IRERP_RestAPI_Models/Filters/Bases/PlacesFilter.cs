using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class PlacesFilter : IRERPFilter<PlacesFilter, Places>
    {
        public virtual System.Guid? PlacesID { get; set; }
        public virtual string LocationName { get; set; }
        public override NHibernate.IQueryOver<Places, Places> Query
        {
            get
            {
                var q = base.Query;
                if (PlacesID != null)
                {
                    q.And((x => x.id == PlacesID));
                }

                if (LocationName != null)
                {
                    AddSimpleCriteria(x => x.LocationName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, LocationName);

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
