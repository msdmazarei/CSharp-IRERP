
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
namespace IRERP_RestAPI.ModelRepositories.jah{
public class PictureType_Repository : IRERPRepositoryBaseSimpleFilter<PictureType_Repository, PictureType, PictureTypeFilter> {
public static PictureType ByPK(Guid PK)
                                {
                                    var filter = new PictureTypeFilter();
                                    filter.AddSimpleCriteria(x=>x.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                    return First(filter);
                                }  
                                                public static IList<PictureType> ListByAddedByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new PictureTypeFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.AddedBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }  
                                                public static IList<PictureType> ListByModifyByPK<TParent>(Guid PK)
                                                    where TParent : MsdLib.CSharp.DALCore.ModelBase
                                                {
                                                    var filter = new PictureTypeFilter();
                                                    filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, false.ToString());

                                                    filter.AddSimpleCriteria(x=>x.ModifyBy.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PK.ToString());
                                                    return GetVList<TParent>(filter);
                                                }
                                                    public static IList<PictureType> GetAll()
                                                    {
                                                        var filter = new PictureTypeFilter();
                                                       
                                                filter.AddSimpleCriteria(x=>x.IsDeleted,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,"false");
                                               
                                                        return GetVList(filter);
                                                    }}}

