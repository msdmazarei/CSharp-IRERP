using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.MetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Controllers
{
    public class msddalController : IRERPController<Support_MetaModel>
    {
        //
        // GET: /msddal/

        public ActionResult Index()
        {
            //Test 
            Models.User m = new Models.User();
                      var u = m.FetchList<Models.User>(0,100,null,null);

            return View();
        }
        public ActionResult msddal()
        {
            return View(MetaModelInstance);
        }

    }
}
