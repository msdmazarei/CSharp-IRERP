using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.Bases;
using IRERP_RestAPI.ModelRepositories.Bases;
using IRERP_RestAPI.Mappings.Bases;
using IRERP_RestAPI.Filters.Bases;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class LanguageMap : IRERPDescriptor<Language>
    {
        public LanguageMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Language"));

            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Version(x => x.Version);
            Map(x => x.LanguageName).Column("LanguageName");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Description).Column("Description");

            HasMany<Help>(x => x._____Help).LazyLoad().Cascade.None().KeyColumn("Language");

            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.LanguageName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LanguageName"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LanguageDescription"));
        }
    }
}
