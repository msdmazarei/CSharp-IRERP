using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IREREPControlTypes_listEndEditAction
    {
        same,//	navigate to the first editable cell in the same record
        next,//	navigate to the first editable cell in the next record
        done,//	complete the edit.
        stop,//	Leave focus in the cell being edited (take no action)
        none,//	take no action
    }
}
