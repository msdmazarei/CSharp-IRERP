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
    public class LegalBranchMap : IRERPDescriptor<LegalBranch>
    {
        public LegalBranchMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "LegalBranch"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Description).Column("Description");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");

            HasMany<LegalCharacter>(x => x._____LegalCharacter).LazyLoad().Cascade.None().KeyColumn("LegalBranchId").NotFound.Ignore();

            #region Any
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);

            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
             .AliasForProperty(_GPN(x => x.AddByDAte))
    .DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));

            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.ModifiyDate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));
            #endregion

            #region General
            DescribeMember(x => x.LegalCharacters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Name, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalBranchName"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalBranchDescription"));
            #endregion

            DescribeMember(x => x.Name, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("LegalBranchName"));
            


        }
    }
}
