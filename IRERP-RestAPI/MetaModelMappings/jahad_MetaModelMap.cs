
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.MetaModel;

namespace IRERP_RestAPI.MetaModelMappings
{
    public class jahad_MetaModel_Mapping : IRERPDescriptor<jahad_MetaModel>
    {
        public jahad_MetaModel_Mapping()
        {
                DescribeMember(x => x.SelectedFilm, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedMagazine, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedMedia, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedPlayShow, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedRadioSchool, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedSlideVision, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SelectedTVSchool, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Auidunce_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmSystemType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.MagNo_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.MagazineType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Matter_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PictureFormat_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PictureType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Resulation_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Size_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.State_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Subject_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TVRD_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Year_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Film_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Magazine_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Media_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Picture_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PlayShow_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.RadioSchool_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.SlideVision_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TVSchool_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmProductionFormat_GetAll, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmClients, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.FilmSystemType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.MagazineType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.TVRD_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_pictureclients, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Size_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Resulation_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Photographers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PictureType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.PictureFormat_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Title_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmProductionFormat_GetAll, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_Client, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_FilmWriters, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmDirector, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmActors, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmSenarists, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmSpeakers, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmExecutives, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmTechnicalExperts, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Matter_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Year_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Matter_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Auidunce_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.State_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalExpert, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Speakers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Actors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Directors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_producres, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Auidunce_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_publishers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalExpert, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalSupervisor, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_RadioPrints, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_typesettrs, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_PageStylists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Graphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_LitoGraphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_BookBinder, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalExpert, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Speakers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Senarists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Photographers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Directors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Auidunce_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_publishers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Writers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalExpert, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_TechnicalSupervisor, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Printers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_typesettrs, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Editors, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_PageStylists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Graphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_Prepators, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_LitoGraphists, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_BookBinder, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Auidunce_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

        }
    }
}