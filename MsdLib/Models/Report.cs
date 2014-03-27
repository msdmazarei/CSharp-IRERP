using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.FilterModel;
using MsdLib.ExtentionFuncs.Strings;
namespace MsdLib.CSharp.Models
{
    public class Report : ModelBase<Report>
    {
        string _title,_Description;
        byte [] _content ; 
        string _classname;
        public Report()
            :base()
        {
            ClassProperties = new string[]{_GPN(x=>x.Title),_GPN(x=>x.Content),_GPN(x=>x.ClassName),_GPN(x=>x.Description)};

        }
        public virtual string Title { get { return _title; } set { _title = value; OnPropertyChanged(_GPN(x => x.Title)); } }
        public virtual string Description { get { return _Description; } set { _Description = value; OnPropertyChanged(_GPN(x => x.Description)); } }
        public virtual byte[] Content { get { return _content; } set { _content = value; OnPropertyChanged(_GPN(x => x.Content)); OnPropertyChanged(_GPN(x => x.ReportLength)); } }
        public virtual string ClassName { get { return _classname; } set { _classname = value; OnPropertyChanged(_GPN(x => x.ClassName)); } }
        public virtual string ReportLength
        {
            get
            {
                if (Content == null) return "0"+ " Bytes" ;
                return Content.Length.ToString()+" Bytes";
            }
        }

        IList<ReportVariable> _variables;
        public virtual IList<ReportVariable> Variables { 
            get {
                if (_variables == null)
                    _variables = ReportVariable.GetReportVariableByReport(this.id);
                return _variables;
                } 
            set { _variables = value; OnPropertyChanged(_GPN(x => x.Variables)); } }

        public override string this[string columnName]
        {
            get
            {
                string rtn = null;
                if (columnName == _GPN(x => x.ReportLength))
                {
                    if (ReportLength == "0 Bytes")
                        rtn += "حتما بایستی پرونده گزارش وجود داشته باشد";
                }
                if (columnName == _GPN(x => x.Content))
                {
                    if (Content == null) rtn+="حتما بایستی پرونده گزارش وجود داشته باشد";
                    if(Content!=null)
                        if (Content.Length < 1) rtn+="حتما بایستی پرونده گزارش وجود داشته باشد";

                }
                if (columnName == _GPN(x => x.Title))
                {
                    if (!Title.NotEmpty())
                        rtn+="عنوان گزارش الزامی است";
                }
                return rtn;
            }
        }
        public virtual Report GetReprtById(Guid Reportid)
        {
            var q =
                (new ReportFilterBase() { Id = Reportid }).Query.List();
            if(q.Count>0) 
                return q[0];
            return null;
        }

    }
}
