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
    public class ReportRepositoryField_Repository : IRERPRepositoryBaseClass<ReportRepositoryField_Repository, Models.ReportRepositoryField>
    {
        public static IRERPVList<ReportRepositoryField, ReportRepositoryFieldFilter> GetVList(ReportRepositoryFieldFilter filter)
        {
            return 
              new IRERPVList<ReportRepositoryField, ReportRepositoryFieldFilter>(
              new ItemsProvider<ReportRepositoryField, ReportRepositoryFieldFilter>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList_ParentChildSpec<TParent, ReportRepositoryField, ReportRepositoryFieldFilter> GetVList<TParent>(ReportRepositoryFieldFilter filter)
            where TParent:IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return
              new IRERPVList_ParentChildSpec<TParent,ReportRepositoryField, ReportRepositoryFieldFilter>(
              new ItemsProvider<ReportRepositoryField, ReportRepositoryFieldFilter>()
              {
                  Filter = filter
              }
              );
        }
        public static ReportRepositoryField GetById(Guid id)
        {
            var lst = GetVList(new ReportRepositoryFieldFilter() { id = id });
            if (lst.Count > 0)
                return lst[0];
            else
                return null;
        }
        public static IRERPVList<ReportRepositoryField, ReportRepositoryFieldFilter> GetBy_ReportRepository(Guid ReportRepositoryid)
        {
            return GetVList(new ReportRepositoryFieldFilter() { ReportRepositoryid = ReportRepositoryid });
        }

        public static IRERPVList_ParentChildSpec<TParent,ReportRepositoryField, ReportRepositoryFieldFilter> GetBy_ReportRepository<TParent>(Guid ReportRepositoryid)
            where TParent : IRERP_RestAPI.Bases.ModelBase<TParent>
        {
            return GetVList<TParent>(new ReportRepositoryFieldFilter() { ReportRepositoryid = ReportRepositoryid });
        }

        
    }
}