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
    public class LanguageLogMap : IRERPDescriptor<LanguageLog>
    {
        public LanguageLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "LanguageLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
            Map(x => x.LanguageName).Column("LanguageName");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Description).Column("Description");
            DescribeMember(x => x.LogId, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
        }
    }
}