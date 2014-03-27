using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib
{
    public abstract class ApplicationGlobalVariables<MyType>
    {
        public static MyType Instance { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
    }
}
