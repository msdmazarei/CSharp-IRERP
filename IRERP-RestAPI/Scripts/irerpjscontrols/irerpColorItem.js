irerp.defineClass("irerpColorItem", "ColorItem");
irerp.irerpColorItem.addProperties({
    
    initWidget: function () {
        var myself = this;
        this.Super("initWidget", arguments);
    },
    showPicker: function () { alert('show picker');}
});

