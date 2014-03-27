using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{

    public class IRERP_SM_SectionItem : IRERP_SM_CanvasItem/* TIRERP_SM_SectionItem<IRERP_SM_SectionItem> { }

    public class TIRERP_SM_SectionItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
   
    {

        bool? _canCollapse;
        public virtual bool? canCollapse { get { return _canCollapse; } set { if (IsInInitializeTime) _canCollapse = value; else throw NotImplementerdForIR(); } }

        bool? _canTabToHeader;
        public virtual bool? canTabToHeader { get { return _canTabToHeader; } set { if (IsInInitializeTime) _canTabToHeader = value; else throw NotImplementerdForIR(); } }


        bool? _sectionExpanded;
        public virtual bool? sectionExpanded { get { return _sectionExpanded; } set { if (IsInInitializeTime) _sectionExpanded = value; else throw NotImplementerdForIR(); } }

        string [] _itemIds;
        public virtual string[] itemIds { get { return _itemIds; } set { if (IsInInitializeTime) _itemIds = value; else throw NotImplementerdForIR(); } }

        bool? _sectionVisible;
        public virtual bool? sectionVisible { get { return _sectionVisible; } set { if (IsInInitializeTime) _sectionVisible = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (canCollapse != null) Parts.Add("canCollapse", "canCollapse:" + bool2JSON((bool)canCollapse) + "");
                if (canTabToHeader != null) Parts.Add("canTabToHeader", "canTabToHeader:" + bool2JSON((bool)canTabToHeader) + "");
                if (sectionExpanded != null) Parts.Add("sectionExpanded", "sectionExpanded:" + bool2JSON((bool)sectionExpanded) + "");
                if (sectionVisible != null) Parts.Add("sectionVisible", "sectionVisible:" + bool2JSON((bool)sectionVisible) + "");

                if (itemIds != null) Parts.Add("itemIds", "itemIds:" + stringArray2JSON(itemIds) + "");

                
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