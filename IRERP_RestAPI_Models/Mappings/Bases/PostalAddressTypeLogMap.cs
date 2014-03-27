using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class PostalAddressTypeLogMap : IRERPDescriptor<PostalAddressTypeLog>
    {
        public PostalAddressTypeLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "PostalAddressTypeLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Description).Column("Description");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id").Not.Nullable();
            DescribeMember(x => x.LogId, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true);
        }
    }
}
