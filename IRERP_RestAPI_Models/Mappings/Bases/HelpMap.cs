using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class HelpMap : IRERPDescriptor<Help>
    {
        public HelpMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Help"));

            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.HelpText).Column("HelpText");
            Map(x => x.HelpKey).Column("HelpKey");
            Version(x => x.Version);
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Description).Column("Description");
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.HelpText, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("HelpHelpText"));
            DescribeMember(x => x.HelpKey, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("HelpHelpKey"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("HelpDescription"));
            References<Language>(x => x._____Language).LazyLoad().Cascade.None().Column("Language");
            DescribeMember(x => x.Language, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

        }
    }
}
