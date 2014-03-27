using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Models;
using IRERP_RestAPI_Models.Filters;
using MsdLib.CSharp.DataVirtualization;
using MsdLib.CSharp.DALCore;

namespace IRERP_RestAPI.ModelRepositories
{
    public class GroupUser_Repository : IRERPRepositoryBaseSimpleFilter<GroupUser_Repository, GroupUser,GroupUserFilter>
    {
        public static IRERPVList<GroupUser, GroupUserFilter> GetAllGroupUser()
        {
            return GetVList(new GroupUserFilter());
        }

        public static GroupUser GetGroupUserByID(Guid GroupUserID)
        {

            GroupUser rtn = null;
            var lst =
                GetVList(new GroupUserFilter() { UserGroupID = GroupUserID, });
            if (lst.Count > 0) rtn = lst[0];
            return rtn;
            ////TODO: need to correction,UserMarafAction
            //GroupUser rtn = new GroupUser();
            //var lst = rtn.Session.QueryOver<GroupUser>().Where(x => x.id == GroupUserID).List();
            //if (lst.Count > 0) return lst[0];
            //return null;
        }
        public static IList<GroupUser> GetByUserId<TParent>(int Userid)
            where TParent:ModelBase
        {
            return GetVList<TParent>(new GroupUserFilter() { UserId = Userid });
        }
        public static IList<GroupUser> GetByUserId(int Userid)
        {
            return GetVList(new GroupUserFilter() { UserId = Userid });
        }



    }
}
