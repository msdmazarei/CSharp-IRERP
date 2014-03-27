using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public enum IREREPControlTypes_ListGridFieldType
    {
        text,//	Simple text rendering for view. For editing a text entry field is shown. If the length of the field (as specified by the DataSourceField.length attribute) is larger than the value specified by ListGrid.longTextEditorThreshold, a text input icon is shown that, when clicked on (or field is focused in) opens a larger editor that expands outside the boundaries of the cell (textarea by default, but overrideable via ListGrid.longTextEditorType).
boolean,//	For viewing and editing a checkbox is shown with a check mark for the true value and no check mark for the false value. This behavior may be suppressed by setting link{listGridField.suppressValueIcon} for the field. See ListGrid.booleanTrueImage for customization.
integer,//	Same as text. Consider setting editorType to use a SpinnerItem.

date,//	Field value should be a Date instance representing a logical date, with no time of day information. See Date and Time Format and Storage for details of the logical date type and how it is represented and manipulated.

//Dates,// will be formatted using ListGridField.dateFormatter if specified, otherwise ListGrid.dateFormatter. If both these attributes are unset, dates are formatted using the standard short display format for dates.

//For editing, by default a DateItem is used with DateItem.useTextField set to true, providing textual date entry plus a pop-up date picker. The dateFormatter and inputFormat for the editor will be picked up from the ListGridField, if specified.
time,//	Field value should be a Date instance representing a logical time, meaning time value that does not have a specific day and also has no timezone. See Date and Time Format and Storage for details of the logical time type and how it is represented and manipulated.

//Times will be formatted using ListGridField.timeFormatter if specified, otherwise ListGrid.timeFormatter.

//If both these attributes are unset, times are formatted using the standard short display format for times.

//For editing, by default a TimeItem is used. The timeFormatter for the editor will be picked up from the ListGridField, if specified.
datetime,//	Field value should be a Date instance representing a specific date and time value. See Date and Time Format and Storage for details of the datetime type and how it is represented and manipulated.

//Dates will be formatted using ListGridField.dateFormatter if specified, otherwise ListGrid.datetimeFormatter. If both these attributes are unset, dates are formatted using the standard short display format for datetime values.

//For editing, by default a DateTimeItem is used, providing textual date entry plus a pop-up date picker. The dateFormatter and inputFormat for the editor will be picked up from the ListGridField, if specified.
sequence,//	Same as text
link,//	Renders a clickable html link (using an HTML anchor tag: <A>). The target URL is the value of the field, which is also the default display value. You can override the display value by setting ListGridRecord.linkText or ListGridField.linkText.

//Clicking the link opens the URL in a new window by default. To change this behavior, you can set field.target, which works identically to the "target" attribute on an HTML anchor (<A>) tag. See ListGridField.target for more information.

//In inline edit mode, this type works like a text field.

//To create a link not covered by this feature, consider using ListGridField.formatCellValue() along with Canvas.linkHTML(), or simply styling the field to look like a link, and providing interactivity via field.recordClick().
image,//	Renders a different image in each row based on the value of the field. If this URL is not absolute, it is assumed to be relative to ListGridField.imageURLPrefix if specified. The size of the image is controlled by ListGridField.imageSize, ListGridField.imageWidth, ListGridField.imageHeight (and by the similarly-named global default attributes on the ListGrid itself).

//You can also specify the following attributes on the field: activeAreaHTML, and extraStuff - these are passed to Canvas.imgHTML() to generate the final URL.

//Note if you want to display icons in addition to the normal cell value, you can use valueIcons instead.
icon,//	Shows field.icon in every cell, and also in the header. Useful for a field that is used as a button, for example, launches a detail window or removes a row. Implement a field.recordClick to define a behavior for the button.

//NOTE: for a field that shows different icons depending on the field value, see ListGridField.valueIcons.

//type:"icon" also defaults to a small field width, accommodating just the icon with padding, and to a blank header title, so that the header shows the icon only.

//field.iconWidth and related properties configure the size of the icon both in the header and in body cells.

//If you want the icon to appear only in body cells and not in the header, set field.cellIcon instead, leaving field.icon null.
binary,//	For viewing, the grid renders a 'view' icon (looking glass) followed by a 'download' icon and then the name of the file is displayed in text. If the user clicks the 'view' icon, a new browser window is opened and the file is streamed to that browser instance, using DataSource.viewFile(). For images and other file types with known handlers, the content is typically displayed inline - otherwise the browser will ask the user how to handle the content. If the download icon is clicked, DataSource.downloadFile() is used to cause the browser to show a "save" dialog. There is no inline editing mode for this field type.
imageFile,//	Same as binary
summary,//	Show a calculated summary based on other field values within the current record. See ListGridField.recordSummaryFunction for more information
    }
}
