using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.CSharp.BLLCore
{
    public class OrderBy : IMsdCore
    {
        public string PropertyName { get; set; }
        public SortType SortType { get; set; }
        //public string AliasBaseName { get { return ""; } }
        
    }

}
