
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
namespace IRERP_RestAPI.Filters.jah{
public class MagazineVersion_GhateFilter : IRERPFilter<MagazineVersion_GhateFilter, MagazineVersion_Ghate> {
public virtual bool? IsDeleted {get;set;}public MagazineVersion_GhateFilter(){
IsDeleted = false;
}
   
                public override NHibernate.IQueryOver<MagazineVersion_Ghate, MagazineVersion_Ghate> Query
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
