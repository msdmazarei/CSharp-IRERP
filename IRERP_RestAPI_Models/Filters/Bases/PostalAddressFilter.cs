using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace IRERP_RestAPI.Filters.Bases
{
    public class PostalAddressFilter : IRERPFilter<PostalAddressFilter, PostalAddress>
    {
        public virtual System.Guid? PostalAddressID { get; set; }
        public virtual System.Guid? PostalAddressTypeID { get; set; }
        public virtual System.Guid? CharacterID { get; set; }
        public virtual string GetPostalAddressByAddress { get; set; }
        public virtual string PostalCode { get; set; }
      
        public virtual System.Guid? CharacterID1 { get; set; }
        public virtual string PostalCode1 { get; set; }
        public override NHibernate.IQueryOver<PostalAddress, PostalAddress> Query
        {
            get
            {
                var q = base.Query;
                if (PostalAddressID != null)
                {
                    q.And((x => x.id == PostalAddressID));
                }
                if (PostalAddressTypeID != null)
                {
                    AddSimpleCriteria(x => x.PostalAddressType.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PostalAddressTypeID.ToString());

                }
                if (CharacterID != null)
                {
                    AddSimpleCriteria(x => x.Character.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID.ToString());

                }
                if (GetPostalAddressByAddress != null)
                {
                    q.And((x => x.Address == GetPostalAddressByAddress));
                }
                if (PostalCode != null)
                {
                    q.And((x => x.Address == PostalCode));
                }
                if (CharacterID1 != null && PostalCode1 != null)
                {
                    AddSimpleCriteria(x => x.Character.id, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, CharacterID1.ToString());
                    AddSimpleCriteria(x => x.PostalCode, MsdLib.CSharp.BLLCore.MsdCriteriaOperator.equals, PostalCode1);

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
