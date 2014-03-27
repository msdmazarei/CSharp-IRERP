using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.Models;
namespace MsdLib.CSharp.FilterModel
{
    public class ReportVariableFilterBase : FilterBase<ReportVariableFilterBase, ReportVariable>
    {
        Guid? _id;
        public virtual Guid? Id { get { return _id; } set { _id = value; OnPropertyChanged(GPN(x => x.id)); } }
        Guid? _reportid;
        public Guid? ReportId { get { return _reportid; } set { _reportid = value; OnPropertyChanged(GPN(x => x.ReportId)); } }


        public override NHibernate.IQueryOver<ReportVariable, ReportVariable> Query
        {
            get
            {
                var basequery =  base.Query;
                if (Id != null)
                    basequery.And(x => x.id == Id);
                if (ReportId != null)
                    basequery.And(x => x.Reportid == ReportId);

                return basequery;
            }
            set
            {
                base.Query = value;
            }
        }
        

             
    }
}
