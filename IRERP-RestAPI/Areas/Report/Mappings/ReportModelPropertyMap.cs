using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportModelPropertyMap : IRERPDescriptor<ReportModelProperty>
    {
        public ReportModelPropertyMap()
        {
            Table(IRERPApplicationUtilities.TableName<Models.Report_ReportRepository>());
            Id(x => x.fullpath);
            
            DescribeMember(x => x.fullpath, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true,Hidden:true);
            DescribeMember(x => x.Name, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.Type, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.ParentPath, IRERPProfile.Any).DataSourceFieldProperty();
        }
    }
}