using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportRepositoryFieldMap : IRERPDescriptor<ReportRepositoryField>
    {
        public ReportRepositoryFieldMap()
        {
            Table(IRERPApplicationUtilities.TableName<ReportRepositoryField>());
            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.DisplayName);
            Map(x => x.Description);
          //  Map(x=>x.ReportRepositoryId).Not.Nullable();
            
            References<ReportRepository>(x => x._____ReportRepository

                ).LazyLoad().NotFound.Ignore().Cascade.None().Column("ReportRepositoryId"); ;
            
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true,Hidden:true);
            DescribeMember(x => x.Name, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.DisplayName, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x=>x.Description, IRERPProfile.Any).DataSourceFieldProperty();
          //  DescribeMember(x => x.ReportRepositoryId, IRERPProfile.Any).DataSourceFieldProperty();



        }
    }
}