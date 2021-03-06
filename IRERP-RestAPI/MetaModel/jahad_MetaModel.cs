
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Models.jah;using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.MetaModel
{
    public class jahad_MetaModel : ControllerMetaModelBase<jahad_MetaModel>
    {  
        public jahad_MetaModel()
        {
            Profile = Bases.MetaDataDescriptors.IRERPProfile.General;

        }


public virtual Film SelectedFilm
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedFilm.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.Film_Repository.ByPK(id);
                return new Film();
 
}
}


public virtual Magazine SelectedMagazine
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedMagazine.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.Magazine_Repository.ByPK(id);
                return new Magazine();
 
}
}


public virtual Media SelectedMedia
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedMedia.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.Media_Repository.ByPK(id);
                return new Media();
 
}
}


public virtual PlayShow SelectedPlayShow
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedPlayShow.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.PlayShow_Repository.ByPK(id);
                return new PlayShow();
 
}
}


public virtual RadioSchool SelectedRadioSchool
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedRadioSchool.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.RadioSchool_Repository.ByPK(id);
                return new RadioSchool();
 
}
}


public virtual SlideVision SelectedSlideVision
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedSlideVision.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.SlideVision_Repository.ByPK(id);
                return new SlideVision();
 
}
}


public virtual TVSchool SelectedTVSchool
{
get{
  var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromRequest<jahad_MetaModel>(x => x.SelectedTVSchool.id);
               
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.jah.TVSchool_Repository.ByPK(id);
                return new TVSchool();
 
}
}

                             public IList<Auidunce> Auidunce_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Auidunce_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmSystemType> FilmSystemType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmSystemType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<MagNo> MagNo_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.MagNo_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<MagazineType> MagazineType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.MagazineType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Matter> Matter_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Matter_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<PictureFormat> PictureFormat_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.PictureFormat_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<PictureType> PictureType_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.PictureType_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Resulation> Resulation_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Resulation_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Size> Size_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Size_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<State> State_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.State_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Subject> Subject_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Subject_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<TVRD> TVRD_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.TVRD_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Title> Title_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Title_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Year> Year_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Year_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmEducationalGoal> FilmEducationalGoal_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmEducationalGoal_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Film> Film_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Film_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Magazine> Magazine_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Magazine_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Media> Media_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Media_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Picture> Picture_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.Picture_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<PlayShow> PlayShow_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.PlayShow_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<RadioSchool> RadioSchool_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.RadioSchool_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<SlideVision> SlideVision_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.SlideVision_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<TVSchool> TVSchool_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.TVSchool_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<FilmProductionFormat> FilmProductionFormat_GetAll
                                    {
                                        get
                                        {
                                            return ModelRepositories.jah.FilmProductionFormat_Repository.GetAll();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmClients
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmClients();
                                        }
                                    }

                        
                             public IList<Character> Character_pictureclients
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.pictureclients();
                                        }
                                    }

                        
                             public IList<Character> Character_Photographers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Photographers();
                                        }
                                    }

                        
                             public IList<Character> Character_Client
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Client();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmWriters
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmWriters();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmDirector
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmDirector();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmActors
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmActors();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmSenarists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmSenarists();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmSpeakers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmSpeakers();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmExecutives
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmExecutives();
                                        }
                                    }

                        
                             public IList<Character> Character_FilmTechnicalExperts
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.FilmTechnicalExperts();
                                        }
                                    }

                        
                             public IList<Character> Character_TechnicalExpert
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.TechnicalExpert();
                                        }
                                    }

                        
                             public IList<Character> Character_Speakers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Speakers();
                                        }
                                    }

                        
                             public IList<Character> Character_Actors
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Actors();
                                        }
                                    }

                        
                             public IList<Character> Character_Writers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Writers();
                                        }
                                    }

                        
                             public IList<Character> Character_Directors
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Directors();
                                        }
                                    }

                        
                             public IList<Character> Character_producres
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.producres();
                                        }
                                    }

                        
                             public IList<Character> Character_publishers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.publishers();
                                        }
                                    }

                        
                             public IList<Character> Character_TechnicalSupervisor
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.TechnicalSupervisor();
                                        }
                                    }

                        
                             public IList<Character> Character_RadioPrints
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.RadioPrints();
                                        }
                                    }

                        
                             public IList<Character> Character_typesettrs
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.typesettrs();
                                        }
                                    }

                        
                             public IList<Character> Character_PageStylists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.PageStylists();
                                        }
                                    }

                        
                             public IList<Character> Character_Graphists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Graphists();
                                        }
                                    }

                        
                             public IList<Character> Character_LitoGraphists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.LitoGraphists();
                                        }
                                    }

                        
                             public IList<Character> Character_BookBinder
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.BookBinder();
                                        }
                                    }

                        
                             public IList<Character> Character_Senarists
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Senarists();
                                        }
                                    }

                        
                             public IList<Character> Character_Printers
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Printers();
                                        }
                                    }

                        
                             public IList<Character> Character_Editors
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Editors();
                                        }
                                    }

                        
                             public IList<Character> Character_Prepators
                                    {
                                        get
                                        {
                                            return ModelRepositories.Bases.Character_Repository.Prepators();
                                        }
                                    }

                        } //Class End
                    }//NameSpace End