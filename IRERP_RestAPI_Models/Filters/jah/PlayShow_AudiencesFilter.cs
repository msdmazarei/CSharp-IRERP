
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
public class PlayShow_AudiencesFilter : IRERPFilter<PlayShow_AudiencesFilter, PlayShow_Audiences> {
public virtual bool? IsDeleted {get;set;}public PlayShow_AudiencesFilter(){
IsDeleted = false;
}
   
                public override NHibernate.IQueryOver<PlayShow_Audiences, PlayShow_Audiences> Query
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
