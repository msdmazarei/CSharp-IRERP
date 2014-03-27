using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.FilterModel;
namespace MsdLib.CSharp.Models
{
    public class ReportVariable : ModelBase<ReportVariable>
    {
        string _name, _description,_defaultvalue;
        public virtual string Name { get { return _name; } set { _name = value; OnPropertyChanged(_GPN(x => x.Name)); } }
        public virtual string Description { get { return _description; } set { _description = value; OnPropertyChanged(_GPN(x => x.Description)); } }
        public virtual string DefaultValue { get { return Name + "_DefaultValue"; } set { _defaultvalue = value; OnPropertyChanged(_GPN(x => x.DefaultValue)); } }
        public virtual string Value { get; set; }
        Report _rpt;
        public virtual Report Report { get {
            if (Reportid == null) return null;
            if (_rpt == null)
                _rpt = Report.GetReprtById((Guid)Reportid);
            return _rpt; 
        } set { _rpt = value;
        if (value == null) _reportid = null;
        if (value != null) _reportid = value.id;
            OnPropertyChanged(_GPN(x => x.Report)); } }

        Guid? _reportid;
        public virtual Guid? Reportid
        {
            get { return _reportid; }
            set
            {
                _reportid = value; 
                _rpt = null;
            OnPropertyChanged(_GPN(x => x.Reportid)); 
            } 
        }
        public static IList<ReportVariable> GetReportVariableByReport(Guid Reportid)
        {
            return (new ReportVariableFilterBase() { ReportId = Reportid }).Query.List();
        }
        public override string this[string columnName]
        {
            get
            {
                string rtn = null;
                if (columnName == _GPN(x => x.Name))
                    rtn += "نام متغییر الزامی است";
                return rtn;
            }
        }
    }
}
