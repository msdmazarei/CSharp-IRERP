using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_TileLayout:IRERP_SM_Canvas
    {
        int? _tileWidth;
        public virtual int? tileWidth { get { return _tileWidth; } set { if (IsInInitializeTime) _tileWidth = value; else throw NotImplementerdForIR(); } }

        int? _tileHeight;
        public virtual int? tileHeight { get { return _tileHeight; } set { if (IsInInitializeTime) _tileHeight = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (tileWidth != null) Parts.Add("tileWidth", "tileWidth:" +int2JSON((int)tileWidth) + "");
                if (tileHeight != null) Parts.Add("tileHeight", "tileHeight:" + int2JSON((int)tileHeight) + "");


                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }
    }
}