using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.Types;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class Report_ReportRepository : ModelBase<Report_ReportRepository>
    {
        /*   public virtual Report _____Report { get; set; }
       Report _Report = null;
       public virtual Report Report */
        LoadableVar<Report> _Report = new LoadableVar<Report>();
        public virtual Report _____Report { get; set; }
        public virtual Report Report { 
            get {
            return LoadNHRelation<Report, Guid>(
                ref _Report, 
                x => x._____Report, 
                ModelRepositories.Report_Repository.GetById, 
                x => x._____Report.id);

            /*if (_Report != null) return _Report;
            _Report = GetByNHibernateRelationProprty<Report>(x => x._____Report);
            if (_Report != null) return _Report;
            //Retrive From Db
            _Report = ModelRepositories.Report_Repository.GetById(_____Report.id);
            return _Report;*/
        }
            set { SetRelationProperty(x => x.Report, x => x._____Report, _Report, value); }
        }

        //public virtual ReportRepository _____ReportRepository { get; set; }
        //ReportRepository _ReportRepository = null;

        LoadableVar<ReportRepository> _ReportRepository = new LoadableVar<ReportRepository>();
        public virtual ReportRepository _____ReportRepository { get; set; }
        public virtual ReportRepository ReportRepository {
            get {
            return LoadNHRelation<ReportRepository, Guid>(
                ref _ReportRepository, x => x._____ReportRepository,
                ModelRepositories.ReportRepository_Repository.GetById, x => x._____ReportRepository.id);

        }
            set { SetRelationProperty(x => x.ReportRepository, x => x._____ReportRepository, _ReportRepository, value); }
        }

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if(PropertyPath == _GPN(x=>x.Report) )return new Tuple<string,NHibernate.SqlCommand.JoinType,NHibernate.Criterion.ICriterion>(_GPN(x=>x._____Report), NHibernate.SqlCommand.JoinType.InnerJoin,null);
            if(PropertyPath == _GPN(x=>x.ReportRepository)) return new Tuple<string,NHibernate.SqlCommand.JoinType,NHibernate.Criterion.ICriterion>(_GPN(x=>x._____ReportRepository), NHibernate.SqlCommand.JoinType.InnerJoin,null);
            return base.GetAssociation(PropertyPath);
        }
        public virtual Stimulsoft.Report.Dictionary.StiBusinessObject ToBussinessObject()
        {
         return ReportRepository.ToBussinessObject();
        }
        public virtual System.Data.DataTable ToDataTable()
        {
            return ReportRepository.ToDataTable();
        }

        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            //Guid _id = Guid.Empty;
            //Report_ReportRepository rtn = null;

            //if (primarykeys_value.Keys.Contains(_GPN(x => x.id)))
            //    rtn = ModelRepositories.Report_ReportRepository_Repository.GetById((Guid)primarykeys_value[_GPN(x=>x.id)]);
            //return rtn;

            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                 && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.Report_ReportRepository_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);

            }
            else
                return null;
        }
        public override void LoadFromStringDictionary(Dictionary<string, string> Dic)
        {
            if (Dic.Keys.Contains(_GPN(x => x.ReportRepository.id).ToClientDsFieldName()))
                ReportRepository = ModelRepositories.ReportRepository_Repository.GetById(Guid.Parse(Dic[_GPN(x => x.ReportRepository.id).ToClientDsFieldName()]));
            if (Dic.Keys.Contains(_GPN(x => x.Report.id).ToClientDsFieldName()))
                Report = ModelRepositories.Report_Repository.GetById(Guid.Parse(Dic[_GPN(x => x.Report.id).ToClientDsFieldName()]));

            //base.LoadFromStringDictionary(Dic);
        }
        public virtual void AddVariablesToReport(ref Stimulsoft.Report.StiReport rpt)
        {
            ReportRepository.AddVariablesToReport(ref rpt);
        }
        public virtual System.Data.DataTable RandomData()
        {
            return ReportRepository.RandomData();
            
        }

    }
}