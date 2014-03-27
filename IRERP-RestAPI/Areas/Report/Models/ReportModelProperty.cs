using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class ReportModelProperty : ModelBase<ReportModelProperty>
    {
        public virtual string fullpath { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual string ParentPath { get; set; }
    }
}