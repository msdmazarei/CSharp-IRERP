
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.DALCore;
using MsdLib.Types;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Filters.jah;
using IRERP_RestAPI.Models.jah;
namespace IRERP_RestAPI.ModelRepositories.jah{
public class Media_ostan_Repository : IRERPRepositoryBaseSimpleFilter<Media_ostan_Repository, Media_ostan, Media_ostanFilter> {
public static Media_ostan ByPK(Guid PK)
                                {
                                    var filter = new Media_ostanFilter();
                                    filter.AddSimpleCriteria(x=>x.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                    return First(filter);
                                }  
                                                public static IList<Media_ostan> ListByAddedByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new Media_ostanFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.AddedBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<Media_ostan> ListByModifyByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new Media_ostanFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.ModifyBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<Media_ostan> ListByMediaPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new Media_ostanFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.Media.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<Media_ostan> ListByStatePK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new Media_ostanFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.State.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }
                                                    public static IList<Media_ostan> GetAll()
                                                    {
                                                        var filter = new Media_ostanFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }}
}

