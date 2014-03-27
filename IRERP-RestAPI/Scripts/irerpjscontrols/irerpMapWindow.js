irerp.defineClass('irerpMapWindow', 'Window');
irerp.irerpMapWindow.addProperties({
    initWidget: function () {
        this._msdHtmlId = '_HTMLID_' + Math.random().toString().replace('.', '_');
        this._msdInitControls(this);
        var rtn = this.Super('initWidget', arguments);
        return rtn;  
    },
    HtmlContent: function (item) {
        var rtn =
            '   <div style="display: inline;        float: left;        margin-left: 20px;background:#00ff00;">\
                    <div > \
                    <div id="' + item._msdHtmlId + 'map" style=" display: block;  width: 450px;  height: 350px;  margin: 0 auto; padding: 1px; "></div>\
                    </div>\
                </div>\
        ';

        return rtn;
    },
    //////////Methods
    _msdInitControls: function (item) {
        var htmlcon = item.HtmlContent(item);
        if (item == null)
            item = this;
        item.isModal = true,
            item.autoCenter = true,
            item.showMaximizeButton = true,
            item.showResizer = true,
            item.canDragResize = true,
            item.width = '500px',
            item.height = '500px',
            item.ID = item._msdHtmlId + 'item',

            item.items = [
                isc.VLayout.create({
                
                members: [
                    isc.Label.create({
                        contents: "Listing",
                        overflow: "hidden",
                        border: "1px solid blue"
                    }),
                    irerp.DynamicForm.create({
                        titleOrientation: "top",
                        ID: item.ID + 'Form',
                        numCols: 2,
                        fields: [
                            { title: "طبقه", type: "text", name: item.ID + '_roof' },
                            { title: "واحد", type: "text", name: item.ID + '_apartmentno' },
                            { title: 'آدرس', type: 'textArea', name: item.ID + '_address' },
                             { title: 'آدرس گوگل', type: 'textArea', name: item.ID + '_googleaddress', disabled: true }

                        ]
                    }),
                ]
            })
            ];
        
    },
    //////////Variables
    _msdDisableFormControls:true,
    _msdmap: null,
    _msdmarker: null,
    _msdHtmlId: null,
    _msdLat: null,
    _msdLng: null,
    _msdZ: null,
    _msdAddress: null,
});