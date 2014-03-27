using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IRERP_RestAPI.Bases.Extension.HTML
{
    public class IRERPPageString : IRERPControlBase
    {

        public virtual string id { get; set; }
        public virtual string DisplayControls { get; set; }
        public virtual string OtherObjects { get; set; } 
        public virtual string Commands { get; set; }
        public virtual string PageTitle { get; set; }
        public IRERPPageString()
        {
            //var c = new Guid();
            id = Guid
                .NewGuid()
                .ToString()
                .Replace("-","");
        }

        private static string GuidFormat()
        {
            return "dddddddddddddddddddddddddddddddd";
        }
        public IRERPPageString(MvcHtmlString str)
        {
            fromstring(str.ToString());
        }
        void fromstring(string FromString)
        {
            string str = FromString.Trim();
            if (str.Trim().IndexOf(IRERPPageString.DISPLAYControlStartSection) > -1)
            {
                id = str.Substring(str.Trim().IndexOf(IRERPPageString.DISPLAYControlStartSection) + IRERPPageString.DISPLAYControlStartSection.Length, GuidFormat().Length);
                int startindex =
                    str.IndexOf(IRERPPageString.DISPLAYControlStartSection + id + JsCommentEndSections())
                    +
                    (IRERPPageString.DISPLAYControlStartSection + id + JsCommentEndSections()).Length;
                int finishindex = str.IndexOf(IRERPPageString.DISPLAYControlFinishSection + id + JsCommentEndSections());
                if (finishindex - startindex > 0)
                    DisplayControls = str.Substring(startindex, finishindex - startindex);

                startindex =
                   str.IndexOf(IRERPPageString.OtherObjectsStartSection + id + JsCommentEndSections())
                   +
                   (IRERPPageString.OtherObjectsStartSection + id + JsCommentEndSections()).Length;
                finishindex = str.IndexOf(IRERPPageString.OtherObjectsFinishSection + id + JsCommentEndSections());

                if (finishindex - startindex > 0)
                    OtherObjects = str.Substring(startindex, finishindex - startindex);


                startindex =
   str.IndexOf(IRERPPageString.CommandsStartSection + id + JsCommentEndSections())
   +
   (IRERPPageString.CommandsStartSection + id + JsCommentEndSections()).Length;
                finishindex = str.IndexOf(IRERPPageString.CommandsFinishSection + id + JsCommentEndSections());

                if (finishindex - startindex > 0)
                    Commands = str.Substring(startindex, finishindex - startindex);
                
                if (DisplayControls != null && DisplayControls.Length > 0)
                if (DisplayControls.Trim()[DisplayControls.Trim().Length - 1] == ';') 
                    DisplayControls = DisplayControls.Trim().Substring(0, DisplayControls.Trim().Length-1);

            }
        }
        public IRERPPageString(string FromString)
        {
            fromstring(FromString);
        }
        public static string DISPLAYControlStartSection { get { return "/*********IRERPDISPCTLID-START:"; } }
        public static string DISPLAYControlFinishSection { get { return "/*********IRERPDISPCTLID-FINISH:"; } }

        public static string OtherObjectsStartSection { get { return "/*********IRERPOTHRCTLID-START:"; } }
        public static string OtherObjectsFinishSection { get { return "/*********IRERPOTHRCTLID-FINISH:"; } }

        public static string CommandsStartSection { get { return "/*********IRERPCMMDCTLID-START:"; } }
        public static string CommandsFinishSection { get { return "/*********IRERPCMMDCTLID-FINISH:"; } }

        public override string ToString()
        {
            string rtn = "";
            if(DisplayControls!=null && DisplayControls.Length>0)
            if (DisplayControls.Trim()[DisplayControls.Trim().Length - 1] != ';') DisplayControls += ";";

            if (OtherObjects != null && OtherObjects.Length > 0)
            if (OtherObjects.Trim()[OtherObjects.Trim().Length - 1] != ';') OtherObjects += ";";

            if (Commands != null && Commands.Length > 0)
            if (Commands.Trim()[Commands.Trim().Length - 1] != ';') Commands += ";";
            rtn += IRERPPageString.OtherObjectsStartSection + id + JsCommentEndSections() + OtherObjects + IRERPPageString.OtherObjectsFinishSection + id + JsCommentEndSections();
            rtn += IRERPPageString.DISPLAYControlStartSection + id + JsCommentEndSections() + DisplayControls + IRERPPageString.DISPLAYControlFinishSection + id + JsCommentEndSections();
            rtn += IRERPPageString.CommandsStartSection + id + JsCommentEndSections() + Commands + IRERPPageString.CommandsFinishSection + id + JsCommentEndSections();
            return rtn;
        }

        private static string JsCommentEndSections()
        {
            return "********************/";
        }
        
     public static IRERPPageString  operator +(IRERPPageString a,IRERPPageString b)
    {
        IRERPPageString rtn = new IRERPPageString();
        rtn.Commands = a.Commands + b.Commands;
        rtn.DisplayControls = a.DisplayControls + b.DisplayControls;
        rtn.OtherObjects = a.OtherObjects + b.OtherObjects;
         return rtn;
    }

    }
}