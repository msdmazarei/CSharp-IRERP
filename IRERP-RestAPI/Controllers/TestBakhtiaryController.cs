using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.IRERPController;

namespace IRERP_RestAPI.Controllers
{
    public class TestBakhtiaryController : IRERPController<MetaModel.Support_MetaModel>
    {
        //
        // GET: /TestBakhtiary/

        public ActionResult Index()
        {
            return View(MetaModelInstance);
        }

    }
}
