using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;

namespace IRERP_RestAPI.Mappings.Bases
{

    public class CharactertypeMap : IRERPDescriptor<Charactertype>
    {

        public CharactertypeMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "CharacterType"));

            Version(x => x.Version);
			Id(x => x.id).GeneratedBy.Guid().Column("id");
			Map(x => x.Charactertypename).Column("CharacterTypeName").Not.Nullable();
			Map(x => x.IsDeleted).Column("IsDeleted");
			Map(x => x.AddBy).Column("AddBy");
			Map(x => x.ModifiedID).Column("ModifiedID");
			Map(x => x.AddBydate).Column("AddByDAte");
			Map(x => x.Modifiydate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            HasMany<Character>(x => x._____Character).LazyLoad().Cascade.None().KeyColumn("CharacterName").NotFound.Ignore();

            #region Any
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);
            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
     .AliasForProperty(_GPN(x => x.AddBydate))
     .DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));

            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.Modifiydate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));
            #endregion

            #region General
            DescribeMember(x => x.Charactertypename, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterTypeCharactertypename"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterTypeDescription"));
            #endregion

            DescribeMember(x => x.Charactertypename, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterTypeCharactertypename"));


        }
    }
}
