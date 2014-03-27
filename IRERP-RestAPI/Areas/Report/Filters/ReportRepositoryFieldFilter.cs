using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.Filters
{
    public class ReportRepositoryFieldFilter : IRERPFilter<ReportRepositoryFieldFilter, Models.ReportRepositoryField>
    {
        public ReportRepositoryFieldFilter():base()
        {
            isDeleted = false;
        }
        public virtual Guid? id { get; set; }
        public virtual Guid? ReportRepositoryid { get; set; }
        public virtual bool? isDeleted { get; set; }
        public override NHibernate.IQueryOver<Models.ReportRepositoryField, Models.ReportRepositoryField> Query
        {
            get
            {
                var rtn = base.Query;
                if(isDeleted!=null)
                    rtn.And(x => x.IsDeleted == isDeleted);
                if (id != null) return 
                    rtn.And(x => x.id == id);
                if (ReportRepositoryid != null) rtn.And(x => x._____ReportRepository.id == ReportRepositoryid);
                return rtn;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}