using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models;

namespace IRERP_RestAPI.Mappings
{


    public class IrerpMenuTbMap : IRERPDescriptor<MenuItem>
    {
        
        public IrerpMenuTbMap() {
            Table(MsdTableName(null, "irerp", "sys", "Menu"));

		LazyLoad();
			Id(x => x.id).GeneratedBy.Guid().Column("id");
            Map(x => x.IsDeleted);
			Map(x => x.EnName).Column("EnName").Not.Nullable().Length(50);
			Map(x => x.Title).Column("Title").Not.Nullable().Length(50);
			Map(x => x.HasChild).Column("HasChild").Not.Nullable();
			Map(x => x.Description).Column("Description").Length(100);
			Map(x => x.MenuItem_Url).Column("URL").Length(100);
			Map(x => x.ParentID).Column("ParentID");
			Map(x => x.MethodToCall).Column("MethodToCall").Length(150);

            //===============================
            //References<GroupMenu>(x => x._____GroupMenu).LazyLoad().Cascade.None();
            HasMany<GroupMenu>(x => x._____GroupMenu).KeyColumn("MenuId").Cascade.None().LazyLoad().NotFound.Ignore();
            //===============================
            DescribeMember(x => x.id, IRERPProfile.General).DataSourceFieldProperty(PrimaryKey:true);
            DescribeMember(x => x.EnName, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MenuItem_EnName"));
            DescribeMember(x => x.Title, IRERPProfile.General).DataSourceFieldProperty(title: ApplicationStatics.T("MenuItem_Title"));
            DescribeMember(x => x.HasChild, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.Description, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.ParentID, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.MenuItem_Url, IRERPProfile.General).DataSourceFieldProperty();
            DescribeMember(x => x.MethodToCall, IRERPProfile.General).DataSourceFieldProperty();
         

        }
    }
}
