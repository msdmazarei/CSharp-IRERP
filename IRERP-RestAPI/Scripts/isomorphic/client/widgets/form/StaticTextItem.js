/*
 * Isomorphic SmartClient
 * Version 8.2 (2011-12-05)
 * Copyright(c) 1998 and beyond Isomorphic Software, Inc. All rights reserved.
 * "SmartClient" is a trademark of Isomorphic Software, Inc.
 *
 * licensing@smartclient.com
 *
 * http://smartclient.com/license
 */

 






//>	@class	StaticTextItem
//	A FormItem that displays an uneditable value.
// @visibility external
//<
isc.ClassFactory.defineClass("StaticTextItem", "FormItem");
isc.StaticTextItem.addProperties({
    //>	@attr	staticTextItem.height		(number : null : IRW)
	//			don't specify a height so the table cell will expand
	//			to show the entire contents.  Note that this can 
	//			mess up dynamic height calculations in forms.
	//		@group	appearance
	//<
	height:null,

    //>	@attr	staticTextItem.width		(number : null : IRW)
	//			If a width is specified, we write out a table to make width consistent,
	//			if <code>null</code> is used, we write out a SPAN which is cheaper.
	//		@group	appearance
	//<
	width:null,

    //>	@attr	staticTextItem.wrap		(boolean : true : IRW)
	// @include FormItem.wrap
	//		@group	appearance
    // @visibility external
	//<
	wrap:true,
    
    //>@attr    staticTextItem.clipValue (boolean : false : IRW)
    // @include FormItem.clipValue
    // @group appearance
    // @visibility external
    //<
    //clipValue:null,
    

    //>	@attr	staticTextItem.textBoxStyle    (FormItemBaseStyle : "staticTextItem" : IRW)
	//  Base CSS class for this item
	// @group   appearance
    // @visibility external
	//<
	textBoxStyle:"staticTextItem",
	
	// when dynamically showing/hiding icons we should be able to resize our textBox without
	// redraw.
	redrawOnShowIcon:false,

    //>	@attr	staticTextItem.outputAsHTML (boolean : null : IRW)
	// By default HTML values in a staticTextItem will be interpreted by the browser.
    // Setting this flag to true will causes HTML characters to be escaped, meaning the
    // raw value of the field (for example <code>"&lt;b&gt;AAA&lt;/b&gt;"</code>) is displayed
    // to the user rather than the interpreted HTML (for example <code>"<b>AAA</b>"</code>)
    // @group appearance
    // @visibility external
    // @deprecated in favor of +link{staticTextItem.escapeHTML}
	//<
//	outputAsHTML:false,

    // set useShortDateFormat to false.
    // This will use "toNormalDate()" rather than toShortDate for date values 
    // Other than those in logical "date" type fields (where we don't want to show time).
    // Document this behaviour by explicitly calling it out in the dateFormatter docs for
    // StaticTextItems.
    //>	@attr staticTextItem.dateFormatter (DateDisplayFormat : null : [IRWA])
    // Display format to use for date type values within this formItem.
    // <P>
    // Note that Fields of type <code>"date"</code>, <code>"datetime"</code> or <code>"time"</code> will
    // be edited using a +link{DateItem} or +link{TimeItem} by default, but 
    // this can be overridden - for <code>canEdit:false</code> fields, a
    // +link{StaticTextItem} is used by default, and the developer can always specify 
    // a custom +link{formItem.editorType} as well as +link{formItem.type,data type}.
    // <P>
    // The +link{formItem.timeFormatter} may also be used to format underlying Date values as
    // times (ommitting the date part entirely). If both <code>dateFormatter</code> and
    // <code>timeFormatter</code> are specified on an item, for
    // fields specified as +link{formItem.type,type "time"} the
    // <code>timeFormatter</code> will be used, otherwise the <code>dateFormatter</code>
    // <P>
    // If <code>item.dateFormatter</code> and <code>item.timeFormatter</code> is unspecified,
    // date display format may be defined at the component level via
    // +link{DynamicForm.dateFormatter}, or for fields of type <code>"datetime"</code>
    // +link{DynamicForm.datetimeFormatter}. Otherwise for fields of type "date",
    // default is to use the system-wide default short date format, configured via
    // +link{Date.setShortDisplayFormat()}. For fields of type "datetime" or for Date values
    // in fields whose type does not inherit from the logical "date" type, default is to use
    // the system-wide normal date format configured via +link{Date.setNormalDisplayFormat()} 
    // (using "toNormalDate()" on logical <code>"date"</code> type fields is not desirable as this
    // would display the time component of the date object to the user).<br>
    // Specify any valid +link{type:DateDisplayFormat} to 
    // change the format used by this item.
    // 
    // @see formItem.timeFormatter
    //
	// @group appearance
    // @visibility external
	//<
	//dateFormatter:null,
    useShortDateFormat:false,

    //> @attr staticTextItem.escapeHTML (boolean : false : IRW)
	// By default HTML values in a staticTextItem will be interpreted by the browser.
    // Setting this flag to true will causes HTML characters to be escaped, meaning the
    // raw value of the field (for example <code>"&lt;b&gt;AAA&lt;/b&gt;"</code>) is displayed
    // to the user rather than the interpreted HTML (for example <code>"<b>AAA</b>"</code>)
    // @group appearance
    // @visibility external
	//<
	escapeHTML:null,
    
     // override 'emptyDisplayValue' to write out "&nbsp;" instead of "" for styling
    emptyDisplayValue:"&nbsp;"
                                       
});
isc.StaticTextItem.addMethods({
	
        
	//>	@method	staticTextItem.mapValueToDisplay()	(A)
	// Map from the internal value for this item to the display value.
	//		@group	drawing
	//		@param	internalValue		(string)	Internal value for this item.
	//		@return	(string)	Displayed value corresponding to internal value.
	//<
	_$nbsp:"&nbsp;",
	mapValueToDisplay : function (internalValue, a,b,c,d) {
        var value = this.invokeSuper(isc.StaticTextItem, "mapValueToDisplay", 
                                     internalValue, a,b,c,d);
        var asHTML = this.escapeHTML || this.outputAsHTML || this.asHTML;
        
        // Don't escape &nbsp; unless that's actually the data value!  
        if (asHTML && (internalValue == null || internalValue == isc.emptyString)
            && value == this._$nbsp) 
        {
            asHTML = false;
        }
        if (isc.isA.String(value) && asHTML) {
            value = value.asHTML();
		}
        return value;
	},

    // Static text items are used for display only - non editable
    isEditable : function () {
        return false;
    },

    _canFocus : function () {
        if (this.canFocus != null) return this.canFocus;
        // needs to be focusable in screen reader mode because the value will only be read if the item
        // can be tabbed to
        return isc.screenReader;
    }
});

