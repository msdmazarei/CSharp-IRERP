using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using System.Linq.Expressions;
using MsdLib.ExtentionFuncs.Strings;
using System.Web.Mvc;
using IRERP_RestAPI.Bases.Extension.HTML;
namespace IRERP_RestAPI.Bases.Skins
{
    public class AbbasiAdmin
    {
        public static string MasterDetailScript<TMetaModel, TMaster>(
    IRERP_SM_SelectItem masterSelectItem,
    IRERP_SM_ListGrid detailgrid,
    IRERP_SM_DynamicForm detailform,
    Expression<Func<TMetaModel, object>> ServerSessionKey,
    Expression<Func<TMaster, object>> MasterPrimaryKeyField
    )
        {

            string rtn = @"AddProxyFunction(" + masterSelectItem.ID + ",'changed'," + @"function(form,item,rec) 
            {
 gridmaster = " + masterSelectItem.ID + ";griddetail=" + detailgrid.ID + ";" + "criteria=" +
                            "{_" +
                            IRERPApplicationUtilities.GPN<TMetaModel>(ServerSessionKey).ToClientDsFieldName() + ":item.getSelectedRecord()." + IRERPApplicationUtilities.GPN<TMaster>(MasterPrimaryKeyField) + "};" +
                            "frmdetail=" + detailform.ID + ";" +
                            @"
console.log('GridMaster:'+gridmaster.ID);
                 GeneralMasterDetail(gridmaster,griddetail,criteria);
                
                 frmdetail.irerpRequestParams= criteria;
                 griddetail.irerpRequestParams= criteria;
                                 });";
            return rtn;
        }

        public static string MasterDetailScript<TMetaModel, TMaster>(
            IRERP_SM_ListGrid mastergrid, 
            IRERP_SM_ListGrid detailgrid,
            IRERP_SM_DynamicForm detailform,
            Expression<Func<TMetaModel, object>> ServerSessionKey,
            Expression<Func<TMaster, object>> MasterPrimaryKeyField
            )
        {

            
            string rtn= @"

AddProxyFunction(" + mastergrid.ID + ",'selectionChanged',"+@"function(record,state) 
            {
 gridmaster = " + mastergrid.ID + ";griddetail=" + detailgrid.ID + ";" + "criteria=" +
                            "{_" +
                            IRERPApplicationUtilities.GPN<TMetaModel>(ServerSessionKey).ToClientDsFieldName() + ":record." + IRERPApplicationUtilities.GPN<TMaster>(MasterPrimaryKeyField) + "};" +
                            "frmdetail=" + detailform.ID + ";" +
                            @"
console.log('GridMaster:'+gridmaster.ID);
                 GeneralMasterDetail(gridmaster,griddetail,criteria);
                
                 frmdetail.irerpRequestParams= criteria;
                 griddetail.irerpRequestParams= criteria;
                                 });";
            return rtn;
        }



        public static IRERP_SM_ToolStripButton GetGenetalToolStripButton(string Id = null, string Title = null, IRERPControlTypes_StringMethods Click = null, string Icon = null)
        {
            IRERP_SM_ToolStripButton rtn = new IRERP_SM_ToolStripButton();
            if (Id != null) rtn.ID = Id;
            if (Title != null) rtn.title = new IRERPControlTypes_HTMLString(Title);
            if (Icon != null) rtn.icon = Icon;
            rtn.height = "100%";
            rtn.actionType = IRERPControlTypes_SelectionType.button;
            // rtn.baseStyle = "btntext";
            rtn.click = Click;
            return rtn;

        }

        public static IRERP_SM_SelectItem GGSelectItem<TModel, ToptioDs>(string id = null, Expression<Func<TModel, object>> name = null,
                 string title = null, Expression<Func<ToptioDs, object>> DisplayField = null, Expression<Func<ToptioDs, object>> valueField = null,
                 IRERP_SM_ListGrid pickListProperties = null,

                 string optionDataSource = null, IRERPControlTypes_StringMethods change = null, bool allowExpressions = true, bool autoFetchData = true, params Expression<Func<ToptioDs, object>>[] pickListFields)
        {
            IRERP_SM_SelectItem rtn = new IRERP_SM_SelectItem();
            rtn.IsInInitializeTime = true;
            if (id != null) rtn.ID = id;
            if (name != null) rtn.name = IRERPApplicationUtilities.GPN(name, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (title != null) rtn.title = title;
            rtn.width = 200;
            rtn.pickListWidth = 400;
            if (change != null) rtn.changed = change;
            if (DisplayField != null) rtn.displayField = IRERPApplicationUtilities.GPN(DisplayField, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (valueField != null) rtn.valueField = IRERPApplicationUtilities.GPN(valueField, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (pickListProperties != null) rtn.pickListProperties = pickListProperties;
            else
                rtn.pickListProperties = new IRERP_SM_ListGrid()
                {
                    showFilterEditor = true,
                    filterOnKeypress = true,
                    fetchDelay = 1000,
                    allowFilterExpressions = true,

                    //    selectionType = IRERPControltypes_listgrid_selectionType .single
                };
            if (pickListFields != null)
            {
                List<IRERP_SM_ListGridFiled> fs = new List<IRERP_SM_ListGridFiled>();
                foreach (var f in pickListFields)
                {

                    fs.Add(new IRERP_SM_ListGridFiled() { name = IRERPApplicationUtilities.GPN(f, false).ToClientDsFieldName()/*.Replace(".","___")*/ });

                }
                rtn.pickListFields = fs.ToArray();
            }
            if (optionDataSource != null) rtn.optionDataSource = optionDataSource;
            rtn.autoFetchData = autoFetchData;
            rtn.allowExpressions = allowExpressions;

            return rtn;
        }


        public static IRERP_SM_SelectItem GGSelectItem<TModel, ToptioDs>(string id = null, Expression<Func<TModel, object>> name = null,
            string title = null, Expression<Func<ToptioDs, object>> DisplayField = null, Expression<Func<ToptioDs, object>> valueField = null,
            IRERP_SM_ListGrid pickListProperties = null,

            string optionDataSource = null, bool allowExpressions = true, bool autoFetchData = true, params Expression<Func<ToptioDs, object>>[] pickListFields)
        {
            IRERP_SM_SelectItem rtn = new IRERP_SM_SelectItem();
            rtn.IsInInitializeTime = true;
            if (id != null) rtn.ID = id;
            if (name != null) rtn.name = IRERPApplicationUtilities.GPN(name, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (title != null) rtn.title = title;
            rtn.width = 200;
            rtn.pickListWidth = 400;
            if (DisplayField != null) rtn.displayField = IRERPApplicationUtilities.GPN(DisplayField, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (valueField != null) rtn.valueField = IRERPApplicationUtilities.GPN(valueField, false).ToClientDsFieldName()/*.Replace(".", "___")*/;
            if (pickListProperties != null) rtn.pickListProperties = pickListProperties;
            else
                rtn.pickListProperties = new IRERP_SM_ListGrid()
                {
                    showFilterEditor = true,
                    filterOnKeypress = true,
                    fetchDelay = 1000,
                    allowFilterExpressions = true,

                    //    selectionType = IRERPControltypes_listgrid_selectionType .single
                };
            if (pickListFields != null)
            {
                List<IRERP_SM_ListGridFiled> fs = new List<IRERP_SM_ListGridFiled>();
                foreach (var f in pickListFields)
                {

                    fs.Add(new IRERP_SM_ListGridFiled() { name = IRERPApplicationUtilities.GPN(f, false).ToClientDsFieldName()/*.Replace(".","___")*/ });

                }
                rtn.pickListFields = fs.ToArray();
            }
            if (optionDataSource != null) rtn.optionDataSource = optionDataSource;
            rtn.autoFetchData = autoFetchData;
            rtn.allowExpressions = allowExpressions;

            return rtn;
        }

        public static IRERP_SM_Window GetGenetalwindow(string Id = null, string Title = null, string _height = null,
        string _width = null, IRERPControlBase[] item = null)
        {
            IRERP_SM_Window rtn = new IRERP_SM_Window();
            if (Id != null) rtn.ID = Id;
            if (Title != null) rtn.title = new IRERPControlTypes_HTMLString(Title);
            // if (Icon != null) rtn.icon = Icon;
            rtn.height = "100%";
            rtn.autoSize = true;
            rtn.autoCenter = true;
            rtn.isModal = true;
            rtn.showModalMask = true;
            rtn.autoDraw = false;
            rtn.showResizeBar = true;
            rtn.showMaximizeButton = true;
            rtn.canDragResize = true;
            //rtn.backgroundColor = "#ffffff";
            if (_height != null) rtn.height = _height;
            if (_width != null) rtn.width = _width;
            if (item != null) rtn.items = item;
            return rtn;

        }

        public static IRERP_SM_Button GetGenetalButton(string title = null, IRERPControlTypes_StringMethods click = null)
        {
            IRERP_SM_Button rtn = new IRERP_SM_Button();
            if (title != null) rtn.title = new IRERPControlTypes_HTMLString(title);
            if (click != null) rtn.click = click;
            return rtn;

        }

        public static IRERP_SM_DynamicForm GetGenetalDynamicForm(string Id = null, string _height = null,
        string _width = null, IRERP_SM_FormItem[] fields = null, int? _numcols = null, int? margin = null, IRERP_SM_FromString data = null)
        {
            IRERP_SM_DynamicForm rtn = new IRERP_SM_DynamicForm();
            if (Id != null) rtn.ID = Id;
            if (_height != null) rtn.height = _height;
            if (_width != null) rtn.width = _width;
            if (_numcols != null) rtn.numCols = _numcols;
            if (fields != null) rtn.fields = fields;
            if (margin != null) rtn.margin = margin;
            if (data != null) rtn.dataSource = data;

            return rtn;

        }
        public static IRERP_SM_DynamicForm GetGenetalDynamicForm_Extend(string Id = null, string _height = null,
       string _width = null, IRERP_SM_FormItem[] fields = null, int? _numcols = null, int? margin = null, IRERP_SM_DataSource datasource = null, bool usedatasourceid = true)
        {
            IRERP_SM_DynamicForm rtn = new IRERP_SM_DynamicForm();
            if (Id != null) rtn.ID = Id;
            if (_height != null) rtn.height = _height;
            if (_width != null) rtn.width = _width;
            if (_numcols != null) rtn.numCols = _numcols;
            if (fields != null) rtn.fields = fields;
            if (margin != null) rtn.margin = margin;


            if (datasource != null)
            {
                var _fields = new List<IRERP_SM_FormItem>();
                if (rtn.fields != null) _fields.AddRange(rtn.fields);
                var notexistfields = (from x in datasource.fields where !(from y in _fields select y.name).Contains(x.name) select x).ToList();
                foreach (var f in notexistfields)
                {
                    if ((bool)f.hidden) continue;
                    _fields.Add(f.ToFormItem());
                }
                rtn.fields = _fields.ToArray();
                if (usedatasourceid)
                    rtn.dataSource = new IRERP_SM_FromString(datasource.ID);
                else
                    rtn.dataSource = datasource;
            }

            return rtn;

        }

        public static IRERP_SM_MenuItem GetmenuItem(string _title = null, IRERPControlTypes_StringMethods _click = null, string _icon = null)
        {
            var menuitem1 = new IRERP_SM_MenuItem()
            {
                IsInInitializeTime = true,
                title = _title,
                click = _click,
                icon = _icon
            };

            return menuitem1;
        }

        public static IRERP_SM_Menu GetMenu(string _id = null, IRERP_SM_MenuItem[] data = null)
        {
            var menuItem = new IRERP_SM_Menu()
            {
                shadowDepth = 10,
                autoDraw = false,
                showShadow = true,
                ID = _id
            };
            menuItem.data = data;

            return menuItem;
        }



        public static IRERP_SM_ListGrid GetGeneralListGrid(string _width = "100%", string _height = "100%", string _backgroundcolor = null,
           bool _alternateRecordStyles = true, IRERPControlBase Datasource = null, string _baseStyle = null,
           string _bodyBackgroundColor = null, bool _autoFetchData = true, string ID = null, bool? _allowFilterExpressions = true, bool? _filterOnKeypress = true,
            bool? _showFilterEditor = true,
            int _fetchDelay = 1000,
            bool? _canAddFormulaFields = true,
            bool? _canAddSummaryFields = true,
            bool? _useAllDataSourceFields = true,
            bool? _CanEdit = false,

           IRERPControlTypes_StringMethods _cellContextClick = null,
           IRERPControlTypes_StringMethods _rowDoubleClick = null,

            IRERPControlTypes_editEvent? _EditEvent = null,
            IREREPControlTypes_listEndEditAction? _listEndEditAction = null,
            bool? wrapCells = true,
            bool? fixedRecordHeights = null,
            bool? _showHover = true 

           )
        {
            var rtn =
                new IRERP_SM_ListGrid()
                {
                    width = _width,
                    height = _height,
                    backgroundColor = _backgroundcolor,
                    alternateRecordStyles = _alternateRecordStyles,
                    dataSource = Datasource,
                    baseStyle = _baseStyle,
                    bodyBackgroundColor = _bodyBackgroundColor,
                    autoFetchData = _autoFetchData,
                    rowDoubleClick=_rowDoubleClick,
                    showHover= _showHover, 


                };
            if (wrapCells != null) rtn.wrapCells = wrapCells;
            if (fixedRecordHeights != null) rtn.fixedRecordHeights = fixedRecordHeights;
            if (_allowFilterExpressions != null) rtn.allowFilterExpressions = _allowFilterExpressions;
            if (_filterOnKeypress != null) rtn.filterOnKeypress = _filterOnKeypress;
            if (_showFilterEditor != null) rtn.showFilterEditor = _showFilterEditor;
            if (_canAddFormulaFields != null) rtn.canAddFormulaFields = _canAddFormulaFields;
            if (_canAddSummaryFields != null) rtn.canAddSummaryFields = _canAddSummaryFields;
            if (_CanEdit != null) rtn.canEdit = _CanEdit;
            if (_EditEvent != null) rtn.editEvent = _EditEvent;
            if (_listEndEditAction != null) rtn.listEndEditAction = _listEndEditAction;
            if (_cellContextClick != null) rtn.cellContextClick = _cellContextClick;
            if (_rowDoubleClick != null) rtn.rowDoubleClick = _rowDoubleClick;

            //if (_fetchDelay != null) 
                rtn.fetchDelay = _fetchDelay;

            if (ID != null) rtn.ID = ID;
            rtn.rowEditorExit = new IRERPControlTypes_StringMethods(@" ""IRERPLG_rowEditorExit(editCompletionEvent, record, newValues, rowNum,this)"" ", true);
            return rtn;
        }

        public static IRERPPageString GetGeneralDVS(
          ViewContext viewContext,
          IRERP_SM_ListGrid Grid,
          IRERPControlBase[] forms = null,
          IRERP_SM_ToolStripButton[] AdditionalActions = null,
          IRERP_SM_MenuItem[] Actions = null,
            string formName = null,

          bool hasEdit = true,
          bool hasInsert = true,
          bool hasDelete = true,
          bool hasRefresh = true,
          bool hasHilit = true,
          bool hasFormula = true,
          bool hasMenu = true
          )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);
            string formid = forms[0].ToString(), gridid = Grid.ID, winid = "win" + formid, delwinid = "delwin" + formid;

            var toolStripInsert = AbbasiAdmin.GetGenetalToolStripButton(formid + "Add", "درج اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralAdd(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510525_insert-object.png");

            var toolStripEdit =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Edit", "ویرایش اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralEdit(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510469_old-edit-find-replace.png");

            var toolStripDelete =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Delete", "حذف اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralDeleteAlert(" + delwinid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510425_edit-delete.png");

            var toolStripEditHiliting =
             AbbasiAdmin.GetGenetalToolStripButton(formid + "EditHilits", "برجسته سازی", new IRERPControlTypes_StringMethods(@" ""EditHiliting(" + gridid + @")"" ", true), "/Images/1377606892_preferences-desktop-color.png");

            var toolStripFormulaBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FormulaBuilder", "افزودن فیلد", new IRERPControlTypes_StringMethods(@" ""FormulaBuilders(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");


            var menuOperationmenu = new IRERP_SM_Menu()
            {
                shadowDepth = 10,
                autoDraw = false,
                showShadow = true
            };
            var menuButton = new IRERP_SM_MenuButton() { title = new IRERPControlTypes_HTMLString("عملیات") };
            if (Actions != null)
            {
                menuOperationmenu.data = Actions;
                menuButton = new IRERP_SM_MenuButton()
                {
                    title = new IRERPControlTypes_HTMLString("عملیات"),
                    menu = menuOperationmenu
                };
            }



            var toolStripRefresh = AbbasiAdmin.GetGenetalToolStripButton(formid + "Refresh", "بارگذاری مجدد", new IRERPControlTypes_StringMethods(@" ""DVS_refresh('"+gridid+@"')"" ", true), "/Images/1377512645_button_blue_repeat.png");
            List<IRERPControlBase> toolstripbtns = new List<IRERPControlBase>();
            if (hasInsert) toolstripbtns.Add(toolStripInsert);
            if (hasEdit) toolstripbtns.Add(toolStripEdit);
            if (hasDelete) toolstripbtns.Add(toolStripDelete);
            if (hasRefresh) toolstripbtns.Add(toolStripRefresh);
            if (hasHilit) toolstripbtns.Add(toolStripEditHiliting);
            if (hasFormula) toolstripbtns.Add(toolStripFormulaBuilder);
            if (hasMenu) toolstripbtns.Add(menuButton);

            var ToolStrip = new IRERP_SM_ToolStrip()
            {
                width = "100%",
                //members = new IRERPControlBase[] { toolStripInsert, toolStripEdit, toolStripDelete, toolStripRefresh, toolStripEditHiliting, toolStripFormulaBuilder, menuButton }
                members = toolstripbtns.ToArray()
            };
            if (AdditionalActions != null)
            {
                List<IRERPControlBase> members = new List<IRERPControlBase>();
                if (ToolStrip.members != null)
                    members.AddRange(ToolStrip.members);
                members.AddRange(AdditionalActions);
                ToolStrip.members = members.ToArray();
            }
            var g = new List<IRERPControlBase>();
            g.AddRange(forms);
            g.Add
                (new IRERP_SM_HLayout()
                {
                    width = "100%",
                    height = "100%",
                    members = new IRERPControlBase[]{ 
                     new IRERP_SM_Label(){width="5%"},
                     AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave(" + winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="0%"},
                     AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="5%"}
                       }
                });


            var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, formName, "30%", "30%", g.ToArray());


            var DeleteWindow =
                AbbasiAdmin.GetGenetalwindow(delwinid, null, "10%", "20%", new IRERPControlBase[] { 
                        AbbasiAdmin.GetGenetalDynamicForm(null, "10%", "20%",
                            new IRERP_SM_FormItem[]{
                                new IRERP_SM_HeaderItem(){defaultValue="آیا برای حذف مورد  انتخاب شده اطمینان دارد؟" }
                                },2,10,null),
                        new IRERP_SM_HLayout(){ width="100%",height="100%", members=new IRERPControlBase[]{ 
                                new IRERP_SM_Label(){width="5%"},
                                AbbasiAdmin.GetGenetalButton("بله",new IRERPControlTypes_StringMethods(@" ""GeneralDelete("+delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="0%"},
                                AbbasiAdmin.GetGenetalButton("خیر",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="5%"}
                       }
                   }
                });

            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { ToolStrip, Grid } };
            IRERPPageString page = new IRERPPageString();
            page.OtherObjects += DeleteWindow.ToString();
            page.OtherObjects += FormWindow.ToString();

            page.DisplayControls += body.ToString();
            page.Commands += winid + ".hide();" + delwinid + ".hide();";
            return page;
        }

     //   public static IRERPPageString GetGeneralDVSFormBase(
     //ViewContext viewContext,
     //IRERPControlBase[] forms = null,
     //string formName = null

     //)
     //   {
     //       Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);
     //       string formid = forms[0].ToString(), winid = "win" + formid;



     //       var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, formName, "30%", "30%", new IRERPControlBase[]{ 
     //       forms[0],
     //          new IRERP_SM_HLayout()
     //            {
     //                 width="100%",
     //                height="100%",
     //                members=new IRERPControlBase[]{ 
     //                new IRERP_SM_Label(){width="5%"},
     //                AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave1(" + winid+ "," + formid+ @")"" ", true)),
     //                new IRERP_SM_Label(){width="0%"},
     //                AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn1(" +winid+ "," + formid+ @")"" ", true)),
     //                new IRERP_SM_Label(){width="5%"}
     //                  }
     //             }
     //       });




     //       var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { forms[0] } };
     //       IRERPPageString page = new IRERPPageString();
     //       page.OtherObjects += FormWindow.ToString();

     //       page.DisplayControls += body.ToString();
     //       page.Commands += winid + ".hide();";
     //       return page;
     //   }




        public static IRERPPageString GetGeneralDVS(
            ViewContext viewContext,
            IRERP_SM_DynamicForm form,
            IRERP_SM_ListGrid Grid,
            IRERP_SM_ToolStripButton[] AdditionalActions = null,
            
            IRERP_SM_MenuItem[] Actions = null,
             string formName = null
            ,
            bool hasEdit = true,
            bool hasInsert = true,
            bool hasDelete = true,
            bool hasRefresh = true,
            bool hasHilit = true,
            bool hasFormula = true,
            bool hasMenu = true,
            bool hasFilterBuilder = true

            )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);
           
            string formid = form.ID, gridid = Grid.ID, winid = "win" + formid, delwinid = "delwin" + formid;

            var toolStripInsert = AbbasiAdmin.GetGenetalToolStripButton(formid + "Add", "درج اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralAdd(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510525_insert-object.png");

            var toolStripEdit =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Edit", "ویرایش اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralEdit(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510469_old-edit-find-replace.png");

            var toolStripDelete =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Delete", "حذف اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralDeleteAlert(" + delwinid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510425_edit-delete.png");

            var toolStripEditHiliting =
             AbbasiAdmin.GetGenetalToolStripButton(formid + "EditHilits", "برجسته سازی", new IRERPControlTypes_StringMethods(@" ""EditHiliting(" + gridid + @")"" ", true), "/Images/1377606892_preferences-desktop-color.png");

            var toolStripFormulaBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FormulaBuilder", "افزودن فیلد", new IRERPControlTypes_StringMethods(@" ""FormulaBuilders(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");

            var toolStripFiltreBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FilterBuilder", "ساخت فیلتر", new IRERPControlTypes_StringMethods(@" ""FilterBuilderFor(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");

            var menuOperationmenu = new IRERP_SM_Menu()
            {
                shadowDepth = 10,
                autoDraw = false,
                showShadow = true
            };
            var menuButton = new IRERP_SM_MenuButton() { title = new IRERPControlTypes_HTMLString("عملیات") };
            if (Actions != null)
            {
                menuOperationmenu.data = Actions;
                menuButton = new IRERP_SM_MenuButton()
                {
                    title = new IRERPControlTypes_HTMLString("عملیات"),
                    menu = menuOperationmenu
                };
            }



            var toolStripRefresh = AbbasiAdmin.GetGenetalToolStripButton(formid + "Refresh", "بارگذاری مجدد", new IRERPControlTypes_StringMethods(@" ""DVS_refresh('" + gridid + @"')"" ", true), "/Images/1377512645_button_blue_repeat.png");
            List<IRERPControlBase> toolstripbtns = new List<IRERPControlBase>();
            if (hasInsert) toolstripbtns.Add(toolStripInsert);
            if (hasEdit) toolstripbtns.Add(toolStripEdit);
            if (hasDelete) toolstripbtns.Add(toolStripDelete);
            if (hasRefresh) toolstripbtns.Add(toolStripRefresh);
            if (hasHilit) toolstripbtns.Add(toolStripEditHiliting);
            if (hasFormula) toolstripbtns.Add(toolStripFormulaBuilder);
            if (hasMenu) toolstripbtns.Add(menuButton);
            if (hasFilterBuilder) toolstripbtns.Add(toolStripFiltreBuilder);

            var ToolStrip = new IRERP_SM_ToolStrip()
            {
                width = "100%",
                //members = new IRERPControlBase[] { toolStripInsert, toolStripEdit, toolStripDelete, toolStripRefresh, toolStripEditHiliting, toolStripFormulaBuilder, menuButton }
                members = toolstripbtns.ToArray()
            };
            if (AdditionalActions != null)
            {
                List<IRERPControlBase> members = new List<IRERPControlBase>();
                if (ToolStrip.members != null)
                    members.AddRange(ToolStrip.members);
                members.AddRange(AdditionalActions);
                ToolStrip.members = members.ToArray();
            }
            var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, formName, "30%", "30%", new IRERPControlBase[]{ 
            form,
               new IRERP_SM_HLayout()
                 {
                      width="100%",
                     height="100%",
                     members=new IRERPControlBase[]{ 
                     new IRERP_SM_Label(){width="5%"},
                     AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave(" + winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="0%"},
                     AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="5%"}
                       }
                  } });


            var DeleteWindow =
                AbbasiAdmin.GetGenetalwindow(delwinid, null, "10%", "20%", new IRERPControlBase[] { 
                        AbbasiAdmin.GetGenetalDynamicForm(null, "10%", "20%",
                            new IRERP_SM_FormItem[]{
                                new IRERP_SM_HeaderItem(){defaultValue="آیا برای حذف مورد  انتخاب شده اطمینان دارد؟" }
                                },2,10,null),
                        new IRERP_SM_HLayout(){ width="100%",height="100%", members=new IRERPControlBase[]{ 
                                new IRERP_SM_Label(){width="5%"},
                                AbbasiAdmin.GetGenetalButton("بله",new IRERPControlTypes_StringMethods(@" ""GeneralDelete("+delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="0%"},
                                AbbasiAdmin.GetGenetalButton("خیر",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="5%"}
                       }
                   }
                });

            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { ToolStrip, Grid } };
            IRERPPageString page = new IRERPPageString();
            page.OtherObjects += DeleteWindow.ToString();
            page.OtherObjects += FormWindow.ToString();

            page.DisplayControls += body.ToString();
            page.Commands += winid + ".hide();" + delwinid + ".hide();";
            return page;
        }


        public static IRERPPageString GetGeneralDVSFormBase(
            ViewContext viewContext,
            IRERP_SM_DynamicForm form,
            string formName=null

            )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);
            string formid = form.ID, winid = "win" + formid;



            var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, formName, "30%", "30%", new IRERPControlBase[]{ 
            form,
               new IRERP_SM_HLayout()
                 {
                      width="100%",
                     height="100%",
                     members=new IRERPControlBase[]{ 
                     new IRERP_SM_Label(){width="5%"},
                     AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave1(" + winid+ "," + formid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="0%"},
                     AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn1(" +winid+ "," + formid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="5%"}
                       }
                  } });




            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { form } };
            IRERPPageString page = new IRERPPageString();
            page.OtherObjects += FormWindow.ToString();

            page.DisplayControls += body.ToString();
            page.Commands += winid + ".hide();";
            return page;
        }

      

        public static IRERPPageString GetGeneralDVS(
            ViewContext viewContext,
            IRERP_SM_DynamicForm form,
            IRERP_SM_ListGrid Grid,
            params IRERP_SM_ToolStripButton[] AdditionalActions
            )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);
            string formid = form.ID, gridid = Grid.ID, winid = "win" + formid, delwinid = "delwin" + formid;

            var toolStripInsert = AbbasiAdmin.GetGenetalToolStripButton(formid + "Add", "درج اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralAdd(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510525_insert-object.png");

            var toolStripEdit =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Edit", "ویرایش اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralEdit(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510469_old-edit-find-replace.png");

            var toolStripDelete =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Delete", "حذف اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralDeleteAlert(" + delwinid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510425_edit-delete.png");

            var toolStripEditHiliting =
             AbbasiAdmin.GetGenetalToolStripButton(formid + "EditHilits", "برجسته سازی", new IRERPControlTypes_StringMethods(@" ""EditHiliting(" + gridid + @")"" ", true), "/Images/1377606892_preferences-desktop-color.png");

            var toolStripFormulaBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FormulaBuilder", "افزودن فیلد", new IRERPControlTypes_StringMethods(@" ""FormulaBuilders(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");


            var menuOperationmenu = new IRERP_SM_Menu()
            {
                shadowDepth = 10,
                autoDraw = false,
                showShadow = true
            };
            menuOperationmenu.data = new IRERP_SM_MenuItem[] 
        {
         new IRERP_SM_MenuItem(){IsInInitializeTime=true,title="گزارش",click=new IRERPControlTypes_StringMethods(@" """" ", true)},
         new IRERP_SM_MenuItem(){IsInInitializeTime=true,title="استخراج",click=new IRERPControlTypes_StringMethods(@" """" ", true)},
       
        };
            var menuButton = new IRERP_SM_MenuButton()
            {
                title = new IRERPControlTypes_HTMLString("عملیات"),
                menu = menuOperationmenu



            };
            var toolStripRefresh = AbbasiAdmin.GetGenetalToolStripButton(formid + "Refresh", "بارگذاری مجدد", new IRERPControlTypes_StringMethods(@" ""DVS_refresh('" + gridid + @"')"" ", true), "/Images/1377512645_button_blue_repeat.png");
            var ToolStrip = new IRERP_SM_ToolStrip()
            {
                width = "100%",

                members = new IRERPControlBase[] { toolStripInsert, toolStripEdit, toolStripDelete, toolStripRefresh, toolStripEditHiliting, toolStripFormulaBuilder, menuButton }

            };
            if (AdditionalActions != null)
            {
                List<IRERPControlBase> members = new List<IRERPControlBase>();
                if (ToolStrip.members != null)
                    members.AddRange(ToolStrip.members);
                members.AddRange(AdditionalActions);
                ToolStrip.members = members.ToArray();
            }

            var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, "form", "30%", "30%", new IRERPControlBase[]{ 
            form,
               new IRERP_SM_HLayout()
                 {
                      width="100%",
                     height="100%",
                     members=new IRERPControlBase[]{ 
                     new IRERP_SM_Label(){width="5%"},
                     AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave(" + winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="0%"},
                     AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="5%"}
                       }
                  } });


            var DeleteWindow =
                AbbasiAdmin.GetGenetalwindow(delwinid, null, "10%", "20%", new IRERPControlBase[] { 
                        AbbasiAdmin.GetGenetalDynamicForm(null, "10%", "20%",
                            new IRERP_SM_FormItem[]{
                                new IRERP_SM_HeaderItem(){defaultValue="آیا برای حذف مورد  انتخاب شده اطمینان دارد؟" }
                                },2,10,null),
                        new IRERP_SM_HLayout(){ width="100%",height="100%", members=new IRERPControlBase[]{ 
                                new IRERP_SM_Label(){width="5%"},
                                AbbasiAdmin.GetGenetalButton("بله",new IRERPControlTypes_StringMethods(@" ""GeneralDelete("+delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="0%"},
                                AbbasiAdmin.GetGenetalButton("خیر",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="5%"}
                       }
                   }
                });

            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { ToolStrip, Grid } };
            IRERPPageString page = new IRERPPageString();
            page.OtherObjects += DeleteWindow.ToString();
            page.OtherObjects += FormWindow.ToString();

            page.DisplayControls += body.ToString();
            page.Commands += winid + ".hide();" + delwinid + ".hide();";
            return page;

        }



        public static IRERPPageString GetGeneralDVSControlBase(
         ViewContext viewContext,
         IRERPControlBase layout
         )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);

            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { layout } };
            IRERPPageString page = new IRERPPageString();
            page.DisplayControls += body.ToString();
            
            return page;
        }

        public static IRERPPageString GetGeneralMasterDetail(IRERPPageString Master, params IRERPPageString[] Details)
        {
            IRERPPageString rtn = new IRERPPageString();
            rtn.OtherObjects += Master.OtherObjects;
            foreach (var x in Details)
                rtn.OtherObjects += x.OtherObjects;

            rtn.Commands += Master.Commands;
            foreach (var x in Details)
                rtn.Commands += x.Commands;

            //Create StackSection And Detail Tabs
            List<IRERP_SM_Tab> tabs = new List<IRERP_SM_Tab>();
            foreach (var tab in Details)
                tabs.Add(new IRERP_SM_Tab() { title = tab.PageTitle, pane = new IRERP_SM_FromString(tab.DisplayControls, false) });

            var tabset = new IRERP_SM_TabSet()
            {
                ID = "_" + Master.id + "_Tabs",
                tabBarPosition = IRERPControlTypes_Side.top,
                tabBarAlign = IRERPControlTypes_Side.right,
                canEditTabTitles = true,
                titleEditEvent = IRERPControlTypes_TabTitleEditEvent.doubleClick,
                titleEditorTopOffset = 2,
                tabs = tabs.ToArray()
            };

            var secction = new IRERP_SM_SectionStack()
            {
                ID = "_" + Master.id + "_sectionStack",
                visibilityMode = IRERPControlTypes_visibilityMode.multiple,
                sections = new IRERP_SM_SectionStackSection[]{
                new IRERP_SM_SectionStackSection{
                            title=Master.PageTitle,
                            expanded=true,
                            resizeable=true,
                            items = new IRERP_SM_FromString(Master.DisplayControls,false)},
                new IRERP_SM_SectionStackSection
                             {
                                 title= "جزییات",
                                 expanded= true,
                                 resizeable= true,
                                 items=tabset
                            }
                }
            };
            rtn.DisplayControls = secction.ToString();
            return rtn;
        }

        //public static IRERP_SM_VLayout GetGroup<TModel, ToptioDs>(string DSId = null,string ListGridID=null,string WindowID=null,
        //params Expression<Func<ToptioDs, object>>[] GridFields)
        //{

        //    IRERP_SM_VLayout V = new IRERP_SM_VLayout();
        //    V.members = new IRERPControlBase[]{
        //       =,
        //        new IRERP_SM_HLayout(){
        //            members=new IRERPControlBase[]{
        //            GetGenetalButton("بازگشت", new IRERPControlTypes_StringMethods(@" ""CloseWindow(" + WindowID + @")"" ", true)),
        // GetGenetalButton("درج گروهی", new IRERPControlTypes_StringMethods(@" ""InvoiceInsert_Save(" + ListGridID + @"," + DSId + @")"" ", true)),

        //        } }  
        //    };


        //    if (GridFields != null)
        //    {
        //        List<IRERP_SM_ListGridFiled> fs = new List<IRERP_SM_ListGridFiled>();
        //        foreach (var f in GridFields)
        //        {

        //            fs.Add(new IRERP_SM_ListGridFiled() { name = IRERPApplicationUtilities.GPN(f, false).ToClientDsFieldName()/*.Replace(".","___")*/ });

        //        }
        //         GetGeneralListGrid(Datasource: ToptioDs, ID: ListGridID,_height:"300").fields = fs.ToArray();
        //    }


        //    return V;
        //}





        public static IRERP_SM_VLayout GetGroupInsert(
            string Datasource = null, IRERPControlBase DatasourceGrid = null, string ListGridID = null, string WindowID = null, IRERPControlTypes_ListGridFiled[] l = null, IRERPControlTypes_StringMethods method = null)
        {

            IRERP_SM_VLayout V = new IRERP_SM_VLayout() { width = "100%", height = "100%" };
            var x = GetGeneralListGrid(Datasource: DatasourceGrid, ID: ListGridID/*, _height: "100%"*/,fixedRecordHeights:false);
            if (method == null) method = new IRERPControlTypes_StringMethods(@" ""InvoiceInsert_Save(" + ListGridID + @"," + Datasource + @")"" ", true);

            x.fields = l;
            V.members = new IRERPControlBase[]{
               x,
                new IRERP_SM_HLayout(){
                    width="100%",height="*",
                    members=new IRERPControlBase[]{
                    GetGenetalButton("بازگشت", new IRERPControlTypes_StringMethods(@" ""CloseWindow(" + WindowID + @")"" ", true)),
         GetGenetalButton("درج گروهی",method),
    
                } }  
            };
            return V;
        }




        public static IRERPPageString GetGeneralDVS(
           ViewContext viewContext,
           IRERP_SM_DynamicForm form,
           IRERPControlBase  SearchForm,
           IRERP_SM_ListGrid Grid,
           IRERP_SM_ToolStripButton[] AdditionalActions = null,

           IRERP_SM_MenuItem[] Actions = null,
            string formName = null
           ,
           bool hasEdit = true,
           bool hasInsert = true,
           bool hasDelete = true,
           bool hasRefresh = true,
           bool hasHilit = true,
           bool hasFormula = true,
           bool hasMenu = true,
           bool hasFilterBuilder = true

           )
        {
            Func<string, string> CID = id => IRERPApplicationUtilities.ControlId((System.Web.Mvc.Controller)viewContext.Controller, id);

            string formid = form.ID, gridid = Grid.ID, winid = "win" + formid, delwinid = "delwin" + formid;

            var toolStripInsert = AbbasiAdmin.GetGenetalToolStripButton(formid + "Add", "درج اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralAdd(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510525_insert-object.png");

            var toolStripEdit =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Edit", "ویرایش اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralEdit(" + winid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510469_old-edit-find-replace.png");

            var toolStripDelete =
                AbbasiAdmin.GetGenetalToolStripButton(formid + "Delete", "حذف اطلاعات", new IRERPControlTypes_StringMethods(@" ""GeneralDeleteAlert(" + delwinid + "," + formid + "," + gridid + @")"" ", true), "/Images/1377510425_edit-delete.png");

            var toolStripEditHiliting =
             AbbasiAdmin.GetGenetalToolStripButton(formid + "EditHilits", "برجسته سازی", new IRERPControlTypes_StringMethods(@" ""EditHiliting(" + gridid + @")"" ", true), "/Images/1377606892_preferences-desktop-color.png");

            var toolStripFormulaBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FormulaBuilder", "افزودن فیلد", new IRERPControlTypes_StringMethods(@" ""FormulaBuilders(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");

            var toolStripFiltreBuilder =
           AbbasiAdmin.GetGenetalToolStripButton(formid + "FilterBuilder", "ساخت فیلتر", new IRERPControlTypes_StringMethods(@" ""FilterBuilderFor(" + gridid + @")"" ", true), "/Images/1377606642_server_add.png");

            var menuOperationmenu = new IRERP_SM_Menu()
            {
                shadowDepth = 10,
                autoDraw = false,
                showShadow = true
            };
            var menuButton = new IRERP_SM_MenuButton() { title = new IRERPControlTypes_HTMLString("عملیات") };
            if (Actions != null)
            {
                menuOperationmenu.data = Actions;
                menuButton = new IRERP_SM_MenuButton()
                {
                    title = new IRERPControlTypes_HTMLString("عملیات"),
                    menu = menuOperationmenu
                };
            }



            var toolStripRefresh = AbbasiAdmin.GetGenetalToolStripButton(formid + "Refresh", "بارگذاری مجدد", new IRERPControlTypes_StringMethods(@" ""DVS_refresh('" + gridid + @"')"" ", true), "/Images/1377512645_button_blue_repeat.png");
            List<IRERPControlBase> toolstripbtns = new List<IRERPControlBase>();
            if (hasInsert) toolstripbtns.Add(toolStripInsert);
            if (hasEdit) toolstripbtns.Add(toolStripEdit);
            if (hasDelete) toolstripbtns.Add(toolStripDelete);
            if (hasRefresh) toolstripbtns.Add(toolStripRefresh);
            if (hasHilit) toolstripbtns.Add(toolStripEditHiliting);
            if (hasFormula) toolstripbtns.Add(toolStripFormulaBuilder);
            if (hasMenu) toolstripbtns.Add(menuButton);
            if (hasFilterBuilder) toolstripbtns.Add(toolStripFiltreBuilder);

            var ToolStrip = new IRERP_SM_ToolStrip()
            {
                width = "100%",
                //members = new IRERPControlBase[] { toolStripInsert, toolStripEdit, toolStripDelete, toolStripRefresh, toolStripEditHiliting, toolStripFormulaBuilder, menuButton }
                members = toolstripbtns.ToArray()
            };
            if (AdditionalActions != null)
            {
                List<IRERPControlBase> members = new List<IRERPControlBase>();
                if (ToolStrip.members != null)
                    members.AddRange(ToolStrip.members);
                members.AddRange(AdditionalActions);
                ToolStrip.members = members.ToArray();
            }
            var FormWindow = AbbasiAdmin.GetGenetalwindow(winid, formName, "30%", "30%", new IRERPControlBase[]{ 
            form,
               new IRERP_SM_HLayout()
                 {
                      width="100%",
                     height="100%",
                     members=new IRERPControlBase[]{ 
                     new IRERP_SM_Label(){width="5%"},
                     AbbasiAdmin.GetGenetalButton("ذخیره",new IRERPControlTypes_StringMethods(@" ""GeneralSave(" + winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="0%"},
                     AbbasiAdmin.GetGenetalButton("بازگشت",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +winid+ "," + formid+ ","+gridid+ @")"" ", true)),
                     new IRERP_SM_Label(){width="5%"}
                       }
                  } });


            var DeleteWindow =
                AbbasiAdmin.GetGenetalwindow(delwinid, null, "10%", "20%", new IRERPControlBase[] { 
                        AbbasiAdmin.GetGenetalDynamicForm(null, "10%", "20%",
                            new IRERP_SM_FormItem[]{
                                new IRERP_SM_HeaderItem(){defaultValue="آیا برای حذف مورد  انتخاب شده اطمینان دارد؟" }
                                },2,10,null),
                        new IRERP_SM_HLayout(){ width="100%",height="100%", members=new IRERPControlBase[]{ 
                                new IRERP_SM_Label(){width="5%"},
                                AbbasiAdmin.GetGenetalButton("بله",new IRERPControlTypes_StringMethods(@" ""GeneralDelete("+delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="0%"},
                                AbbasiAdmin.GetGenetalButton("خیر",new IRERPControlTypes_StringMethods(@" ""GeneralReturn(" +delwinid+ "," + formid+ ","+gridid+ @")"" ", true)),
                                new IRERP_SM_Label(){width="5%"}
                       }
                   }
                });

            var body = new IRERP_SM_VLayout() { members = new IRERPControlBase[] { ToolStrip, SearchForm, Grid } };
            IRERPPageString page = new IRERPPageString();
            page.OtherObjects += DeleteWindow.ToString();
            page.OtherObjects += FormWindow.ToString();

            page.DisplayControls += body.ToString();
            page.Commands += winid + ".hide();" + delwinid + ".hide();";
            return page;
        }


    }
}

