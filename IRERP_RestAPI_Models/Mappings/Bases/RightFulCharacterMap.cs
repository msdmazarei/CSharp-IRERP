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
    public class RightFulCharacterMap : IRERPDescriptor<RightFulCharacter>
    {
        public RightFulCharacterMap()
        {
            Table(MsdTableName(null, "irerp", "bases", "RightFulCharacter"));

            LazyLoad();
            Version(x => x.Version);
            Id(x => x.id).Column("id").GeneratedBy.Assigned();
            Map(x => x.Fname).Column("Fname");
            Map(x => x.LName).Column("LName");
            Map(x => x.NationalCode).Column("NationalCode");
            Map(x => x.FatherName).Column("FatherName");
            Map(x => x.BirthCertificateSerial).Column("BirthCertificateSerial");
            Map(x => x.BrithDayYear).Column("BrithDayYear");
            Map(x => x.BirthCertificateNumber).Column("BirthCertificateNumber");
            Map(x => x.IsDeleted).Column("IsDeleted");
            Map(x => x.AddBy).Column("AddBy");
            Map(x => x.ModifiedID).Column("ModifiedID");
            Map(x => x.AddByDAte).Column("AddByDAte");
            Map(x => x.ModifiyDate).Column("ModifiyDate");
            Map(x => x.Description).Column("Description");

            References<Gender>(x => x._____Gender).LazyLoad().Cascade.None().Column("Gender").NotFound.Ignore();
            References<Places>(x => x._____BirthPlace).LazyLoad().Cascade.None().Column("BrithdayPlaceId").NotFound.Ignore();
            References<Character>(x => x._____Character).LazyLoad().Cascade.None().Column("id").NotFound.Ignore().ReadOnly();
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
            DescribeMember(x => x.Fname, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            DescribeMember(x => x.NationalCode, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterNationalCode"));
            DescribeMember(x => x.FatherName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFatherName"));
            DescribeMember(x => x.BirthCertificateNumber, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterBirthCertificateNumber"));
            DescribeMember(x => x.BirthCertificateSerial, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterBirthCertificateSerial"));
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterDescription"));
            DescribeMember(x => x.Gender, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.BirthPlace, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Character, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
       
            #endregion

            #region B_RightFulCharacter
            DescribeMember(x => x.Fname, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            DescribeMember(x => x.NationalCode, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterNationalCode"));
            DescribeMember(x => x.FatherName, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFatherName"));
            DescribeMember(x => x.BirthCertificateNumber, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterBirthCertificateNumber"));
            DescribeMember(x => x.BirthCertificateSerial, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterBirthCertificateSerial"));
            DescribeMember(x => x.BrithDayYear, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterBirthCertificateSerial"));
            DescribeMember(x => x.Description, IRERPProfile.B_RightFulCharacter).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterDescription"));
            DescribeMember(x => x.Gender, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.BirthPlace, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.Character, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.B_RightFulCharacter);
            #endregion

            #region Abstract
            DescribeMember(x => x.Fname, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            #endregion


            #region DO_ViewSales
            DescribeMember(x => x.Fname, IRERPProfile.DO_ViewSales).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.DO_ViewSales).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            DescribeMember(x => x.Character, IRERPProfile.DO_ViewSales).UserAsProfile(IRERPProfile.DO_ViewSales);

            #endregion

            #region D_ViewFeasibility
            DescribeMember(x => x.Fname, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.D_ViewFeasibility).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            DescribeMember(x => x.Character, IRERPProfile.D_ViewFeasibility).UserAsProfile(IRERPProfile.D_ViewFeasibility);


            #endregion
            #region D_Contract
            DescribeMember(x => x.Fname, IRERPProfile.D_Contract).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterFName"));
            DescribeMember(x => x.LName, IRERPProfile.D_Contract).DataSourceFieldProperty(title: ApplicationStatics.T("RightFulCharacterLName"));
            DescribeMember(x => x.Character, IRERPProfile.D_Contract).UserAsProfile(IRERPProfile.D_Contract);

            #endregion


        }
    }
}
