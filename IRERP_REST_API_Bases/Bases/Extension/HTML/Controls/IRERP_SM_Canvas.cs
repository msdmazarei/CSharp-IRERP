using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using System.Linq.Expressions;
using System.Reflection;
namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_Canvas : IRERPControlBase/*TIRERP_SM_Canvas<IRERP_SM_Canvas> { }
    public class TIRERP_SM_Canvas<T> : IRERPControlBase
        where T : IRERPControlBase*/
    {
        //public T SET<PT>(Expression<Func<T, object>> express, PT value)
        //{
        //     ((PropertyInfo)IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetClassMember(express)).SetValue
        //     (this,value,null);
        //   return (T)(IRERPControlBase) this;
        //}
        #region "Properties"
        public virtual IRERPControlTypes_StringMethods resized { get; set; }
        //If specified this governs the accessKey for the widget. This should be set to a character - when a user hits Alt+[accessKey], or in Mozilla Firefox 2.0 and above, Shift+Alt+[accessKey], focus will be given to the widget in question.
        public string accessKey { get; set; }
//        public T SET_accessKey(string _accessKey) { this.accessKey = _accessKey; return (T)(IRERPControlBase)this; }
        
        //	If true, this canvas will draw itself immediately after it is created.
        //  Note that you should turn this OFF for any canvases that are provided as children of other canvases, or they will draw initially, then be clear()ed and drawn again when added as children, causing a large performance penalty.
        private bool _autoDraw ;
        public bool autoDraw
        {
            get
            {
                return _autoDraw;
        } 
            set {
            if (this.IsInInitializeTime) _autoDraw = value; 
            else 
                throw new NotImplementedException("this Property Use in [IR] mode.");
        } }
  //      public T SET_autoDraw(bool _autoDraw) { this.autoDraw = _autoDraw; return (T)(IRERPControlBase)this; }

        //If set to true, the widget's parent (if any) will automatically be shown whenever the widget is shown.
        public bool autoShowParent { get; set; }
    //    public T SET_autoShowParent(bool _autoShowParent) { autoShowParent = _autoShowParent; return (T)(IRERPControlBase)this; }

        //The background color for this widget. It corresponds to the CSS background-color attribute. You can set this property to an RGB value (e.g. #22AAFF) or a named color (e.g. red) from a list of browser supported color names.
        public string backgroundColor { get; set; }
      //  public T SET_backgroundColor(string _backgroundColor) { backgroundColor = _backgroundColor; return (T)(IRERPControlBase)this; }

        //URL for a background image for this widget (corresponding to the CSS "background-image" attribute).
        public IRERPControlTypes_URL backgroundImage { get; set; }
        public virtual IRERP_SM_Menu contextMenu { get; set; }
        //public T SET_backgroundImage(IRERPControlTypes_URL url) { this.backgroundImage = url; return (T)(IRERPControlBase)this; }

        //Specifies how the background image should be positioned on the widget. It corresponds to the CSS background-position attribute. If unset, no background-position attribute is specified if a background image is specified.
        //[IR]
        private string _backgroundPosition ;

        public string backgroundPosition
        {
            get { return _backgroundPosition; }
            set {
                if (this.IsInInitializeTime) _backgroundPosition = value;
                else
                    throw new NotImplementedException("this Property Use in [IR] mode.");
            }
        }
        //public T SET_backgroundPosition(string _backgroundPosition) { this.backgroundPosition = _backgroundPosition; return (T)(IRERPControlBase)this; }

        //[IR]
        private IRERPControlTypes_BackgroundRepeat? _backgroundRepeat;
        public IRERPControlTypes_BackgroundRepeat? backgroundRepeat 
        {
            get { return _backgroundRepeat; }
            set
            {
                if (this.IsInInitializeTime) _backgroundRepeat = value;
                else
                    throw new NotImplementedException("this Property Use in [IR] mode.");
            }
        }
        //public T SET_backgroundRepeat(IRERPControlTypes_BackgroundRepeat _backgroundRepeat) { this._backgroundRepeat = _backgroundRepeat; return (T)(IRERPControlBase)this; }


        //[IR]
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                if (this.IsInInitializeTime) _ID = value;
                else
                    throw new NotImplementedException("this Property Use in [IR] mode.");
            }
        }
        //public T SET_ID(string _ID) { this.ID = _ID; return (T)(IRERPControlBase)this; }


        public string border { get; set; }
        //public T SET_border(string _border) { border = _border; return (T)(IRERPControlBase)this; }

        public int? edgeSize { get; set; }
        public bool canDrag { get; set; }
        //public T SET_canDrag(bool _canDrag) { canDrag = _canDrag; return (T)(IRERPControlBase)this; }

        public string height { get; set; }
        //public T SET_height(string _height) { height = _height; return (T)(IRERPControlBase)this; }

        public string width { get; set; }
        public int? minwidth { get; set; }
//        public T SET_width(string _width) { this.width = _width; return (T)(IRERPControlBase)this; }

        public IRERPControlTypes_StringMethods click { get; set; }
        
        public Nullable<bool> showResizeBar { get; set; }
        public Nullable<bool> showEdges { get; set; }
        public string hoverStyle { get; set; }
        
        public int? margin { get; set; }
        public int? padding { get; set; } 
  //      public T SET_showResizeBar(Nullable<bool> _showResizeBar) { this.showResizeBar = _showResizeBar; return (T)(IRERPControlBase)this; }
        #endregion
        protected override Dictionary<string,string> GetOutPutParts() {


            var Parts = CreateDictionaryFromProperties(this,
                x => x.ID,
                x=>x.height,
                x=>x.width,
                x=>x.minwidth,
                x=>x.showResizeBar
                );
            if (showShadow != null) Parts.Add("showShadow", "showShadow:" + string2JSON(showShadow.ToString()) + "");
            if (shadowDepth != null) Parts.Add("shadowDepth", "shadowDepth:" + string2JSON(shadowDepth.ToString()) + "");
            if (edgeSize != null) Parts.Add("edgeSize", "edgeSize:" + int2JSON(edgeSize));
            if (showEdges != null) Parts.Add("showEdges", "showEdges:" + bool2JSON(showEdges));
            if (click != null) Parts.Add("click", "click:" + click.ToString() + "");
            if (backgroundColor != null) Parts.Add("backgroundColor", "backgroundColor:" + string2JSON(backgroundColor));
            if (hoverStyle != null) Parts.Add("hoverStyle", "hoverStyle:" + string2JSON(hoverStyle));
            if (backgroundImage != null) Parts.Add("backgroundImage", "backgroundImage:" + string2JSON(backgroundImage.Url));
            if (backgroundRepeat != null) Parts.Add("backgroundRepeat", "backgroundRepeat:" + enum2JSON(backgroundRepeat));
            if (margin != null) Parts.Add("margin", "margin:" + int2JSON(margin));
            if (padding != null) Parts.Add("padding", "padding:" + int2JSON(padding));
            if (resized != null) Parts.Add("resized", "resized:" + resized.ToString());
            return Parts;
              

        }
        public override string ToString()
        {
            string rtn = "";
            rtn = "isc.Canvas.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
                return rtn;
            
        }

       
        public virtual bool? showShadow { get; set; }
        public virtual int? shadowDepth { get; set; }





        
    }
}