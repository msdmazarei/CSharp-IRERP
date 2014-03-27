using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_CanvasItem : IRERP_SM_FormItem/* TIRERP_SM_CanvasItem<IRERP_SM_CanvasItem> { }

    public class TIRERP_SM_CanvasItem <T>: TIRERP_SM_FormItem<T>
        where T: IRERPControlBase*/

    {
        public virtual bool? applyPromptToCanvas { get; set; }
        public virtual bool? autoDestroy { get; set; }
        public virtual IRERPControlBase canvas { get; set; }
        public virtual string canvasConstructor { get; set; }
        public virtual object canvasDefaults { get; set; }
        public virtual object canvasProperties { get; set; }
        bool? _editCriteriaInInnerForm;
        public virtual bool? editCriteriaInInnerForm { get { return _editCriteriaInInnerForm; } set { if (IsInInitializeTime) _editCriteriaInInnerForm = value; else throw NotImplementerdForIR(); } }
        bool? _multiple;
        public virtual bool? multiple { get { return _multiple; } set { if (IsInInitializeTime) _multiple = value; else throw NotImplementerdForIR(); } }

        bool? _shouldSaveValue;
        public virtual bool? shouldSaveValue { get { return _shouldSaveValue; } set { if (IsInInitializeTime) _shouldSaveValue = value; else throw NotImplementerdForIR(); } }

        IRERPControlTypes_Overflow? _overflow;
        public virtual IRERPControlTypes_Overflow? overflow { get { return _overflow; } set { if (IsInInitializeTime) _overflow = value; else throw NotImplementerdForIR(); } }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            if (IsInInitializeTime)
            {
                var Parts = base.GetOutPutParts();
                if (canvasConstructor != null) Parts.Add("canvasConstructor", "canvasConstructor:" + string2JSON(canvasConstructor.ToString()) + "");
                if (applyPromptToCanvas != null) Parts.Add("applyPromptToCanvas", "applyPromptToCanvas:" + bool2JSON((bool)applyPromptToCanvas) + "");
                if (autoDestroy != null) Parts.Add("autoDestroy", "autoDestroy:" + bool2JSON((bool)autoDestroy) + "");
                if (editCriteriaInInnerForm != null) Parts.Add("editCriteriaInInnerForm", "editCriteriaInInnerForm:" + bool2JSON((bool)editCriteriaInInnerForm) + "");
                if (multiple != null) Parts.Add("multiple", "multiple:" + bool2JSON((bool)multiple) + "");
                if (shouldSaveValue != null) Parts.Add("shouldSaveValue", "shouldSaveValue:" + bool2JSON((bool)shouldSaveValue) + "");
                if (canvas != null) Parts.Add("canvas", "canvas:" + canvas.ToStringAsMemberOfOther() + "");
                if (canvasDefaults != null) Parts.Add("canvasDefaults", "canvasDefaults:" + Object2JSON(canvasDefaults) + "");
                if (canvasProperties != null) Parts.Add("canvasProperties", "canvasProperties:" + Object2JSON(canvasProperties) + "");
                if (overflow != null) Parts.Add("overflow", "overflow:" + enum2JSON(overflow) + "");


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