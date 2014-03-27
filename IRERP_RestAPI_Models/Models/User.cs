using System.Collections.Generic;
using System.Text;
using System;
using MsdLib.CSharp.DALCore;
using IRERP_RestAPI.Bases;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.CSharp.Types;
using MsdLib.CSharp.BLLCore;
using NHibernate.Criterion;
using MsdLib.Types;


using System.Linq;
using System.Web;
using System.Data;
using IRERP_RestAPI.Bases.DataVirtualization;
namespace IRERP_RestAPI.Models {
    

    public partial class User : IRERP_RestAPI.Bases.ModelBase<User>{
 
        public override FunctionResult<IEnumerable<string>> SerializeToJSON(string Profile)
        {
            return base.SerializeToJSON(Profile);
        }
     

        public override IList<NHibernate.Criterion.ICriterion> PrimaryKeyCriterion(INHibernateEntity Obj)
        {
            IList<ICriterion> Criterias = new List<ICriterion>();
            //NHibernate.Mapping.PersistentClass a = null;
            var meminfo = IRERPApplicationUtilities.GetClassMember<User,Guid?>(x=>x.id);
            Criterias.Add(Expression.Eq("id",
                                        ((User)Obj).id));
            return Criterias;
            }
        public virtual string Username { get /*{ return _username; } */; set /*{ _username = value; }*/; }
        public virtual string Password { get; set; }
        public override INHibernateEntity LoadByPrimaryKeys(Dictionary<string, object> primarykeys_value)
        {
            //if (
            //     primarykeys_value.Keys.Contains(_GPN(x => x.id))
            //     )
            //    return ModelRepositories.UserRepository.GetUserById((int)primarykeys_value[_GPN(x => x.id)]);

            //return base.LoadByPrimaryKeys(primarykeys_value);




            if (primarykeys_value.Keys.Contains(_GPN(x => x.id))
       && primarykeys_value[_GPN(x => x.id)] != null)
            {


             
                return ModelRepositories.UserRepository.GetUserById((Guid)primarykeys_value[_GPN(x => x.id)]);
            }





            return null;

        }
        

     
        
       

    

        


      
    }
}
