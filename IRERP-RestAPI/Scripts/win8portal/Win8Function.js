
function backtomainpage() {
    closeAllCurrentPortlets();
    loadportlets('/testsc/Portlets');
}
function test() {
    closeAllCurrentPortlets();
    loadportlets('/BuyTraffic/Portlets');

}

function test1() {
    closeAllCurrentPortlets();
    loadportlets('/BuySevice/BuyService');

}

function CereditBank_Click() {
    closeAllCurrentPortlets();
    loadportlets('/Ceredit/PortletsCeredit');

}

function test2() {
    closeAllCurrentPortlets();
    loadportlets('/SMS/SMSPortlets');

}
function CereditBankPassargad_DialgSelectDuration(txtid) {

    var price = TextPrice.getValue();
    window.open("/PeymentAllBank/BankPost?BankType=Passargad && price=" + price);

}

function CereditBankMelat_DialgSelectDuration(txtid) {

    var price = TextPrice.getValue();
    window.open("/PeymentAllBank/BankPost?BankType=mellat && price=" + price);

}
function SupportManager_Click() {
   
    // loadvLayout('/ManagerView/Technical/Support');
    // sectionStack2.load('/ManagerView/Technical/Support');
}

function ServiceContinue() {
    closeAllCurrentPortlets();
    loadportlets('/BuySevice/PortletsBuyServiceContinue');
}


function ServiceBack() {
    closeAllCurrentPortlets();
    loadportlets('/BuySevice/PortletsBuyService');
}

function FinancialReport_Click() {
    closeAllCurrentPortlets();
    loadportlets('/FinancialRecords/FinancialPortlets');
}

function ReminnigTraffic_Click() {
    closeAllCurrentPortlets();
    loadportlets('/Traffice/PortletsUserTraffic');
}

function Transaction_Click() {
    closeAllCurrentPortlets();
    loadportlets('/Transaction/PortletsTransaction');
}

function CurentUserService_Click() {
    closeAllCurrentPortlets();
    loadportlets('/UserService/PortletsUserCurrentService');
}

function buyService_DialgSelectDuration(servicename) {
    modalWindow.servicename = servicename;
    Lbl1.setValue(
        "شما در حال انتخاب مدت زمان برای سرویس " +

        servicename +
        "هستید."
        );
    modalWindow.show();


}

function Ceredit_DialgSelectDuration() {
    
    modalWindow.show();
}

function MenuInsert_Save(frmid) {
    frmid.saveData();
}

function MenuInsert_DialgSelectDuration(winid, FormId) {
    FormId.editNewRecord();
    winid.show();
    
}

function VisibleDynamicForm(form, item, value) {
  
        form.getField(item).setLayoutStyle(value);
  

}

function GroupInsert_DialgSelectDuration(winid, FormId) {
    FormId.editNewRecord();
    winid.show();
}
function Insert_Save(frmid) {
    frmid.saveData();
}

function Insert_CloseWindow(winid) {

    winid.hide();
}

function CloseWindow(winid) {

    winid.hide();
}

function OpenWindow(winid) {

    winid.show();
  
}


function Delete_OK(winid, lstid) {
    lstid.removeSelectedData();
    winid.hide();
}

function Delete_CloseWindow(winid) {

    winid.hide();
}

function Delete_DialgSelectDuration(winid) {

    winid.show();
}

function MenuRefresh_DialgSelectDuration() {
    window.location.reload();
}
function MenuInsert_CloseWindow(winid) {

    winid.hide();
}
function MenuDelete_DialgSelectDuration(winid) {

    winid.show();
}
function MenuDelete_CloseWindow(winid) {

    winid.hide();
}
function MenuDelete_OK(winid, lstid) {
    lstid.removeSelectedData();
    winid.hide();
}
function CancleService_DialgSelectDuration(winid) {

    winid.show();


}

function SelectGridMenu_DialgSelectDuration(record, state, winid,FormId) {
    if (state) {
        winid.show();
        FormId.editRecord(record);
    }
}
function RemoveTab () {
    TabsetTest.removeTab(TabsetTest.tabs.length - 1);
        }


function AddTab(tit,url,directload) {
    if (directload == true) {
        TabsetTest.addTab
   ({
       title: tit, canClose: true, pane: isc.HTMLPane.create({
           showEdges: true,
           contentsURL: url,
           contentsType: "page",
           overflow : "visible"
       })
   });
        return;
    }
   

    loadTab(tit,url);
}


function CancleService_CloseWindow(winid) {

    winid.hide();


}
function CereditBank_DialgSelectDuration() {

    window.open("/Payment/PassargadPost");



}
function ChangePassUser_DialgSelectDuration() {

    ChangePassWindow.show();


}

function ChangePassUser_CloseWindow() {

    ChangePassWindow.hide();


}

function SendPassUser_DialgSelectDuration() {

    SendPassWindow.show();


}

function SendPassUser_CloseWindow() {

    SendPassWindow.hide();


}

function ChangePicUser_DialgSelectDuration() {

    ChangePictureWindow.show();


}

function ChangePicUser_CloseWindow() {

    ChangePictureWindow.hide();




}



function ChangeProfileUser_DialgSelectDuration() {

    ChangeProfileWindow.show();


}

function ChangeProfileUser_CloseWindow() {

    ChangeProfileWindow.hide();


}


function UserProperty_Click() {
    closeAllCurrentPortlets();
    loadportlets('/UserProperty/PortletsUser');

}


function buyServiceCloaseWindow() {
    modalWindow.hide();

}

function buyCereditCloaseWindow() {
    modalWindow.hide();

}


function buyServiceFillLbl(lblText) {
    modalWindow.lblText = lblText;
    lblText.setValue('ghwgshgshws');

}


function InvoiceInsert_Save(listgrid, DS) {
    //if (listgrid.getTotalRows > 1000)
    //{

    //    var r = confirm("آیا برای درج مطمئن هستید؟تعداد رکوردها بیشتر از 1000 می باشد.")
    //    if (r == true) {
    //        for (var i = 0; i < listgrid.getSelectedRecords() ; i++) {
    //            DS.addData(i);
    //        }
    //    }
    //    else {
    //        alert("You pressed Cancel!")
    //    }

    //}
    //else {
    var items = listgrid.getSelectedRecords();

    for (var i = 0; i < items.length ; i++) {
        DS.addData(listgrid.getSelectedRecords()[i]);
       
    }

}


function EditHiliting(ListGrid) {
   
    ListGrid.editHilites();

}

function FormulaBuilders(ListGrid) {
  
    ListGrid.addFormulaField();

}


function AdvanceFilters(ListGrid,FilterBulderID) {
    alert(ListGrid.ID);
    ListGrid.filterData(FilterBulderID.getCriteria());

}

function ItemMenuContext(itemListMenu) {
 

    itemListMenu.showContextMenu();

}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

//Default for Persian
var farsikey = [

   0x0020, // " "

   0x0021, // "!"

   0x061B, // ";"

   0x066B, // ","

   0x00A4, // " "

   0x066A, // "%"

   0x060C, // "،"

   0x06AF, // "گ"

   0x0029, // "("

   0x0028, // ")"

   0x002A, // "*"

   0x002B, // "+"

   0x0648, // "و"

   0x002D, // "-"

   0x002E, // "."

   0x002F, // "/"

   0x06F0, // "۰"

   0x06F1, // "۱"

   0x06F2, // "۲"

   0x06F3, // "۳"

   0x06F4, // "۴"

   0x06F5, // "۵"

   0x06F6, // "۶"

   0x06F7, // "۷"

   0x06F8, // "۸"

   0x06F9, // "۹"

   0x003A, // ":"

   //0x0643, // "ك"

   0x06A9, // "ک"

   0x003E, // "<"

   0x003D, // "="

   0x003C, // ">"

   0x061F, // "?"

   0x066C, // "،"

   0x0624, // "ؤ"

   0x200C, // " "

   0x0698, // "ژ"

   0x0649, // "ی"

   0x064D, // " "

   0x0625, // " "

   0x0623, // "ًٌٍإ"

   0x0622, // " "

   0x0651, // " "

   0x0629, // "ًٌة"

   0x00BB, // "«"

   0x00AB, // "»"

   0x0621, // "ء"

   0x004E, // "N"

   0x005D, // "["

   0x005B, // "]"

   0x0652, // " "

   0x064B, // " "

   0x0626, // "ئ"

   0x064F, // " "

   0x064E, // " "

   0x0056, // "V"

   0x064C, // " "

   0x0058, // "X"

   0x0650, // " "

   0x0643, // "ك"

   0x062C, // "ج"

   0x005C, // "\"

   0x0686, // "چ"

   0x00D7, // "x"

   0x0640, // "-"

   0x200D, // " "

   0x0634, // "ش"

   0x0630, // "ذ"

   0x0632, // "ز"

   0x06CC, // "ی"

   // 0x064A = ي

   0x062B, // "ث"

   0x0628, // "ب"

   0x0644, // "ل"

   0x0627, // "ا"

   0x0647, // "ه"

   0x062A, // "ت"

   0x0646, // "ن"

   0x0645, // "م"

   //0x067E, // "پ"

   0x0626, // "ئ"

   0x062F, // "د"

   0x062E, // "خ"

   0x062D, // "ح"

   0x0636, // "ض"

   0x0642, // "ق"

   0x0633, // "س"

   0x0641, // "ف"

   0x0639, // "ع"

   0x0631, // "ر"

   0x0635, // "ص"

   0x0637, // "ط"

   0x063A, // "غ"

   0x0638, // "ظ"

   0x007D, // "{"

   0x007C, // "|"

   0x007B, // "}"

   0x007E  // "~"

];
var lang = 1;   // 1: Farsi, 0: English  
function changeLang() {

    if (lang == 0) {

        lang = 1;

        return true;

    }

    else {

        lang = 0;

        return true;

    }

}



function FKeyDown(txtFrm) {

    var key = window.event.keyCode;

    if (key == 145) {

        if (lang == 0) {

            lang = 1;

            return true;

        }

        else {

            lang = 0;

            return true;

        }

    }

}



function FKeyPress(txtFrm) {

    var key = window.event.keyCode;



    if (key == 13) { window.event.keyCode = 13; return true; }

    if (lang == 1) { // If Farsi

        if (key == 0x0020 && window.event.shiftKey) // Shift-space -> ZWNJ

            window.event.keyCode = 0x200C;

        else

            window.event.keyCode = farsikey[key - 0x0020];

        if (farsikey[key - 0x0020] == 92) {

            window.event.keyCode = 0x0698;

        }

        if (farsikey[key - 0x0020] == 8205) {

            window.event.keyCode = 0x067E;

        }

    }

    return true;

}

