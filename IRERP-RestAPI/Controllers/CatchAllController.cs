using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Controllers
{
    public class CatchAllController : Controller
    {
        //
        // GET: /CatchAll/

        public ActionResult Index()
        {
            var sess= DBFactory.Instance.NewSession();
            var t = new IRERP_RestAPI.Models.User();
            t.PrimaryKeyCriterion(t);
           
            return View();
        }

    }
}
