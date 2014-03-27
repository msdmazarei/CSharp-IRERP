irerp.ClassFactory.defineClass('irerpSelectItem', 'SelectItem');
irerp.irerpSelectItem.addProperties({
    MsdHelpWindowWidth: 200,
    MsdHelpWindowHeight:100,
    MsdHelpIcon: "[SKIN]/actions/help.png",
    MsdHelpMessage: null,
    
    
    MsdHoverFields:null, // like [{name:"",title:""},{name:"",title:""}]
    MsdHelpIconClick: function (form, item, icon) {
        item._MsdHelpDialog('راهنما', item.MsdHelpMessage);
    },

    MsdshowRefreshIcon: function () { return this._hasOptionDataSource() && this.MsdRefreshIconClick!=null; },
    MsdRefreshIcon: "[SKIN]/actions/refresh.png",
    MsdRefreshIconClick: function (form, item, icon) { item.data = null; item.fetchData();},
   
    MsdWindowManageTitle: function () { return "پنجره";},
    MsdShowManageIcon: function () { return this._hasOptionDataSource() && this.MsdManageIconClick!=null;},
    MsdManageIcon: "[SKIN]/headerIcons/settings.png",
    MsdManageUrl:null,
    MsdManageIconClick: function (form, item, icon) {
        if (item == null)
            return;
        if(item.MsdManageUrl!=null)
            if (item.MsdManageUrl.Class == 'String') {
                var winLoading = irerp.Window.create({
                    showHeader:false,
                    edgeImage:"[SKIN]/Menu/m.png",
                    edgeSize:10, edgeTop:17, edgeBottom:17,
                    edgeCenterBackgroundColor:"#F7F7F7",
                    title: "Waiting ...", 
                    isModal: true, 
                    autoCenter: true, 
                    showCloseButton: false, 
                    showMinimizeButton: false, 
                    autoSize: true,
                     items: [
                      irerp.Label.create({ contents: "<b>در حال بارگذاری ...</b>", width:"*",height:"*" ,align :'right'})
                    ]
                });
                winLoading.show();
                //Open Url In Window
                getPageParts(item.MsdManageUrl,
                    { skin: "win8", to: ["send to the server"], calltype: "ajaxCall", Requester: "irerpSelectItem" },
                    //Success
                   function (url, sentData, arrayPageParts) {
                       winLoading.hide();
                       var disp = LoadPageAndReturnDisplayControls(
                           arrayPageParts.OtherObjects,
                           arrayPageParts.Display,
                           arrayPageParts.Commands);
                   
                       //eval(arrayPageParts.OtherObjects);
                       irerp.Window.create({
                           title:item.MsdWindowManageTitle(),
                           //maximized: true,
                           items: [disp/*eval(arrayPageParts.Display)*/],
                           isModal: true,
                       autoCenter: true,
                       //autoSize: true,
                       showMaximizeButton: true,
                       showModalMask: true,
                       width: '90%',
                       height: '90%',
                       defaultLayoutAlign: 'right',
                       showResizer: true,
                       canDragResize :true,
                       });
                       //eval(arrayPageParts.Commands);
                   },
                   //Error
                   function (url, sentData, jqXHR, textStatus, errorThrown) {
                       winLoading.hide();
                       alert(errorThrown);
                   });
            }
    },
    
    
    _hasOptionDataSource :function(){
        var rtn = false;
        if(this.optionDataSource !=null)
            switch(this.optionDataSource .Class){
                case 'String':
                    if(irerp.DS.getDataSource(this.optionDataSource)!=null)
                        switch(irerp.DS.getDataSource(this.optionDataSource).Class){
                            case 'RestDataSource':
                                rtn = true;
                                break;
                            case 'irerpRestDataSource':
                                rtn=true;
                                break;
                        }
                    break;
                case 'RestDataSource':
                    rtn = true;
                    break;
                case 'irerpRestDataSource':
                    rtn = true;
                    break;
            }
        return rtn;
    },
    _getHelpIcon: function (form, item, icon) {
        var rtn = null;
        if (this.MsdHelpIcon != null)
            switch (this.MsdHelpIcon.Class) {
                case 'String':
                    rtn ={src:this.MsdHelpIcon,prompt :'راهنما'};
                    break;
                default:
                    rtn = this.MsdHelpIcon;
                    break;
                
                
            }
        if (rtn != null)
            if (this.MsdHelpIconClick != null)
                AddProxyFunction(rtn, 'click', this.MsdHelpIconClick);
        return rtn;
    },
    
    _getRefreshIcon: function () {
        var rtn = null;
        if (this.MsdRefreshIcon != null)
            switch (this.MsdRefreshIcon.Class) {
                case 'String':
                    rtn = { src: this.MsdRefreshIcon, prompt:'بروزرسانی' };
                    break;
                default:
                    rtn = this.MsdRefreshIcon;
                    break;
            }
        if (rtn != null)
            if (this.MsdRefreshIconClick != null)
                AddProxyFunction(rtn, 'click', this.MsdRefreshIconClick);
        return rtn;
    },
    _getManageIcon: function () {
        var rtn = null;
        if (this.MsdManageIcon != null)
            switch (this.MsdManageIcon.Class) {
                case 'String':
                    rtn ={ src: this.MsdManageIcon, prompt:'مدیریت'};
                    break;
                default:
                    rtn = this.MsdManageIcon;
                    break;
            }
        if (rtn != null)
            if (this.MsdHelpIconClick != null)
                AddProxyFunction(rtn, 'click', this.MsdManageIconClick);
        return rtn;
    },
    init: function () {
        this.hoverAlign = 'right';
        this.itemHoverWidth = 200;
        var msdIcons = [];
        ////////////////////////////////////////Help Icon Below
        if (this.MsdHelpMessage != null)
            switch (this.MsdHelpMessage.Class) {
                case 'String':
                    if (this.MsdHelpMessage.trim() != '')
                        msdIcons[msdIcons.length] = this._getHelpIcon();
                    break;
            }
        //////////////////////////////////////////Refresh Icon Below
        if (this.MsdshowRefreshIcon()) {
            var refreshicon = this._getRefreshIcon();
            if (refreshicon != null)
                msdIcons[msdIcons.length] = refreshicon;
        }
        //////////////////////////////////////////Manage Icon Below
        if (this.MsdShowManageIcon()) {
            var manageicon = this._getManageIcon();
            if (manageicon != null)
                msdIcons[msdIcons.length] = manageicon;
        }

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
        if (this.itemHoverHTML == null) {
            this.itemHoverHTML = this._MsdHoverHTML;
        }
        this.Super('init', arguments);
    },

    _MsdHoverHTML: function (item, form) {
        var strHoverHTML = '';

        if (item != null) {
            if (item._hasOptionDataSource() && item.getSelectedRecord() != null) {
                var fields = item.getOptionDataSource().getFieldNames(true); //get Visible Fields
                var selectedRecord = item.getSelectedRecord();

                if (this.MsdHoverFields != null)
                    if (this.MsdHoverFields.length > 0) 
                        fields = this.MsdHoverFields;
                     else
                        return false;
                if (this.pickListFields != null)
                    fields = this.pickListFields;
                if (fields != null && fields.length > 0) {
                    for (var i = 0; i < fields.length; i++) {
                        var field = item.getOptionDataSource().getField(fields[i]);
                        strHoverHTML += '<b>' + field.title + '</b>:' + selectedRecord[field.name] + '<br/>';
                    }
                    return strHoverHTML;
                }

            }
        }
        return false;
    },
    _MsdHelpDialog: function (helptitle, helpmessage) {
        var helpMessageControl = null;
        if (helpmessage != null)
            if (helpmessage.Class == 'String')
                helpMessageControl = irerp.Label.create({ contents: helpmessage,width:"*",height:"*" ,align :'right'});
            else
                helpMessageControl = helpmessage;

        var rtn = irerp.Window.create({
            title: helptitle,
            isModal: true,
            autoCenter: true,
            autoSize: true,
            showMaximizeButton: true,
            showModalMask: true,
            width: this.MsdHelpWindowWidth,
            height: this.MsdHelpWindowHeight,
            defaultLayoutAlign: 'right',
            showResizer: true,
            canDragResize :true,
            items: [
                irerp.HLayout.create({
                    members: [
                        helpMessageControl
                    ]
                })
            ]
        });
    }
});




