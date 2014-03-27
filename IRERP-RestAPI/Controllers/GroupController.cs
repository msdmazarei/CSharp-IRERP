using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.IRERPController;

namespace IRERP_RestAPI.Controllers
{
    public class GroupController : IRERPController<MetaModel.Support_MetaModel>
    {
        //
        // GET: /Group/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GroupManager()
        {
            //TypedMetaModelInstance.Profile = Bases.MetaDataDescriptors.IRERPProfile.General;
            return View(TypedMetaModelInstance);
        }


        public ActionResult GroupUserManager()
        {
           // TypedMetaModelInstance.Profile = Bases.MetaDataDescriptors.IRERPProfile.General;
            return View(TypedMetaModelInstance);
        }

        public ActionResult GroupMenuManager()
        {
            return View(TypedMetaModelInstance);
        }
    }
}
