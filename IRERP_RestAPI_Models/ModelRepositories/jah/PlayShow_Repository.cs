
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
public class PlayShow_Repository : IRERPRepositoryBaseSimpleFilter<PlayShow_Repository, PlayShow, PlayShowFilter> {
public static PlayShow ByPK(Guid PK)
                                {
                                    var filter = new PlayShowFilter();
                                    filter.AddSimpleCriteria(x=>x.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                    return First(filter);
                                }  
                                                public static IList<PlayShow> ListByAddedByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new PlayShowFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.AddedBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<PlayShow> ListByModifyByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new PlayShowFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.ModifyBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<PlayShow> ListByTitlePK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new PlayShowFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.Title.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }
                                                    public static IList<PlayShow> GetAll()
                                                    {
                                                        var filter = new PlayShowFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }}
}

