using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI.Filters
{
    public class UserFilter : IRERPFilter<UserFilter, User>
    { 
        public UserFilter():base()
        {
            //For Nh Bug. -To-One Lazy load Problem -- with Property-Ref
           /* AdditionalJoinTables.Add(IRERPApplicationUtilities.GPN<User>(x => x.UserInformation));
            AdditionalJoinTables.Add(IRERPApplicationUtilities.GPN<User>(x => x.UserConnectionInfo));
            AdditionalJoinTables.Add(IRERPApplicationUtilities.GPN<User>(x => x.UserConnectionInfo.Service));

            AdditionalJoinTables.Add(IRERPApplicationUtilities.GPN<User>(x => x.UserInformation.House));
            AdditionalJoinTables.Add(IRERPApplicationUtilities.GPN<User>(x => x.UserInformation.Office));
            * */

        }
        public virtual string Email { get; set; }
        public virtual int? createdByUserId { get; set; }
        public virtual Guid? UserID { get; set; }
        public virtual Guid? BuildingID { get; set; }
        public virtual Guid? EquiptId { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual int? UsersUserID { get; set; }

        public override NHibernate.IQueryOver<User, User> Query
        {
            get
            {
                //var q = base.Query;


              
                    if (UserID != null)
                {
                    AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, UserID.ToString());

                }

               
            
               
                if (UsersUserID != null)
                {
                    AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, UsersUserID.ToString());
                }


                return base.Query;




            }
            set
            {
                base.Query = value;
            }
        }   
    }
}