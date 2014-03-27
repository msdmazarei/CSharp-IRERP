using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;

namespace IRERP_RestAPI.Bases
{
   public class LogModelBase<A>:ModelBase<A>
       where A:ModelBase<A>
    {
       public LogModelBase()
       {
           LogDateInserted = DateTime.Now;
           //LogOperator = InstanceStatics.LoggedUser.id;
       }
        public virtual System.Guid LogId { get; set; }
        public virtual System.DateTime LogDateInserted { get; set; }
        public virtual int LogOperator { get; set; }
    }
}
