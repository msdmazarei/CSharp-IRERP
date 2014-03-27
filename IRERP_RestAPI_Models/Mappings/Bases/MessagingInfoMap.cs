using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class MessagingInfoMap : IRERPDescriptor<IRERP_RestAPI.Models.Bases.MessagingInfo>
    {
        public MessagingInfoMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "MessagingInfo"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.MessagingAddress).Column("MessagingAddress");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            References<IRERP_RestAPI.Models.Bases.MessagingInfoType>(x => x._____MessagingInfoType).LazyLoad().Cascade.None().Column("Type");
            References<IRERP_RestAPI.Models.Bases.MessagingRelationType>(x => x._____MessagingRelationType).LazyLoad().Cascade.None().Column("RelationType");
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
            DescribeMember(x => x.MessagingAddress, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoMessagingAddress"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoDescription"));
            DescribeMember(x => x.MessagingInfoType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.MessagingRelationType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Character, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            #endregion


            #region D_MessagingInfo
            DescribeMember(x => x.MessagingAddress, IRERPProfile.D_MessagingInfo).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoMessagingAddress"));
            DescribeMember(x => x.Description, IRERPProfile.D_MessagingInfo).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoDescription"));
            DescribeMember(x => x.MessagingInfoType, IRERPProfile.D_MessagingInfo).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.MessagingRelationType, IRERPProfile.D_MessagingInfo).UserAsProfile(IRERPProfile.Abstract);
            #endregion
          
        }
    }
}
