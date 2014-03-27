using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.ModelRepositories;
using IRERP_RestAPI.Bases.IRERPActionResults;
using IRERP_RestAPI.Bases.Extension.Methods;
namespace IRERP_RestAPI.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            if (!DAL.isDbSetuped) DAL.SetupDb();
        }

        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            InstanceStatics.LoggedUser = null;
            return new IRERPMethodActionResult()
            {
                Success = true,
                RedirectToUrl = "/Login"
            };
        }
        public ActionResult Login()
        {
            string UserName = IRERPApplicationUtilities.GetHttpParameter("username");
            string Password = IRERPApplicationUtilities.GetHttpParameter("password");

            var usr = UserRepository.GetUserByUserNameAndPassword(UserName, Password);
            if (usr != null)
            {
                InstanceStatics.LoggedUser = usr;
                return new IRERPMethodActionResult() 
                { 
                    Success = true,
                    RedirectToUrl="/support/support"
                };
            }
            else
            {
                return new IRERPMethodActionResult()
                {
                    Success = false,
                    Error = "UserName Or Password Is Incorrect, Try Again"
                };
            }
            
        }
    }
}
