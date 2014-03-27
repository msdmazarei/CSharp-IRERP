irerp.defineClass('irerpTextItem', 'TextItem');
irerp.irerpTextItem.addProperties({
    MsdHelpWindowWidth: 200,
    MsdHelpWindowHeight: 100,
    MsdHelpIcon: "[SKIN]/actions/help.png",
    MsdHelpMessage: null,
    MsdHelpIconClick: function (form, item, icon) {
        item._MsdHelpDialog('راهنما', item.MsdHelpMessage);
    },
    _getHelpIcon: function (form, item, icon) {
        var rtn = null;
        if (this.MsdHelpIcon != null)
            switch (this.MsdHelpIcon.Class) {
                case 'String':
                    rtn = { src: this.MsdHelpIcon, prompt: this.MsdHelpMessage.substring(0,50) };
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

        this.Super('init', arguments);
    },
    _MsdHelpDialog: _MsdHelpDialog
    
});
    