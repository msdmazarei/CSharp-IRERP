
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
using IRERP_RestAPI.Models.jah;
using IRERP_RestAPI.Models.Bases;
namespace IRERP_RestAPI.Filters.jah{
public class TVSchool_TVPrintsFilter : IRERPFilter<TVSchool_TVPrintsFilter, TVSchool_TVPrints> {
public virtual bool? IsDeleted {get;set;}public TVSchool_TVPrintsFilter(){
IsDeleted = false;
}
   
                public override NHibernate.IQueryOver<TVSchool_TVPrints, TVSchool_TVPrints> Query
                {
                    get
                    {
                        var q = base.Query;
                if(IsDeleted!=null) 
                        AddSimpleCriteria(x => x.IsDeleted, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, IsDeleted.ToString());
  return q;
            }
            set
            {
                base.Query = value;
            }
        }
}
}
