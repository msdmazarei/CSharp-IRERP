
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
public class RadioSchool_PageStylistsFilter : IRERPFilter<RadioSchool_PageStylistsFilter, RadioSchool_PageStylists> {
public virtual bool? IsDeleted {get;set;}public RadioSchool_PageStylistsFilter(){
IsDeleted = false;
}
   
                public override NHibernate.IQueryOver<RadioSchool_PageStylists, RadioSchool_PageStylists> Query
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
