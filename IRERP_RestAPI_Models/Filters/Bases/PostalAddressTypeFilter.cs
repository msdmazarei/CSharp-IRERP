using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class PostalAddressTypeFilter : IRERPFilter<PostalAddressTypeFilter, PostalAddressType>
    {
        public virtual Guid? PostalAddressTypeID { get; set; }
        public virtual string Name { get; set; }

        public override NHibernate.IQueryOver<PostalAddressType, PostalAddressType> Query
        {
            get
            {
                var q = base.Query;
                if (PostalAddressTypeID != null)
                {
                    q.And((x => x.id == PostalAddressTypeID));
                }

                if (Name != null)
                {
                    AddSimpleCriteria(x => x.Name, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, Name.ToString());

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
