using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.ExtensionFuncs.Double
{
    public static class DoubleExtensions
    {
        public static string ToDecmialString(this double source)
        {
            if ((source % 1) == 0)
                return source.ToString("f1");
            else
                return source.ToString();

        }
    }
}
