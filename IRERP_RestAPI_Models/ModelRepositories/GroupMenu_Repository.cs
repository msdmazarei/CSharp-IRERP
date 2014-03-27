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
    public class GroupMenu_Repository : IRERPRepositoryBaseSimpleFilter<GroupMenu_Repository, GroupMenu, GroupMenuFilter>
    {
        public static IRERPVList<GroupMenu, GroupMenuFilter> GetAllGroupMenu()
        {
            return GetVList(new GroupMenuFilter());
        }

        public static GroupMenu GetGroupMenuByID(Guid GroupMenuID)
        {

            GroupMenu rtn = null;
            var lst =
                GetVList(new GroupMenuFilter() { GroupManagerId = GroupMenuID, });
            if (lst.Count > 0) rtn = lst[0];
            return rtn;
            ////TODO: need to correction,UserMarafAction
            //GroupMenu rtn = new GroupMenu();
            //var lst = rtn.Session.QueryOver<GroupMenu>().Where(x => x.id == GroupMenuID).List();
            //if (lst.Count > 0) return lst[0];
            //return null;
        }

    }
}
