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
    public class MessagingRelationTypeLogMap : IRERPDescriptor<MessagingRelationTypeLog>
    {
        public MessagingRelationTypeLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "MessagingRelationTypeLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
            Map(x => x.id).Column("id");
            Map(x => x.RelationName).Column("RelationName").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            Map(x => x.LogDate).Column("LogDate");
            DescribeMember(x => x.LogId, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);

        }
    }
}
