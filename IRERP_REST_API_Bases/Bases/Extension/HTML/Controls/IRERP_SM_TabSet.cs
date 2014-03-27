using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_TabSet : IRERP_SM_Canvas/* TIRERP_SM_TabSet<IRERP_SM_TabSet> { }
    public class TIRERP_SM_TabSet<T> : TIRERP_SM_Canvas<T>
        where T:IRERPControlBase*/
    {
        

        Types.IRERPControlTypes_Side? _tabBarPosition;
        public virtual Types.IRERPControlTypes_Side? tabBarPosition { get { return _tabBarPosition; } set { if (IsInInitializeTime) _tabBarPosition = value; else throw NotImplementerdForIR(); } }

        Types.IRERPControlTypes_Side? _tabBarAlign;
        public virtual Types.IRERPControlTypes_Side? tabBarAlign { get { return _tabBarAlign; } set { if (IsInInitializeTime) _tabBarAlign = value; else throw NotImplementerdForIR(); } }

        public virtual bool? canEditTabTitles { get; set; }

        public virtual Types.IRERPControlTypes_TabTitleEditEvent? titleEditEvent { get; set; }

        public virtual int? titleEditorTopOffset { get; set; }
        public virtual IRERP_SM_Tab[] tabs {get; set;}

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (tabBarPosition != null) Parts.Add("tabBarPosition", "tabBarPosition:" + enum2JSON(tabBarPosition) + "");
                if (tabBarAlign != null) Parts.Add("tabBarAlign", "tabBarAlign:" + enum2JSON(tabBarAlign) + "");

                if (canEditTabTitles != null) Parts.Add("canEditTabTitles", "canEditTabTitles:" + bool2JSON((bool)canEditTabTitles) + "");
                if (titleEditEvent != null) Parts.Add("titleEditEvent", "titleEditEvent:" + enum2JSON(titleEditEvent) + "");
                if (titleEditorTopOffset != null) Parts.Add("titleEditorTopOffset", "titleEditorTopOffset:" +int2JSON((int)titleEditorTopOffset) + "");
                List<string> _fi = new List<string>();
                if (tabs != null) foreach (var a in tabs) _fi.Add(a.ToStringAsMemberOfOther());
                if (tabs != null) Parts.Add("tabs", "tabs:[" + string.Join(",", _fi) + "]");

                return Parts;
            }
            else
            {
                return new Dictionary<string, string>(); 
            }
            
        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)

                return "isc.TabSet.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }

        public override string ToString()
        {
            if (IsInInitializeTime)

                return "isc.TabSet.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}