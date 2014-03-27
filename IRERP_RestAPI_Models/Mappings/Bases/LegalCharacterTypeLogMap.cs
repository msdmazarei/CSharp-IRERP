using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;

namespace IRERP_RestAPI.Mappings.Bases
{

    public class LegalcharactertypelogMap : IRERPDescriptor<LegalCharacterTypeLog>
    {

        public LegalcharactertypelogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "LegalCharacterTypelog"));

			Id(x => x.LogId).GeneratedBy.Guid().Column("Logid");
			Map(x => x.LogDate).Column("LogDate").Not.Nullable();
			Map(x => x.id).Column("id").Not.Nullable();
			Map(x => x.Name).Column("Name").Not.Nullable();
			Map(x => x.Description).Column("Description");
			Map(x => x.IsDeleted).Column("IsDeleted");
			Map(x => x.Version).Column("Version");
			Map(x => x.AddBy).Column("AddBy");
			Map(x => x.ModifiedID).Column("ModifiedID");
			Map(x => x.AddByDAte).Column("AddByDAte");
			Map(x => x.ModifiyDate).Column("ModifiyDate");
        }
    }
}
