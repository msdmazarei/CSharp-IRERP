using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_editEvent
    {
        click,//"	A single mouse click triggers inline editing
        doubleClick,//	A double click triggers inline editing
        none,//No mouse event will trigger editing. Editing must be programmatically started via ListGrid.startEditing() (perhaps from an external button) or may be triggered by keyboard navigation if ListGrid.editOnFocus is set.
    }
}
