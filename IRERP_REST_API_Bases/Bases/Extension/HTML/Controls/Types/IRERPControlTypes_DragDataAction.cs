using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_DragDataAction
    {
        none,//	Don't do anything, resulting in the same data being in both lists.
        copy,//	Copy the data leaving the original in our list.
        move,//	Remove the data from this list so it can be moved into the other list.
    }
}
