using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_PortalLayout : IRERP_SM_Layout
    {
        public virtual bool? canResizeColumns { get; set; }
        public virtual bool? canResizePortlets { get; set; }
        public virtual bool? canResizeRows { get; set; }
        public virtual bool? canShrinkColumnWidths { get; set; }
        public virtual bool? canStretchColumnWidths { get; set; }
        public virtual Types.IRERPControlTypes_Overflow?  columnBorder { get; set; }

        string [] _dropTypes;
        public virtual string [] dropTypes { get { return _dropTypes; } set { if (IsInInitializeTime) _dropTypes = value; else throw NotImplementerdForIR(); } }

        int? _numColumns;
        public virtual int? numColumns { get { return _numColumns; } set { if (IsInInitializeTime) _numColumns = value; else throw NotImplementerdForIR(); } }

        public virtual Types.IRERPControlTypes_Overflow? overflow { get; set; }
        public virtual string[] portletDropTypes { get; set; }
        public virtual bool? preventColumnUnderflow { get; set; }
        public virtual bool? preventRowUnderflow { get; set; }
        public virtual bool? preventUnderflow { get; set; }
        public virtual bool? showColumnMenus { get; set; }
        public virtual bool? stretchColumnWidthsProportionally { get; set; }

        IRERP_SM_Portlets _portlets;
        public virtual IRERP_SM_Portlets  portlets { get { return _portlets; } set { if (IsInInitializeTime) _portlets = value; else throw NotImplementerdForIR(); } }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (canResizeColumns != null) Parts.Add("canResizeColumns", "canResizeColumns:" + bool2JSON((bool)canResizeColumns) + "");
                if (canResizePortlets != null) Parts.Add("canResizePortlets", "canResizePortlets:" + bool2JSON((bool)canResizePortlets) + "");

                if (canResizeRows != null) Parts.Add("canResizeRows", "canResizeRows:" + bool2JSON((bool)canResizeRows) + "");
                if (canShrinkColumnWidths != null) Parts.Add("canShrinkColumnWidths", "canShrinkColumnWidths:" + bool2JSON((bool)canShrinkColumnWidths) + "");
                if (canStretchColumnWidths != null) Parts.Add("canStretchColumnWidths", "canStretchColumnWidths:" + bool2JSON((bool)canStretchColumnWidths) + "");
                if (preventColumnUnderflow != null) Parts.Add("preventColumnUnderflow", "preventColumnUnderflow:" + bool2JSON((bool)preventColumnUnderflow) + "");

                if (preventRowUnderflow != null) Parts.Add("preventRowUnderflow", "preventRowUnderflow:" + bool2JSON((bool)preventRowUnderflow) + "");
                if (preventUnderflow != null) Parts.Add("preventUnderflow", "preventUnderflow:" + bool2JSON((bool)preventUnderflow) + "");
                if (showColumnMenus != null) Parts.Add("showColumnMenus", "showColumnMenus:" + bool2JSON((bool)showColumnMenus) + "");
                if (stretchColumnWidthsProportionally != null) Parts.Add("stretchColumnWidthsProportionally", "stretchColumnWidthsProportionally:" + bool2JSON((bool)stretchColumnWidthsProportionally) + "");

                if (columnBorder != null) Parts.Add("columnBorder", "columnBorder:" + enum2JSON(columnBorder) + "");
                if (numColumns != null) Parts.Add("numColumns", "numColumns:" + int2JSON((int)numColumns) + "");

                if (portletDropTypes != null) Parts.Add("portletDropTypes", "portletDropTypes:" + stringArray2JSON(portletDropTypes) + "");
                if (dropTypes != null) Parts.Add("dropTypes", "dropTypes:" + stringArray2JSON(dropTypes) + "");

                //List<string> _fi = new List<string>();

                //if (portlets != null) foreach (var a in portlets) _fi.Add(a.ToStringAsMemberOfOther());
                
                //if (portlets != null) Parts.Add("portlets", "portlets:[" + string.Join(",", _fi) + "]");
                if (portlets != null) Parts.Add("portlets", "portlets:" +portlets.ToStringAsMemberOfOther() + "");
             
                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return "isc.PortalLayout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return "isc.PortalLayout.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }






    }
}