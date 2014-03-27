using IRERP_RestAPI.Bases;
using MsdLib.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class ReportRepositoryField : ModelBase<ReportRepositoryField>
    {
        public override MsdLib.CSharp.DALCore.INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            //if (primarykeys_value.Keys.Contains(_GPN(x => x.id)))
            //    return ModelRepositories.ReportRepositoryField_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);


            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
                       && primarykeys_value[_GPN(x => x.id)] != null)
            {
                this.id = (System.Guid)primarykeys_value[_GPN(x => x.id)];
                return ModelRepositories.ReportRepositoryField_Repository.GetById((Guid)primarykeys_value[_GPN(x => x.id)]);
            }
            else
                return null;
          
           // return base.LoadByPrimaryKeys(primarykeys_value);
        }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
       // public virtual Guid ReportRepositoryId { get; set; }
        Type _targetType;
        public virtual Type TargetType
        {
            get
            {
                if (_targetType != null) return _targetType;
                _targetType = IRERPApplicationUtilities.GetTypeFromString(this.ReportRepository.strTargetModel);
                return _targetType;
            }

        }

        //public virtual ReportRepository _____ReportRepository { get; set; }

        //public virtual ReportRepository ReportRepository
        //{
        //    get { return _____ReportRepository; }
        //    set { _____ReportRepository = value; }
        //}


        LoadableVar<ReportRepository> _ReportRepository = new LoadableVar<ReportRepository>();
        public virtual ReportRepository _____ReportRepository { get; set; }
        public virtual ReportRepository ReportRepository
        {
            get
            {
                return LoadNHRelation<ReportRepository, Guid>
                    (ref _ReportRepository,
                    x => x._____ReportRepository,
                    ModelRepositories.ReportRepository_Repository.GetById,
                    x => x._____ReportRepository.id);
            }

            set { SetRelationProperty(x => x.ReportRepository, x => x._____ReportRepository, _ReportRepository, value); }


        }



        public override Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion> GetAssociation(string PropertyPath)
        {
            if (_GPN(x => x.ReportRepository) == PropertyPath)
                return new Tuple<string, NHibernate.SqlCommand.JoinType, NHibernate.Criterion.ICriterion>(_GPN(x => x._____ReportRepository), NHibernate.SqlCommand.JoinType.InnerJoin, null);
            return base.GetAssociation(PropertyPath);
        }
        public virtual Stimulsoft.Report.Dictionary.StiDataColumn ToStiDataColumn()
        {

            Stimulsoft.Report.Dictionary.StiDataColumn dc = new Stimulsoft.Report.Dictionary.StiDataColumn();
            dc.Name = Name;//.Replace(".", "__");
            dc.Alias= DisplayName;
            
            Type TargetType = IRERPApplicationUtilities.GetTypeFromString(this.ReportRepository.strTargetModel);
            dc.Type= IRERPApplicationUtilities.GetClassPropertyType(TargetType, this.Name);
            return dc;

        }
        public virtual System.Data.DataColumn ToDataColumn()
        {
            System.Data.DataColumn dc = new System.Data.DataColumn();
            dc.ColumnName = Name;//.Replace(".","__");
            dc.Caption = DisplayName;
            Type TargetType = IRERPApplicationUtilities.GetTypeFromString(this.ReportRepository.strTargetModel);
           Type columnType =  IRERPApplicationUtilities.GetClassPropertyType(TargetType, this.Name);
            if(IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(Nullable<>),columnType))
                columnType = IRERPApplicationUtilities.GetGenericTypeConstructor(columnType,0);
            dc.DataType = columnType;
            return dc;

        }
        public virtual dynamic GetValue(object obj)
        {
                return IRERPApplicationUtilities.GetProperty(obj, Name);
        }
        public virtual Stimulsoft.Report.Dictionary.StiDataColumn ToStiColumn()
        {
            try
            {
                Stimulsoft.Report.Dictionary.StiDataColumn rtn = new Stimulsoft.Report.Dictionary.StiDataColumn();
                rtn.Name = Name;
                rtn.NameInSource = Name;
                rtn.Alias = DisplayName;
             //   Type TargetType = TargetType;// IRERPApplicationUtilities.GetTypeFromString( this.ReportRepository.strTargetModel);
                rtn.Type = IRERPApplicationUtilities.GetClassPropertyType(TargetType, this.Name);
                return rtn;

            }
            catch
            {
                return new Stimulsoft.Report.Dictionary.StiDataColumn();
            }
        }
    }
}