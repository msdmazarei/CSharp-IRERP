using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportMap : IRERPDescriptor<Models.Report>
    {
        public ReportMap()
        {
            Table(IRERPApplicationUtilities.TableName<Models.Report>());
            Id(x => x.id);
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.ReportName);
            Map(x => x.TypeFullName);
            Map(x => x.ReportDocument);
            Map(x => x.ReportFileName);
            Version(x => x.Version);
                
            ///////////////////
            HasMany<Report_ReportRepository>(x => x._____ReportRepositories).Cascade.None();   
                
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Description, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.ReportName, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.ReportRepositories, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            //DescribeMember(x => x.ReportFields, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
        }
    }
}