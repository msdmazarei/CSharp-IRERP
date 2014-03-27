using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_visibilityMode
    {
        mutex , //Only one section can be expanded at a time.
      multiple ,	//Multiple sections can be expanded at the same time, and will share space.
	 
    }
}