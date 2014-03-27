using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class MessagingInfoFilter : IRERPFilter<MessagingInfoFilter,MessagingInfo>
    {
        public virtual System.Guid? MessagingInfoID { get; set; }
        public virtual System.Guid? MessaginIfoTypeID { get; set; }
        public virtual System.Guid? CharacterID { get; set; }

        public virtual System.Guid? MessaginInfoRelationTypeID { get; set; }
        public virtual string MessagingAddress { get;set;}
        
        public override NHibernate.IQueryOver<MessagingInfo,MessagingInfo> Query
        {
            get
            {
                var q = base.Query;
                if (MessagingInfoID != null)
                {
                    q.And((x => x.id == MessagingInfoID));
                }
                if (MessaginIfoTypeID != null)
                {
                    AddSimpleCriteria(x => x.MessagingInfoType.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, MessaginIfoTypeID.ToString());

                }
               
                if (CharacterID != null)
                {
                    AddSimpleCriteria(x => x.Character.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID.ToString());

                }
                if (MessaginInfoRelationTypeID != null)
                {
                    AddSimpleCriteria(x => x.MessagingRelationType.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, MessaginInfoRelationTypeID.ToString());

                }
                if (MessagingAddress != null)
                {
                    q.And((x => x.MessagingAddress == MessagingAddress));
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
