using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
namespace IRERP_RestAPI.Areas.Report.Filters
{
    public class ReportFieldFilter : IRERPFilter<ReportFieldFilter, Models.ReportField>
    {
        public Guid? Id { get; set; }
        public override NHibernate.IQueryOver<Models.ReportField, Models.ReportField> Query
        {
            get
            {
                var rtn = base.Query;
                rtn.And(x=>x.IsDeleted == false);
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