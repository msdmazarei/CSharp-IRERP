using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class CharacterLogMap : IRERPDescriptor<CharacterLog>
    {
        public CharacterLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "CharacterLog"));
            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
            Map(x => x.CharacterName).Column("CharacterName");
            Map(x => x.NickName).Column("NickName");
            //Map(x => x.Role).Column("Role").Not.Nullable();
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            Map(x => x.CellNumber).Column("CellNumber");
            Map(x => x.Email).Column("Email");
            Map(x => x.Address).Column("Address");
            Map(x => x.PostalCode).Column("PostalCode");
            Map(x => x.TellNumber).Column("TellNumber");

            Map(x => x.Natinality).Column("Natinality");


            DescribeMember(x => x.LogId, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
        }
    }
}
