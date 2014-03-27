using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
namespace IRERP_RestAPI.Areas.Report.Filters
{
    public class Report_ReportRepositoryFilter : IRERPFilter<Report_ReportRepositoryFilter, Models.Report_ReportRepository>
    {
        public Report_ReportRepositoryFilter()
        {
            this.isDeleted = false;
        }
        public Guid? id { get; set; }
        public bool? isDeleted { get; set; }
        public Guid? Report_id { get; set; }
        public override NHibernate.IQueryOver<Report_ReportRepository, Report_ReportRepository> Query
        {
            get
            {
                var q = base.Query;
                if (id != null)
                    q.And(x => x.id == id);
                if (isDeleted != null)
                    q.And(x => x.IsDeleted == isDeleted);
                if (Report_id != null)
                    q.And(x => x._____Report.id == Report_id);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}