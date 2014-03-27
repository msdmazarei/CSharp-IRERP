using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
namespace IRERP_RestAPI.Areas.Report.Filters
{
    public class ReportFilter : IRERPFilter<ReportFilter, Models.Report>
    {
        public Guid? Id { get; set; }
        public string ReportName { get; set; }
        public bool? isDeleted { get; set; }
        public ReportFilter()
        {
            isDeleted = false;
        }

        public override NHibernate.IQueryOver<Models.Report, Models.Report> Query
        {
            get
            {
                var rtn = base.Query;
                if(isDeleted!=null) 
                rtn.And(x=>x.IsDeleted == false);
                if (ReportName != null)
                    rtn.And(x => x.ReportName == ReportName);
                if (Id != null) rtn.And(x => x.id == Id);
                return rtn;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}