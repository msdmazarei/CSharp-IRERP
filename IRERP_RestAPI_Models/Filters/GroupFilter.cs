using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using MsdLib.CSharp.BLLCore;

namespace IRERP_RestAPI_Models.Filters
{
    public class GroupFilter : IRERPFilter<GroupFilter, Group>
    {
        public virtual int? userid { get; set; }
        public virtual Guid? Groupid { get; set; }
        public override NHibernate.IQueryOver<Group, Group> Query
        {
            get
            {
                var q =  base.Query;

                if (userid != null)
                {
                    MsdCriteria crit = new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<Group>(x => x._____GroupUsers[0]._____User.id),
                        Operator = MsdCriteriaOperator.equals,
                        value = userid.ToString()
                    };
                    this.Criterias.Add(crit);
                }
                if (Groupid != null)
                    q.And(x => x.id == Groupid);
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
