using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class CharacterFilter : IRERPFilter<CharacterFilter, Character>
    {
        public virtual System.Guid? CharacterID { get; set; }

        public virtual Guid? CharacterTypeId { get; set; }

        public virtual System.Guid? CharacterTypeID { get;set;}
        public virtual Guid? NatinalId { get; set; }
        public virtual string EmailID { get; set; }
        public virtual string RoleName { get; set; }
        public override NHibernate.IQueryOver<Character, Character> Query
        {
            get
            {
                var q = base.Query;
                if (CharacterID != null)
                {
                    q.And((x => x.id == CharacterID));
                }

                if (CharacterTypeId != null)
                {
                    AddSimpleCriteria(x => x.Characterstype.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterTypeId.ToString());

                }

                if (CharacterTypeID != null)
                {
                    AddSimpleCriteria(x => x.Characterstype.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterTypeID.ToString());

                }

                if (NatinalId != null)
                {
                    AddSimpleCriteria(x => x.Nationality.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, NatinalId.ToString());

                }

                if (EmailID != null)
                {
                    AddSimpleCriteria(x => x.Email, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, EmailID.ToString());

                }
                if (RoleName != null)
                {
                 

                }
                q.And(x => x.IsDeleted == false);
                return q;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}
