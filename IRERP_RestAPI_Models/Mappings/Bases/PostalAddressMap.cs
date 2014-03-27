using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class PostalAddressMap : IRERPDescriptor<PostalAddress>
    {
        public PostalAddressMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "PostalAddress"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
           
            Map(x => x.PostalCode).Column("PostalCode");
            Map(x => x.Address).Column("Address");
            Map(x => x.KMZ).Column("KMZ");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            References<IRERP_RestAPI.Models.Bases.PostalAddressType>(x => x._____PostalAddressType).LazyLoad().Cascade.None().Column("PostalAddressType");
            References<IRERP_RestAPI.Models.Bases.Character>(x => x._____Character).LazyLoad().Cascade.None().Column("CharacterID");

            #region Any
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);

            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
   .AliasForProperty(_GPN(x => x.AddByDAte))
.DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));

            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.ModifiyDate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));
            #endregion

            #region General
            DescribeMember(x => x.PostalCode, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressPostalCode"));
            DescribeMember(x => x.Address, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressAddress"));
            DescribeMember(x => x.KMZ, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressKMZ"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressDescription"));
            DescribeMember(x => x.PostalAddressType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Character, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            #endregion

            #region D_postalAddress
            DescribeMember(x => x.PostalCode, IRERPProfile.D_postalAddress).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressPostalCode"));
            DescribeMember(x => x.Address, IRERPProfile.D_postalAddress).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressAddress"));
            DescribeMember(x => x.KMZ, IRERPProfile.D_postalAddress).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressKMZ"));
            DescribeMember(x => x.Description, IRERPProfile.D_postalAddress).DataSourceFieldProperty(title: ApplicationStatics.T("PostalAddressDescription"));
            DescribeMember(x => x.PostalAddressType, IRERPProfile.D_postalAddress).UserAsProfile(IRERPProfile.Abstract);
            #endregion
           

        }
    }
}
