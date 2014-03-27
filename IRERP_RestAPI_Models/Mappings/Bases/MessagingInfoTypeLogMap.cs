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
    public class MessagingInfoTypeLogMap : IRERPDescriptor<MessagingInfoTypeLog>
    {
        public MessagingInfoTypeLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "MessagingInfoTypeLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.MessagingType).Column("MessagingType").Not.Nullable();
            Map(x => x.LogDate).Column("LogDate").Not.Nullable();
            Map(x => x.id).Column("id").Not.Nullable();
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
