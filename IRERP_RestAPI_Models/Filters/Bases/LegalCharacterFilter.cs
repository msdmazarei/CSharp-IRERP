using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class LegalCharacterFilter : IRERPFilter<LegalCharacterFilter, LegalCharacter>
    {
        public virtual System.Guid? LegalCharacterID { get; set; }
        public virtual Guid? BranchId { get; set; }
        public virtual Guid? LegalCharacterTypeId { get; set; }
        public virtual Guid? PlacesId { get; set; }
        public virtual Guid? CharacterId { get; set; }
        public virtual string EconomicNumber { get; set; }

        public virtual string NickName { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string NationalIdentifier { get; set; }


        
        public override NHibernate.IQueryOver<LegalCharacter, LegalCharacter> Query
        {
            get
            {
                var q = base.Query;
                if (LegalCharacterID != null)
                {
                    q.And((x => x.id == LegalCharacterID));
                }
                if (BranchId != null)
                {
                    AddSimpleCriteria(x => x.LegalBranchs.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, BranchId.ToString());

                }

                if (LegalCharacterTypeId != null)
                {
                    AddSimpleCriteria(x => x.LegalCharactersType.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, LegalCharacterTypeId.ToString());

                }

                if (PlacesId != null)
                {
                    AddSimpleCriteria(x => x.Places.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PlacesId.ToString());

                }

                if (CharacterId != null)
                {
                    AddSimpleCriteria(x => x.Characters.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterId.ToString());

                }

                if (EconomicNumber != null)
                {
                    AddSimpleCriteria(x => x.EconomicNumber, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, EconomicNumber);

                }


                if (RegistrationNumber != null)
                {
                    AddSimpleCriteria(x => x.RegistrationNumber, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, RegistrationNumber);

                }

                if (NationalIdentifier != null)
                {
                    AddSimpleCriteria(x => x.NationalIdentifier, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, NationalIdentifier);

                }

                if (NickName != null)
                {
                    AddSimpleCriteria(x => x.Characters.NickName, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, NickName);

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
