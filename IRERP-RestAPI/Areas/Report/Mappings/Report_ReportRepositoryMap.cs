using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class Report_ReportRepositoryMap : IRERPDescriptor<Models.Report_ReportRepository>
    {
        public Report_ReportRepositoryMap()
        {
             Table(IRERPApplicationUtilities.TableName<Models.Report_ReportRepository>());
            Id(x => x.id).GeneratedBy.Guid();
            References<Models.Report>(x => x._____Report).Cascade.None().Column("Report_id");
            References<Models.ReportRepository>(x => x._____ReportRepository).Cascade.None().Column("ReportRepository_id");
            Map(x => x.IsDeleted);
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Report, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.ReportRepository, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);


        }
    }
}