using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.Bases;
using NHibernate.Criterion;
using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using MsdLib.CSharp.BLLCore;
using MsdLib.Types.NH;
using FluentNHibernate;
using NHibernate.Mapping;
using NHibernate.Cache;
using NHibernate.Engine;
using NHibernate.Loader.Entity;
using NHibernate;
namespace IRERP_RestAPI.Mappings {

    public class UserPersisterClass : NHibernate.Persister.Entity.SingleTableEntityPersister
    {
        public UserPersisterClass(PersistentClass persistentClass, ICacheConcurrencyStrategy cache,
                                                                            ISessionFactoryImplementor factory,IMapping mapping)
            :base(persistentClass,cache,factory,mapping)
        {
            Console.WriteLine("hello");
            foreach (Join join in persistentClass.JoinClosureIterator)
            {
                Console.WriteLine(join.Table);
            }
        }
        

    }

    public class UserMap : IRERPDescriptor<User>
    {
        
        public UserMap() {
            //User tmp = new User();
            Table(MsdTableName(null, "irerp", "sys", "User"));

			LazyLoad();
			Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Username).Column("Username").Not.Nullable().Length(100);
            Map(x => x.Password);
         		Map(x => x.IsDeleted).Column("IsDeleted").Not.Nullable();
                DescribeMember(x => x.id, IRERPProfile.Any).DataSourceFieldProperty();
                DescribeMember(x => x.Username, IRERPProfile.Any).DataSourceFieldProperty();
		
         
        }

        ICriterion test(object a, PCriteria q)
        {
            return null;
        }

    }
}

