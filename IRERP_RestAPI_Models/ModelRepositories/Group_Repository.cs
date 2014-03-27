using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters;
using IRERP_RestAPI.Models;
using IRERP_RestAPI_Models.Filters;
using MsdLib.CSharp.DataVirtualization;

namespace IRERP_RestAPI.ModelRepositories
{
    public class Group_Repository : IRERPRepositoryBaseSimpleFilter<Group_Repository, Group, GroupFilter>
    {
   

        public static IRERPVList<Group, GroupFilter> GetAllGroup()
        {
            return GetVList(new GroupFilter());
        }


        public static IRERPVList<Group, GroupFilter> GetGroupsByUserId(int UserId)
        {
            var rtn = GetVList(new GroupFilter() { userid = UserId});
            
                return rtn;
        
        }
        public static Group GetGroupByID(Guid GroupID)
        {

            ////TODO: need to correction,UserMarafAction
            //Group rtn = new Group();
            //var lst = rtn.Session.QueryOver<Group>().Where(x => x.id == GroupID).List();
            //if (lst.Count > 0) return lst[0];
            //return null;
            Group rtn = null;
            var lst =
                GetVList(new GroupFilter() { Groupid = GroupID });
            if (lst.Count > 0) rtn = lst[0];
            return rtn;
        }

       
    }
}
