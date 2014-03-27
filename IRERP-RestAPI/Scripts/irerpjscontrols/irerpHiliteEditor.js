irerp.defineClass("irerpHiliteRule", "HiliteRule");
irerp.irerpHiliteRule.addProperties({
    hiliteFormDefaults: {
        _constructor: "DynamicForm",
        numCols: 3,
        colWidths: [90, 40, 80],
        width: 210,
        items: [
            {
                name: "colorType", type: "SelectItem", showTitle: false, valign: "center",
                valueMap: { foreground: "Foreground", background: "Background" },
                defaultValue: "foreground", width: "*"
            },
            { name: "color", title: "Color", type: "irerpColorItem", width: "*" }
        ]
    },
});
irerp.defineClass("irerpHiliteEditor", "HiliteEditor");
irerp.irerpHiliteEditor.addProperties({
    
    initWidget: function () {
        this.Super("initWidget", arguments);
    },
    addAdvancedHiliteButtonDefaults: {
        _constructor: "IButton",
        title: "افزودن شرایط پیچیده",
        align: "center",
        width: "100%",
        height: 22,
        autoParent: "fieldLayout",
        click: function () {
            this.creator.addAdvancedHilite();
        }
    },
    fieldListDefaults: {
        _constructor: "ListGrid",
        width: "100%",
        height: "*",
        autoParent: "fieldLayout",
        fields: [
            { name: "name", showIf: "false" },
            { name: "title", title: "فیلدهای موجود" }
        ],
        recordClick: function (grid, record) {
            this.creator.addHilite(record);
        }
    },
    saveButtonDefaults: {
        _constructor: "IButton",
        autoParent: "hiliteButtons",
        title: "اعمال",
        click: function () {
            this.creator.saveHilites();
        }
    },
    cancelButtonDefaults: {
        _constructor: "IButton",
        autoParent: "hiliteButtons",
        title: "بازگشت",
        click: function () {
            this.creator.completeEditing();
        }
    },
    hiliteRuleDefaults: {
        _constructor: "irerpHiliteRule"
    },

});

