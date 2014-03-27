function _MsdHelpDialog(helptitle, helpmessage) {
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