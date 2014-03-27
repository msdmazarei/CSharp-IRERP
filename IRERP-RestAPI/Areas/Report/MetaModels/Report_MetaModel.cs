using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Areas.Report.ModelRepositories;
namespace IRERP_RestAPI.Areas.Report.MetaModels
{
    public class Report_MetaModel : ControllerMetaModelBase<Report_MetaModel>
    {
        public Report_MetaModel()
        {
            this.Profile = Bases.MetaDataDescriptors.IRERPProfile.General;
        }
       /* public virtual IList<ReportModel> ReportModels
        {
            get
            {
                return ReportModel_Repository.GetAll();
            }
        }
        */
    /*    public virtual IList<ReportRepositoryField> ReportRepositoryFields
        {
            get { return ReportRepositoryField_Repository.GetAll(); }
        }
        */


        public virtual IList<ReportRepository> ReportRepositories
        {
            get { return ReportRepository_Repository.GetAll(); }
        }
        public virtual ReportRepository SelectedReportRepository
        {
            get {
                var selectedid = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromSession<Report_MetaModel>(x => x.SelectedReportRepository.id);
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.ReportRepository_Repository.GetById(id);
                return new ReportRepository(); 
            }
            set { }
        }
        public virtual IList<Models.Report> Reports
        {
            get
            {
                return ModelRepositories.Report_Repository.GetAll();
            }

        }
        public virtual Models.Report SelectedReport
        {
            get
            {
                var selectedid = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetFromSession<Report_MetaModel>(x => x.SelectedReport.id);
                Guid id;
                if (selectedid != null)
                    if (Guid.TryParse(selectedid, out id))
                        return ModelRepositories.Report_Repository.GetById(id);
                return new Models.Report();
            }
            set
            {
            }
        }

    }
}