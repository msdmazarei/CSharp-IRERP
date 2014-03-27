using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI.Areas.BaseInformation.Controllers
{
    public class BasesController  : IRERPController<MetaModel.BasesInformation_MetaModel>
    {


        public override void InitControllerSessionValues()
        {
            base.InitControllerSessionValues();
            IRERPApplicationUtilities.SessionParameters<MetaModel.BasesInformation_MetaModel>(x => x.SelecteCharacterFilter.id);
           
            
        }
        //
        // GET: /BaseInformation/Bases/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CharacterType()
        {
            return View(MetaModelInstance);
        }
        public ActionResult PostalAddressType()
        {
            return View(MetaModelInstance);
        }
        public ActionResult CallInfoType()
        {
            return View(MetaModelInstance);
        }
        public ActionResult MessaginRelationType()
        {
            return View(MetaModelInstance);
        }
    
        public ActionResult LegalCharacterType()
        {
            return View(MetaModelInstance);
        }

        public ActionResult Branch()
        {
            return View(MetaModelInstance);
        }

        public ActionResult MessagingInfoType()
        {
            return View(MetaModelInstance);
        }
        public ActionResult CharacterRole()
        {
            return View(MetaModelInstance);
        }
        public ActionResult RightFullCharacter()
        {
            return View(MetaModelInstance);
        }
        public ActionResult Gender()
        {
            return View(MetaModelInstance);
        }



        public ActionResult LegalCharecter()
        {
            return View(MetaModelInstance);
        }


        public ActionResult Places()
        {
            return View(MetaModelInstance);
        }

        public ActionResult DropDownListGroup()
        {
            return View(MetaModelInstance);
        }
        public ActionResult ACCErrorRecieved()
        {
            return View(MetaModelInstance);
        }

        public ActionResult AllCharacters()
        {
            return View(MetaModelInstance);
        }

        public ActionResult AllNationality()
        {
            return View(MetaModelInstance);
        }
  
        public ActionResult AllHelp()
        {
            return View(MetaModelInstance);
        }
        public ActionResult AllLanguage()
        {
            return View(MetaModelInstance);
        }

        public ActionResult IdentificationType()
        {
            return View(MetaModelInstance);
        }
        public ActionResult AllServe()
        {

            return View(MetaModelInstance);
        }
        public ActionResult AllDamage()
        {

            return View(MetaModelInstance);
        }
        
    }
}
