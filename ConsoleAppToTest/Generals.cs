using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.ModelRepositories;
using MsdLib.CSharp.DALCore;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Reflection;
using MsdLib.CSharp.BLLCore;
namespace IRERP_RestAPI.Tests
{
    public enum TrafficTimeStatus
    {
        fullExpire,
        TimeExpire,
        TrafficExpire,
        Valid
    }
    public class Generals
    {

        public static HttpContext context=null;
        public static NHibernate.ISession session=null;
      
        public static void startup()
        {
            if (context == null)
            {
                Generals.MakeHttpContext();
                context = System.Web.HttpContext.Current;

            }
            else
            {
                System.Web.HttpContext.Current = context;
            }
            if (session == null)
            {
                DAL.SetupDb();
                session = DAL.Session;
            }
         
        }
        
        public static void MakeHttpContext()
        {
            
            var httpRequest = new HttpRequest("", "http://mis.petiak.com/", "");
            var stringWriter = new StringWriter();
            var httpResponce = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponce);

            var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            httpContext.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                                     BindingFlags.NonPublic | BindingFlags.Instance,
                                                     null, CallingConventions.Standard,
                                                     new[] { typeof(HttpSessionStateContainer) },
                                                     null)
                                                .Invoke(new object[] { sessionContainer });

            System.Web.HttpContext.Current = httpContext;
        }
       
        public static void checkandthrow( FunctionResult<INHibernateEntity> rtn)
        {
            if (!rtn.Result)
                throw rtn.Error;
        }
        public static void fillTables()
        {
            User admin = new User() { Username = "admin", Password = "admin" };
            admin.Save();
            Group admingroup = new Group() { GroupName = "admin" };
            admingroup.Save();
            admingroup.GroupUsers = new List<GroupUser>();
            GroupUser gu = new GroupUser() { User = admin, Group = admingroup };
            gu.Save();
            //create menu
            MenuItem ADMINMnu = new MenuItem() { EnName = "adminmenu", Title = "AdminMenu" };
            ADMINMnu.Save();

            MenuItem menus = new MenuItem() { EnName = "menus", Title = "menus", ParentID = ADMINMnu.id, MethodToCall = "\"AddTab('menus','/MenuManager/MngMenu')\"" };
            menus.Save();
            GroupMenu gmenu = new GroupMenu() {  Group = admingroup, Menu = menus};
            gmenu.Save();
            GroupMenu gmenuadmins = new GroupMenu() { Group = admingroup, Menu = ADMINMnu };
            gmenuadmins.Save();

            MenuItem usergroup = new MenuItem() { EnName = "usergroup", Title = "usergroup", ParentID = ADMINMnu.id, MethodToCall = "\"AddTab('گروه کاربر','/Group/GroupUserManager')\"" };
            usergroup.Save();
            GroupMenu usergroupGP= new GroupMenu() { Group = admingroup, Menu = usergroup };
            usergroupGP.Save();


            MenuItem groupmenu = new MenuItem() { EnName = "groupmenu", Title = "groupmenu", ParentID = ADMINMnu.id, MethodToCall = "\"AddTab('گروه منو','/Group/GroupMenuManager')\"" };
            groupmenu.Save();
            GroupMenu groupmenuGP = new GroupMenu() { Group = admingroup, Menu = groupmenu };
            groupmenuGP.Save();


            gmenuadmins.RunTransaction(null
                );

        }

             
    }
}
