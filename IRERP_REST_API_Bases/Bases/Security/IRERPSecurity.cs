using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.CSharp.BLLCore;
using System.Reflection;
namespace IRERP_RestAPI.Bases.Security
{
    public class IRERPSecurity : IRERPSecurityBase<IRERPSecurity>
    {
        public static FunctionResult<bool> isMethodAccessable( 
            string ClassName,
            string MethodName,
            bool throwExceptionOnError = true,
            params dynamic[] Parameters)
        {
            return new FunctionResult<bool>() { Result = true };
        }

        public static FunctionResult<bool> isMethodAccessable(
            Type Class,
            MethodBase MethodName,
            bool throwExceptionOnError = true,
            params dynamic[] Parameters)
        {
            return new FunctionResult<bool>() { Result = true };
        }

    }
}