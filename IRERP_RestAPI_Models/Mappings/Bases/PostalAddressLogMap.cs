using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class PostalAddressLogMap : IRERPDescriptor<PostalAddressLog>
    {
        public PostalAddressLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "PostalAddressLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
            Map(x => x.CharacterID).Column("CharacterID").Not.Nullable();
            Map(x => x.PostalAddressType).Column("PostalAddressType").Not.Nullable();
            Map(x => x.PostalCode).Column("PostalCode").Not.Nullable();
            Map(x => x.Address).Column("Address").Not.Nullable();
            Map(x => x.KMZ).Column("KMZ");
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
