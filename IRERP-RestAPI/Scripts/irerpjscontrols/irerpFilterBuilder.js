irerp.defineClass("irerpFilterBuilder", "FilterBuilder");
irerp.irerpFilterBuilder.addProperties({
    
    initWidget: function () {
        var myself = this;
        this.Super("initWidget", arguments);
        this.addSubClause = function () {
            this.Super("addSubClause", arguments);
        }
    }
});

