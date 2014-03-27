using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{
    public class Validate : IRERPProfileBaseAttribute { }
    public class Validate<T> : Validate
    {
        //Return NULL means ok and returns not null returns error
        public virtual Func<T, string> Validation { get; set; }
        public virtual string doValidate(T inp)
        {
            string rtn = null;
            if (Validation != null && inp != null)
                rtn = Validation(inp);
            return rtn;
        }
    }
}
