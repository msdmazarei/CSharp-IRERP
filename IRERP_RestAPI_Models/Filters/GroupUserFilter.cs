using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI_Models.Filters
{
    public class GroupUserFilter : IRERPFilter<GroupUserFilter, GroupUser>
    {
        public virtual Guid? UserGroupID { get; set; }
        public virtual int? UserId { get; set; }
        public override NHibernate.IQueryOver<GroupUser, GroupUser> Query
        {
            get
            {
                var q =  base.Query;
                if (UserGroupID != null)
                    q.And(x => x.id == UserGroupID);
                if (UserId != null)
                    this.Criterias.Add(new MsdLib.CSharp.BLLCore.MsdCriteria() 
                    { 
                        fieldName = GPN(x => ((GroupUser)x).User.id), 
                        Operator = MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, 
                        value = UserId.ToString() 
                    });

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
