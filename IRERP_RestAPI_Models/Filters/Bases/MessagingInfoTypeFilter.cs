using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class MessagingInfoTypeFilter : IRERPFilter<MessagingInfoTypeFilter, MessagingInfoType>
    {
        public virtual System.Guid? MessagingInfoTypeID { get; set; }
        public virtual string  MessagingInfoTypeName { get; set; }
        
        public override NHibernate.IQueryOver<MessagingInfoType, MessagingInfoType> Query
        {
            get
            {
                var q = base.Query;
                if (MessagingInfoTypeID != null)
                {
                    q.And((x => x.id == MessagingInfoTypeID));
                }
                if (MessagingInfoTypeName != null)
                {
                    q.And((x => x.MessagingType == MessagingInfoTypeName));
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
