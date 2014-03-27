using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;
namespace IRERP_RestAPI.Mappings.Bases
{
    public class CharacterMap : IRERPDescriptor<Character>
    {
        public CharacterMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "Character"));

            
            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).GeneratedBy.Assigned().Column("id");
           
            Map(x => x.NickName).Column("NickName");
            Map(x => x.IsDeleted).Column("IsDeleted");
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

            References<Charactertype>(x => x._____Charactertype).LazyLoad().Cascade.None().Column("CharacterName").NotFound.Ignore();
            References<Nationality>(x => x._____Nationality).LazyLoad().Cascade.None().Column("Natinality").NotFound.Ignore();

            HasOne<RightFulCharacter>(x => x._____RightFulCharacter).LazyLoad().Cascade.None().PropertyRef(x => x._____Character);
            HasOne<LegalCharacter>(x => x._____LegalCharacterMain).LazyLoad().Cascade.None().PropertyRef(x => x._____MainCharacter);
            HasMany<LegalCharacter>(x => x._____LegalCharacter).LazyLoad().Cascade.None().KeyColumn("AgentId").NotFound.Ignore();
            HasMany<CallInfo>(x => x._____CallInfo).LazyLoad().Cascade.None().KeyColumn("CharacterID").NotFound.Ignore();
            HasMany<MessagingInfo>(x => x._____MessagingInfo).LazyLoad().Cascade.None().KeyColumn("CharacterID").NotFound.Ignore();
            HasMany<RolsOfCharacter>(x => x._____RolsOfCharacter).LazyLoad().Cascade.None().KeyColumn("CharacterID").NotFound.Ignore();
            HasMany<PostalAddress>(x => x._____PostalAddress).LazyLoad().Cascade.None().KeyColumn("CharacterID").NotFound.Ignore();
            HasMany<Identification>(x => x._____Identification).LazyLoad().Cascade.None().KeyColumn("Identification").NotFound.Ignore();
            
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
            DescribeMember(x => x.Characterstype, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.NickName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterNickName"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterDescription"));
            DescribeMember(x => x.CallInfo, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.LegalCharacterMain, IRERPProfile.General).UserAsProfile(IRERPProfile.LegalCharacter_General);
            DescribeMember(x => x.MessagingInfo, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.RolsOfCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.PostalAddress, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
           
            DescribeMember(x => x.CellNumber, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.General).DataSourceFieldProperty();

            DescribeMember(x => x.PostalCode, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.Nationality, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Identification, IRERPProfile.General).UserAsProfile(IRERPProfile.General);





           
            #endregion

            #region LegalCharacter_General
            DescribeMember(x => x.LegalCharacters, IRERPProfile.LegalCharacter_General).UserAsProfile(IRERPProfile.General);
            #endregion

            #region Abstract
            DescribeMember(x => x.NickName, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterNickName"));
            DescribeMember(x => x.CellNumber, IRERPProfile.Abstract).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.Abstract).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.Abstract).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.Abstract).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.Abstract).DataSourceFieldProperty();
            #endregion

            #region DDl_Character
            DescribeMember(x => x.NickName, IRERPProfile.DDl_Character).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterNickName"));
            DescribeMember(x => x.CellNumber, IRERPProfile.DDl_Character).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.DDl_Character).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.DDl_Character).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.DDl_Character).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.DDl_Character).DataSourceFieldProperty();
            #endregion

            #region  D_ViewFeasibility
            DescribeMember(x => x.NickName, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty(title: ApplicationStatics.T("OrderWFStep"));
            DescribeMember(x => x.LegalCharacterMain, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.D_ViewFeasibility);
            DescribeMember(x => x.CallInfo, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.D_CallInfo);
            DescribeMember(x => x.MessagingInfo, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.D_MessagingInfo);
            DescribeMember(x => x.PostalAddress, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.D_postalAddress);
            DescribeMember(x => x.CellNumber, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty();

            #endregion

            #region B_RightFulCharacter
            DescribeMember(x => x.NickName, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterNickName"));
            DescribeMember(x => x.Characterstype, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.CallInfo, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.D_CallInfo);
            DescribeMember(x => x.MessagingInfo, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.D_MessagingInfo);
            DescribeMember(x => x.PostalAddress, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.D_postalAddress);
            DescribeMember(x => x.RolsOfCharacter, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.D_RolesOfCharacter);
            DescribeMember(x => x.CellNumber, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Nationality, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Identification, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.General);


            #endregion

            #region B_LegalCharacter
            DescribeMember(x => x.NickName, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("CharacterNickName"));
            DescribeMember(x => x.Characterstype, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.CallInfo, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.D_CallInfo);
            DescribeMember(x => x.MessagingInfo, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.D_MessagingInfo);
            DescribeMember(x => x.PostalAddress, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.D_postalAddress);
            DescribeMember(x => x.RolsOfCharacter, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.D_RolesOfCharacter);
            DescribeMember(x => x.CellNumber, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.B_LegalCharacter).DataSourceFieldProperty();
            DescribeMember(x => x.Nationality, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Identification, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.General);


            #endregion

            #region  D_Contract
            DescribeMember(x => x.NickName, IRERPProfile.D_Contract).DataSourceFieldProperty(title: ApplicationStatics.T("OrderWFStep"));
            DescribeMember(x => x.LegalCharacterMain, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.D_Contract);
            DescribeMember(x => x.CallInfo, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.D_CallInfo);
            DescribeMember(x => x.MessagingInfo, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.D_MessagingInfo);
            DescribeMember(x => x.PostalAddress, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.D_postalAddress);
            DescribeMember(x => x.CellNumber, IRERPProfile.D_Contract).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.D_Contract).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.D_Contract).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.D_Contract).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.D_Contract).DataSourceFieldProperty();
            #endregion

            #region  DO_ViewSales
            DescribeMember(x => x.CellNumber, IRERPProfile.DO_ViewSales).DataSourceFieldProperty();
            DescribeMember(x => x.Email, IRERPProfile.DO_ViewSales).DataSourceFieldProperty();
            DescribeMember(x => x.Address, IRERPProfile.DO_ViewSales).DataSourceFieldProperty();
            DescribeMember(x => x.PostalCode, IRERPProfile.DO_ViewSales).DataSourceFieldProperty();
            DescribeMember(x => x.TellNumber, IRERPProfile.DO_ViewSales).DataSourceFieldProperty();
            #endregion

        }
    }
}
