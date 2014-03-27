using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class RightFulCharacterFilter : IRERPFilter<RightFulCharacterFilter, RightFulCharacter>
    {
        public virtual System.Guid? RightFulCharacterID { get; set; }
        public virtual System.Guid? GenderID { get; set; }
        public virtual string FName { get; set; }
        public virtual string LName { get; set; }
        public virtual string NickName { get; set; }
        public virtual string NationalCode { get; set; }


        public override NHibernate.IQueryOver<RightFulCharacter, RightFulCharacter> Query
        {
            get
            {
                var q = base.Query;
                if (RightFulCharacterID != null)
                {
                    q.And((x => x.id == RightFulCharacterID));
                }
                if (GenderID != null)
                {
                    AddSimpleCriteria(x => x.Gender.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, GenderID.ToString());

                }

                if (FName != null)
                {
                    AddSimpleCriteria(x => x.Fname, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, FName);

                }
                if (LName != null)
                {
                    AddSimpleCriteria(x => x.LName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, LName);

                }

                if (NickName != null)
                {
                    AddSimpleCriteria(x => x.Character.NickName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, NickName);

                }

                if (NationalCode != null)
                {
                    AddSimpleCriteria(x => x.NationalCode, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, NationalCode);

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
