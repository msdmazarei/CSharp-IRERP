isc.TreeGrid.create({
    ID: "employeeTree",
    width: 500,
    height: 400,
    dataSource: "employees",
    autoFetchData: true,
    nodeIcon:"icons/16/person.png",
    folderIcon:"icons/16/person.png",
    showOpenIcons:false,
    showDropIcons:false,
    closedIconSuffix:"",
    fields: [
        {name: "Name"},
        {name: "Job"},
        {name: "Salary", formatCellValue: "isc.Format.toUSDollarString(value*1000)"}
    ]
});


