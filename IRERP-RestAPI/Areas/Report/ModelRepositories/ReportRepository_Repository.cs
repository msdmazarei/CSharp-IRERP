using IRERP_RestAPI.ModelRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Areas.Report.Models;
using IRERP_RestAPI.Areas.Report.Filters;
using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.DataVirtualization;
namespace IRERP_RestAPI.Areas.Report.ModelRepositories
{ 
    public class ReportRepository_Repository : IRERPRepositoryBaseClass<ReportRepository_Repository, ReportRepository>
    {
        public static IRERPVList<ReportRepository, ReportRepositoryFilter> GetVList(ReportRepositoryFilter filter)
        {
            return
              new IRERPVList<ReportRepository, ReportRepositoryFilter>(
              new ItemsProvider<ReportRepository, ReportRepositoryFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList_ParentChildSpec<TParent, ReportRepository, ReportRepositoryFilter> GetVList<TParent>(ReportRepositoryFilter filter)
            where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return
              new IRERPVList_ParentChildSpec<TParent, ReportRepository, ReportRepositoryFilter>(
              new ItemsProvider<ReportRepository, ReportRepositoryFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList<ReportRepository, ReportRepositoryFilter> GetAll()
        {
            var Filter = new ReportRepositoryFilter();
            return GetVList(Filter);
        }
        public static ReportRepository GetById(Guid id)
        {

            var Filter = new ReportRepositoryFilter() {id=id};
            var lst = GetVList(Filter);
            if (lst.Count > 0)
                return (ReportRepository)lst[0];
            return null;
        }
    }
}