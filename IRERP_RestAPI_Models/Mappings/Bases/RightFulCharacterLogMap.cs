using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class RightFulCharacterLogMap : IRERPDescriptor<RightFulCharacterLog>
    {
        public RightFulCharacterLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "RightFulCharacterLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.LogDate).Column("LogDate");
            Map(x => x.id).Column("id");
            Map(x => x.Fname).Column("Fname");
            Map(x => x.LName).Column("LName");
            Map(x => x.NationalCode).Column("NationalCode");
            Map(x => x.FatherName).Column("FatherName");
            Map(x => x.BirthCertificateSerial).Column("BirthCertificateSerial");
          
            Map(x => x.Gender).Column("Gender");
            Map(x => x.BrithDayYear).Column("BrithDayYear");
            Map(x => x.BrithdayPlaceId).Column("BrithdayPlaceId");
         
            Map(x => x.BirthCertificateNumber).Column("BirthCertificateNumber");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
            DescribeMember(x => x.LogId, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
        }
    }
}
