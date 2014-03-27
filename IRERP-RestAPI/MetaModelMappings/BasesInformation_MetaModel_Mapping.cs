using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.MetaModel;

namespace IRERP_RestAPI.MetaModelMappings
{
    public class BasesInformation_MetaModel_Mapping : IRERPDescriptor<BasesInformation_MetaModel>
    {
        public BasesInformation_MetaModel_Mapping()
        {

            DescribeMember(x => x.SelecteCharacterFilter, IRERPProfile.General)
         .UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.allLegalCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllCharacterRole, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllRightFullCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllGender, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allMessagingInfoType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);


            DescribeMember(x => x.AllCallInfo, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllMessaginInfo, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllPostalAddress, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allLegalcharactertype, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allLegalBranch, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allPlaces, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllRolsOfCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllPostalAddressType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllCallInfoType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllCharacterType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllMessaginRelationTypeType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllMenu, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
       
            DescribeMember(x => x.AllRightFullCharacter, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.B_RightFulCharacter);
            DescribeMember(x => x.SelecteCharacterFilter, IRERPProfile.B_RightFulCharacter).UserAsProfile(IRERPProfile.B_RightFulCharacter);


            DescribeMember(x => x.SelecteCharacterFilter, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.B_LegalCharacter);
            DescribeMember(x => x.allLegalCharacter, IRERPProfile.B_LegalCharacter).UserAsProfile(IRERPProfile.B_LegalCharacter);


           DescribeMember(x => x.allNationality, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
           DescribeMember(x => x.allHelp, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

           DescribeMember(x => x.AllLanguage, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
           DescribeMember(x => x.allIdentificationType, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
           DescribeMember(x => x.AllUsers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
          }
    }
}