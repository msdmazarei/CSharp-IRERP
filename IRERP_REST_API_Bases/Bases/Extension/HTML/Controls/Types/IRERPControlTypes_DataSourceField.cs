using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls.Types
{
    public class IRERPControlTypes_DataSourceField : TIRERPControlTypes_DataSourceField<IRERPControlTypes_DataSourceField> { }
    public class TIRERPControlTypes_DataSourceField <T>: TIRERPControlTypes_Base<T>
        where T: IRERPControlTypes_Base
    {
        //editorType [IR]
        IRERPControlTypes_FormItem _editorType;
        public IRERPControlTypes_FormItem editorType { get { return _editorType; } set { if (IsInInitializeTime) _editorType = value; else throw NotImplementerdForIR(); } }

        //hidden [IR]
        Nullable<bool> _hidden;
        public Nullable<bool> hidden { get { return _hidden; } set { if (IsInInitializeTime) _hidden = value; else throw NotImplementerdForIR(); } }

        // name [IR]
        string _name;
        public string name { get { return _name; } set { if (IsInInitializeTime) _name = value; else throw NotImplementerdForIR(); } }
       
        //mimeType [IR]
        string _mimeType;
        public string mimeType { get { return _mimeType; } set { if (IsInInitializeTime) _mimeType = value; else throw NotImplementerdForIR(); } }

        //primaryKey [IR]        

        bool _primaryKey;
        public bool primaryKey { get { return _primaryKey; } set { if (IsInInitializeTime) _primaryKey = value; else throw NotImplementerdForIR(); } }

        //readOnlyEditorType [IR]
        IRERPControlTypes_FormItem _readOnlyEditorType;
        public IRERPControlTypes_FormItem readOnlyEditorType { get { return _readOnlyEditorType; } set { if (IsInInitializeTime) _readOnlyEditorType = value; else throw NotImplementerdForIR(); } }

        //required [IR]
        Nullable<bool> _required;
        public Nullable<bool> required { get { return _required; } set { if (IsInInitializeTime) _required = value; else throw NotImplementerdForIR(); } }

        //rootValue [IR]
        object _rootValue;
        public object rootValue { get { return _rootValue; } set { if (IsInInitializeTime) _rootValue = value; else throw NotImplementerdForIR(); } }

        //title [IR]

        string _title;
        public string title { get { return _title; } set { if (IsInInitializeTime) _title = value; else throw NotImplementerdForIR(); } }

        //type [IR]

        IRERPControlTypes_FieldType _type;
        public IRERPControlTypes_FieldType type { get { return _type; } set { if (IsInInitializeTime) _type = value; else throw NotImplementerdForIR(); } }
        public string foreignKey { get; set; }

        protected override Dictionary<string, string> GetOutPutParts()
        {
            var rtn = CreateDictionaryFromProperties(this, 
                x => x.editorType, 
                x => x.hidden, 
                x => x.mimeType, 
                x => x.name, 
                x => x.primaryKey, 
                x => x.readOnlyEditorType, 
                x => x.required, 
                x => x.rootValue, 
                x => x.title,
                x=>x.foreignKey,
                x=>x.type);
            if (valueMap != null)
                rtn.Add("valueMap", "valueMap:" + valueMap);
            return rtn;

        }
        public override string ToStringAsMemberOfOther()
        {
            string rtn = "";
            rtn = "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "}";
            return rtn;

        }
        public override string ToString()
        {
            string rtn = "";
            rtn = "{" + string.Join(",", GetOutPutParts().Values.ToArray()) + "};";
            return rtn;

        }
        public virtual IRERP_SM_FormItem ToFormItem()
        {
            IRERP_SM_FormItem rtn = new IRERP_SM_FormItem();
            rtn.name = this.name;
            rtn.title = this.title;
            rtn.required = this.required;
            rtn.valueMap = this.valueMap;
            
            switch (this.type)
            {
                case IRERPControlTypes_FieldType.binary:
                    rtn.type = IRERPControlTypes_FormItemType.binary;
                    break;
                case IRERPControlTypes_FieldType.boolean:
                    rtn.type = IRERPControlTypes_FormItemType.boolean;
                    break;

                case IRERPControlTypes_FieldType.date:
                    rtn.type = IRERPControlTypes_FormItemType.date;
                    break;

                case IRERPControlTypes_FieldType.integer:
                    rtn.type = IRERPControlTypes_FormItemType.integer;
                    break;

                case IRERPControlTypes_FieldType.password:
                    rtn.type = IRERPControlTypes_FormItemType.password;
                    break;

                case IRERPControlTypes_FieldType.text:
                    rtn.type = IRERPControlTypes_FormItemType.text;
                    break;
                case IRERPControlTypes_FieldType.sequence:
                    rtn.type = IRERPControlTypes_FormItemType.sequence;
                    break;
                case IRERPControlTypes_FieldType.link:
                    rtn.type = IRERPControlTypes_FormItemType.link;
                    break;

            }


            return rtn;
        }
        public virtual string valueMap { get; set; }

    }
}