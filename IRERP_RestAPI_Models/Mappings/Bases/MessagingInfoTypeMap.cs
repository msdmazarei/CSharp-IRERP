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
    public class MessagingInfoTypeMap : IRERPDescriptor<MessagingInfoType>
    {
        public MessagingInfoTypeMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "MessagingInfoType"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");

            Map(x => x.MessagingType).Column("MessagingType").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            HasMany<IRERP_RestAPI.Models.Bases.MessagingInfo>(x => x._____MessagingInfo).LazyLoad().Cascade.None().KeyColumn("Type");

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
            DescribeMember(x => x.MessagingType, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoTypeMessagingType"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoTypeDescription"));
            #endregion


            DescribeMember(x => x.MessagingType, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("MessagingInfoTypeMessagingType"));


        }
    }
}
