isc.defineClass("irerpPickTreeItem", "PickTreeItem");
isc.irerpPickTreeItem.addProperties({
    setCriteria: function (crit) {
        this.button.criteria = crit; // to set initialize criteria to DataSource
    },
    getCriteria: function () {
        return this.button.criteria;
    }
}
    );

