using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.Bases
{
    public class MessagingRelationTypeFilter : IRERPFilter<MessagingRelationTypeFilter, MessagingRelationType>
    {
        public virtual System.Guid? MessagingRelationTypeID { get; set; }
        public virtual string RelationName { get; set; }
        public override NHibernate.IQueryOver<MessagingRelationType, MessagingRelationType> Query
        {
            get
            {
                var q = base.Query;
                if (MessagingRelationTypeID != null)
                {
                    q.And((x => x.id == MessagingRelationTypeID));
                }
                if (RelationName != null)
                {
                    AddSimpleCriteria(x => x.RelationName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, RelationName);

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
