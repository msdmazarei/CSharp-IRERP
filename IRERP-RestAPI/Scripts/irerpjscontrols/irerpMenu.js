isc.defineClass("irerpMenu", "Menu");
isc.irerpMenu.addProperties({
    initWidget: function () {
        this.Super("initWidget", arguments);
    },
    placeSubmenu: function (item, submenu) {
        // No op if called repeatedly
        
        if (this._openItem == item && this._open_submenu == submenu) return;

        // remember the submenu so we can close it later
        this._openItem = item;
        this._open_submenu = submenu;

        // Show the submenu offscreen.  This ensures that is has been drawn (so we can determine
        // it's size), but is not visible to the user.
        // It also prevents Moz's strange "flash" in the old position.
        submenu._showOffscreen();

        // place the menu adjacent to the item that's showing it
        // Note: use '_placeRect()' to avoid placing submenus offscreen (and avoid occluding the
        // super-menu)
        var itemNum = this.getItemNum(item),
            submenuRect = submenu.getPeerRect(),
            pos = isc.Canvas._placeRect(
            submenuRect[2], submenuRect[3],
            {
                left: this.getPageLeft() - this.submenuOffset - this.getVisibleWidth()-submenu.getVisibleWidth(),
                width: this.getVisibleWidth() + this.submenuOffset,
                top: this.body.getRowPageTop(itemNum)
                // No need for height - we want it to be as close to that point as possible
            },
             this.submenuDirection == this._$left ? this._$left : this._$right,
             false
        )


        submenu.setPageRect(pos[0], pos[1]);

        // the "target" property is passed to the click() function.  if the main menu has been
        // given a "target" other than itself (the default), give it to the submenu if it also has
        // no target.
        if (this.target != this && submenu.target != submenu) {
            submenu.target = this.target;
        }

        submenu.show();
        submenu._parentMenu = this;
        submenu._parentItemNum = itemNum;

        // If we just placed a submenu, we don't want to do a delayed 'placeSubmenu' for another
        // menu that we're waiting on data from.
        if (isc.Menu._submenuQueue) delete isc.Menu._submenuQueue[this.getID()];
    },
   
});
