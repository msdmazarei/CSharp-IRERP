using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class LegalCharacterMap : IRERPDescriptor<LegalCharacter>
    {
        public LegalCharacterMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "LegalCharacter"));

            LazyLoad();
            Id(x => x.id).GeneratedBy.Assigned().Column("id");
            Version(x => x.Version);

            Map(x => x.NationalIdentifier).Column("NationalIdentifier");
            Map(x => x.RegistrationNumber).Column("RegistrationNumber");
            Map(x => x.EconomicNumber).Column("EconomicNumber");
            Map(x => x.ChairMan).Column("ChairMan");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");



            References<LegalBranch>(x => x._____LegalBranch).LazyLoad().Cascade.None().Column("LegalBranchId").NotFound.Ignore();
            References<LegalCharacterType>(x => x._____LegalCharacterType).LazyLoad().Cascade.None().Column("LegalCharacterTypeId").NotFound.Ignore();
            References<Places>(x => x._____Place).LazyLoad().Cascade.None().Column("RegistrationPlace").NotFound.Ignore();
            References<Character>(x => x._____Character).LazyLoad().Cascade.None().Column("AgentId").NotFound.Ignore();
            References<Character>(x => x._____MainCharacter).LazyLoad().Cascade.None().Column("id").NotFound.Ignore().ReadOnly();
            References<LegalCharacter>(x => x._____Dependent).LazyLoad().Cascade.None().Column("DependentCompany").NotFound.Ignore();


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
            DescribeMember(x => x.NationalIdentifier, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterNationalIdentifier"));
            DescribeMember(x => x.RegistrationNumber, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterRegistrationNumber"));
            DescribeMember(x => x.EconomicNumber, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterEconomicNumber"));
            DescribeMember(x => x.ChairMan, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterChairMan"));
          //  DescribeMember(x => x.DependentCompany, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterDependentCompany"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterDescription"));
            DescribeMember(x => x.LegalBranchs, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.LegalCharactersType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Places, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Characters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.MainCharacters, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
      

            #endregion

            DescribeMember(x => x.Characters, IRERPProfile.LegalCharacter_General).UserAsProfile(IRERPProfile.CharacterAgent);
            DescribeMember(x => x.Characters, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Characters, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.Abstract);



            #region B_LegalCharacter
            DescribeMember(x => x.NationalIdentifier, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterNationalIdentifier"));
            DescribeMember(x => x.RegistrationNumber, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterRegistrationNumber"));
            DescribeMember(x => x.EconomicNumber, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterEconomicNumber"));
            DescribeMember(x => x.ChairMan, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterChairMan"));
           // DescribeMember(x => x.DependentCompany, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterDependentCompany"));
            DescribeMember(x => x.Description, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("LegalCharacterDescription"));
            DescribeMember(x => x.LegalBranchs, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.LegalCharactersType, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Places, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Characters, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.B_LegalCharacter);
            DescribeMember(x => x.MainCharacters, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.B_LegalCharacter);
            //DescribeMember(x => x.Dependent, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.B_LegalCharacter);

            #endregion

            DescribeMember(x => x.Dependent, IRERPProfile.General).UserAsProfile(IRERPProfile.B_Dependent);
            DescribeMember(x => x.MainCharacters, IRERPProfile.B_Dependent).UserAsProfile(IRERPProfile.Abstract);


        }
    }
}
