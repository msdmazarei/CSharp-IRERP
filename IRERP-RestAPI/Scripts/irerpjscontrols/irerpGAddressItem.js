irerp.defineClass('irerpGAddressItem', 'TextAreaItem');
irerp.irerpGAddressItem.addProperties({
    MsdMaxFileSize:-1,
    MsdHelpIcon: "[SKIN]/actions/help.png",
    MsdHelpIconClick: function (form, item, icon) { },
    MsdHelpIconTitle: 'راهنما',
    MsdHelpIconShow: true,

    MsdGMapIconTitle: 'انتخاب از روی نقشه',
    MsdGMapIcon: "[SKIN]/Google_Maps.png",
    MsdGMapIconClick: function (form, item, icon) {
        //item._msdOpenBroweserWindow();
        item._msdCorrectFormFields(form, item, icon);
        var win = item._msdWindow(form, item, icon, function () { });
        win.show();
    },
    MsdGMapIconShow: true,
    _msdFormCorrected : false,
    _msdCorrectFormFields: function (form, item, icon) {
        var propertypathes = item.name.split("___");
        propertypathes.pop();

        //check that 
        if(item._msdFormCorrected==false)
        if (form != null) {
            var ppath = propertypathes.join("___")+"___";
            var fieldName = ppath  + "Lat";
            if (form.getField(fieldName) == null) 
                form.addField(item._msdgetField(fieldName));

            fieldName =ppath+"Lng";
            if (form.getField(fieldName) == null)
                form.addField(item._msdgetField(fieldName));

            fieldName = ppath+"Roof";
            if (form.getField(fieldName) == null)
                form.addField(item._msdgetField(fieldName));

            fieldName = ppath + "ApartmentNo";
            if (form.getField(fieldName) == null)
                form.addField(item._msdgetField(fieldName));

            fieldName = ppath + "GoogleAddress";
            if (form.getField(fieldName) == null)
                form.addField(item._msdgetField(fieldName));
            
            item._msdFormCorrected = true;

        }

    },
    init: function () {
        this._msdHtmlId = '_HTMLID_' + Math.random().toString().replace('.', '_');
        this._msdIcons();
        this.canEdit = false;
        this.Super('init', arguments);
    },

    _msdgetField:function(fieldName)
    {
        return {
            name: fieldName, type: "text", editorType: "HiddenItem"
        };
    },
        
    _msdIcons: function(){
        var msdIcons = [];
        var helpicon = this._msdgetGeneralIcon(this.MsdHelpIconShow, this.MsdHelpIcon, this.MsdHelpIconTitle, this.MsdHelpIconClick);
        if (helpicon != null)
            msdIcons[msdIcons.length] = helpicon;

        var gmapicon = this._msdgetGeneralIcon(this.MsdGMapIconShow, this.MsdGMapIcon, this.MsdGMapIconTitle, this.MsdGMapIconClick);
        if (gmapicon != null)
            msdIcons[msdIcons.length] = gmapicon;
        if (this.icons != null)
            if (this.icons.length > 0) {
                for (var i = 0 ; i < msdIcons.length; i++)
                    this.icons.splice(i, 0, msdIcons[i]);
            }
            else
                this.icons = msdIcons;
        else
            this.icons = msdIcons;

    },
    _msdgetGeneralIcon: function (ShowIcon, Icon, IconTitle, IconClick) {
        if (!ShowIcon)
            return null;
        var rtn = {
            src: Icon,
            click: IconClick,
            prompt: IconTitle,
            neverDisable :true
        };
        return rtn;
    },
    _msdmapdiv: null,
    _msdGAdderessForm: function (form, item, icon) {
        var formid = item.ID + 'Form';
        var winform = eval(formid);
        return winform;
    },
    _msdDetermineposition: function (form, item, icon) {
        item._msdLat = item._msdmarker.getPosition().lat();
        item._msdLng = item._msdmarker.getPosition().lng();
    },
    _msdDetermineAddress: function (form, item, icon) {
        item._msdgeocoder.geocode({
            latLng: item._msdmarker.getPosition()
        }, function (responses) {
            if (responses && responses.length > 0) {
                //item._msdupdateMarkerAddress(form, item, icon, responses[0].formatted_address);
                item._msdAddress = responses[0].formatted_address;
                item._msdGAdderessForm(form, item, icon).getField(item.ID + '_googleaddress').setValue(item._msdAddress+'   Lat:'+item._msdLat+'   Lng:'+item._msdLng);

            } else {
                item._msdAddress = 'Cannot determine address at this location.';
                item._msdGAdderessForm(form, item, icon).getField(item.ID + '_googleaddress').setValue('آدرس را نمی توان تعیین کرد');

            }
        });
    },
    _msdAddElementHandlers: function (form, item, icon) {
        item._msdgeocoder = new google.maps.Geocoder();
        var latLng = new google.maps.LatLng(-34.397, 150.644);
        item._msdmap = new google.maps.Map(document.getElementById(item._msdHtmlId + 'map'), {
            zoom: 8,
            center: latLng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });
        item._msdmarker = new google.maps.Marker({
            position: latLng,
            title: 'Point A',
            map: item._msdmap,
            draggable: true
        });
        item._msdDetermineAddress(form, item, icon);
        item._msdDetermineposition(form, item, icon);

        google.maps.event.addListener(
            item._msdmarker,
            'dragend',
            function () {
                item._msdDetermineposition(form, item, icon);
                item._msdDetermineAddress(form, item, icon);
            });

        // Onload handler to fire off the app.
        //google.maps.event.addDomListener(window, 'load', initialize);
    },
    _msdWindow: function (form,item,icon,callbackfunction) {
        var htmlcon = item.HtmlContent(form, item, icon);

        var rtn = irerp.Window.create({
            isModal: true,
            autoCenter: true,
            autoSize: true,
            showMaximizeButton: true,
            showModalMask: true,
            defaultLayoutAlign: 'right',
            showResizer: true,
            canDragResize: true,
            width:'500px',height:'500px',
            ID: item._msdHtmlId + 'win',
         
            items: [
                irerp.VLayout.create({
               
                    ID:item._msdHtmlId+'_WinVLayout',
                    members: [
                        irerp.HTMLPane.create({ width: "520px", backgroundColor: '#ff0000', contents: htmlcon, height: '400px' }),
                        irerp.DynamicForm.create({
                            titleOrientation:"top",
                            ID:item.ID+'Form',
                            numCols:2,
                            fields: [
                                { title: "طبقه", type: "text", name: item.ID + '_roof' },
                                { title: "واحد", type: "text", name: item.ID + '_apartmentno' },
                                { title: 'آدرس', type: 'textArea', name: item.ID + '_address' },
                                 { title: 'آدرس گوگل', type: 'textArea', name: item.ID + '_googleaddress',disabled:true }

                            ]
                        }),
                        irerp.Button.create({
                            ID:item._msdHtmlId+'UploadBtn',
                            title: 'تایید آدرس', click: function () {
                                //Set Values To Items
                                var propertypathes = item.name.split("___");
                                propertypathes.pop();
                                var ppath = propertypathes.join("___")+"___";
                                var fieldName = ppath + "Lat";
                                var myform = eval(item.ID + 'Form');

                                form.getField(fieldName).setValue(item._msdLat);

                                fieldName = ppath + "Lng";
                                form.getField(fieldName).setValue(item._msdLng);

                                fieldName = ppath + "Roof";
                                form.getField(fieldName).setValue(myform.getField(item.ID + '_roof').getValue());

                                fieldName = ppath + "ApartmentNo";
                                form.getField(fieldName).setValue(myform.getField(item.ID + '_apartmentno').getValue());

                                fieldName = ppath + "GoogleAddress";
                                form.getField(fieldName).setValue(myform.getField(item.ID + '_googleaddress').getValue());

                                item.setValue(myform.getField(item.ID + '_address').getValue());
                                //Hide Window
                                var win = eval(item._msdHtmlId + 'win');
                                win.hide();
                                delete win;
                            }
                        })
                    ]
                })
            ]
        });
        item._msdAddElementHandlers(form, item, icon);
        ///// Set Values To Controls
        var propertypathes = item.name.split("___");
        propertypathes.pop();
        var ppath = propertypathes.join("___") + "___";
        var fieldName = ppath + "Lat";
        var myform = eval(item.ID + 'Form');

        item._msdLat = form.getField(fieldName).getValue();

        fieldName = ppath + "Lng";
        item._msdLng = form.getField(fieldName).getValue();

        fieldName = ppath + "Roof";
        myform.getField(item.ID + '_roof').setValue(form.getField(fieldName).getValue());

        fieldName = ppath + "ApartmentNo";
        myform.getField(item.ID + '_apartmentno').setValue(form.getField(fieldName).getValue());

        fieldName = ppath + "GoogleAddress";
        myform.getField(item.ID + '_googleaddress').setValue(form.getField(fieldName).getValue());

        myform.getField(item.ID + '_address').setValue(item.getValue());

        //Correct Marker Position
        if (item._msdLat == null) item._msdLat = 35.783531;
        if (item._msdLng == null) item._msdLng = 51.440316;
        var latlng = new google.maps.LatLng(item._msdLat, item._msdLng);

        item._msdmarker.setPosition(latlng);
        item._msdmap.setCenter(latlng);
        item._msdmap.setZoom(18);

        return rtn;
    },
    _msdgeocoder: null,
    _msdupdateMarkerAddress: function (form, item, icon, str) {
        // document.getElementById(item._msdHtmlId+'address').innerHTML = str;
        console.log(str);
    },
    _msdmap: null,
    _msdmarker: null,
    
    _msdHtmlId: null,
    _msdLat: null,
    _msdLng: null,
    _msdZ: null,
    _msdAddress:null,

    HtmlContent: function (form,item,icon) {
        var rtn = 
'   <div style="display: inline;        float: left;        margin-left: 20px;">\
    <div > <div id="' + item._msdHtmlId + 'map" style=" display: block;  width: 450px;  height: 350px;  margin: 0 auto; padding: 1px; "></div>\
</div></div>\
        ';

        return rtn;
    },
});