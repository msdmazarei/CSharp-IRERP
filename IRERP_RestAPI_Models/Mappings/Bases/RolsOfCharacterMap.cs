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
    public class RolsOfCharacterMap : IRERPDescriptor<RolsOfCharacter>
    {
        public RolsOfCharacterMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "RoleOfCharacter"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.Description).Column("Description");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            References<IRERP_RestAPI.Models.Bases.CharacterRole>(x => x._____CharacterRole).LazyLoad().Cascade.None().Column("RoleID");
            References<IRERP_RestAPI.Models.Bases.Character>(x => x._____Character).LazyLoad().Cascade.None().Column("CharacterID");

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
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RolesOfCharacterDescription"));
            DescribeMember(x => x.Character, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.CharacterRole, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            #endregion

            #region D_RolesOfCharacter
            DescribeMember(x => x.Description, IRERPProfile.D_RolesOfCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RolesOfCharacterDescription"));
            DescribeMember(x => x.Character, IRERPProfile.D_RolesOfCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.CharacterRole, IRERPProfile.D_RolesOfCharacter).UserAsProfile(IRERPProfile.Abstract);
            #endregion

        }
    }
}
