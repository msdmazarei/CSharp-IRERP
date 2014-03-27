using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters;
using IRERP_RestAPI.Models;
using IRERP_RestAPI_Models.Filters;
using MsdLib.CSharp.DataVirtualization;
using NHibernate;

namespace IRERP_RestAPI.ModelRepositories
{
    public class UserRepository : IRERPRepositoryBaseSimpleFilter<UserRepository, User, UserFilter>
    {
        public static User ByPK(Guid id)
        {
            return GetUserById(id);
        }
 //TODO:Get user By ResellerId
        public static User GetResellerUserByUserID(int userID)
        {
            return null;
        }
        //public static IList<User> g()
        //{
        //    var filter = new UserFilter();
        //    filter.AddSimpleCriteria(x => x.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.greaterThan, "5000");
        //    filter.AddSimpleCriteria(x => x.CreatedOnDate, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.greaterThan, DateTime.Now.AddDays(-1000).ToString());
        //    filter.Orders.Add(new MsdLib.CSharp.BLLCore.OrderBy(){ PropertyName = 
        //       );
        //    return GetVLis(filter);

         
        //}

        public static User GetUserById(Guid UserId)
        {
            IRERP_RestAPI.Bases.Security.IRERPSecurity.isMethodAccessable(
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                System.Reflection.MethodBase.GetCurrentMethod()
                ,true,
                UserId);

          return First(new UserFilter() { UserID = UserId });
            
        }

        public static IList<User> GetUsersByBuildId<TParent>(Guid BuildingID)
            where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new UserFilter() { BuildingID = BuildingID });
           
        }
        public static IList<User> GetUsersByEquiptId<TParent>(Guid EquiptID)
        where TParent : MsdLib.CSharp.DALCore.ModelBase
        {
            return GetVList<TParent>(new UserFilter() { EquiptId = EquiptID });

        }

        public static User GetUserByEquiptId(Guid equiptID)
        {


            var rtn = GetVList(new UserFilter() { EquiptId = equiptID });
            if (rtn.Count > 0)
                return rtn[0];
            else
                return null;

          
        }
        public static User GetUserByBuildId(Guid BuildingID)
        {


            var rtn = GetVList(new UserFilter() { BuildingID = BuildingID });
            if (rtn.Count > 0)
                return rtn[0];
            else
                return null;

            //User rtn = new User();
            //var lst = rtn.Session.QueryOver<User>().Where(x => x.id == UserId).List();
            //if (lst.Count > 0) return lst[0];
            //return null;
        }
        public static User GetUserByCreatedByUserId(int CreatedByUserId)
        {

            User rtn = null;
            var lst =
                GetVList(new UserFilter() { createdByUserId = CreatedByUserId });
            if (lst.Count > 0) rtn = lst[0];
            return rtn;
        }

        public static User GetUserByUserNameAndPassword(string UserName, string Password)
        {
            UserFilter filter = new UserFilter();
            filter.AddSimpleCriteria(x => x.Username, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, UserName);
            filter.AddSimpleCriteria(x => x.Password, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, Password);
            filter.AddSimpleCriteria(x => x.IsDeleted,  MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,false.ToString());
            return First(filter);
              
        }
        //public static IRERPVList<User, UserFilter> GetAllUsers_ForSupport()
        //{
        //    var filter = new UserFilter();
        //    filter.AdditionalJoinTables.Add(IRERP_RestAPI.Bases.IRERPApplicationUtilities.GPN<User>(x => x.UserConnectionInfo));
        //    return GetVList(filter);
        //}
        public static IRERPVList<User, UserFilter> GetAllUsers()
        {
            return GetVList(new UserFilter());


        
        }


      
     

     

    }
}