using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_imageType
    {
        center,//	Center (and don't stretch at all) the image if smaller than its enclosing frame.CENTER:"center",
        tile,//	Tile (repeat) the image if smaller than its enclosing frame.
        stretch,//	Stretch the image to the size of its enclosing frame.
        normal,//	Allow the image to have natural size
    }
}