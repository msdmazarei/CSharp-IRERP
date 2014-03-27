using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_PickTreeItem : IRERP_SM_CanvasItem/* TIRERP_SM_PickTreeItem<IRERP_SM_PickTreeItem> { }

    public class TIRERP_SM_PickTreeItem<T> : TIRERP_SM_CanvasItem<T>
        where T: IRERPControlBase*/
  
    {
        public IRERP_SM_PickTreeItem()
        {
            this.type = Types.IRERPControlTypes_FormItemType.pickTree;
        }
        public virtual bool? canSelectParentItems { get; set; }


        string _emptyMenuMessage;
        public virtual string emptyMenuMessage { get { return _emptyMenuMessage; } set { if (IsInInitializeTime) _emptyMenuMessage = value; else throw NotImplementerdForIR(); } }

        bool? _loadDataOnDemand;
        public virtual bool? loadDataOnDemand { get { return _loadDataOnDemand; } set { if (IsInInitializeTime) _loadDataOnDemand = value; else throw NotImplementerdForIR(); } }


        string _valueField;
        public virtual string valueField { get { return _valueField; } set { if (IsInInitializeTime) _valueField = value; else throw NotImplementerdForIR(); } }

        IRERPControlBase _dataSource;
        public virtual IRERPControlBase dataSource { get { return _dataSource; } set { if (IsInInitializeTime) _dataSource = value; else throw NotImplementerdForIR(); } }

      

        IRERP_SM_Tree _valueTree;
        public virtual IRERP_SM_Tree valueTree { get { return _valueTree; } set { if (IsInInitializeTime) _valueTree = value; else throw NotImplementerdForIR(); } }


        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (canSelectParentItems != null) Parts.Add("canSelectParentItems", "canSelectParentItems:" + bool2JSON((bool)canSelectParentItems) + "");
                if (loadDataOnDemand != null) Parts.Add("loadDataOnDemand", "loadDataOnDemand:" + bool2JSON((bool)loadDataOnDemand) + "");
                if (emptyMenuMessage != null) Parts.Add("emptyMenuMessage", "emptyMenuMessage:" + string2JSON(emptyMenuMessage.ToString()) + "");
                if (valueField != null) Parts.Add("valueField", "valueField:" + string2JSON(valueField.ToString()) + "");

                if (dataSource != null) Parts.Add("dataSource", "dataSource:" + dataSource.ToStringAsMemberOfOther() + "");
                if (valueTree != null) Parts.Add("valueTree", "valueTree:" + valueTree.ToStringAsMemberOfOther() + "");



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