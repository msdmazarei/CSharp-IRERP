using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
namespace IRERP_RestAPI.Areas.Report.Filters
{
    public class ReportRepositoryFilter : IRERPFilter<ReportRepositoryFilter, ReportRepository>
    {
        public ReportRepositoryFilter()
        {
            isDeleted = false;
        }
        public Guid? id { get; set; }
        public bool? isDeleted { get; set; }
        public override NHibernate.IQueryOver<ReportRepository, ReportRepository> Query
        {
            get
            {
                var q = base.Query;
                if(isDeleted!=null) q.And(x => x.IsDeleted == isDeleted);
                if (id != null) q.And(x => x.id == id);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}