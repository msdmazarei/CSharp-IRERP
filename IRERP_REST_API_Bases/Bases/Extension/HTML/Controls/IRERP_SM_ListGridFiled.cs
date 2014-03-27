using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_ListGridFiled : /*TIRERP_SM_ListGridFiled<IRERP_SM_ListGridFiled> { }
        public class TIRERP_SM_ListGridFiled<T>: */IRERPControlBase

    {
            public virtual bool? autoFetchDisplayMap { get; set; }

            bool? _autoFitWidth;
            public virtual bool? autoFitWidth { get { return _autoFitWidth; } set { if (IsInInitializeTime) _autoFitWidth = value; else throw NotImplementerdForIR(); } }
            bool? _autoFreeze;
            public virtual bool? autoFreeze { get { return _autoFreeze; } set { if (IsInInitializeTime) _autoFreeze = value; else throw NotImplementerdForIR(); } }
            bool? _canDragResize;
            public virtual bool? canDragResize { get { return _canDragResize; } set { if (IsInInitializeTime) _canDragResize = value; else throw NotImplementerdForIR(); } }
            string _name;
            public virtual string name { get { return _name; } set { if (IsInInitializeTime) _name = value; else throw NotImplementerdForIR(); } }

            public virtual string valueMap { get; set; }

            protected override Dictionary<string, string> GetOutPutParts()
            {
                if (IsInInitializeTime)
                {
                    var Parts = base.GetOutPutParts();
                    if (autoFetchDisplayMap != null) Parts.Add("autoFetchDisplayMap", "autoFetchDisplayMap:" + bool2JSON((bool)autoFetchDisplayMap) + "");
                    if (autoFitWidth != null) Parts.Add("autoFitWidth", "autoFitWidth:" + bool2JSON((bool)autoFitWidth) + "");
                    if (autoFreeze != null) Parts.Add("autoFreeze", "autoFreeze:" + bool2JSON((bool)autoFreeze) + "");
                    if (canDragResize != null) Parts.Add("canDragResize", "canDragResize:" + bool2JSON((bool)canDragResize) + "");
                    if (name != null) Parts.Add("name", "name:" + string2JSON(name.ToString()) + "");
                    if (valueMap != null) Parts.Add("valueMap", "valueMap:" + valueMap);

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