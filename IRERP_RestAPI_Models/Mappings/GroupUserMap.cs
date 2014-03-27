using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI.Mappings
{


    public class GroupUserMap : IRERPDescriptor<GroupUser>
    {
        
        public GroupUserMap() {
            Table(MsdTableName(null, "irerp", "sys", "GroupUser"));

			LazyLoad();
			Id(x => x.id).GeneratedBy.Guid().Column("Id");
			Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
            //Map(x => x.GroupId).Column("GroupId").Not.Nullable();
            //Map(x => x.id).Column("UserID").Not.Nullable();

            //=========================
           
            References<User>(x => x._____User).LazyLoad().Cascade.None().Column("UserID");
            References<Group>(x => x._____Group).LazyLoad().Cascade.None().Column("GroupId");


            //=========================
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true);
            //DescribeMember(x => x.GroupId, IRERPProfile.Detail).DataSourceFieldProperty(title: ApplicationStatics.T("GroupUserMap_GroupID"));
            //DescribeMember(x => x.id, IRERPProfile.Detail).DataSourceFieldProperty(title: ApplicationStatics.T("GroupUserMap_UserID"));

            DescribeMember(x => x.Group, IRERPProfile.Any).UserAsProfile(IRERPProfile.Abstract);
            DescribeMember(x => x.User, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);


        }
    }
}
