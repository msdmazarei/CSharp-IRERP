using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    //TODO: To Convert To String there is a problem: Float -> float , Enum -> enum in js
    public enum IRERPControlTypes_FieldType
    {

        text,//	Generic text, e.g. "John Doe". This is the default field type. Use field.length to set length.
boolean,//A boolean value, e.g. true
integer,//	A whole number, e.g. 123
Float,//	A floating point (decimal) number, e.g. 1.23
date,//	A logical date, with no time value (such as a holiday or birthday). Represented on the client as a JavaScript Date object with all time fields set to zero in browser local time. Transmitted in UTC/GMT by default. See Date and Time Format and Storage for more information on date display and serialization formats. See also Date for SmartClient extensions to the Date object.
time,//	A time of day, with no date. Represented on the client as a JavaScript Date object in UTC/GMT by default (see also Date and Time Format and Storage and the Time class).
datetime,//	A date and time, accurate to the second. Represented on the client as a JavaScript Date object. See also Date and Time Format and Storage and Date for SmartClient extensions to the Date object.
Enum,//	A text value constrained to a set of legal values specified by the field's valueMap, as though a ValidatorType of "isOneOf" had been declared.
intEnum,//	An enum whose values are numeric.
sequence,//	If you are using the SmartClient SQL datasource connector, a sequence is a unique, increasing whole number, incremented whenever a new record is added. Otherwise, sequence behaves identically to integer. This type is typically used with field.primaryKey to auto-generate unique primary keys. See also DataSourceField.sequenceName.
link,//	A string representing a well-formed URL. Some components will render this as an HTML link (using an anchor tag for example).
image,//	A string representing a well-formed URL that points to an image. Some components will render an IMG tag with the value of this field as the 'src' attribute to render the image.
binary,//	Arbitrary binary data. When this field type is present, three additional fields are automatically generated. They are: <fieldName>_filename, <fieldName>_filesize, and <fieldName>_date_created where <fieldName> is the value of the name attribute of this field. These fields are marked as DataSourceField.hidden:true to suppress their rendering by default. You can show one or more of these fields by specifying the field with a hidden:false override in the fields array of the databound component. Stream / view file support for custom DataSources: a custom DataSource or DMI must implement the "viewFile" and "downloadFile" operationTypes and return a single Record with an byte[] as the field value for the binary field. For more detail see the overview of Binary Fields.
imageFile,//	Binary data comprising an image.
any,//	Fields of this type can contain any data value and have no default formatting or validation behavior. This is useful as the parent type for SimpleTypes where you do not want any of the standard validation or formatting logic to be inherited from the standard built-in types.
modifier,//	Fields of this type are automatically populated by the SmartClient Server with the current authenticated userId as part of "add" and "update" operations. By default, fields of this type are hidden and not editable; the server ignores any value that the client sends in a field of this type. Note that the "authenticated user" can be set explicitly on the server-side RPCManager using the setUserId() method, or it can come from the servlet API if you are using its built-in authentication scheme. See the server-side Javadocs for RPCManager.
modifierTimestamp,//	Fields of this type are automatically populated by the SmartClient Server with the current date and time as part of "add" and "update" operations. By default, fields of this type are hidden and not editable; the server ignores any value that the client sends in a field of this type.
creator,//	Fields of this type are automatically populated by the SmartClient Server with the current authenticated userId as part of "add" operations. By default, fields of this type are hidden and not editable; the server ignores any value that the client sends in a field of this type. The notes about type "modifier" also apply to fields of this type.
creatorTimestamp,//	Fields of this type are automatically populated by the SmartClient Server with the current date and time as part of an "add" operation (when the record is first created). By default, fields of this type are hidden and not editable; the server ignores any value that the client sends in a field of this type.
password,//	A password field type.
custom,//	A custom SimpleType field type.
ntext//	A special field type specifically for use with Unicode data in conjunction with the Microsoft SQL Server database. Field type "ntext" implies the use of sqlStorageStrategy "ntext"; other than that, this type is identical to "text"
        ,
        irerpFile,
        irerpGAddress,
       
    }
}