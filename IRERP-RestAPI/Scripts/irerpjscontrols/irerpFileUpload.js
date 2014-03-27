irerp.defineClass('irerpFileUploadItem', 'TextItem');
irerp.irerpFileUploadItem.addProperties({
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
        var win = item.UploadWindow(form, item, icon, function () { });
        win.show();
    },
    MsdUploadIconShow: true,
    MsdUploadPath:'',

    init: function () {
        this._msdFileUploadId ='_FileUpload_'+Math.random().toString().replace('.','_')
        this._msdIcons();
        this.canEdit = false;
        this.Super('init', arguments);
        if(this.form!=null)
            if(this.form.dataSource!=null)
                if(
                    this.form.dataSource.Class =='RestDataSource' 
                    || 
                    this.form.dataSource.Class=='irerpRestDataSource'
                    )
                {
                    var filefieldurl = this.form.dataSource.dataURL.toString().replace('/DataSource/','/FileFieldUpload/'+this.name+'/');
                    if(this.MsdUploadPath == null)
                        this.MsdUploadPath = filefieldurl;
                    if(this.MsdUploadPath.trim()=='')
                        this.MsdUploadPath = filefieldurl;
                }
        


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
    UploadWindow: function (form,item,icon,callbackfunction) {
        var uploaderform=item.UploadHtmlContent(form,item,icon);
        var rtn = irerp.Window.create({
            isModal: true,
            autoCenter: true,
            autoSize: true,
            showMaximizeButton: true,
            showModalMask: true,
            defaultLayoutAlign: 'right',
            showResizer: true,
            canDragResize: true,
            ID:item._msdFileUploadId+'win',
            items: [
                irerp.VLayout.create({
                    ID:item._msdFileUploadId+'_WinVLayout',
                    members: [
                        irerp.HTMLFlow.create({ contents: uploaderform }),
                        irerp.Button.create({
                            ID:item._msdFileUploadId+'UploadBtn',
                            title: 'بارگذاری...', click: function () {
                                //getfile element 
                                var fileselect = document.getElementById(item._msdFileUploadId + "fileselect");
                                item.UploadFile(form, item, icon,fileselect.files[0]);
                            }
                        })
                    ]
                })
            ]
        });
        item._msdAddElementHandlers(form,item,icon);
        return rtn;
    },
    _msdAddElementHandlers: function (form, item, icon) {
        //After Items Created
        var fileselect = document.getElementById(item._msdFileUploadId + "fileselect"),
			filedrag = document.getElementById(item._msdFileUploadId + "filedrag"),
			submitbutton = document.getElementById(item._msdFileUploadId + "submitbutton");


        // file select
        fileselect.addEventListener("change", function (e) { item._msdFileSelectHandler(form, item, icon, e); }, false);

        // is XHR2 available?
        var xhr = new XMLHttpRequest();
        if (xhr.upload) {

            // file drop
            filedrag.addEventListener("dragover", function (e) { item._msdFileDragHover(form, item, icon, e); }, false);
            filedrag.addEventListener("dragleave", function (e) { item._msdFileDragHover(form, item, icon, e); }, false);
            filedrag.addEventListener("drop", function (e) { item._msdFileSelectHandler(form, item, icon, e); }, false);
            filedrag.style.display = "block";

            // remove submit button
            submitbutton.style.display = "none";
        }

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
    _msdFileUploadId:null, 
    UploadHtmlContent: function (form,item,icon) {
        var rtn = 
'\
\
<form id="' + item._msdFileUploadId+ 'upload" action="'+item.MsdUploadPath+'" method="POST" enctype="multipart/form-data">\
\
<fieldset>\
<legend>بارگذاری پرونده</legend>\
\
<input type="hidden" id="' + item._msdFileUploadId + 'MAX_FILE_SIZE" name="MAX_FILE_SIZE" value="300000" />\
\
<div id="'+item._msdFileUploadId+'fileselectdiv">\
	<label for="' + item._msdFileUploadId + 'fileselect">پرونده برای بارگذاری:</label>\
	<input type="file" id="' + item._msdFileUploadId + 'fileselect" name="fileselect" />\
	<div id="' + item._msdFileUploadId + 'filedrag">یا اینجا رها کنید.</div>\
</div>\
\
<div id="' + item._msdFileUploadId + 'submitbutton">\
	<button type="submit">بارگذاری پرونده</button>\
</div>\
\
</fieldset>\
\
</form>\
\
<div id="' + item._msdFileUploadId + 'progress"></div>\
\
<div id="' + item._msdFileUploadId + 'messages">\
<p>پیام های مربوط به وضعیت</p>\
</div>\
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


});