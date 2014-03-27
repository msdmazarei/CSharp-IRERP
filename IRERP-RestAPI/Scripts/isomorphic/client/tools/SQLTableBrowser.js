/*
 * Isomorphic SmartClient
 * Version 8.2 (2011-12-05)
 * Copyright(c) 1998 and beyond Isomorphic Software, Inc. All rights reserved.
 * "SmartClient" is a trademark of Isomorphic Software, Inc.
 *
 * licensing@smartclient.com
 *
 * http://smartclient.com/license
 */
isc.defineClass("SQLTableBrowser", "VLayout").addProperties({

previewGridDefaults: {
    _constructor: "ListGrid",
    canDragSelectText: true,
    autoFetchData: false,
    height: "*",
    minFieldWidth: 100,
    showFilterEditor: true,
    canEdit: true
},
//schema: "SST",
previewGridStripDefaults: {
    _constructor: "GridToolStrip",
    width: "100%",

    generateDSButtonDefaults: {
        _constructor: "IAutoFitButton",
        title: "Show DataSource",
        layoutAlign: "center",
        click: "this.creator.creator.showDS()"
    },

    members: ["autoChild:removeButton", "autoChild:addButton", "autoChild:exportButton", "autoChild:generateDSButton",
              "starSpacer",
              "autoChild:refreshButton", "autoChild:totalRowsIndicator"
    ]
},

initWidget : function () {
    this.Super("initWidget", arguments);

    var ds = isc.DataSource.get("DataSourceStore");
    ds.performCustomOperation("dsFromTable", {schema:this.schema,dbName: this.dbName, tableName: this.config.name}, this.getID()+".dsLoaded(data)");
},


dsLoaded : function (data) {
    this.dataSource = data.ds;
    this.dataSourceXML = data.dsXML;

    this.addAutoChild("previewGrid", {
        dataSource: this.dataSource
    });
    this.addAutoChild("previewGridStrip", {
        grid: this.previewGrid
    });
    this.previewGrid.filterData();
},

showDS : function () {
    isc.say(this.dataSourceXML.asHTML(), null, {blurbProperties: {canSelectText: true, wrap: false}});
}

});
