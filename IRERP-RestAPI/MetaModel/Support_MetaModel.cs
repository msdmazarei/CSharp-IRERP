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
    public class Support_MetaModel : ControllerMetaModelBase<Support_MetaModel>
    {
        public Support_MetaModel()
        {
            Profile = Bases.MetaDataDescriptors.IRERPProfile.General;
        }

      

        public IList<RightFulCharacter> AllRightFulCharacter
        {
            get
            {
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetAllRightFulCharacter();
            }
        }
        
        public IList<User> AllUsers
        {
            get
            {
                return ModelRepositories.UserRepository.GetAllUsers();
            }
        }


       
       
        public User SelectedUser
        {
            get

            {

                var uid = IRERPApplicationUtilities.GetFromSession<Support_MetaModel, User>(x => x.SelectedUser);
                if (uid != null)
                    return ModelRepositories.UserRepository.GetUserById(Guid.Parse(uid));
                else
                    return new User();
                
            }
            set
            {
                if (value != null)
                    IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(x => x.SelectedUser, value.id.ToString());
                else
                    IRERPApplicationUtilities.SaveToSession<Support_MetaModel, User>(x => x.SelectedUser, null);
            }

        }

    
        public IList<MenuItem> AllMenu
        {
            get
            {
                return ModelRepositories.IrerpMenu_Repository.GetAllMenu();
            }
        }
    
        public IList<Group> AllGroup
        {
            get
            {
                return ModelRepositories.Group_Repository.GetAllGroup();
            }
        }

        public IList<GroupUser> AllGroupUser
        {
            get
            {
                //return null;
               return ModelRepositories.GroupUser_Repository.GetAllGroupUser();
            }
        }

        public IList<GroupMenu> AllGroupMenu
        {
            get
            {
                //return null;
                return ModelRepositories.GroupMenu_Repository.GetAllGroupMenu();
            }
        }

        public virtual Models.User SelecteUserFilter
        {
            get
            {
                var selectedid = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromSession<Support_MetaModel,User>(x => x.SelecteUserFilter);
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.UserRepository.GetUserById((Guid)id);
                return new Models.User();
            }
            set
            {
            }
        }



                public IList<RightFulCharacter> AllRanzerMan
        {
            get
            {
                //return null;
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetAllRanzerMan();
            }
        }

        public IList<RightFulCharacter> allManager
        {
            get
            {
                //return null;
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetAllallManager();
            }
        }
        public IList<RightFulCharacter> allMarketer
        {
            get
            {
                //return null;
                return ModelRepositories.Bases.RightFulCharacter_Repository.GetAllMarketer();
            }
        }

      
    }
}
