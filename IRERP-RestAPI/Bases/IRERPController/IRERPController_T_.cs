using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.IRERPController
{
    public partial class IRERPController<T>: IRERPController
        where T:IRERPControllerMetaModel.ControllerMetaModelBase<T>
    {
        public string _GPN(Expression<Func<T, object>> exp, bool cancelindex = false)
        {
            return IRERPApplicationUtilities.GPN<T>(exp, cancelindex);
        }
        public override Type DataSourceMetaModelType
        {
            get
            {
                return typeof(T);
            }
        }

        public virtual T TypedMetaModelInstance
        {
            get
            {
                return IRERPApplicationUtilities.NewInstance<T>();
            }
        }
        public override MsdLib.CSharp.DALCore.INHibernateEntity MetaModelInstance
        {
            get
            {
                return TypedMetaModelInstance;
            }
        }
        
        //
        // GET: /IRERPController_T_/
        
      
    }
}
