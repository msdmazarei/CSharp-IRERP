using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Portlet:IRERP_SM_Window
    {
        public virtual bool? canDrop { get; set; }
        public virtual string closeConfirmationMessage { get; set; }
        public virtual bool? destroyOnClose { get; set; }
        public virtual string dragType { get; set; }
        public virtual int? rowHeight { get; set; }

        public virtual bool? showCloseConfirmationMessage { get; set; }
        

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (canDrop != null) Parts.Add("canDrop", "canDrop:" + bool2JSON((bool)canDrop) + "");
                if (destroyOnClose != null) Parts.Add("destroyOnClose", "destroyOnClose:" + bool2JSON((bool)destroyOnClose) + "");

                if (showCloseConfirmationMessage != null) Parts.Add("showCloseConfirmationMessage", "showCloseConfirmationMessage:" + bool2JSON((bool)showCloseConfirmationMessage) + "");
               
                if (rowHeight != null) Parts.Add("rowHeight", "rowHeight:" + int2JSON((int)rowHeight) + "");

                if (dragType != null) Parts.Add("dragType", "dragType:" + string2JSON(dragType.ToString()) + "");
                if (closeConfirmationMessage != null) Parts.Add("closeConfirmationMessage", "closeConfirmationMessage:" + string2JSON(closeConfirmationMessage.ToString()) + "");



                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.Portlet.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.Portlet.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }

    }
}