irerp.defineClass("irerpListGrid", "ListGrid");
irerp.irerpListGrid.addProperties({
    showIRERP_Btns: true,
    showIRERP_SummaryMsg: false,
    //IRERP_SummaryMsg_DataSource: this.dataSource,
    IRERP_SummaryMsg_Url:null,
    irerpListGridSummaryMsg:null,// isc.Label.create({ contents: "داده ای برای نمایش نیست." ,height:"auto",align :"center",layoutAlign :"center"}),
    IRERP_SummaryMsg_LastCriteria:null,
    IRERP_SummaryMsg_RequestParams: { _irerpFetchType: "IRERP_SummaryMsg", _irerpMessageName: "General" },
    IRERP_SummaryMsg_Loading: function (Grid) {
        Grid.irerpListGridSummaryMsg.setContents('در حال بارگذاری...');
    },

    IRERP_SummaryMsg_CallBack: function (/*PlainObject*/ data, /*String*/ textStatus, /*jqXHR*/ jqXHR,additionalParams) {
        if (textStatus == "success") {
            data = JSON.parse(data);
            eval(additionalParams.Grid).irerpListGridSummaryMsg.setContents(
                data.data);
        }

    },

    __IRERPFILE_formatCellValue: function (value, record, rowNum, colNum, grid) {
        if (value == null)
            return 'پرونده ندارد';
        else if (value.trim() != '')
            return 'پرونده دارد';
        else return 'مقدار نامشخص';
            
    },
    _msdIRERPFieldTypeIsSetupped:false,
    _msdIRERPFieldTypesFormatters: function () {
        if (this.fields == null) return;
        if (this._msdIRERPFieldTypeIsSetupped == true)
            return;
        this._msdIRERPFieldTypeIsSetupped = true;
        var field, i;
        for (i = 0; i < this.fields.length; i++) {
            field = this.fields[i];
            if(irerp.SimpleType.inheritsFrom(field.type, "irerpFile")){
                field.formatCellValue = this.__IRERPFILE_formatCellValue;
            }
             
        }
    },
 
    initWidget: function () {
        var lstgrd = this;
        this.useAdvancedFieldPicker = true;
        this.fieldPickerWindowProperties = { isModal: false };
        this.canResizeFields= true;
        this.showRecordComponents = true;
        this.showRecordComponentsByCell = true;
        this.filterLocalData = false;
        //--------------------------------------------------------

        //-------------------------------------------------------
        this.Super("initWidget", arguments);
        this._msdIRERPFieldTypesFormatters();
        /////====================================================
        //// Try To Retrive SummaryMessage Url From Grid DataSource
        if (this.showIRERP_SummaryMsg)
            if(this.IRERP_SummaryMsg_Url==null)
                if (this.dataSource != null) {
                    var gridDataSource = this.dataSource;
                    if (this.dataSource.Class == 'String')
                        if (window[this.dataSource] != null)
                            gridDataSource = window[this.dataSource];
                    if (gridDataSource.Class == 'RestDataSource') 
                        this.IRERP_SummaryMsg_Url = gridDataSource.dataURL.replace("/DataSource/", "/SummaryMessage/");

                }
        /////====================================================
        this.irerpListGridBtns = isc.ToolStrip.create({
            //styleName:"headerTitle",
            width: "100%", height: 24,
            members: [
                isc.Label.create({
                    padding: 5,
                    Content: "تست"
                }),
                isc.LayoutSpacer.create({ width: "*" }),
                isc.ToolStripButton.create({
                    icon: "[SKIN]/ListGrid/formula_menuItem.png",
                    prompt: isc.i18nMessages.dataBoundComponent_addFormulaFieldText,
                    click: function () {
                        lstgrd.addFormulaField();
                    }
                }),
                isc.ToolStripButton.create({
                    icon: "[SKIN]/actions/search.png",
                    prompt: isc.i18nMessages.irerp_search,
                    click: function () { FilterBuilderFor(lstgrd); }
                }),
                isc.ToolStripButton.create(
                    {
                        icon: "[SKIN]/actions/column_preferences.png",
                        prompt: isc.i18nMessages.irerp_hilite,
                        click: function () { lstgrd.editHilites();}
                    }
                    ),
                isc.ToolStripButton.create(
                    {
                        icon: "[SKIN]/actions/sort_ascending.png",
                        prompt: isc.i18nMessages.listGrid_configureSortText,
                        click: function () {
                            isc.MultiSortDialog.askForSort(
                                lstgrd,
                                lstgrd.getSort(),
                                function (sortLevels) {
                                    if (sortLevels) lstgrd.setSort(sortLevels);
                                }
                            );
                        }
                    }
                    ),
                isc.ToolStripButton.create(
                    {
                        icon: "[SKIN]/actions/configure.png",
                        prompt: isc.i18nMessages.irerp_fieldpicker,
                        click: function () { lstgrd.editFields();}
                    }
                    )

            ]
        });
        this.gridComponents = [
            "header",//	The header-component displayed when ListGrid.showHeader is true.
            "filterEditor",//	The standard filter-component displayed when ListGrid.showFilterEditor is true
            "body",//	The body component for the grid.
            "summaryRow"//	The summary-row component displayed when ListGrid.showGridSummary is true.
        ];
        if (this.showIRERP_Btns)
            this.gridComponents.splice(0, 0, this.irerpListGridBtns);
        if (this.showIRERP_SummaryMsg)
            this.gridComponents.splice(this.gridComponents.length-1,0,this.irerpListGridSummaryMsg);

    }
    ,
    editHilites: function () {
        var fields = this.getAllFields();
        if (!fields) return;

        // if any fields are specifically marked as canHilite: false, remove them from the list -
        // we use this for special listGrid fields, like rowNumber and expansion fields
        var invalidFields = fields ? fields.findAll("canHilite", false) : null;

        if (invalidFields && invalidFields.length > 0) {
            fields.removeList(invalidFields);
        }

        // needs to be dynamically re-created to account for formula fields
        var ds = irerp.DataSource.create({
            fields: fields
        });

        if (this.hiliteWindow) {
            this.hiliteEditor.setDataSource(ds);
            this.hiliteEditor.clearHilites();
            this.hiliteEditor.setHilites(this.getHilites());
            this.hiliteWindow.show();
            return;
        }
        var grid = this,
            hiliteEditor = this.hiliteEditor = irerp.irerpHiliteEditor.create({
                autoDraw: false,
                dataSource: ds,
                hilites: this.getHilites(),
                callback: function (hilites) {
                    if (hilites != null) grid.setHilites(hilites);
                    grid.hiliteWindow.hide();
                }
            }),
            theWindow = this.hiliteWindow = irerp.Window.create({
                autoDraw: true,
                items: [hiliteEditor],
                autoSize: true,
                autoCenter: true, isModal: true, showModalMask: true,
                closeClick: function () {
                    this.hide();
                },
                title: "ویرایش برجسته سازها",
                bodyProperties: { layoutMargin: 8, membersMargin: 8 }
            });
        return theWindow;

    }
    ,
    fetchData: function()
    {
        var rtn = this.Super('fetchData', arguments);
        if (this.showIRERP_SummaryMsg == true) {
            try{
                var filtercrit = this.getCriteria();
                if (this.IRERP_SummaryMsg_LastCriteria != filtercrit) {
                    this.Load_IRERP_SummaryMsg(filtercrit);
                    this.IRERP_SummaryMsg_LastCriteria = filtercrit;
                }
            } catch (err) {
                console.log(err);
            }
        }
        return rtn;
        
    }
    ,
    Load_IRERP_SummaryMsg: function () {
        
        var crit = this.getCriteria();
        if (Object.keys(crit).length > 0)
            crit = JSON.stringify(crit);
        var dataToSendToServer = this.IRERP_SummaryMsg_RequestParams;
        dataToSendToServer["_componentId"] = this.ID;
        if (crit != null)
            dataToSendToServer["criteria"] = crit;
        this.IRERP_SummaryMsg_Loading(this);
        callServerMethod(this.IRERP_SummaryMsg_Url, dataToSendToServer, this.IRERP_SummaryMsg_CallBack, 'GET', {Grid:this.ID});
    }
    ,
    draw: function () {
        this.Super('draw', arguments);
    }
    ,
    setData: function () {
        var rtn = this.Super('setData', arguments);
        if (this.showIRERP_SummaryMsg == true) {
            try{
                var filtercrit = this.getCriteria();
                if (this.IRERP_SummaryMsg_LastCriteria != filtercrit) {
                    this.Load_IRERP_SummaryMsg(filtercrit);
                    this.IRERP_SummaryMsg_LastCriteria = filtercrit;
                }
            } catch (err) {
                console.log(err);
            }
        }
        return rtn;
        
    },
    dataChanged: function () {
        return this.Super('dataChanged', arguments);
    },
    msdReload: function () {
        // Clear All Old Fetched Data
        this.data = null;
        this.fetchData();
    },
    //@Override
    getFilterEditorType: function (field) {
        var rtn = this.Super('getFilterEditorType', arguments);
        if (isc.SimpleType.inheritsFrom(field.type, "irerpFile") && this.getDataSource())
        {
            rtn = "irerpNullOrNotFilterEditorItem";
        }
        return rtn;
    },
    //@Override
    getDisplayValue: function (fieldID, valueFieldValue) {
        var rtn = this.Super('getDisplayValue', arguments);
        return rtn;

    },
    //@Override
    draw: function () {
        var rtn = this.Super('draw', arguments);
        this._msdIRERPFieldTypesFormatters();
        return rtn;
    },
    //@Override
    createRecordComponent: function (record, colNum) {
        var grid = this;
        var field = grid.getField(colNum);
        //Check Field Type
        if (irerp.SimpleType.inheritsFrom(field.type, "irerpGAddress")) {
            var recordCanvas = isc.HLayout.create({
                height: 22,
                align: "center"
            });

            var editImg = isc.ImgButton.create({
                showDown: false,
                showRollOver: false,
                layoutAlign: "center",
                src: "[SKIN]/Google_Maps.png",
                prompt: "Edit Comments",
                height: 16,
                width: 16,
                grid: this,
                click: function () {
                    isc.say("Edit Comment Icon Clicked for country : " + record["countryName"]);
                }
            });

            var chartImg = isc.ImgButton.create({
                showDown: false,
                showRollOver: false,
                layoutAlign: "center",
                src: "[SKIN]/Google_Maps.png",
                prompt: "View Chart",
                height: 16,
                width: 16,
                grid: this,
                click: function () {
                    isc.say("Chart Icon Clicked for country : " + record["countryName"]);
                }
            });

            recordCanvas.addMember(editImg);
            recordCanvas.addMember(chartImg);
            return recordCanvas;
        }

    }
    
});

