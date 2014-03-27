
isc.ListGrid.create({
    ID: "companyList",
    width:600, height:520,
    alternateRecordStyles:true,
    autoFetchData:true,
    dataSource:orderItemLocalDS,
    showAllRecords:true,
    groupByField:"category", groupStartOpen:"all",
    canEdit:true, editEvent:"click",
    
    showGridSummary:true,
    showGroupSummary:true,
    showGroupSummaryInHeader:true,
    fields:[
        {name:"orderID", includeInRecordSummary:false, summaryFunction:"count"},
        {name:"itemDescription"},
        {name:"category",  showGridSummary:true, 
            getGridSummary:function (records, summaryField) {
                var seenCategories = {};
                for (var i = 0; i < records.length; i++) {
                    seenCategories[records[i].category] = true;
                }
                var totalCategories = isc.getKeys(seenCategories).length;
                return totalCategories + " Categories";
                
            },
            summaryFunction:function (records, summaryField) {
                var seenCategories = {};
                for (var i = 0; i < records.length; i++) {
                    seenCategories[records[i].category] = true;
                }
                var totalCategories = isc.getKeys(seenCategories).length;
                return totalCategories + " Categories"; 
            }
        },
        {name:"shipDate", showGroupSummary:true, showGridSummary:false, summaryFunction:"max"},
        
        {name:"quantity", showGroupSummary:false, showGridSummary:false},
        {name:"unitPrice", showGroupSummary:false, showGridSummary:false,
            formatCellValue : function (value, record, rowNum, colNum, grid) {
                if (record == null || record._isGroup) {
            	    return "&nbsp;";
                } else {
                    return '$'+isc.Format.toUSString(value, 2);
                }
            }
        },
        {name:"Total", type:"summary", recordSummaryFunction:"multiplier",
         summaryFunction:"sum",
         showGridSummary:true, showGroupSummary:true,
         align:"right",
         formatCellValue: "'$'+isc.Format.toUSString(value, 2)",
        }
    ]
})
