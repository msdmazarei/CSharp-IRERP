using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
  public enum IREREPControlTypes_EnterKeyEditAction
    {
        done,//	end editing
        nextCell,//	edit the next editable cell in the record
        nextRow,//	edit the same field in the next editable record
        nextRowStart,//	edit the first editable cell in next editable record
    }
}
