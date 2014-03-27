using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsdLib.Types
{
    public class LoadableVar<T>
    {
        public virtual T Value { get; set; }
        public bool isLoaded { get; set; }
        public LoadableVar()
        {
            isLoaded = false;
        }
        public void SetValue(T value)
        {
            Value = value;
            isLoaded = true;
        }

    }
}
