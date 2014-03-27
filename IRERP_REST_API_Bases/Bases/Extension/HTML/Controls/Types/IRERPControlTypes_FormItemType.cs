using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IRERPControlTypes_FormItemType
    {
        text,
        Float
            ,
        boolean,//	Rendered as a CheckboxItem
        integer,//	Same as text by default. Consider setting editorType:SpinnerItem.
        date,//	Rendered as a DateItem
        time,//	Rendered as a TimeItem
        sequence,//	Same as text
        link,//	If DataSourceField.canEdit:false is set on the field, the value is rendered as a LinkItem. Otherwise the field is rendered as a TextItem.
        image,//	Rendered as an image if not editable, or as a TextItem to edit the URL or partial URL if editable
        imageFile,//	Rendered as a FileItem, or a ViewFileItem if not editable
        binary,//	Rendered as a FileItem, or a ViewFileItem if not editable
        header,
        button,
        cancel, hidden, color, select, comboBox, radioGroup,
        password, StaticTextItem, checkbox, textArea, SelectItem, slider, pickTree, PersianDatePicker,irerpPickTree,irerpSelectItem,
        irerpTextItem, irerpFile
    }
}