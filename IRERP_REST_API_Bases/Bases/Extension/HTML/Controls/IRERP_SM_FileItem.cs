using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_FileItem : IRERP_SM_CanvasItem /*TIRERP_SM_FileItem<IRERP_SM_FileItem> { }

    public class TIRERP_SM_FileItem <T>: TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/

    {
       string _accept;
        public virtual string accept { get { return _accept; } set { if (IsInInitializeTime) _accept = value; else throw NotImplementerdForIR(); } }

        bool? _showFileInline;
        public virtual bool? showFileInline { get { return _showFileInline; } set { if (IsInInitializeTime) _showFileInline = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (accept != null) Parts.Add("accept", "accept:" + string2JSON(accept.ToString()) + "");
                if (showFileInline != null) Parts.Add("showFileInline", "showFileInline:" + bool2JSON((bool)showFileInline) + "");


                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }
        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "}";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "};";
            else
                return "";
        }
    }
}