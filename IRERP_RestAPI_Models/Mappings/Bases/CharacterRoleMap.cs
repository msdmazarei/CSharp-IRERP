using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class CharacterRoleMap : IRERPDescriptor<CharacterRole>
    {
        public CharacterRoleMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "CharacterRole"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.RoleName).Column("RoleName").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            HasMany<RolsOfCharacter>(x => x._____RolsOfCharacter).LazyLoad().Cascade.None().KeyColumn("RoleID").NotFound.Ignore();

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
            DescribeMember(x => x.RoleName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterRoleRoleName"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterRoleDescription"));
            DescribeMember(x => x.RolsOfCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            #endregion

            DescribeMember(x => x.RoleName, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterRoleRoleName"));


        }
    }
}
