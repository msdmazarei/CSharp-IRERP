using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Areas.Report.Mappings
{
    public class ReportFieldMap : IRERPDescriptor<Models.ReportField>
    {
        public ReportFieldMap()
        {
            Table(IRERPApplicationUtilities.TableName<ReportField>());
            Id(x => x.id);
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.stiName).Not.Nullable();
            Map(x => x.stiDisplayName).Not.Nullable();
            Map(x => x.TypeName).Not.Nullable();
            
            ///////////////////
            References<Models.Report>(x => x.Report).LazyLoad().Cascade.None().ForeignKey("none");
               
                
            DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty(PrimaryKey: true, Hidden: true);
            DescribeMember(x => x.stiName, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.stiDisplayName, IRERPProfile.Any).DataSourceFieldProperty();
            DescribeMember(x => x.TypeName, IRERPProfile.Any).UserAsProfile(IRERPProfile.General);
        }
    }
}