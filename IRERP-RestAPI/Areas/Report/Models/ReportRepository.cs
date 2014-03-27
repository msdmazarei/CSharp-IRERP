using IRERP_RestAPI.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using Stimulsoft.Report.Dictionary;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
namespace IRERP_RestAPI.Areas.Report.Models
{
    public class ReportRepository : IRERP_RestAPI.Bases.ModelBase<ReportRepository>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string strTargetModel { get; set; }
        public virtual string Filter { get; set; }
        public virtual string RepositoryType { get; set; }
        public virtual ReportModel TargetModel { get { return new ReportModel() { fullname = strTargetModel }; } }



        //public virtual IList<ReportRepositoryField> _____Fields { get; set; }
        //IList<ReportRepositoryField> _fields = null;
        LoadableVar<IList<ReportRepositoryField>> _fields = new LoadableVar<IList<ReportRepositoryField>>();
        public virtual IList<ReportRepositoryField> _____Fields { get; set; }
        public virtual IList<ReportRepositoryField> Fields { get {
            return LoadNHRelation<ReportRepositoryField, Guid>(
                ref _fields, 
                x => x._____Fields, 
                ModelRepositories.ReportRepositoryField_Repository.GetBy_ReportRepository<ReportRepository>, 
                x => x.id,
                (x, y) =>
                   {
                       y.ReportRepository = x;
                       return y.Save(y.Session, y.Transaction, false);
                   },
                (x, y) =>
                      {
                          return y.Remove(CommitTransaction: false);
                      });


/*            IRERP_RestAPI.Models.RealInvoice a = new IRERP_RestAPI.Models.RealInvoice();
            if (_fields!= null) return _fields;
            var parentchildspec = ModelRepositories.ReportRepositoryField_Repository.GetBy_ReportRepository<ReportRepository>(this.id);
            parentchildspec.ParentInstance = this;
            
            parentchildspec.AddToCollection = new Func<ReportRepository, ReportRepositoryField, FunctionResult<INHibernateEntity>>(
                (x, y) => { 
                    y.ReportRepository= x;
                    return y.Save(y.Session, y.Transaction, false);
                    }
                );
            parentchildspec.RemoveFromCollection = new Func<ReportRepository, ReportRepositoryField, FunctionResult<INHibernateEntity>>(
                (x, y) =>
                {
                    return y.Remove(CommitTransaction:false);
                });

            _fields= parentchildspec;
            return _fields; */
        }
            set { SetRelationProperty(x => x.Fields, x => x._____Fields, _fields, value); } 

        //    set { 
        //    _fields= value;
        //    _____Fields = value;
        //}
        }
        public virtual IList<Report_ReportRepository> _____Report_Repositories { get; set; }

        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.Fields) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____Fields), NHibernate.SqlCommand.JoinType.InnerJoin, null);

            return base.GetAssociation(PropertyPath);
        }
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            //if (primarykeys_value.Keys.Contains(_GPN(x => x.id)))
            //    return ModelRepositories.ReportRepository_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);
            //return base.LoadByPrimaryKeys(primarykeys_value);

            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.ReportRepository_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            else
                return null;
        }

        public virtual Stimulsoft.Report.Dictionary.StiBusinessObject ToBussinessObject
          ()
        {
            try
            {
                Stimulsoft.Report.Dictionary.StiBusinessObject rtn = new Stimulsoft.Report.Dictionary.StiBusinessObject();
                rtn.Name = this.Name;
                rtn.Alias = this.Name;
                foreach (var f in this.Fields)
                {
                    rtn.Columns.Add(f.ToStiColumn());
                }
                return rtn;
            }
            catch
            {
                return new Stimulsoft.Report.Dictionary.StiBusinessObject();
            }
        }
        public virtual void AddVariablesToReport(ref Stimulsoft.Report.StiReport rpt)
        {
            if (rpt.Dictionary.Variables == null)
                rpt.Dictionary.Variables = new StiVariablesCollection();
            var inst = IRERPApplicationUtilities.NewInstance(
                IRERPApplicationUtilities.GetTypeFromString(strTargetModel)
                );
            foreach (var f in Fields)
            {
                rpt.Dictionary.Variables.Add(f.DisplayName,f.GetValue(inst));

            }
        }
        public virtual void RegisterDataToReport(ref Stimulsoft.Report.StiReport Report, DataTable Datas)
        {
            Report.RegData(Name, Datas);
            Report.Dictionary.Synchronize();
        }
        public virtual void RegisterDataToReport(ref Stimulsoft.Report.StiReport Report,IList Datas)
        {
            
            //Report.RegBusinessObject(this.Name, Datas);
            DataTable dt = new DataTable();
            foreach (var f in Fields)
            {
                dt.Columns.Add(f.ToDataColumn());
            }

            if (Datas == null)
            {
                Report.RegData(Name, dt);
                Report.Dictionary.Synchronize();
                return;
            }
                
            //TODO: Use parallel method
            foreach (var d in Datas)
            {
                List<object>  values = new List<object>();
                foreach (var f in Fields)
                    values.Add(f.GetValue(d));

                dt.Rows.Add(values.ToArray());
            }
            DataView _q = new DataView(dt);
            _q.Table.TableName = Name;
            
            Report.RegData(Name,_q);
            /*for (int i = 0; i < Report.Dictionary.DataSources.Items.Length; i++)

                if (Report.Dictionary.DataSources.Items[i].Name == "view"+Name)
                {
                    Report.Dictionary.DataSources.Items.
                }
              */      

            
            Report.Dictionary.Synchronize();
            
        }
        public virtual StiDataTableSource ToStiDataTableSource()
        {
            StiDataTableSource rtn = new StiDataTableSource();
            foreach (var f in Fields)
            {
               rtn.Columns.Add(f.ToStiColumn());
            }
            rtn.Name = Name;
            rtn.NameInSource = Name;
            rtn.Alias = Name;
            return rtn;

        }
        public virtual DataTable ToDataTable()
        {
            DataTable dt = new DataTable();
            foreach (var f in Fields)
            {
                dt.Columns.Add(f.ToDataColumn());
            }
            return dt;
        }
        public virtual DataTable ToDataTable(IList datas)
        {
            DataTable dt = new DataTable();
            foreach (var f in Fields)
            {
                dt.Columns.Add(f.ToDataColumn());
            }
            if (datas != null)
            {
                /* cause make our orders worng
                System.Threading.Tasks.Parallel.For(0,datas.Count,x=>{
                    var d = datas[x];
                    List<object> values = new List<object>();
                    foreach (var f in Fields)
                        values.Add(f.GetValue(d));
                    lock (dt)
                    {
                        dt.Rows.Add(values.ToArray());
                    }
                });
               }
                */
                for (int x = 0; x < datas.Count; x++)
                {
                    var d = datas[x];
                    List<object> values = new List<object>();
                    foreach (var f in Fields)
                        values.Add(f.GetValue(d));
                    /* lock (dt)
                     {*/
                    dt.Rows.Add(values.ToArray());
                    //}
                }
            }
            return dt;
        }
        public virtual System.Data.DataTable RandomData()
        {
            var dt = ToDataTable();
            List<int> a = new List<int>();
            for (int i = 0; i < 3; i++)
                a.Add(i);
            a.AsParallel().ForAll(x =>
            {
                var dr = dt.NewRow();
                foreach(DataColumn q in dt.Columns)
                {
                    dr[q] = IRERPApplicationUtilities.GetRandomValue(q.DataType);
                }
                lock (dt)
                {
                    dt.Rows.Add(dr);
                }
            });
                
            return dt;
        }
    }
}