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
        public static void jahad(Group admingroup)
        {

            MenuItem mnu;
            MenuItem mnuModu;
            GroupMenu gpmn;


            mnuModu = new MenuItem() { EnName = "jahad", Title = "jahad" };
            mnuModu.Save();
            gpmn = new GroupMenu() { Menu = mnuModu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Auidunce",
                EnName = "Auidunce",
                MethodToCall = "\"AddTab('Auidunce','/jahad/jahad/Auidunce')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "FilmSystemType",
                EnName = "FilmSystemType",
                MethodToCall = "\"AddTab('FilmSystemType','/jahad/jahad/FilmSystemType')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "MagNo",
                EnName = "MagNo",
                MethodToCall = "\"AddTab('MagNo','/jahad/jahad/MagNo')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "MagazineType",
                EnName = "MagazineType",
                MethodToCall = "\"AddTab('MagazineType','/jahad/jahad/MagazineType')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Matter",
                EnName = "Matter",
                MethodToCall = "\"AddTab('Matter','/jahad/jahad/Matter')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "PictureFormat",
                EnName = "PictureFormat",
                MethodToCall = "\"AddTab('PictureFormat','/jahad/jahad/PictureFormat')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "PictureType",
                EnName = "PictureType",
                MethodToCall = "\"AddTab('PictureType','/jahad/jahad/PictureType')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Resulation",
                EnName = "Resulation",
                MethodToCall = "\"AddTab('Resulation','/jahad/jahad/Resulation')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Size",
                EnName = "Size",
                MethodToCall = "\"AddTab('Size','/jahad/jahad/Size')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "State",
                EnName = "State",
                MethodToCall = "\"AddTab('State','/jahad/jahad/State')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Subject",
                EnName = "Subject",
                MethodToCall = "\"AddTab('Subject','/jahad/jahad/Subject')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "TVRD",
                EnName = "TVRD",
                MethodToCall = "\"AddTab('TVRD','/jahad/jahad/TVRD')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Title",
                EnName = "Title",
                MethodToCall = "\"AddTab('Title','/jahad/jahad/Title')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Year",
                EnName = "Year",
                MethodToCall = "\"AddTab('Year','/jahad/jahad/Year')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "FilmEducationalGoal",
                EnName = "FilmEducationalGoal",
                MethodToCall = "\"AddTab('FilmEducationalGoal','/jahad/jahad/FilmEducationalGoal')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Film",
                EnName = "Film",
                MethodToCall = "\"AddTab('Film','/jahad/jahad/Film')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Magazine",
                EnName = "Magazine",
                MethodToCall = "\"AddTab('Magazine','/jahad/jahad/Magazine')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Media",
                EnName = "Media",
                MethodToCall = "\"AddTab('Media','/jahad/jahad/Media')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "Picture",
                EnName = "Picture",
                MethodToCall = "\"AddTab('Picture','/jahad/jahad/Picture')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "PlayShow",
                EnName = "PlayShow",
                MethodToCall = "\"AddTab('PlayShow','/jahad/jahad/PlayShow')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "RadioSchool",
                EnName = "RadioSchool",
                MethodToCall = "\"AddTab('RadioSchool','/jahad/jahad/RadioSchool')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "SlideVision",
                EnName = "SlideVision",
                MethodToCall = "\"AddTab('SlideVision','/jahad/jahad/SlideVision')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

            mnu = new MenuItem()
            {
                ParentID = mnuModu.id,
                Title = "TVSchool",
                EnName = "TVSchool",
                MethodToCall = "\"AddTab('TVSchool','/jahad/jahad/TVSchool')\""
            };
            mnu.Save();
            gpmn = new GroupMenu() { Menu = mnu, Group = admingroup };
            gpmn.Save();

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
            
            MenuItem mnu;
            MenuItem mnuModu;
            GroupMenu gpmn;
            jahad(admingroup);
            gmenuadmins.RunTransaction(null
                );

        }

             
    }
}
