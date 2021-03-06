
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Models.Bases;

namespace IRERP_RestAPI.Areas.jahad.Controllers
{
    public class jahadController  : IRERPController<MetaModel.jahad_MetaModel>
    {


public override void InitControllerSessionValues()
        {
            base.InitControllerSessionValues();
            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedFilm.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedMagazine.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedMedia.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedPlayShow.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedRadioSchool.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedSlideVision.id);


            IRERPApplicationUtilities.RequestParameters<MetaModel.jahad_MetaModel>(x => x.SelectedTVSchool.id);

        }

    public ActionResult Auidunce()
        {
            return View(MetaModelInstance);
        }


    public ActionResult FilmSystemType()
        {
            return View(MetaModelInstance);
        }


    public ActionResult MagNo()
        {
            return View(MetaModelInstance);
        }


    public ActionResult MagazineType()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Matter()
        {
            return View(MetaModelInstance);
        }


    public ActionResult PictureFormat()
        {
            return View(MetaModelInstance);
        }


    public ActionResult PictureType()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Resulation()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Size()
        {
            return View(MetaModelInstance);
        }


    public ActionResult State()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Subject()
        {
            return View(MetaModelInstance);
        }


    public ActionResult TVRD()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Title()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Year()
        {
            return View(MetaModelInstance);
        }


    public ActionResult FilmEducationalGoal()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Film()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Magazine()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Media()
        {
            return View(MetaModelInstance);
        }


    public ActionResult Picture()
        {
            return View(MetaModelInstance);
        }


    public ActionResult PlayShow()
        {
            return View(MetaModelInstance);
        }


    public ActionResult RadioSchool()
        {
            return View(MetaModelInstance);
        }


    public ActionResult SlideVision()
        {
            return View(MetaModelInstance);
        }


    public ActionResult TVSchool()
        {
            return View(MetaModelInstance);
        }

} //Controller end
            }//namespace end