using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportModelMap : IRERPDescriptor<ReportModel>
    {
        public ReportModelMap()
        {
            Id(x => x.fullname);
            DescribeMember(x => x.fullname, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.Name, IRERPProfile.Any);
            DescribeMember(x => x.NameSpace, IRERPProfile.Any);
            DescribeMember(x => x.Properties, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
        }
    }
}