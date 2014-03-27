using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class CallInfoFilter : IRERPFilter<CallInfoFilter, CallInfo>
    {
        public virtual System.Guid? CallInfoID { get; set; }
        public virtual System.Guid? CallInfoTypeID { get; set; }

        public virtual System.Guid? CharacterID { get; set; }
        public virtual string CallNumber {get;set;}


        public virtual System.Guid? CharacterID1 { get; set; }
        public virtual string CallNumber1 { get; set; }
        public override NHibernate.IQueryOver<CallInfo, CallInfo> Query
        {
            get
            {
                var q = base.Query;
                if (CallInfoID != null)
                {
                    q.And((x => x.id == CallInfoID));
                }
                if (CallInfoTypeID != null)
                {
                    AddSimpleCriteria(x => x.CallInfoType.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CallInfoTypeID.ToString());

                }
                if (CharacterID != null)
                {
                    AddSimpleCriteria(x => x.Characters.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID.ToString());
                }
                if (CallNumber != null)
                {
                    q.And((x => x.CallNumber == CallNumber));
                }
                if (CharacterID1 != null && CallNumber1 != null)
                {
                    AddSimpleCriteria(x => x.Characters.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID1.ToString());
                    AddSimpleCriteria(x => x.CallNumber, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CallNumber1.ToString());

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
