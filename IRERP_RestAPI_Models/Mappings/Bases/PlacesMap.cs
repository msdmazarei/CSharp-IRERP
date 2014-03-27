using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class PlacesMap : IRERPDescriptor<Places>
    {
        public PlacesMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Places"));

            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Version(x => x.Version);
            Map(x => x.LocationName).Column("LocationName");
            Map(x => x.Pid).Column("Pid");
            Map(x => x.Description).Column("Description");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");

            HasMany<LegalCharacter>(x => x._____LegalCharacter).LazyLoad().Cascade.None().KeyColumn("RegistrationPlace").NotFound.Ignore();
            HasMany<RightFulCharacter>(x => x._____RightFullCharacters).LazyLoad().Cascade.None().KeyColumn("BrithdayPlaceId");

            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);

            DescribeMember(x => x.LocationName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PlacesLocationName"));
            DescribeMember(x => x.Pid, IRERPProfile.General).DataSourceFieldProperty(Hidden:true);
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PlacesDescription"));

            DescribeMember(x => x.LegalCharacters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);


            DescribeMember(x => x.LocationName, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("PlacesLocationName"));


            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
      .AliasForProperty(_GPN(x => x.AddByDAte))
.DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));

            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.ModifiyDate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));

        }
    }
}
