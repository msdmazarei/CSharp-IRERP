using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class LegalCharacterLogMap : IRERPDescriptor<LegalCharacterLog>
    {
        public LegalCharacterLogMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "LegalCharacterLog"));

            LazyLoad();
            Id(x => x.LogId).GeneratedBy.Guid().Column("LogId");
            Map(x => x.id);
            Map(x => x.NationalIdentifier).Column("NationalIdentifier");
            Map(x => x.RegistrationNumber).Column("RegistrationNumber");
            Map(x => x.EconomicNumber).Column("EconomicNumber");
            Map(x => x.AgentId).Column("AgentId");
            Map(x => x.LegalCharacterTypeId).Column("LegalCharacterTypeId");
            Map(x => x.ChairMan).Column("ChairMan");
            Map(x => x.RegistrationPlace).Column("RegistrationPlace");
            Map(x => x.LegalBranchId).Column("LegalBranchId");
            Map(x => x.DependentCompany).Column("DependentCompany");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.Version).Column("Version");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");
        }
    }
}
