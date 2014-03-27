using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace IRERP_RestAPI.MetaModel
{
    public class BasesInformation_MetaModel : ControllerMetaModelBase<BasesInformation_MetaModel>
    {
        public BasesInformation_MetaModel()
        {
            Profile = Bases.MetaDataDescriptors.IRERPProfile.General;

        }


        public virtual Models.Bases.Character SelecteCharacterFilter
        {
            get
            {
                var selectedid =
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromSession<BasesInformation_MetaModel>(x => x.SelecteCharacterFilter.id);

                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.Bases.Character_Repository.GetCharacterByID((Guid)id);
                return new Models.Bases.Character();
            }
            set
            {
            }
        }

        public IList<LegalCharacter> allLegalCharacter
        {
            get
            {
                return ModelRepositories.Bases.LegalCharacter_Repository.GetAllLegalCharacter();
            }
        }




        public IList<LegalCharacterType> allLegalcharactertype
        {
            get
            {
                return ModelRepositories.Bases.LegalCharacterType_Repository.GetAllLegalCharacterType();
            }
        }

        public IList<LegalBranch> allLegalBranch
        {
            get
            {
                return ModelRepositories.Bases.LegalBranch_Repository.GetAllLegalBranch();
            }
        }


        public IList<Places> allPlaces
        {
            get
            {
                return ModelRepositories.Bases.Places_Repository.GetAllPlaces();
            }
        }



        public IList<MessagingInfoType> allMessagingInfoType
        {
            get
            {
                return ModelRepositories.Bases.MessagingInfoType_Repository.GetAllMessagingInfoType();
            }
        }



        public IList<CharacterRole> AllCharacterRole
        {
            get
            {
                return ModelRepositories.Bases.CharacterRole_Repository.GetAllCharacterRole();
            }
        }
        public IList<Gender> AllGender
        {
            get
            {
                return ModelRepositories.Bases.Gender_Repository.GetAllGender();
            }
        }

      

        public IList<Charactertype> AllCharacterType
        {
            get
            {
                return ModelRepositories.Bases.Charactertype_Repository.GetAllCharacterType();
            }
        }
        public IList<CallInfo> AllCallInfo
        {
            get
            {
                return ModelRepositories.Bases.CallInfo_Repository.GetAllCallInfo();
            }
        }
        public IList<PostalAddressType> AllPostalAddressType
        {
            get
            {
                return ModelRepositories.Bases.PostalAddressType_Repository.GetAllPostalAddressType();
            }
        }
        public IList<CallInfoType> AllCallInfoType
        {
            get
            {
                return ModelRepositories.Bases.CallInfoType_Repository.GetAllCallInfoType();
            }
        }
        public IList<MessagingRelationType> AllMessaginRelationTypeType
        {
            get
            {
                return ModelRepositories.Bases.MessagingRelationType_Repository.GetAllMessagingRelationType();
            }
        }


        public IList<RightFulCharacter> AllRightFullCharacter
        {
            get
            {
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetAllRightFulCharacter();
            }
        }
        public IList<MessagingInfo> AllMessaginInfo
        {
            get
            {
                return ModelRepositories.Bases.MessagingInfo_Repository.GetAllMessagingInfo();
            }
        }

        public IList<PostalAddress> AllPostalAddress
        {
            get
            {
                return ModelRepositories.Bases.PostalAddress_Repository.GetAllPostalAddress();
            }
        }
        public IList<Character> AllCharacter
        {
            get
            {
                return ModelRepositories.Bases.Character_Repository.GetAllCharacter();
            }
        }

        public IList<RolsOfCharacter> AllRolsOfCharacter
        {
            get
            {
                return ModelRepositories.Bases.RolsOfCharacter_Repository.GetAllRolsOfCharacter();
            }
        }

        public IList<MenuItem> AllMenu
        {
            get
            {
                return ModelRepositories.IrerpMenu_Repository.GetAllMenu();
            }
        }

       
        
        public IList<Character> AllCharacters
        {
            get
            {
                return ModelRepositories.Bases.Character_Repository.GetAllCharacter();
            }
        }
        public IList<Nationality> allNationality
        {
            get
            {
                return ModelRepositories.Bases.Nationality_Repository.GetAllNationality();
            }
        }
        public IList<Help> allHelp
        {
            get
            {
                return ModelRepositories.Bases.Help_Repository.GetAllHelp();
            }
        }
        public IList<Language> AllLanguage
        {
            get
            {
                return ModelRepositories.Bases.Language_Repository.GetAllLanguage();
            }
        }


        public IList<IdentificationType> allIdentificationType
        {
            get
            {
                return ModelRepositories.Bases.IdentificationType_Repository.GetAllIdentificationType();
            }
        }
              public IList<User> AllUsers
        {
            get
            {
                //return null;
                return ModelRepositories.UserRepository.GetAllUsers();
            }
        }
    
      
    }
}