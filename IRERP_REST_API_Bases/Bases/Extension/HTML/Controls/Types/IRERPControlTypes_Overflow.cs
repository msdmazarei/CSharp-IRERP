using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_Overflow
    {
        visible,//	Content that extends beyond the widget's width or height is displayed. Note: To have the content be sized only by the drawn size of the content set the overflow to be Canvas.VISIBLE and specify a small size, allowing the size to expand to the size required by the content. Leaving the width / height for the widget undefined will use the default value of 100, and setting the size to zero may cause the widget not to draw.
hidden,//	Content that extends beyond the widget's width or height is clipped (hidden).
auto,//	Horizontal and/or vertical scrollbars are displayed only if necessary. Content that extends beyond the remaining visible area is clipped.
scroll,//	Horizontal and vertical scrollbars are always drawn inside the widget. Content that extends beyond the remaining visible area is clipped, and can be accessed via scrolling.
clip_h,//	Clip horizontally but extend the canvas's clip region vertically if necessary.
clip_v//	Clip vertically but extend the canvas's clip region horizontally if necessary.
    }
}