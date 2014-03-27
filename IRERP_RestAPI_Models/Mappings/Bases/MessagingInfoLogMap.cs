using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class MessagingInfoLogMap : IRERPDescriptor<IRERP_RestAPI.Models.Bases.MessagingInfoLog>
    {
        public MessagingInfoLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "MessagingInfoLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
            Map(x => x.CharacterID).Column("CharacterID");
            Map(x => x.MessagingAddress).Column("MessagingAddress").Not.Nullable();
            Map(x => x.RelationType).Column("RelationType").Not.Nullable();
            Map(x => x.Type).Column("Type").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
        }
    }
}
