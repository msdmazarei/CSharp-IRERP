using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI_Models.Filters
{
   public  class GroupMenuFilter : IRERPFilter<GroupMenuFilter, GroupMenu>
    {
       public virtual Guid? GroupManagerId { get; set; }
        public override NHibernate.IQueryOver<GroupMenu, GroupMenu> Query
        {
            get
            {
                var q = base.Query;
                if (GroupManagerId != null)
                    q.And(x => x.id == GroupManagerId);
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
