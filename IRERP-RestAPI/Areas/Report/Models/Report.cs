using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MsdLib.Types;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class Report : ModelBase<Report>
    {
        public virtual string ReportName { get; set; }
        public virtual string Description { get; set; }
        public virtual string TypeFullName { get; set; }
        public virtual Type ModelType { get { return IRERPApplicationUtilities.GetTypeFromString(TypeFullName); } set { TypeFullName = value.FullName; } }
        public virtual byte[] ReportDocument { get; set; }
        public virtual string ReportFileName { get; set; }
/*        public virtual IList<ReportField> ReportFields { get { return _____ReportFields; } set { _____ReportFields = value; } }
        public virtual IList<ReportField> _____ReportFields { get; set; }*/
        // IList<Report_ReportRepository> _ReportRepositories = null;

        LoadableVar<IList<Report_ReportRepository>> _ReportRepositories = new LoadableVar<IList<Report_ReportRepository>>();
        public virtual IList<Report_ReportRepository> _____ReportRepositories { get; set; }
        public virtual IList<Report_ReportRepository> ReportRepositories { 
            get {

            return LoadNHRelation<Report_ReportRepository, Guid>(
            ref _ReportRepositories,
            x => x._____ReportRepositories,
            ModelRepositories.Report_ReportRepository_Repository.GetByReportId<Models.Report>,
            x => x.id,
            (x, y) => {
                y.Report = x;
                return y.Save(y.Session, y.Transaction, false);
                 },
            (x, y) => {
                return y.Remove(null, false);
                 }
            );
           }
            set { SetRelationProperty(x => x.ReportRepositories, x => x._____ReportRepositories, _ReportRepositories, value); } 
        }

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            //if(
            //    primarykeys_value.Keys.Contains(_GPN(x=>x.id))
            //    )
            //    return ModelRepositories.Report_Repository.GetById((Guid)primarykeys_value[_GPN(x=>x.id)]);
            //return base.LoadByPrimaryKeys(primarykeys_value);

            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                      && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Report_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);

            }
            else
                return null;
        }
        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (PropertyPath == _GPN(x => x.ReportRepositories))
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____ReportRepositories), NHibernate.SqlCommand.JoinType.InnerJoin, null);

         /*   if (PropertyPath == _GPN(x => x.ReportFields))
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____ReportFields), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            */
            return base.GetAssociation(PropertyPath);
        }
        public virtual string ReportFileName_fullpath()
        {
            var physicalpath = IRERP_RestAPI.Bases.IRERPApplicationUtilities.PhysicalApplicationPath();
            if (ReportFileName == null) ReportFileName = id.ToString();
            if (ReportFileName.Trim() == "") ReportFileName = id.ToString();
            string RptFilePath = physicalpath + @"Areas\Report\ReportFiles\"
               + ReportFileName;

            return RptFilePath;
        }
        public virtual Stimulsoft.Report.StiReport ToStiReport()
        {
            try
            {
                
                Stimulsoft.Report.StiReport rtn = new Stimulsoft.Report.StiReport();
                IRERPApplicationUtilities.ResumeNext(() => rtn.Load(ReportFileName_fullpath()));
                if (rtn == null) rtn = new Stimulsoft.Report.StiReport();
                if(rtn.Dictionary!=null)
                rtn.Dictionary.Clear();
                if (rtn.Dictionary.Variables != null) 
                rtn.Dictionary.Variables.Clear();


                foreach (var RR in ReportRepositories)
                {
                    if (RR.ReportRepository.RepositoryType != null)
                    {
                        switch (RR.ReportRepository.RepositoryType.Trim().ToLower())
                        {
                            case "dictionary":
                                rtn.Dictionary.DataSources.Add(RR.ReportRepository.ToStiDataTableSource());
                                break;
                            case "variable":
                                RR.ReportRepository.AddVariablesToReport(ref rtn);
                                break;
                        }
                    }

                    /*DataView _q;
                    var q = RR.ReportRepository.ToDataTable();
                    _q= new DataView(q);
                    _q.Table.TableName = RR.ReportRepository.Name;*/
                    
                    rtn.Dictionary.Synchronize();
                }
                return rtn;
            }
            catch
            {
                return new Stimulsoft.Report.StiReport();
            }
            
        }
        
    }
}