using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;


namespace IRERP_RestAPI.Mappings
{


    public class GroupMenuMap : IRERPDescriptor<GroupMenu>
    {
        
        public GroupMenuMap() {
            Table(MsdTableName(null, "irerp", "sys", "GroupMenu"));

			LazyLoad();
			Id(x => x.id).GeneratedBy.Guid().Column("id");
			Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
            Map(x => x.WithChildren).Column("WithChildren").Not.Nullable();
            //================================================
            References<MenuItem>(x => x._____MenuItem).Column("MenuId").LazyLoad().Cascade.None();
            References<Group>(x => x._____Group).Column("GroupId").LazyLoad().Cascade.None();
            //================================================

            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true);
            DescribeMember(x => x.WithChildren, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.Group, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Menu, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
        }
    }
}
