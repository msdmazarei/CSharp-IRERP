
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
DescribeMember(x => x.FilmProductionFormat_GetAll, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmClients, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.FilmSystemType_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
DescribeMember(x => x.Character_FilmWriters, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmDirector, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmActors, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmSenarists, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmSpeakers, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmExecutives, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.Character_FilmTechnicalExperts, IRERPProfile.Abstract).UserAsProfile(IRERPProfile.Abstract);
DescribeMember(x => x.FilmEducationalGoal_GetAll, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

        }
    }
}