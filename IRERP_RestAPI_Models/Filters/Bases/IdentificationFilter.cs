using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class IdentificationFilter : IRERPFilter<IdentificationFilter, Identification>
    {
        public virtual System.Guid? IdentificationID { get; set; }
        public virtual Guid? CharacterID { get; set; }
        public override NHibernate.IQueryOver<Identification, Identification> Query
        {
            get
            {
                var q = base.Query;
                if (IdentificationID != null)
                {
                    q.And((x => x.id == IdentificationID));
                }

                if (CharacterID != null)
                {
                    AddSimpleCriteria(x=>x.Characters.id,MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals,CharacterID.ToString());
                }
                q.And(x=>x.IsDeleted==false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
