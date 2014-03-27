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
    public class Report_ReportRepository_Repository : IRERPRepositoryBaseClass<Report_ReportRepository_Repository, Report_ReportRepository>
    {
        public static IRERPVList<Report_ReportRepository, Report_ReportRepositoryFilter> GetVList(Report_ReportRepositoryFilter filter)
        {
            return
              new IRERPVList<Report_ReportRepository, Report_ReportRepositoryFilter>(
              new ItemsProvider<Report_ReportRepository, Report_ReportRepositoryFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList_ParentChildSpec<TParent, Report_ReportRepository, Report_ReportRepositoryFilter> GetVList<TParent>(Report_ReportRepositoryFilter filter)
            where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return
              new IRERPVList_ParentChildSpec<TParent, Report_ReportRepository, Report_ReportRepositoryFilter>(
              new ItemsProvider<Report_ReportRepository, Report_ReportRepositoryFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList<Report_ReportRepository, Report_ReportRepositoryFilter>  GetByReportId(Guid Report_id)
        {
            return GetVList(new Report_ReportRepositoryFilter() { Report_id = Report_id });
        }

        public static IRERPVList_ParentChildSpec<TParent, Report_ReportRepository, Report_ReportRepositoryFilter> GetByReportId<TParent>(Guid Report_id)
            where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return GetVList<TParent>(new Report_ReportRepositoryFilter() { Report_id = Report_id });
        }
        public static Report_ReportRepository GetById(Guid id)
        {
            var lst = GetVList(new Report_ReportRepositoryFilter() { id = id });
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
    }
}