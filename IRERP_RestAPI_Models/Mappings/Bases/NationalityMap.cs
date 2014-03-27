using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class NationalityMap : IRERPDescriptor<Nationality>
    {
        public NationalityMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Nationality"));

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

            HasMany<Character>(x => x._____Character).LazyLoad().Cascade.None().KeyColumn("Natinality").NotFound.Ignore();

            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Name, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("NatinalityName"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("NatinalityDescription"));
            DescribeMember(x => x.Name, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("NatinalityName"));
            DescribeMember(x => x.PersianAddByDAte, IRERPProfile.Any)
           .AliasForProperty(_GPN(x => x.AddByDAte))
           .DataSourceFieldProperty(title: ApplicationStatics.T("ADDDate"));
            DescribeMember(x => x.PersianModifiyDate, IRERPProfile.Any)
            .AliasForProperty(_GPN(x => x.ModifiyDate))
            .DataSourceFieldProperty(title: ApplicationStatics.T("ModifayDate"));
        }
    }
}
