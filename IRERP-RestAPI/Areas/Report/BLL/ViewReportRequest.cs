using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.BLLCore;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Areas.Report.BLL
{
    public enum ReportDataProviderEnum{
        SiteAction,
        Database,
        Models
    }
    public class ViewReportRequest

    {
        public virtual Models.Report Report { get; set; }
        public virtual ReportDataProviderEnum ReportDataProvider { get; set; }
        public virtual string SiteActionUrl { get; set; }
        public virtual string Request_Params { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string Criteria { get; set; }
        public virtual string Orders { get; set; }
        public virtual System.Data.DataTable RetriveData( Models.ReportRepository rr)
        {
            if (ReportDataProvider == ReportDataProviderEnum.SiteAction)
            {
                if(ControllerName!=null)
                    if (ControllerName.Trim() != "")
                    {
                        //ours site
                        IRERP_RestAPI.Bases.IRERPController.IRERPController contr = 
                            IRERPApplicationUtilities.NewInstance(
                            IRERPApplicationUtilities.GetTypeFromString(ControllerName)
                            );
                        contr.virtualurl = SiteActionUrl;
                        var req = new Bases.ClientEngine.FetchRequest();
                        req.startRow = 0;
                        req.endRow = 1000; //standard report count
                        if (Criteria != null)
                            IRERPApplicationUtilities.ResumeNext(() =>
                        req.Criterias.AddRange(
                                Newtonsoft.Json.JsonConvert.DeserializeObject<MsdCriteria[]>("[" + Criteria + "]")
                                )
                                );
                        req.SortBy = new List<string>();
                        if (Orders != null)
                            Orders.Split(',').ToList().ForEach(x => req.SortBy.Add(x.FromClientDsFieldName()));
                        var rtn = contr.FetchMethod(req);

                        if(rtn.GetResponse().totalRows>0)
                        return rr.ToDataTable(rtn.GetResponse().data);

                        
                        
                    }

            }
            //returns DataTable or IData
            return rr.RandomData();
        }
    }
}