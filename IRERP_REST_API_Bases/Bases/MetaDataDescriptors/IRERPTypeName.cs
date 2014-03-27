using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.MetaDataDescriptors
{
    public class IRERPTypeName
    {
        public string me { get; set; }
        public IRERPTypeName(Type s)
        {
            me = s.ToString();
        }
        public override bool Equals(object obj)
        {
            var extobj = (IRERPTypeName)obj;
            return extobj.me == this.me;
        }
        public override int GetHashCode()
        {
            return me.GetHashCode();
        }

    }
}