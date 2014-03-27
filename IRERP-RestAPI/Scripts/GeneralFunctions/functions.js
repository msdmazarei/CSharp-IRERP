function OpenBrowserWindowWithPostParams(tit, url, props, PostParams) {
    if (props == null) {
        var params;
        params = 'width=' + screen.width;
        params += ', height=' + screen.height;
        params += ', top=0, left=0'
        params += ', fullscreen=yes';
        props = params;
    }
    var form = document.createElement("form");
    form.style = "display:none"; //to hide form
    //mapForm.target = "Map";
    form.target = "_blank";
    form.method = "POST"; // or "post" if appropriate
    form.action = url;
    for (var prop in PostParams) {
        var inp = document.createElement("input");
        inp.type = "hidden";
        inp.name = prop;
        inp.id = prop;
        inp.value = PostParams[prop];
        form.appendChild(inp);

    }
    document.body.appendChild(form);
    form.submit();
    /*win = window.open("", "Map", props);

    if (win) {
        form.submit();
    } else {
        alert('You must allow popups for this map to work.');
    }*/
 
}

function randomString(string_length) {
    if (string_length == null) string_length = 8;
    var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz";
    var randomstring = '';
    for (var i = 0; i < string_length; i++) {
        var rnum = Math.floor(Math.random() * chars.length);
        randomstring += chars.substring(rnum, rnum + 1);
    }
   return  randomstring;
}

function FilterBuilderFor(gridid) {
    irerp.Window.create({
        ID:gridid.ID+'_FilterBuilderWindow',
        showMaximizeButton: true,
        autoCenter: true,
        showResizer :true,
        width: 600,
        height: 300,
        canDragResize: true,
        showResizer: true,
        title:'فیلتر کردن حرفه ای ...',
        items: [irerp.irerpFilterBuilder.create({
            dataSource:gridid.dataSource,criteria:gridid.getCriteria(),ID:gridid.ID+'_FilterBuilder'
        }),
        irerp.HLayout.create({
            members: [irerp.Button.create({
                title: 'اعمال', click: function () {
                    var filterBuilder = eval(gridid.ID + '_FilterBuilder');
                    gridid.fetchData(filterBuilder.getCriteria(), IRERPDS_callBack, { params: gridid.irerpRequestParams });
                }
            }),
            irerp.Button.create({ title: 'بازگشت', click: function () { var winid = eval(gridid.ID + '_FilterBuilderWindow'); winid.hide(); } })],
            
        })
        
        ],
        isModal:true,
    });
}

function SendItemsToPrint(gridid/*string*/, reportParams/*javascript object*/, reportName/*string*/) {
    
    if (gridid == null) return;
    if (window[gridid] == null) return;

    var grid = eval(gridid);
    var rptreq = reportParams;

    /// Criteria 
    if(Object.keys(grid.getCriteria()).length>0)
        rptreq.Criteria = JSON.stringify(grid.getCriteria());
                
    var _order='';
    //// Order
    if(grid.getSort()!=null)
        if(grid.getSort().length>0)
            for(var i=0;i<grid.getSort().length;i++)
            {
                var orde= grid.getSort()[i];
                if(orde.direction =='ascending')
                    _order+=orde.property+',';
                else
                    _order+='-'+orde.property+',';
            }
    if(_order!='')
        _order=_order.substring(0,_order.length-1);
    rptreq.Orders=_order;
    if (grid.getSelectedRecords() != null && grid.getSelectedRecords().length > 0) {
        //get datasource 
        var gridDataSource = null;
        if (grid.dataSource != null && grid.dataSource.Class == 'String')
            gridDataSource = eval(grid.dataSource);
        else
            gridDataSource = grid.dataSource;
        var pkfield = null;

        if (gridDataSource.Class == 'RestDataSource')
            pkfield = gridDataSource.getPrimaryKeyField();

        var ids = [];
        
        if (pkfield != null) {
            //Change Criteria and limit criteria to selected items
            for (var i = 0; i < grid.getSelectedRecords().length; i++) {
                ids[i] = grid.getSelectedRecords()[i][pkfield.name];
            }
            //{ fieldName:"salary", operator:"lessThan", value:"80000" }
            rptreq.Criteria =  JSON.stringify({ fieldName: pkfield.name, operator: 'inSet', value: ids });
        }
    }
    OpenBrowserWindowWithPostParams(reportName, '/Report/Report/ViewReport', null, rptreq);
}

function callServerMethod(url, data, callbackfunction, CallType,additionalParams) {
    CallType = typeof CallType !== 'undefined' ? CallType : 'POST';
    $.ajax(
   {
       type: CallType,
       url: url,
       data: data,
       success: function (data, textStatus, jqXHR) {
           callbackfunction(data, textStatus, jqXHR, additionalParams);
       }
   }
   );
}


function AddProxyFunction(object, funcname, handler) {
    //Check that function has early defined>
    if (object[funcname] != null) {
        //Detect how many old memberrs exists
        var i = 0;
        var found = false;
        while (!found) {
            if (object['___MSDOLDFUNC_' + i.toString() + '_' + funcname] == null) {
                found = true;
                break;
            }
            i++;
        }
        object['___MSDOLDFUNC_' + i.toString() + '_' + funcname] = object[funcname];
        object[funcname] = function () {
            object['___MSDOLDFUNC_' + i.toString() + '_' + funcname].apply(object, arguments);
            handler.apply(object, arguments);
        };
    } else
        object[funcname] = handler;
}
function SelectItemOptionDsDetail(selectitem,_params) {
    selectitem.fetchData(null, {params:_params});
}

function DVS_refresh(grdid) {
    var grid = null;
    if (grdid.Class.toString().toLowerCase() == 'string')
        grid = eval(grdid);
    if (grid != null)
        if (grid.Class == 'irerpListGrid') {
            grid.msdReload();
        }
}

/*
    url : url to get,
    data: data to send to server 
    successCallback: function(url,sentData,arrayPageParts) which arrayPageParts contains Display,OtherObjects,Commands
    errorCallbak: function(url,sentData,jqXHR jqXHR, String textStatus, String errorThrown )
*/
function getPageParts(url,data,successCallBack,errorCallBack) {
    
    $.ajax(
    {
        type: 'POST',
        url: url,
        data: data,
        success: function (recdata) {
            var pageparts = {};
            var str = $.trim(recdata);
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

            pageparts.Display = DisplayControls;
            pageparts.OtherObjects = OtherObjects;
            pageparts.Commands = Commands;

            successCallBack(url, data, pageparts);
            return pageparts;
        },
        error: function( jqXHR,textStatus, errorThrown ){
            if(errorCallBack!=null) 
                errorCallBack(url,data,jqXHR,textStatus,errorThrown);
        }

    }
    );
}
function IncludeJS(sId, source) {
    if ((source != null) && (!document.getElementById(sId))) {
        var oHead = document.getElementsByTagName('HEAD').item(0);
        var oScript = document.createElement("script");
        oScript.language = "javascript";
        oScript.type = "text/javascript";
        oScript.id = sId;
        oScript.defer = true;
        oScript.text = source;
        oHead.appendChild(oScript);
    }
}


function humanFileSize(bytes, si) {
    var thresh = si ? 1000 : 1024;
    if (bytes < thresh) return bytes + ' B';
    var units = si ? ['kB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'] : ['KiB', 'MiB', 'GiB', 'TiB', 'PiB', 'EiB', 'ZiB', 'YiB'];
    var u = -1;
    do {
        bytes /= thresh;
        ++u;
    } while (bytes >= thresh);
    return bytes.toFixed(1) + ' ' + units[u];
};

function msdlog(str) {
    console.log(str
        );
}

function MSDGUID(){
    var guid = 'xxxxxxxx-xxxx-5xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
        var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
        return v.toString(16);
    });		
    return guid;
};
function LoadPageAndReturnDisplayControls(OtherObjects, DisplayControls, Commands) {
    var gid = '_' + MSDGUID().replace(/-/gi, '');
    
    DisplayControls = 'var ' + gid + 'VAR=' + DisplayControls;
    IncludeJS(gid, OtherObjects + DisplayControls + Commands);
    /*IncludeJS(gid + '_OtherObjects', OtherObjects);
    IncludeJS(gid + '_DisplayControls', DisplayControls);
    IncludeJS(gid + '_Commands', Commands);*/
    setTimeout(function () {
        document.getElementById(gid ).remove();
        /*document.getElementById(gid + '_OtherObjects').remove();
        document.getElementById(gid + '_DisplayControls').remove();
        document.getElementById(gid + '_Commands').remove();
        */
    }, 30000);
    return window[gid + 'VAR'];



}

function FromJson(data) {
    return JSON.parse(data);
}