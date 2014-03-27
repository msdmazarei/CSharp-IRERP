using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
      public class IRERP_SM_SectionStackSection: TIRERP_SM_SectionStackSection<IRERP_SM_SectionStackSection> { }
      public class TIRERP_SM_SectionStackSection<T> : IRERPControlBase
   
    {
          string _ID;
          public virtual string ID { get { return _ID; } set { if (IsInInitializeTime) _ID = value; else throw NotImplementerdForIR(); } }

        string _title;
        public virtual string title { get { return _title; } set { if (IsInInitializeTime) _title = value; else throw NotImplementerdForIR(); } }

        bool? _expanded;
        public virtual bool? expanded { get { return _expanded; } set { if (IsInInitializeTime) _expanded = value; else throw NotImplementerdForIR(); } }

        bool? _resizeable;
        public virtual bool? resizeable { get { return _resizeable; } set { if (IsInInitializeTime) _resizeable = value; else throw NotImplementerdForIR(); } }

        IRERPControlBase _items;
        public virtual IRERPControlBase items { get { return _items; } set { if (IsInInitializeTime) _items = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (title != null) Parts.Add("title", "title:" + string2JSON(title.ToString()) + "");
                if (ID != null) Parts.Add("ID", "ID:" + string2JSON(ID.ToString()) + "");

                if (expanded != null) Parts.Add("expanded", "expanded:" + bool2JSON((bool)expanded) + "");
                if (resizeable != null) Parts.Add("resizeable", "resizeable:" + bool2JSON((bool)resizeable) + "");


                if (items != null) Parts.Add("items", "items:" + items.ToStringAsMemberOfOther() + "");

                

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