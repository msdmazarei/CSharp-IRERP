using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Extension.HTML
{
   
    public static class IRERPUIControls_Extensions
    {
        public static IRERP_SM_HLayout HLayout(this HtmlHelper helper,string id = null )
        {
            return new IRERP_SM_HLayout(){IsInInitializeTime=true,ID=id};
        }
        
        public static IRERP_SM_Label LabeL(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_Label() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_VLayout VLayout(this HtmlHelper helper , string id = null) {
            return new IRERP_SM_VLayout(){IsInInitializeTime=true,ID=id};
        }

        public static IRERP_SM_RestDataSource RestDataSource(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_RestDataSource() { IsInInitializeTime = true, ID = id };
        }


        public static IRERP_SM_ListGrid ListGrid(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_ListGrid() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_Menu Menu(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_Menu() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_SectionStack SectionStack(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_SectionStack() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_TabSet TabSet(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_TabSet() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_ToolStrip ToolStrip(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_ToolStrip() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_ToolStripButton ToolStripButton(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_ToolStripButton() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_DynamicForm DynamicForm(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_DynamicForm() { IsInInitializeTime = true, ID = id };
        }

        public static IRERP_SM_Tab Tab(this HtmlHelper helper, string id = null, string title = null, IRERPControlBase pane = null)
        {
            return new IRERP_SM_Tab() { IsInInitializeTime = true, ID = id,title=title,pane=pane };
        }

        public static IRERP_SM_MenuButton MenuButton(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_MenuButton() { IsInInitializeTime = true, ID = id};
        }

        public static IRERP_SM_SectionStackSection SectionStackSection(this HtmlHelper helper, string id = null, string title = null, bool? expanded = null, bool? resizeable = null, IRERPControlBase items=null)
        {
            return new IRERP_SM_SectionStackSection() { IsInInitializeTime = true, ID = id,title=title,expanded=expanded,resizeable=resizeable,items=items };
        }

        public static IRERP_SM_FormItem FormItem(this HtmlHelper helper, string name=null, bool? showTitle=null, int? width = null, object valueMap=null, object defaultValue=null)
        {
            return new IRERP_SM_FormItem() { IsInInitializeTime = true ,name=name  ,showTitle=showTitle ,width=width ,valueMap=valueMap ,defaultValue=defaultValue };
        }

        public static IRERP_SM_TextItem TextItem(this HtmlHelper helper, string title = null, IRERPControlTypes_FormItemType? type = null)
        {
            return new IRERP_SM_TextItem() { IsInInitializeTime = true, title = title, type = type };
        }

        public static IRERP_SM_ButtonItem ButtonItem(this HtmlHelper helper)
        {
            return new IRERP_SM_ButtonItem() { IsInInitializeTime = true };
        }

        public static IRERP_SM_Window Window(this HtmlHelper helper, string id = null)
        {
            return new IRERP_SM_Window() { IsInInitializeTime = true, ID = id };
        }

    }
}