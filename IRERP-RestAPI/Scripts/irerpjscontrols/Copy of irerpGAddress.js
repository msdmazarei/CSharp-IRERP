irerp.defineClass('irerpGAddressItem', 'TextItem');
irerp.irerpGAddressItem.addProperties({
    MsdMaxFileSize:-1,
    MsdHelpIcon: '',
    MsdHelpIconClick: function (form, item, icon) { },
    MsdHelpIconTitle: 'راهنما',
    MsdHelpIconShow: true,
   

    MsdDownloadIcon: '',
    MsdDownloadIconClick: function (form, item, icon) { },
    MsdDownloadIconTitle: 'دانلود',
    MsdDownloadIconShow: true,
   


    MsdPreviewIcon: 'نمایش',
    MsdPreviewIconClick: function (form, item, icon) { },
    MsdPreviewIconTitle: '',
    MsdPreviewIconShow: true,

    MsdUploadIconTitle: 'آپلود',
    MsdUploadIcon: '',
    MsdUploadIconClick: function (form, item, icon) {
        //item._msdOpenBroweserWindow();
        var win = item._msdWindow(form, item, icon, function () { });
        win.show();
    },
    MsdUploadIconShow: true,
    MsdUploadPath:'',

    init: function () {
        this._msdHtmlId ='_HTMLID_'+Math.random().toString().replace('.','_')
        this._msdIcons();
        this.canEdit = false;
        this.Super('init', arguments);
    },
    emptyDisplayValue: 'پرونده ای انتخا نشده است',
    
    _msdIcons: function(){
        var msdIcons = [];
        var helpicon = this._msdgetGeneralIcon(this.MsdHelpIconShow, this.MsdHelpIcon, this.MsdHelpIconTitle, this.MsdHelpIconClick);
        if (helpicon != null)
            msdIcons[msdIcons.length] = helpicon;

        var upload = this._msdgetGeneralIcon(this.MsdUploadIconShow, this.MsdUploadIcon, this.MsdUploadIconTitle, this.MsdUploadIconClick);
        if (upload != null)
            msdIcons[msdIcons.length] = upload;

        var previewicon = this._msdgetGeneralIcon(this.MsdPreviewIconShow, this.MsdPreviewIcon, this.MsdPreviewIconTitle, this.MsdPreviewIconClick);
        if (previewicon != null)
            msdIcons[msdIcons.length] = previewicon;
       
        var downloadicon = this._msdgetGeneralIcon(this.MsdDownloadIconShow, this.MsdDownloadIcon, this.MsdDownloadIconTitle, this.MsdDownloadIconClick);
        if (downloadicon != null)
            msdIcons[msdIcons.length] = downloadicon;

        if (this.icons != null)
            if (this.icons.length > 0) {
                ////////////// 
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
    _msdmapdiv:null,
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
            resized: function () {
                if (this._msdmapdiv == null)
                    this._msdmapdiv = document.getElementById( this.ID.replace('win','') + 'map');
                if (this._msdmapdiv != null
                    ) {
                    this._msdmapdiv.style.width = this.items[0].width * 0.9 + 'px';
                    this._msdmapdiv.style.height = this.items[0].height * 0.9 + 'px';
                }
               
                console.log(this.items[0].width + ' ' +
                            this.items[0].height);
            },
            items: [
                irerp.VLayout.create({
               
                    ID:item._msdHtmlId+'_WinVLayout',
                    members: [
                        irerp.HTMLPane.create({width:"500px",  backgroundColor :'#ff0000',contents: htmlcon,  height: '400px' }),
                        irerp.Button.create({
                            ID:item._msdHtmlId+'UploadBtn',
                            title: 'تایید آدرس', click: function () {
                            }
                        })
                    ]
                })
            ]
        });
        item._msdAddElementHandlers(form, item, icon);
        item._msdmapdiv = document.getElementById(item._msdHtmlId + 'map');
        return rtn;
    },
    _msdgeocoder: null,
    _msdgeocodePosition: function (form, item, icon, pos) {
        item._msdgeocoder.geocode({
            latLng: pos
        }, function (responses) {
            if (responses && responses.length > 0) {
                item._msdupdateMarkerAddress(form,item,icon,responses[0].formatted_address);
            } else {
                item._msdupdateMarkerAddress(form, item, icon, 'Cannot determine address at this location.');
            }
        });
    },
    _msdupdateMarkerStatus: function (form, item, icon, str) {
        document.getElementById(item._msdHtmlId+'markerStatus').innerHTML = str;
    },
    _msdupdateMarkerPosition: function (form, item, icon, latLng) {
        document.getElementById(item._msdHtmlId+ 'info').innerHTML = [
            latLng.lat(),
            latLng.lng()
        ].join(', ');

    },
    _msdupdateMarkerAddress: function (form, item, icon, str) {
        document.getElementById(item._msdHtmlId+'address').innerHTML = str;
    },
    _msdmap:null,
    _msdAddElementHandlers: function (form, item, icon) {

        item._msdmap = new GMaps({
            el: item._msdHtmlId+'map',
            lat: -12.043333,
            lng: -77.028333,
        });
        return;





        item._msdgeocoder = new google.maps.Geocoder();
            var latLng = new google.maps.LatLng(-34.397, 150.644);
            var map = new google.maps.Map(document.getElementById(item._msdHtmlId+'mapCanvas'), {
                zoom: 8,
                center: latLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            var marker = new google.maps.Marker({
                position: latLng,
                title: 'Point A',
                map: map,
                draggable: true
            });

            // Update current position info.
            item._msdupdateMarkerPosition(form, item, icon, latLng);
            item._msdgeocodePosition(form, item, icon, latLng);

            // Add dragging event listeners.
            google.maps.event.addListener(marker, 'dragstart', function () {
               item._msdupdateMarkerAddress('Dragging...');
            });

            google.maps.event.addListener(marker, 'drag', function () {
                item._msdupdateMarkerStatus('Dragging...');
                item._msdupdateMarkerPosition(form, item, icon, marker.getPosition());
            });

            google.maps.event.addListener(marker, 'dragend', function () {
                item._msdupdateMarkerStatus('Dragging...');
                item._msdupdateMarkerPosition(form,item,icon,marker.getPosition());
            });
       
        // Onload handler to fire off the app.
        //google.maps.event.addDomListener(window, 'load', initialize);
    },
    // file selection
    _msdFileSelectHandler: function (form, item, icon,e) {
    	// cancel event and hover styling
		item._msdFileDragHover(form,item,icon,e);
        // fetch FileList object
        var files = e.target.files || e.dataTransfer.files;

        // process all File objects
       // for (var i = 0, f; f = files[i]; i++) {
        item.ParseFile(form, item, icon, files[0]);
       
        //}
    },

    _msdFileDragHover: function (form, item, icon, e) {
		e.stopPropagation();
        e.preventDefault();
        e.target.className = (e.type == "dragover" ? "hover" : "");
     },
    _msdHtmlId:null, 
    HtmlContent: function (form,item,icon) {
        var rtn = 
'   <div style="display: inline;        float: left;        margin-left: 20px;">\
    <div > <div id="' + item._msdHtmlId + 'map" style=" display: block;  width: 450px;  height: 350px;  margin: 0 auto; padding: 1px; "></div>\
</div></div>\
        ';

        return rtn;
    },
    UploadFile: function (form,item,icon,file) {
	var xhr = new XMLHttpRequest();
    if (xhr.upload) {
        // start upload
        xhr.onreadystatechange = function () {
            switch (xhr.status) {
                case 200:
                    switch (xhr.readyState) {
                        case 0:// request not initialized
                            item.Output(form,item,icon,'ایجاد درخواست');
                            break;
                        case 1:// server connection established
                            ite.Output(form,item,icon,'اتصال به سرور');
                            break;
                        case 2:// request received
                            item.Output(form,item,icon,'ارسال درخواست');
                            break;
                        case 3:// processing request
                            item.Output(form,item,icon,'بررسی درخواست');
                            break;
                        case 4:// request finished and response is ready
                            var txt = xhr.responseText;
                            //evaluate To Json
                            var obj = null;
                            try{obj = JSON.parse(txt);} catch (e) { }
                            if (obj != null)
                                if (obj.Success == true)
                                    //success in upload
                                {
                                    item.Output(form, item, icon, 'پرونده با موفقیت بارگذاری شد.');
                                    var winid = eval(item._msdFileUploadId + 'win');
                                    item.setValue(obj.data);
                                    winid.hide();
                                }
                                else
                                    item.Output(form, item, icon, obj.Error);
                            else
                                item.Output(form, item, icon, 'پاسخ مناسبی از سرور دریافت نشد');
                            break;
                    }

                    break;
                case 404:
                    item.Output(form,item,icon,'ارسال با موفقیت صورت نگرفت آدرس برای ارسال معتبر نیست');
                    break;
                case 0:
                    item.Output(form, item, icon, 'ایجاد درخواست');
                    break;
                default:
                    item.Output(form,item,icon,'وضعیت نامشخص برای درخواست ایجاد شده است.'+ ' '+ xhr.status.toString());
                    console.log('irerpFileUpload.js: Unknown Status (' + xhr.status.toString() + ') for request');
                    break;
            }

        }
        xhr.open("POST", document.getElementById(item._msdFileUploadId + 'upload').action, true);
        xhr.setRequestHeader("X_FILENAME", file.name);
        try{
            xhr.send(file);
        } catch (e) {
            console.log(e);
        }

    }

    },
    _msdGetFormattedSize : function(size)
    {
        return humanFileSize(size, 1000);
    },
    _msdDeselectFile: function (form, item, icon) {
        var fileselectdiv = document.getElementById(item._msdFileUploadId + "fileselectdiv");
        fileselectdiv.innerHTML = fileselectdiv.innerHTML;
        item._msdAddElementHandlers(form, item, icon);
        
   },
    ParseFile: function (form, item, icon, file) {
        if (item.MsdMaxFileSize > 0)
            if (file.size > item.MsdMaxFileSize) {
                alert('حداکثر حجم مجاز برای پرونده '+ 
                    item._msdGetFormattedSize(item.MsdMaxFileSize)+' '+
                    'می باشد در صورتیکه پرونده انتخاب شده دارای حجم '+
                    item._msdGetFormattedSize(file.size)+
                    ' است '
                    );
                item._msdDeselectFile(form, item, icon);
                var Vlayout = eval(item._msdFileUploadId + '_WinVLayout');
                if (Vlayout.members.length > 2) {
                    Vlayout.removeMember(Vlayout.members[2]); // Remove Last Preview
                }
                return;
            }
     /*   
    // display an image
    if (file.type.indexOf("image") == 0) {
        var reader = new FileReader();
        reader.onload = function (e) {
            //the image
            var Vlayout = eval(item._msdFileUploadId + '_WinVLayout');
            if (Vlayout.members.length > 2){
                Vlayout.removeMember(Vlayout.members[2]);
            }
            Vlayout.addMember (irerp.Img.create({ src: e.target.result ,imageType :'center'}));
        }
        reader.readAsDataURL(file);
    }*/
    },
    Output: function (form, item, icon, msg) {
		var m = document.getElementById(item._msdFileUploadId+"messages");
		m.innerHTML = msg;// + m.innerHTML;
    }

    ,
    _msdOpenBroweserWindow: function () {
        var newWin = window.open('file:///C:/Users/Mazarei/Desktop/address/1.htm', 'name', 'height=200,width=150');
        newWin.document.body.innerHTML = '        ';
        if (window.focus) { newWin.focus() }

    }


});