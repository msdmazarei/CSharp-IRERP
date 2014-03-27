using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class IdentificationLogMap : IRERPDescriptor<IdentificationLog>
    {
        public IdentificationLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "IdentificationLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.IdentificationType).Column("IdentificationType");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
        }
    }
}
