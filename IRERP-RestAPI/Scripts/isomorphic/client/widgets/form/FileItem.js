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

 



//> @groupDef upload
// SmartClient provides special client and server-side support for file upload that allows
// uploaded files to be treated like ordinary DataSource fields.  This includes:
// <ul>
// <li>the +link{FileItem} and +link{MultiFileItem} FormItems that enable users to upload one or
// more files as a background operation, without leaving the current page
// <li>server-side support that allows binary uploads to be treated as a normal DataSource field
// values, with all other aspects of server-side integration unchanged
// <li>built-in SQL DataSource support that can store and retrieve uploaded files from SQL
// databases
// </ul>
// The following documentation assumes you are using the SmartClient Java Server.  If you are
// not, skip to the sections near the end of this document.
// <P>
// <b>Single file upload: "binary" field type</b>
// <P>
// To use SmartClient's client-server upload system, you use a DataSource field of
// +link{dataSourceField.type,type} "binary".  By default, a DynamicForm bound to a DataSource
// with a field of type "binary" will use the +link{FileItem}, which displays a standard HTML
// &lt;input type="upload"&gt; form control.
// <P>
// When you call +link{dynamicForm.saveData()} on a DynamicForm containing a FileItem,
// SmartClient processes the save identically to a saveData() call that did not include a file
// upload:
// <ul>
// <li> if you are using the built-in SQL connectors via serverType:"sql", the file will be
// saved to SQL as described under +link{type:FieldType,field type "binary"}.
// <li> if you have server-side business logic, the inbound request may be routed to your
// business logic via RPCManager dispatch or DMI declarations as normal, your business logic
// will receive a normal DSRequest, and you are expected to provide a normal DSResponse.
// </ul>
// <P>
// Client-side callbacks, such as the callback passed to saveData(), fire normally.
// <P>
// <b>Processing File Uploads with server-side business logic</b>
// <P>
// Server-side business logic that processes file uploads may retrieve upload files via the
// server side API dsRequest.getUploadedFile(<i>fieldName</i>).  The uploaded file is returned
// as an instance of ISCFileItem, which provides access to a Java InputStream as well as
// metadata about the file (size, name).  
// See the +docTreeLink{javaServerReference,Java Server Reference} for details.
// <P>
// <span style="color:red;font-weight:bold;">NOTE:</span> request processing engines such as
// Struts may parse the inbound request before SmartClient receives it.  If you are creating an
// RPCManager object inside of a Struts Action and the file being uploaded is not available via
// <code>dsRequest.getUploadedFile()</code>, this is likely to be the problem, and you should
// use SmartClient +link{dmiOverview,DMI} instead.
// <P>
// Server-side validation errors may be provided, including validation errors for the uploaded
// file (such as too large or invalid content), and will be displayed in the form that
// attempted an upload.
// <P>
// Be aware of the following special concerns when processing file uploads:
// <ul>
// <li> if you provide your own Java Servlet or JSP that creates an instance of RPCManager in
// order process SmartClient requests, many APIs of the HttpServletRequest are not safe to call
// before you have created the RPCManager, passing in the HttpServletRequest.  These include
// getReader(), getParameter() and other commonly called methods.  This is a limitation of
// Java Servlets, not specific to SmartClient
// <li> unlike other DataSource "add" and "update" operations, you are not expected to return
// the file as part of the data returned in the DSResponse
// </ul>
// <P>
// <b>Multi file upload: MultiFileItem</b>
// <P>
// The MultiFileItem provides an interface for a user to save one or more files that are
// related to a DataSource record, where each file is represented by a record in a
// related DataSource.
// <P>
// See the +link{MultiFileItem} docs for details.
// <P>
// <b>Upload without the SmartClient Server</b>
// <P>
// If it is acceptable that the application will do a full-page reload after the upload
// completes, you can simply:
// <ul>
// <li> set +link{DynamicForm.encoding} to "multipart"
// <li> include an +link{UploadItem} to get a basic HTML upload control
// <li> set +link{DynamicForm.action} to a URL where you have deployed server-side code to
// handle the upload
// <li> call +link{dynamicForm.submitForm()} to cause the form to be submitted
// </ul>
// This cause the DynamicForm component to submit to the form.action URL like an ordinary HTML
// &lt;form&gt; element.  Many 
// +externalLink{http://www.google.com/search?q=html+file+upload+example,online tutorials}
// are available which explain how to handle HTML form file upload in various server-side
// technologies.
// <P>
// Note that when you submitForm(), the only values that will be sent to your actionURL are 
// values for which actual FormItems exist.  This differs from saveData(), in which the
// entire set of +link{dynamicForm.values,form values} are always sent.  To handle submitting
// extra values, use +link{HiddenItem}s.
// <P>
// For further details, see the +link{UploadItem} docs.
// <P>
// <b>Background upload without the SmartClient Server</b>
// <P>
// Achieving background file upload without using the SmartClient server is also possible
// although considerably more advanced.  In addition to the steps above, create a hidden
// &lt;iframe&gt; element in the page, and use +link{dynamicForm.target} to target the form
// submission at this IFRAME.  In order receive a callback notification when the upload
// completes, after processing the file upload, your server should output HTML content for the
// IFRAME that includes a &lt;SCRIPT&gt; block which will navigate out of the IFRAME (generally
// via the JavaScript global "top") and call a global method you have declared as a callback.
//
// @title Uploading Files
// @visibility external
// @treeLocation Client Reference/Forms/Form Items/FileItem
//<


//>	@class FileItem
//
// Binary data interface for use in DynamicForms. Allows users to select a single file for
// upload. In read-only mode (canEdit:false) displays the contents of "imageFile" fields.
//
// <P>
// <b>Editable mode</b>
// <P>
// See the +link{group:upload,Upload Overview} for information on using this control.
//
// <P>
// <b>Read-only mode</b>
// <P>
// Displays one of two UIs, according to the value of 
// +link{fileItem.showFileInline, showFileInline}.  If showFileInline is false, this Item
// displays the View and Download icons and the filename.  Otherwise, it streams the image-file 
// and displays it inline.
//
// @group upload
// @treeLocation Client Reference/Forms/Form Items
// @visibility external
//<
isc.ClassFactory.defineClass("FileItem", "CanvasItem");

isc.FileItem.addProperties({
    // we want our value to show up in the forms values object!
    shouldSaveValue:true,
    
    //> @attr fileItem.showFileInline  (boolean : null : IR)
    // Indicates whether to stream the image and display it
    // inline or to display the View and Download icons.
    // 
    // @visibility external
    //<

    _$blob:"blob",
    _createCanvas : function () {
        if (!isc.isA.Canvas(this.canvas)) {
            // Save the read-only state of our canvas

            this._isReadOnly = this.isReadOnly();
            this.canvas = (this._isReadOnly ? this._createReadOnlyCanvas()
                                            : this._createEditableCanvas());
        }
        this.containerWidget.addChild(this.canvas);
    },
    
    _createReadOnlyCanvas : function () {
        var canvas;

        if (this.type == this._$blob) {
            // A read-only blob is rendered as a StaticTextItem.
            canvas = isc.DynamicForm.create({
                autoDraw:false,
                // suppress redraws as much as possible - redraw == killing the item value.
                _redrawWithParent:false,
                redrawOnResize:false,
                canSubmit:true,
                action:this.action,
                targetItem:this,
                items:[
                    {type:"text", editorType:"StaticText",
                     width:this.width, height:this.height,
                     name:this.getFieldName(), showTitle:false
                    }
                ]
            });
        } else {
            canvas = isc.Canvas.create({
                height: 10
            });
        }
        return canvas;
    },

    _createEditableCanvas : function () {
        return isc.DynamicForm.create({
            // Default the form to fill the available space
            autoDraw:false,
            // suppress redraws as much as possible - redraw == killing the item value.
            _redrawWithParent:false,
            redrawOnResize:false,
            canSubmit:true,
            action:this.action,
            targetItem:this,
            getSaveOperationType:function () {
                if (this.targetItem && this.targetItem.form) 
                    return this.targetItem.form.getSaveOperationType();
                return this.Super("getSaveOperationType", arguments);
            },
            items:[
            {targetItem:this, type:"upload", 
                width:this.width, height:this.height,
                name:this.getFieldName(), showTitle:false,
                    saveValue : function (a,b,c,d) {
                        this.Super("saveValue", arguments);
                        this.targetItem.saveValue(a,b,c,d);
                    }
                },
                // FileItems are used with the SmartClient server - _transaction item to contain
                // details of the transaction when submitted to the server.
                
                {name:"_transaction", type:"HiddenItem"}
            ]
        });
    },

    // Update enabled/disabled state of the element to match our read-only/disabled state.
    setElementReadOnly : function (readOnly) {
        // The two states require two different canvas's therefore a redraw.
        // This override is necessary because CanvasItem avoids redraws by default.
        this.redraw();
    },

    
    redraw : function () {
        // This occurs when changing the state of canEdit.
        if (this._isReadOnly != this.isReadOnly()) {
            var value = this.getValue();
            if (this.canvas) {
                delete this.canvas.canvasItem;
                this.canvas.destroy(true);
            }
            this._isReadOnly = this.isReadOnly();
            this.setCanvas(this._isReadOnly ? this._createReadOnlyCanvas()
                                            : this._createEditableCanvas());
            this.setValue(value);
        }
        this.Super("redraw", arguments);
    },

    getValue : function () {
        return (this._isReadOnly ? this.Super("getValue", arguments)
                                 : this.canvas.getValue(this.getFieldName()));
    },
    
    // support setValue() only if the newValue is empty (to clear a programmatically set value)
    setValue:function (newValue) {
        if (this.isReadOnly()) {
            var form = this.form,
                record = form.getValues()
            ;
            if (this.type == "blob") {
                // Update the StaticTextItem value
                this.canvas.getItem(this.getFieldName()).setValue(newValue);
            } else if (this.type == "imageFile" && this.showFileInline != false) {
                this.canvas.setHeight("*");
                this.canvas.setWidth("*");
                this.canvas.setContents(this.getImageHTML());
            } else {
                if (this.showFileInline == true) {
                    // non-imageFile field
                    this.logWarn("setValue(): Unsupported field-type for showFileInline: " +
                                 this.type);
                }
                this.canvas.setHeight(20);
                this.canvas.setWidth("100%");
                this.canvas.setContents(this.getViewDownloadHTML(newValue, record));
            }
            return this.Super("setValue", arguments)
        } else {
            if (newValue == null || isc.isA.emptyString(newValue)) {
                this.canvas.getItem(this.getFieldName()).setValue(newValue);
                return this.Super("setValue", arguments);
            } else {
                this.logWarn("Cannot programatically set the value of an upload field due to security restraints");
                return;        
            } 
        }
    },
    
    setWidth : function (width) {
        if (this.canvas && !this.isReadOnly()) {
            this.canvas.items[0].setWidth(width);
        }
        this.Super("setWidth", arguments);
    },
    setHeight : function (height) {
        if (this.canvas && !this.isReadOnly()) {
            this.canvas.items[0].setHeight(height);
        }
        this.Super("setHeight", arguments);
    },

    getViewDownloadHTML : function (value, record) {

        if (isc.isA.String(value)) return value;
        if (record == null) return null;

        var name = record[this.name + "_filename"];

        
        if (name == null || isc.isA.emptyString(name)) return this.emptyCellValue;
        var viewIconHTML = isc.Canvas.imgHTML("[SKIN]actions/view.png", 16, 16, null,
                        "style='cursor:"+isc.Canvas.HAND+"' onclick='"+this.getID()+".viewFile()'");
        var downloadIconHTML = isc.Canvas.imgHTML("[SKIN]actions/download.png", 16, 16, null,
                        "style='cursor:"+isc.Canvas.HAND+"' onclick='"+this.getID()+".downloadFile()'");

        return "<nobr>" + viewIconHTML + "&nbsp;" + downloadIconHTML + "&nbsp;" + name + "</nobr>";
    },

    getImageHTML : function () {
        var record = this.form.getValues(),
            field = this.form.getField(this.name),
            urlProperty = this.name + "_imgURL",
            value
        ;
        if (!record[this.name]) return " ";

        if (!record[urlProperty]) {
            var dimensions = isc.Canvas.getFieldImageDimensions(field, record);
            
            value = record[urlProperty] = 
                isc.Canvas.imgHTML(this.form.getDataSource().streamFile(record, field.name),
                    dimensions.width, dimensions.height);
        } else 
            value = record[urlProperty];

        return value;
    },

    viewFile : function () {
        isc.DS.get(this.form.dataSource).viewFile(this.form.getValues(), this.name);
    },

    downloadFile : function () {
        isc.DS.get(this.form.dataSource).downloadFile(this.form.getValues(), this.name);
    },
    
    _shouldAllowExpressions : function () {
        return false;
    }
});
