
function closeAllCurrentPortlets() {
    mainPortal.destroy();

}

var toType = function(obj) {
    return ({}).toString.call(obj).match(/\s([a-zA-Z]+)/)[1].toLowerCase()
}

function loadportlets(url) {
    var data = { skin: "win8", to: ["send to the server"], calltype: "ajaxCall" };
    $.ajax(
    {
        type: 'POST',
        url: url,
        data: data,
        success: loadportletcallback
    }
    );
    
//    RPCManager.sendRequest({ data: data, callback: "loadportletcallback(data)", actionURL: url});
    lblwaiting.show();
}
function loadportletcallback(data) {
    var spliter = "/*********************SCRIPTSECTION*******************/";
    lblwaiting.hide();
    var parts = data.split(spliter);
    if (typeof (parts) == "string")
        mainLayout.addMember(eval(data), 1);
    else {
        mainLayout.addMember(eval(parts[0]), 1);
        if(parts.length > 1)
        eval(parts[1]);
    }
    
}
function closePortlet(portlet) {
    portlet.destroy();
}

///////////////////////////////////////////////////////////
function loadTab(tit,url) {
    var data = { skin: "win8", to: ["send to the server"], calltype: "ajaxCall" };
    $.ajax(
    {
        type: 'POST',
        url: url,
        data: data,
        success: function (data) { loadTabCallBack(tit, data) }
    }
    );
}
function loadTabCallBack(tit,data) {
   
    var str = $.trim(data);
    var DISPLAYControlStartSection = '/*********IRERPDISPCTLID-START:';
    var DISPLAYControlFinishSection = '/*********IRERPDISPCTLID-FINISH:';
    var OtherObjectsStartSection = '/*********IRERPOTHRCTLID-START:';
    var OtherObjectsFinishSection = '/*********IRERPOTHRCTLID-FINISH:';
    var CommandsStartSection = '/*********IRERPCMMDCTLID-START:';
    var CommandsFinishSection = '/*********IRERPCMMDCTLID-FINISH:';
    var JsCommentEndSections = '********************/';
    var GuidFormat = 'dddddddddddddddddddddddddddddddd';
    var DisplayControls = '';
    var OtherObjects = '';
    var Commands = '';
    if (str.indexOf(DISPLAYControlStartSection) > -1) {
        
        var id = str.substr(str.indexOf(DISPLAYControlStartSection) + DISPLAYControlStartSection.length, GuidFormat.length);
        var startindex =
                   str.indexOf(DISPLAYControlStartSection + id + JsCommentEndSections)
                   +
                   (DISPLAYControlStartSection + id + JsCommentEndSections).length;
        var finishindex = str.indexOf(DISPLAYControlFinishSection + id + JsCommentEndSections);
        if (finishindex - startindex > 0)
            DisplayControls = str.substr(startindex, finishindex - startindex);

        startindex =
                 str.indexOf(OtherObjectsStartSection + id + JsCommentEndSections)
                 +
                 (OtherObjectsStartSection + id + JsCommentEndSections).length;
        finishindex = str.indexOf(OtherObjectsFinishSection + id + JsCommentEndSections);
        if (finishindex - startindex > 0)
            OtherObjects = str.substr(startindex, finishindex - startindex);

        startindex =
str.indexOf(CommandsStartSection + id + JsCommentEndSections)
+
(CommandsStartSection + id + JsCommentEndSections).length;
        finishindex = str.indexOf(CommandsFinishSection + id + JsCommentEndSections);

        if (finishindex - startindex > 0)
            Commands = str.substr(startindex, finishindex - startindex);

    }
    var disp =
        LoadPageAndReturnDisplayControls(OtherObjects, DisplayControls, Commands);
    TabsetTest.addTab ({ title: tit, canClose: true, pane: disp});
    var lasttab = TabsetTest.tabs[TabsetTest.tabs.length-1];
    TabsetTest.selectTab(lasttab);
    //eval(OtherObjects);
    /*
    IncludeJS('_' + id + '_OtherObjects', OtherObjects);
    var lastchar = DisplayControls.substring(DisplayControls.length - 1, DisplayControls.length);
    if (lastchar = ';')
        DisplayControls = DisplayControls.substring(0, DisplayControls.length - 1);
    DisplayControls = 'TabsetTest.addTab ({ title: "'+tit+'", canClose: true, pane: '+DisplayControls+'});\
    var lasttab = TabsetTest.tabs[TabsetTest.tabs.length-1];\
    TabsetTest.selectTab(lasttab);'
    IncludeJS('_' + id + '_DisplayControls', DisplayControls);
    */
    /*TabsetTest.addTab 
    ({ title: tit, canClose: true, pane: eval(DisplayControls) });
    var lasttab = TabsetTest.tabs[TabsetTest.tabs.length-1];
    TabsetTest.selectTab(lasttab);*/
    
    //eval(Commands);
    //IncludeJS('_' + id + '_Commands', Commands);
   
}
///////////////////////////////////////////////////////////
function closePortletArray(portletArray) {
    portletArray.map( function(a){
        if (toType(a) == 'array')
            closePortletArray(a);
        else
            closePortlet(a);
    });
    }

function showmessage(title, message) {
    alert(message);
}

function win8skinlogout() {
    RPCManager.sendRequest({
        actionURL: '/Login/Logout',
        callback: function (dsResponse, data, dsRequest) {
            if (dsResponse.status == 0) {
                //on Successfuly Request to Servr
                var result = JSON.parse(data);
                if (result.Success == true) {
                    window.location = result.RedirectToUrl;
                } else {
                    showmessage('alert', result.Error);
                }
            }
        },
    });
}
function win8skinlogin() {
    var username = loginform.getField('username').getValue();
    var password = loginform.getField('password').getValue();
    RPCManager.sendRequest(
{
    actionURL: '/Login/Login',
    callback: function (dsResponse, data, dsRequest) {
        if (dsResponse.status == 0) {
            //on Successfuly Request to Servr
            var result = JSON.parse(data);
            if (result.Success==true) {
                window.location = result.RedirectToUrl;
            } else {
                showmessage('alert',result.Error);
            }
        }
    },
    params: { username: username, password: password},
    willHandleError : true,
}
);
   

}

function GeneralAdd(winid, formid, gridid) {
    formid.clearErrors(true);
    formid.editNewRecord();
    winid.show();
}

function GeneralEditAndSave(winid, formid, gridid) {
    if (gridid.getSelectedRecord() != null) {
        formid.clearErrors(true);
        formid.editNewRecord(gridid.getSelectedRecord());
        winid.show();

    } else {
        alert('یک رکورد را برای ویرایش انتخاب کنید');
    }
}

function GeneralEdit(winid, formid, gridid) {
    if (gridid.getSelectedRecord() != null) {
        formid.clearErrors(true);
        formid.editRecord(gridid.getSelectedRecord());
        winid.show();
    } else {
        alert('یک رکورد را برای ویرایش انتخاب کنید');
    }
}
function GeneralDelete(winid, formid, gridid) {
    var todelete = [];
    if (gridid.getSelectedRecords() != null
        &&
        gridid.getSelectedRecords().length>0
        ) {
        
        for (var i = 0; i < gridid.getSelectedRecords().length; i++) {
            todelete[i] = gridid.getSelectedRecords()[i];
        }
        //get grid primary keys 
        var gridDataSource = gridid.dataSource;
        if(gridDataSource.Class=='String')
            if(window[gridid.dataSource]!=null) 
                gridDataSource = window[gridid.dataSource];
            else 
                gridDataSource=null;
        
        var pkfield = null;
        if (gridDataSource.Class == 'RestDataSource') {
            pkfield = gridDataSource.getPrimaryKeyField();

        }

        for (var i = 0; i < todelete.length; i++)
            if (pkfield) {
                var myObj = new Object;
                myObj[pkfield.name]=todelete[i][pkfield.name];
                gridid.removeData(
                    myObj, function (dsResponse, data, dsRequest) { }, { params: formid.irerpRequestParams }
                    );
            } else
            gridid.removeData(todelete[i], function (dsResponse, data, dsRequest) { }, { params: formid.irerpRequestParams });

        winid.hide();
    }
}
function GeneralSaveCallBack(dsResponse, data, dsRequest) {
    if (dsResponse.status == 0) {
        var component = eval(dsRequest.componentId);
        if (component != null) {
            if (component.Class == "ListGrid" || component.Class=="irerpListGrid") {
                if (dsRequest.operationType == "update") {
                    component.endEditing(); //todo: لازمه دیتای برگشته از سرور جایگزین مقدار فعلی شود این روش فعلی ابتدایی است
                }
            }
            if (component.Class == "DynamicForm" || component.Class=="irerpDynamicForm") {
                if (dsRequest.operationType == "add") {
                    showmessage("افزودن", "عملیات ذخیره با موفقیت انجام شد.");
                    component.editNewRecord();
                }
                if (dsRequest.operationType == "update") {
                    showmessage("بروزرسانی", "بروزرسانی با موفقیت انجام شد.");
                    //get window
                    var wind = null;
                    var parent = component;
                    while (wind == null) {
                        if (parent.Class == "Window" ||  parent.Class=="irerpWindow") {
                            wind = parent;
                            continue;
                        }
                        parent = parent.parentElement;
                        if (parent == null) break;
                    }
                    if (wind != null) wind.hide();
                }
            }
        }
    } else if (dsResponse.status == -1) {
        //خطای کلی رخ داده
        console.log('gholi');
        console.log("Error", dsResponse.data);
    } else if (dsResponse.status == -4) {
        //خطای اعتبار سنجی
    }

}

function GeneralSave(winid, formid, gridid) {
      formid.saveData( GeneralSaveCallBack, { params: formid.irerpRequestParams } );
      //winid.hide();
    }
function GeneralReturn(winid, formid, gridid) {
    winid.hide();
}
function GeneralDeleteAlert(winid, formid, gridid) {
    winid.show();
}

function GeneralMasterDetail(MasterGridId, DetailGridId, DetailGridCriteria) {
    DetailGridId.filterData(DetailGridCriteria);
}
function OpenReportDesigner(Reportid) {
    if (Reportid != null)
        OpenBrowserWindow('طراحی گزارش', '/Report/Report/DesignReport?id=' + Reportid);
}

function OpenBrowserWindow(tit, url) {
    params = 'width=' + screen.width;
    params += ', height=' + screen.height;
    params += ', top=0, left=0'
    params += ', fullscreen=yes';

    window.open(url, tit,params);
    //window.open(url, tit);
}
function IRERPDS_handleError(response, request) {
    if (response.status == -1) {
        console.log(response.data);
        return false; //dont call sc
    }
    else if (response.status == -4) {
        if (request.data != null)
            if (request.data.__client_Operation == 'GroupInsert')
                return false;
        
        return true; //call sc 
    }

    console.log('some Error Happend. Called From js.IRERPDS_handleError');
    return false; // To Prevent To run SmartClient Error Handeling , return false call SC error handeling
}
function IRERPDS_callBack(dsResponse,data, dsRequest) {
}
function IRERPLG_rowEditorExit(editCompletionEvent, record, newValues, rowNum, lstid) {
    if (editCompletionEvent == 'enter') {
        //ذخیره تغییرات
        if (Object.keys(newValues).length > 1) {
            //از آنجا که فرض کرده ایم تمامی دیتاسورس ها حتما یک کلید اصلی دارند پس تعداد باید بیش تر از 
            //یک باشد و اگر 1 یا کمتر از آن بود یعنی تغییری در داده صورت نگرفته است
            lstid.updateData(newValues,GeneralSaveCallBack, { params: lstid.irerpRequestParams });
            return false;//برای جلوگیری از اجرای پیش فرض های اسمارت کلاینت
        }
    }
    

}