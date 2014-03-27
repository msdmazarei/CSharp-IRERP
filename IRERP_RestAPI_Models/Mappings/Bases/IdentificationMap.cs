using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class IdentificationMap : IRERPDescriptor<Identification>
    {
        public IdentificationMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Identification"));
            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid().Column("id");
            Version(x => x.Version);

            Map(x => x.fileuploadtest).Column("fileuploadtest");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            Component(x => x.TestFile).ColumnPrefix("TestFile");
            Component(x => x.TestAddress).ColumnPrefix("TestAddress");

            References<IdentificationType>(x => x._____IdentificationType).LazyLoad().Cascade.None();
            References<Character>(x => x._____Character).LazyLoad().Cascade.None();

            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Version, IRERPProfile.Any).DataSourceFieldProperty(Hidden: true);

            DescribeMember(x => x.fileuploadtest, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.TestFile.FileName, IRERPProfile.General).DataSourceFieldProperty(ClientType: IRERP_RestAPI.Bases.Extension.HTML.Controls.Types.IRERPControlTypes_FieldType.irerpFile);
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.IdentificationType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Characters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
          


        }
    }
}
