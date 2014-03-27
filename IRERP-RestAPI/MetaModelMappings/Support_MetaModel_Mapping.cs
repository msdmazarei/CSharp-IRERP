using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.MetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.MetaModelMappings
{
    public class Support_MetaModel_Mapping : IRERPDescriptor<Support_MetaModel>
    {
        public Support_MetaModel_Mapping()
        {
            
            DescribeMember(x => x.AllUsers, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllUsers,IRERPProfile.SupportUser_Overview).UserAsProfile(IRERPProfile.SupportUser_Overview);
          
            DescribeMember(x => x.AllUsers, IRERPProfile.Detail).UserAsProfile(IRERPProfile.Detail);

            DescribeMember(x => x.SelectedUser, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.SelecteUserFilter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
    
            DescribeMember(x => x.AllGroup, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllGroupUser, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllGroupMenu, IRERPProfile.General).UserAsProfile(IRERPProfile.General);

            DescribeMember(x => x.AllMenu, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            



            DescribeMember(x => x.AllRightFulCharacter, IRERPProfile.General).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.AllRanzerMan, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allManager, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.allMarketer, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);

        }
    }
}