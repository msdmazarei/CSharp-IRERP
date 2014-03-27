using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportRepositoryMap : IRERPDescriptor<ReportRepository>
    {
        public ReportRepositoryMap()
        {
            Table(IRERPApplicationUtilities.TableName<ReportRepository>());
            LazyLoad();
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            Map(x => x.strTargetModel).Column("TargetModel").Not.Nullable();
            Map(x => x.Filter).Length(1024);
            Map(x => x.RepositoryType); // can be Dictionary or Variable
            HasMany<Report_ReportRepository>(x => x._____Report_Repositories).Cascade.None();
            HasMany<ReportRepositoryField>(x => x._____Fields).Cascade.None().KeyColumn("ReportRepositoryId");
            //HasMany(x => x._____Fields).LazyLoad().Cascade.None().KeyColumn(IRERPApplicationUtilities.GPN<ReportRepositoryField>(x => x.ReportRepositoryId));
            
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true,Hidden:true);
            DescribeMember(x => x.Name, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.Description, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.strTargetModel, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.RepositoryType, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.Fields, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.TargetModel, IRERPProfile.Detail).UserAsProfile(IRERPProfile.General);
            
  
        }
    }
}