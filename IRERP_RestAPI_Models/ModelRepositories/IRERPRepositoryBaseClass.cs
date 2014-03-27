using IRERP_RestAPI.Bases.DataVirtualization;
using MsdLib.CSharp.DataVirtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.ModelRepositories
{
    public class IRERPRepositoryBaseClass<MyType,ModelType>
    {
         
    }
    public class IRERPRepositoryBaseSimpleFilter<MyType,ModelType,FilterType>
        where ModelType : MsdLib.CSharp.DALCore.ModelBase
        where FilterType : IRERP_RestAPI.Bases.IRERPFilter<FilterType, ModelType>
    {
        public static ModelType First(FilterType filter)
        {
            var rtn =  filter.Criteria.SetMaxResults(1).UniqueResult<ModelType>();


            if (filter.UseStatelessSession)
            {
#if DEBUG
                System.Diagnostics.Trace.WriteLine("--- Dispose StatelessSession:" + filter.StatelessSession.GetHashCode().ToString());

#endif
                if (filter.StatelessSession.Transaction != null)
                    filter.StatelessSession.Transaction.Dispose();
                var _session = filter.StatelessSession;
                _session.Close();
                _session.Dispose();
#if DEBUG
                System.Diagnostics.Trace.WriteLine("--- StatelessSession " + filter.StatelessSession.GetHashCode().ToString()+" Disposed.");

#endif

                //filter.StatelessSession.Dispose();
            }

            return rtn;
        }
         public static IRERPVList<ModelType, FilterType> GetVList(FilterType filter)
        {
            return
              new IRERPVList<ModelType,FilterType>(
              new ItemsProvider<ModelType, FilterType>()
              {
                  Filter = filter
              }
              );
        }

        public static IRERPVList_ParentChildSpec<TParent, ModelType, FilterType> GetVList<TParent>(FilterType filter)
            where TParent : MsdLib.CSharp.DALCore.ModelBase
             
            
        {
            return
              new IRERPVList_ParentChildSpec<TParent, ModelType, FilterType>(
              new ItemsProvider<ModelType, FilterType>()
              {
                  Filter = filter
              }
              );
        }
    }
}