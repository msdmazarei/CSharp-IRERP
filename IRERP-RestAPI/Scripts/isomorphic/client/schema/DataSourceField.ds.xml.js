isc.DataSource.create({
    ID:"DataSourceField",
    addGlobalId:"false",
    fields:{
        name:{
            basic:"true",
            primaryKey:"true",
            required:"true",
            title:"Name",
            type:"string",
            xmlAttribute:"true"
        },
        type:{
            basic:"true",
            title:"Type",
            type:"string",
            xmlAttribute:"true"
        },
        disabled:{
            title:"Disabled",
            type:"boolean"
        },
        idAllowed:{
            title:"ID Allowed",
            type:"boolean",
            xmlAttribute:"true"
        },
        required:{
            title:"Required",
            type:"boolean",
            xmlAttribute:"true"
        },
        valueMap:{
            type:"ValueMap"
        },
        validators:{
            multiple:"true",
            propertiesOnly:"true",
            type:"Validator"
        },
        length:{
            title:"Length",
            type:"integer",
            xmlAttribute:"true"
        },
        xmlRequired:{
            type:"boolean",
            visibility:"internal"
        },
        xmlMaxOccurs:{
            type:"string",
            visibility:"internal"
        },
        xmlMinOccurs:{
            type:"integer",
            visibility:"internal"
        },
        xmlNonEmpty:{
            type:"boolean",
            visibility:"internal"
        },
        xsElementRef:{
            type:"boolean",
            visibility:"internal"
        },
        canHide:{
            title:"User can hide",
            type:"boolean"
        },
        xmlAttribute:{
            type:"boolean",
            visibility:"internal"
        },
        mustQualify:{
            type:"boolean",
            visibility:"internal"
        },
        valueXPath:{
            title:"Value XPath",
            type:"XPath",
            xmlAttribute:"true"
        },
        childrenProperty:{
            type:"boolean"
        },
        title:{
            title:"Title",
            type:"string",
            xmlAttribute:"true"
        },
        detail:{
            title:"Detail",
            type:"boolean",
            xmlAttribute:"true"
        },
        canEdit:{
            title:"Can Edit",
            type:"boolean",
            xmlAttribute:"true"
        },
        canSave:{
            title:"Can Save",
            type:"boolean",
            xmlAttribute:"true"
        },
        canView:{
            title:"Can View",
            type:"boolean",
            xmlAttribute:"true"
        },
        inapplicable:{
            inapplicable:"true",
            title:"Inapplicable",
            type:"boolean"
        },
        advanced:{
            inapplicable:"true",
            title:"Advanced",
            type:"boolean"
        },
        visibility:{
            inapplicable:"true",
            title:"Visibility",
            type:"string"
        },
        hidden:{
            inapplicable:"true",
            title:"Hidden",
            type:"boolean",
            xmlAttribute:"true"
        },
        primaryKey:{
            title:"Is Primary Key",
            type:"boolean",
            xmlAttribute:"true"
        },
        foreignKey:{
            title:"Foreign Key",
            type:"string",
            xmlAttribute:"true"
        },
        rootValue:{
            title:"Tree Root Value",
            type:"string",
            xmlAttribute:"true"
        },
        showFileInline:{
            type:"boolean",
            xmlAttribute:"true"
        },
        nativeName:{
            hidden:"true",
            title:"Native Name",
            type:"string"
        },
        fieldName:{
            hidden:"true",
            title:"Field Name",
            type:"string"
        },
        fields:{
            childTagName:"field",
            hidden:"true",
            multiple:"true",
            propertiesOnly:"true",
            type:"DataSourceField",
            uniqueProperty:"name"
        },
        multiple:{
            type:"boolean",
            xmlAttribute:"true"
        },
        validateEachItem:{
            type:"boolean",
            xmlAttribute:"true"
        },
        pickListFields:{
            multiple:"true",
            type:"Object"
        },
        canFilter:{
            type:"boolean",
            xmlAttribute:"true"
        },
        ignore:{
            type:"boolean"
        },
        unknownType:{
            type:"boolean",
            xmlAttribute:"true"
        },
        canSortClientOnly:{
            type:"boolean",
            xmlAttribute:"true"
        },
        childTagName:{
            type:"string",
            xmlAttribute:"true"
        },
        basic:{
            type:"boolean"
        },
        maxFileSize:{
            type:"integer"
        },
        frozen:{
            title:"Frozen",
            type:"boolean",
            xmlAttribute:"true"
        },
        canExport:{
            type:"boolean",
            xmlAttribute:"true"
        },
        sqlStorageStrategy:{
            type:"string",
            xmlAttribute:"true"
        },
        encodeInResponse:{
            type:"boolean",
            xmlAttribute:"true"
        }
    }
})
