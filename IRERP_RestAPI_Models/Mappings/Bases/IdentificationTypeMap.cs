using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class IdentificationTypeMap : IRERPDescriptor<IdentificationType>
    {
        public IdentificationTypeMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "IdentificationType"));

            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Version(x => x.Version);
            Map(x => x.Name).Column("Name");
            Map(x => x.Description).Column("Description");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);
            DescribeMember(x => x.Name, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty();
        }
    }
}
