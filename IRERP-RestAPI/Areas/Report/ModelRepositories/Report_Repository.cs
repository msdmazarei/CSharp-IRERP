using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using IRERP_RestAPI.Areas.Report.Filters;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.DataVirtualization;
namespace IRERP_RestAPI.Areas.Report.ModelRepositories
{
    public class Report_Repository : IRERPRepositoryBaseClass<Report_Repository, Models.Report>
    {
        public static IRERPVList<Models.Report, ReportFilter> GetVList(ReportFilter filter)
        {
            return
              new IRERPVList<Models.Report, ReportFilter>(
              new ItemsProvider<Models.Report, ReportFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList_ParentChildSpec<TParent, Models.Report, ReportFilter> GetVList<TParent>(ReportFilter filter)
            where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return
              new IRERPVList_ParentChildSpec<TParent, Models.Report, ReportFilter>(
              new ItemsProvider<Models.Report, ReportFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static Models.Report GetById(Guid Id)
        {
            var rpt =
                new IRERPVList<Models.Report, ReportFilter>(
                new ItemsProvider<Models.Report, ReportFilter>()
                {
                    Filter = new ReportFilter() { Id = Id }
                }
                );
            if (rpt.Count > 0)
                return rpt[0];
            else
                return null;

            
        }
        public static Models.Report GetByReportName(string name)
        {
            var lst = GetVList(new ReportFilter() { ReportName = name });
            if (lst.Count > 0)
                return lst[0];

            return null;
        }
        public static IRERPVList<Models.Report, ReportFilter> GetAll()
        {

            return new IRERPVList<Models.Report,ReportFilter>(
               new ItemsProvider< Models.Report,ReportFilter>()
               {
                   Filter =  new ReportFilter()
               }
               );
        }
    }
}