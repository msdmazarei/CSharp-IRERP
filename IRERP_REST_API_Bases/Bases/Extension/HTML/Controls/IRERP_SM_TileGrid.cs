using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_TileGrid:IRERP_SM_TileLayout
    {

        bool? _showAllRecords;
        public virtual bool? showAllRecords { get { return _showAllRecords; } set { if (IsInInitializeTime) _showAllRecords = value; else throw NotImplementerdForIR(); } }

        public virtual IRERPControlBase dataSource { get; set; }

        bool? _autoFetchData;
        public virtual bool? autoFetchData { get { return _autoFetchData; } set { if (IsInInitializeTime) _autoFetchData = value; else throw NotImplementerdForIR(); } }

        public virtual Types.IRERPControlTypes_StringMethods recordClick { get; set; }
        public virtual bool? animateTileChange {get;set;}

        IRERP_SM_DetailViewer[] _fields;
        public virtual IRERP_SM_DetailViewer[] fields { get { return _fields; } set { if (IsInInitializeTime) _fields = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (autoFetchData != null) Parts.Add("autoFetchData", "autoFetchData:" + bool2JSON((bool)autoFetchData) + "");
                if (showAllRecords != null) Parts.Add("showAllRecords", "showAllRecords:" + bool2JSON((bool)showAllRecords) + "");
                if (animateTileChange != null) Parts.Add("animateTileChange", "animateTileChange:" + bool2JSON((bool)animateTileChange) + "");
                if (dataSource != null) Parts.Add("dataSource", "dataSource:" +dataSource.ToStringAsMemberOfOther() + "");
                if (recordClick != null) Parts.Add("recordClick", "recordClick:" + recordClick.ToString() + "");

                List<string> _fi = new List<string>();

                if (fields != null) foreach (var a in fields) _fi.Add(a.ToStringAsMemberOfOther());



                if (fields != null) Parts.Add("fields", "fields:[" + string.Join(",", _fi) + "]");

                return Parts;
            }

            else
            { return new Dictionary<string, string>(); }


        }

        public override string ToStringAsMemberOfOther()
        {
            if (IsInInitializeTime)
                return " isc.TileGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
            else
                return "";
        }
        public override string ToString()
        {
            if (IsInInitializeTime)
                return " isc.TileGrid.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
            else
                return "";
        }
    }
}