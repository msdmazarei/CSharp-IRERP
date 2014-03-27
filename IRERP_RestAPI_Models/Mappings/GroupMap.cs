using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI.Mappings
{


    public class GroupMap : IRERPDescriptor<Group>
    {
        
        public GroupMap() {
            Table(MsdTableName(null, "irerp", "sys", "Group"));
			LazyLoad();
			Id(x => x.id).GeneratedBy.Guid().Column("id");
			Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
			Map(x => x.GroupName).Column("GroupName").Not.Nullable().Length(150);
			Map(x => x.Description).Column("Description").Length(500);
            //=================================
            HasMany<GroupUser>(x => x._____GroupUsers).KeyColumn("GroupId").Cascade.None().LazyLoad().NotFound.Ignore();
            //=================================





            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true);
            DescribeMember(x => x.GroupName, IRERPProfile.Any).DataSourceFieldProperty(title: ApplicationStatics.T("GroupMap_GroupName"));
            DescribeMember(x => x.Description, IRERPProfile.Any).DataSourceFieldProperty(title: ApplicationStatics.T("GroupMap_Description"));
            DescribeMember(x => x.GroupName, IRERPProfile.Abstract).DataSourceFieldProperty(title: ApplicationStatics.T("GroupMap_GroupName"));
        }
    }
}
