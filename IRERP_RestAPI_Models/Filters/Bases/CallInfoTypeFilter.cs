using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class CallInfoTypeFilter : IRERPFilter<CallInfoTypeFilter, CallInfoType>
    {
        public virtual Guid? CallInfoTypeID { get; set; }
        public virtual Guid? CallInfoID { get; set; }
        public virtual string CallInfoTypeName { get; set; }
        
        public override NHibernate.IQueryOver<CallInfoType, CallInfoType> Query
        {
            get
            {
                var q = base.Query;
                if (CallInfoTypeID != null)
                {
                    q.And((x => x.id == CallInfoTypeID));
                }
                if (CallInfoTypeName != null)
                {
                    q.And((x => x.TypeName == CallInfoTypeName));
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
