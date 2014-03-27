isc.defineClass("PersianDatePickerItem", "TextItem");
isc.PersianDatePickerItem.addProperties({
    drawn: function () {
        var rtn = this.Super("drawn", arguments);
        Calendar.setup({
            inputField: this.getDataElementId(),   // id of the input field
            ifFormat: "%Y/%m/%d",       // format of the input field
            dateType: 'jalali',
            showOthers: true,
            weekNumbers: true
        });
        return rtn;
    }
}
    );

