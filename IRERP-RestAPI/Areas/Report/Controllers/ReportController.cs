using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report.MvcDesign;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Areas.Report.MetaModels;
using Stimulsoft.Report;
using System.Web.Routing;
using System.Data;
using IRERP_RestAPI.Bases;
namespace IRERP_RestAPI.Areas.Report.Controllers
{
    public class ReportController : IRERPController<Report_MetaModel>
    {
        public override void InitControllerSessionValues()
        {
            base.InitControllerSessionValues();
            IRERPApplicationUtilities.SessionParameters<Report_MetaModel>(x => x.SelectedReport.id);
        }
        //
        // GET: /Report/Report/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportListInvoice ()
        {
            return View();
        }
        public ActionResult DefineReport()
        {
            return View(MetaModelInstance);
        }
        public ActionResult ExitDesigner()
        {
            //return new IRERP_RestAPI.Bases.IRERPActionResults.IRERPMethodActionResult(){ Success=true , data="gholi is here"};
            //return new RedirectResult("/support/support");
            return null;
        }


        public ActionResult DesignReport()
        {
            var id = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetHttpParameter("id");
            string qstring = "?id=" + id;
            var options = new StiMvcDesignerOptions()
            {
                Controller = "Report/Report",
                ActionGetReportTemplate = "GetReportTemplate"+qstring,
                ActionSaveReportTemplate = "SaveReportTemplate" + qstring,
                ActionGetReportSnapshot = "GetReportSnapshot" + qstring,
                ActionExportReport = "ExportReport" + qstring,
                ActionGetLocalization = "GetLocalization" + qstring,
                ActionExitDesigner = "ExitDesigner"+qstring,
                ActionDataProcessing = "DataProcessing" + qstring,
                ActionGoogleDocs = "GoogleDocs" + qstring,
                ActionGetReportCode = "GetReportCode" + qstring,
                LocalizationDirectory = Server.MapPath("~/Content/Localization/"), // Necessary to get a list of available localization files
                Width = System.Web.UI.WebControls.Unit.Percentage(100),
                Height = System.Web.UI.WebControls.Unit.Percentage(100),
            };
            return View(options);
        }
        public ActionResult GetLocalization()
        {
            // Load the localization file requested by the designer
            string name = StiMvcDesigner.GetLocalizationName(this.Request);
            string path = Server.MapPath("~/Content/Localization/");
            return StiMvcDesigner.GetLocalizationResult(path + name);
        }
        public ActionResult GetReportTemplate()
        {
            string id = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetHttpParameter("id");
            Guid reportid;
            if (!Guid.TryParse(id, out reportid))
                return null;
            Models.Report Report = ModelRepositories.Report_Repository.GetById(reportid);
            RouteValueDictionary routeValues = StiMvcDesigner.GetRouteValues(this.Request);
            
            if (routeValues["controller"].ToString() == "Report" && routeValues["action"].ToString() == "DesignReport")
            {
                if (Report != null)
                {
                    
                    StiReport report =new StiReport();
                    report = Report.ToStiReport();
                    /*try
                    {
                        report.Load(
                            ReportFileName(Report)
                            );
                    }
                    catch (Exception ex)
                    {
                        report = Report.ToStiReport();
                    }*/
                        //= Report.ToStiReport();

                    return StiMvcDesigner.GetReportTemplateResult(report);
                    
                }
                else
                    return null;
            }
            else
                return null;
        }
        public ActionResult DataProcessing()
        {
            // Necessary for work the designers data dictionary and some components
            return StiMvcDesigner.DataProcessingResult(this.Request);
        }
        public ActionResult GetReportSnapShot()
        {
            string id = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetHttpParameter("id");
            Guid reportid;
            if (!Guid.TryParse(id, out reportid))
                return null;
            Models.Report Report = ModelRepositories.Report_Repository.GetById(reportid);

            // Get the report template
            StiReport report = StiMvcDesigner.GetReportObject(this.Request);
            foreach (var RR in Report.ReportRepositories)
            {
                if (RR.ReportRepository.RepositoryType != null)
                {
                    switch (RR.ReportRepository.RepositoryType.Trim().ToLower())
                    {
                        case "dictionary":
                            RR.ReportRepository.RegisterDataToReport(ref report, RR.ReportRepository.RandomData());
                            break;
                            
                    }
                }
                
            }
            
            return StiMvcDesigner.GetReportSnapshotResult(this.Request, report);
        }
        public virtual string ReportFileName(Models.Report rpt)
        {
            var physicalpath = IRERP_RestAPI.Bases.IRERPApplicationUtilities.PhysicalApplicationPath();
            if (rpt.ReportFileName == null) rpt.ReportFileName = rpt.id.ToString();
            if (rpt.ReportFileName.Trim() == "") rpt.ReportFileName = rpt.id.ToString();
            string RptFilePath = physicalpath + @"Areas\Report\ReportFiles\"
               + rpt.ReportFileName;
           
            return RptFilePath;
        }
        public ActionResult SaveReportTemplate()
        {
            string id = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetHttpParameter("id");
            Guid reportid;
            if (!Guid.TryParse(id, out reportid))
                return null;
            Models.Report Report = ModelRepositories.Report_Repository.GetById(reportid);
            var physicalpath= IRERP_RestAPI.Bases.IRERPApplicationUtilities.PhysicalApplicationPath();
            if (Report == null) return StiMvcDesigner.SaveReportResult("There is no Report in DB");
            if (Report.ReportFileName == null) Report.ReportFileName = Report.id.ToString();
            if (Report.ReportFileName.Trim() == "") Report.ReportFileName = Report.id.ToString();
            string RptFilePath = ReportFileName(Report);
            var stiReport = StiMvcDesigner.GetReportObject(this.Request);
            if (stiReport != null)
            {
                if (System.IO.File.Exists(RptFilePath))
                    //Backup
                    System.IO.File.Move(RptFilePath, RptFilePath +"--" +Report.Version.ToString()+ "--" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "_"));
                try
                {
                    stiReport.Save(RptFilePath);
                    return StiMvcDesigner.SaveReportResult(true);
                }
                catch(Exception ex)
                {
                    return StiMvcDesigner.SaveReportResult(ex.Message);
                }
                
            }
            return StiMvcDesigner.SaveReportResult("can Not Get report From Request");
            

        }
        public ActionResult ExportReport()
        {
            return StiMvcViewerFx.ExportReportResult(this.Request);
            //return StiMvcDesigner.ExportReportResult(this.Request);
        }
        #region "Viewer"
        protected void RemoveReportRequest(string key)
        {
            IRERPApplicationUtilities.RemoveFromSession(key);
        }
        protected BLL.ViewReportRequest GetReportRequest(string key)
        {
            return (BLL.ViewReportRequest)IRERPApplicationUtilities.GetFromSession(key);
        }
        protected string saveReportRequestToSession()
        {
            try{

            string identifier = Guid.NewGuid().ToString();
            BLL.ViewReportRequest rvr = new BLL.ViewReportRequest();
            rvr.Report = new Models.Report();
            rvr.Report.id = Guid.Parse( IRERPApplicationUtilities.GetHttpParameter("id"));
            rvr.Report = ModelRepositories.Report_Repository.GetById(rvr.Report.id);
            rvr.SiteActionUrl = IRERPApplicationUtilities.GetHttpParameter("SiteActionUrl");
            rvr.ControllerName = IRERPApplicationUtilities.GetHttpParameter("ControllerName");
            rvr.Orders = IRERPApplicationUtilities.GetHttpParameter("Orders");
            rvr.ReportDataProvider = (BLL.ReportDataProviderEnum) Enum.Parse(
                typeof(BLL.ReportDataProviderEnum), 
                IRERPApplicationUtilities.GetHttpParameter("ReportDataProvider")
                );
            rvr.Request_Params = IRERPApplicationUtilities.GetHttpParameter("Request_Params");
            rvr.Criteria = IRERPApplicationUtilities.GetHttpParameter("Criteria");
            IRERPApplicationUtilities.SaveToSession(identifier, rvr);
                return identifier;
            } catch{}
            return null;
        }
        public ActionResult ViewPrint()
        {
            
            return StiMvcViewer.PrintReportResult(this.HttpContext);
        }
        public ActionResult ViewReport()
        {
            string sessionident = saveReportRequestToSession();
            if (sessionident == null)
                return null; // Convert to better
            string qstring = "?sesid=" + sessionident;
            StiMvcViewerFxOptions options = new StiMvcViewerFxOptions()
            {
                Controller = "Report/Report",
                ActionGetReportSnapshot = "ViewSnapShot" + qstring,
                ActionExportReport = "ViewExport" + qstring,
                Width=System.Web.UI.WebControls.Unit.Percentage(100),
                Height=System.Web.UI.WebControls.Unit.Percentage(80),
                 
                
                
/*                ActionPrintReport = "ViewPrint" + qstring,
                ActionViewerEvent = "ViewEvent" + qstring,
                ActionDesignReport = "DesignReport" + qstring,
                ActionInteraction = "ViewInteraction" + qstring,
                Theme = StiTheme.Office2007Blue,*/
/*                RightToLeft = true,
                PageAlignment = StiContentAlignment.Center,
                ToolbarAlignment = StiContentAlignment.Center,*/
            };
            /*StiMvcViewerOptions options = new StiMvcViewerOptions()
            { 
                 Controller="Report/Report",
                 ActionGetReportSnapshot ="ViewSnapShot"+qstring,
                 ActionExportReport="ViewExport"+qstring,
                 ActionPrintReport="ViewPrint"+qstring,
                 ActionViewerEvent="ViewEvent"+qstring,
                 ActionDesignReport="DesignReport"+qstring,
                 ActionInteraction="ViewInteraction"+qstring,
                 Theme= StiTheme.Office2007Blue,
                 RightToLeft=true,
                 PageAlignment= StiContentAlignment.Center,
                 ToolbarAlignment= StiContentAlignment.Center,
            };*/
            return View(options);
        }
        public ActionResult ViewExport()
        {
            return StiMvcViewerFx.ExportReportResult(this.Request);
            //return StiMvcViewer.ExportReportResult(this.HttpContext);
        }
        public ActionResult ViewEvent()
        {
            
            return StiMvcViewer.ViewerEventResult(this.HttpContext);
        }
        public ActionResult ViewInteraction()
        {
            return StiMvcViewer.InteractionResult(this.HttpContext);
            //return StiMvcViewer.
        }
        public ActionResult ViewSnapShot()
        {
            string id = IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetHttpParameter("sesid");
            BLL.ViewReportRequest rptreq = GetReportRequest(id);
            if (rptreq == null)
                return null;
            Models.Report Report = rptreq.Report;

            // Get the report template
            StiReport report = new StiReport();
            
            report.Load(ReportFileName(Report));
            foreach (var RR in Report.ReportRepositories)
            {
                if(RR.ReportRepository.RepositoryType!=null)
                    if(RR.ReportRepository.RepositoryType.ToLower().Trim()=="dictionary")
                        RR.ReportRepository.RegisterDataToReport(ref report, rptreq.RetriveData(RR.ReportRepository));
            }
            //Remove From Session
           // RemoveReportRequest(id);
            //return StiMvcViewer.GetReportSnapshotResult(this.HttpContext, report);
            return StiMvcViewerFx.GetReportSnapshotResult(this.Request, report);
            //return StiMvcViewerFxHelper.GetReportSnapshotResult(report, this.Request);
        }
        #endregion
    }
}
