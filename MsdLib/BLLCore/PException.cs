using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.CSharp.BLLCore
{
    public class PException : System.Exception
    {
        public PException(string Message, Exception InnerException)
            : base
                (Message, InnerException)
        {
        }

    }
}
