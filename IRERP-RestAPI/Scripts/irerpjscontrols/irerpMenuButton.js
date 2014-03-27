isc.defineClass("irerpMenuButton", "MenuButton");
isc.irerpMenuButton.addProperties({
    initWidget: function () {
        this.Super("initWidget", arguments);
        this.alignMenuLeft = false;

    },
    showMenu: function () {
        this.Super('showMenu', arguments);
    }
});
