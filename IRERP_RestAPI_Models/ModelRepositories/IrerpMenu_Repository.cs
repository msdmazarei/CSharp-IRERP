using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.DataVirtualization;
using IRERP_RestAPI.Filters;
using IRERP_RestAPI.Models;
using MsdLib.CSharp.DataVirtualization;

namespace IRERP_RestAPI.ModelRepositories
{
    public class IrerpMenu_Repository : IRERPRepositoryBaseSimpleFilter<IrerpMenu_Repository, MenuItem, IrerpMenuFilter>
    {
        //public static IRERPVList<MenuItem, IrerpMenuFilter> GetVList(IrerpMenuFilter filter)
        //{
        //    //return GetVList(new IrerpMenuFilter());
        //    return GetVList(filter);

        //}

        //public static IRERPVList_ParentChildSpec<TParent, MenuItem, IrerpMenuFilter> GetVList<TParent>(IrerpMenuFilter filter)
        //    where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        //{
        //    return
        //      new IRERPVList_ParentChildSpec<TParent, MenuItem, IrerpMenuFilter>(
        //      new ItemsProvider<MenuItem, IrerpMenuFilter>()
        //      {
        //          Filter = filter
        //      }
        //      );
        //}


        public static IRERPVList<MenuItem, IrerpMenuFilter> GetByUserId(Guid id)
        {
            //List<MenuItem> rtn = new List<MenuItem>();
            //var Groups = Group_Repository.GetGroupsByUserId(userid);
            //foreach (var q in Groups)
            //    rtn.AddRange(IrerpMenu_Repository.GetByGroupId(q.id));
            //return rtn;

            return GetVList(new IrerpMenuFilter() { userId = id });
        }

        public static IRERPVList<MenuItem, IrerpMenuFilter> GetByGroupId(Guid Groupid)
        {
            var rtn = GetVList(new IrerpMenuFilter() { groupmenuId = Groupid });
           
                return rtn;
       
            //List<MenuItem> rtn = new List<MenuItem>();
            //var q = (new GroupMenu()).Session.QueryOver<GroupMenu>().Where(x => x.GroupId == Groupid).And(x => x.IsDeleted == false).List();
            //foreach (var _tmp in q)
            //    rtn.Add(_tmp.Menu);

            //return rtn;
        }
        public static IRERPVList<MenuItem, IrerpMenuFilter> GetByParentId(Guid ParentId)
        {
            return GetVList(new IrerpMenuFilter() { ParentId = ParentId, useParentIdInFilter = true });

       
        }
        public static IRERPVList<MenuItem, IrerpMenuFilter> GetByParentId(Guid ParentId, User usr)
        {
            IrerpMenuFilter filter = new IrerpMenuFilter() { ParentId = ParentId, useParentIdInFilter = true,userId = usr.id };
            
            return GetVList(filter);
        }
        public static IRERPVList<MenuItem, IrerpMenuFilter> GetAllMenu()
        {
            return GetVList(new IrerpMenuFilter());
            /*return new IRERPVList<MenuItem, IrerpMenuFilter>(
                new ItemsProvider<MenuItem, IrerpMenuFilter>()
                {
                   Filter=new IrerpMenuFilter()
                }
                );*/
        }

        public static IRERPVList<MenuItem, IrerpMenuFilter> GetHeadMenu()
        {
            return GetVList(new IrerpMenuFilter() { ParentId = null, useParentIdInFilter = true });
        }
        public static IRERPVList<MenuItem, IrerpMenuFilter> GetHeadMenu(User User)
        {
            return GetVList(new IrerpMenuFilter() { ParentId = null, useParentIdInFilter = true , userId = User.id});
        }


        public static MenuItem GetMenuItemById(Guid id)
        {
            var lst = GetVList(new IrerpMenuFilter() { id= id});
            if (lst.Count > 0) return lst[0];
            //var tmp = new Filters.IrerpMenuFilter() { /*id = new MsdLib.CSharp.BLLCore.DBVar<Guid?>() { value = id }*/ id=id,useidInFilter=true }.Query.List();
            /*if (tmp != null)
                if (tmp.Count > 0)
                    return tmp[0];*/
            return null;
        }
    }
}