using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.MetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.MetaModelMapping
{
    public class Report_MetaData_Mapping : IRERPDescriptor<Report.MetaModels.Report_MetaModel>
    {
        public Report_MetaData_Mapping()
        {
            DescribeMember(x => x.SelectedReportRepository, IRERPProfile.Detail).UserAsProfile(IRERPProfile.Detail);
            DescribeMember(x => x.ReportRepositories, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
          //  DescribeMember(x => x.ReportModels, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.SelectedReportRepository, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.Reports, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
            DescribeMember(x => x.SelectedReport, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);

            
        }
        
    }
}