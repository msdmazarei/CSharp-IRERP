using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.IRERPController;
using IRERP_RestAPI.Areas.Report.MetaModels;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Areas.Report.Models;
using System.Collections;
namespace IRERP_RestAPI.Areas.Report.Controllers
{
    public class ReportRepositoryController : IRERPController<Report_MetaModel>
    {
        //
        // GET: /Report/ReportRepository/
        public override void InitControllerSessionValues()
        {
            base.InitControllerSessionValues();
            IRERPApplicationUtilities.SessionParameters<Report_MetaModel>(x => x.SelectedReportRepository.id);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllReportRepository()
        {
            return View();
        }

        public ActionResult Admin()
        {
            
            return View(MetaModelInstance);
        }

        public override Bases.IRERPActionResults.IRERPFetchResponseActionResult FetchMethod(Bases.ClientEngine.FetchRequest req)
        {
            //Get ParentPath Parmetere
            string parentPath = IRERPApplicationUtilities.GetHttpParameter(IRERPApplicationUtilities.GPN<Report.Models.ReportModelProperty>(x => x.ParentPath));
            if (parentPath == null )
                return base.FetchMethod(req);
            else
            {

                Bases.ClientEngine.FetchResponse ftchrep = new Bases.ClientEngine.FetchResponse();
                var m = ((Report_MetaModel)MetaModelInstance).SelectedReportRepository.TargetModel.fullname;
                Type proptype = null;
                if (parentPath == "null")
                {
                    proptype = IRERPApplicationUtilities.GetTypeFromString(m);
                }
                else
                {
                    string propertypath = parentPath.Substring(m.Length + 1);
                    proptype = IRERPApplicationUtilities.GetClassPropertyType(
                        IRERPApplicationUtilities.GetTypeFromString(m), propertypath);
                }

                
                if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(ModelBase<>), proptype))
                {
                    ReportModel tmp = new ReportModel();
                    if(parentPath=="null") tmp.fullname = proptype.FullName; 
                    else tmp.fullname = parentPath;
                    tmp.ReportModelType = proptype;
                    ftchrep.data = (IList)tmp.Properties;
                    ftchrep.status = 0;
                    ftchrep.startRow = 0;
                    ftchrep.endRow = ftchrep.data.Count-1;
                    ftchrep.totalRows = ftchrep.data.Count;
                      
                }
                else
                {
                    ftchrep.totalRows = -1;
                    ftchrep.status = 0;
                }
                return new Bases.IRERPActionResults.IRERPFetchResponseActionResult(ftchrep);
            }
        }



    }
}
