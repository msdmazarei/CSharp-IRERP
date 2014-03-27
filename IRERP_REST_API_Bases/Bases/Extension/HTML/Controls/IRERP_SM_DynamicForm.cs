using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERP_SM_DynamicForm : IRERP_SM_Canvas/*TIRER_SM_DynamicForm<IRERP_SM_DynamicForm> { }
        public class TIRER_SM_DynamicForm<T>:TIRERP_SM_Canvas<T>
            where T:IRERPControlBase*/
    {
            public virtual int? numCols { get; set; }
            public virtual Types.IRERPControlTypes_TitleOrientation? titleOrientation { get; set; }
            public virtual IRERP_SM_FormItem[] fields { get; set; }
            public virtual IRERP_SM_FormItem[] items { get; set; }
            public IRERPControlBase dataSource { get; set; }
            public virtual void ChangeFormItemByName(string Name,Func<IRERP_SM_FormItem,IRERP_SM_FormItem> act)
            {
                for (int i = 0; i < (fields != null ? fields.Length : 0); i++)
                    if (fields[i].name == Name)
                        fields[i]=act(fields[i]);
            }
            public virtual void RemoveFieldByName(string Name)
            {
                for (int i = 0; i < (fields != null ? fields.Length : 0); i++)

                    if (fields[i].name == Name)
                    {
                        var tmp = fields.ToList();
                        tmp.RemoveAt(i);
                        fields = tmp.ToArray();
                        return;
                    }
            }
            protected override Dictionary<string, string> GetOutPutParts()
            {
                if (IsInInitializeTime)
                {
                    var Parts = base.GetOutPutParts();
                    if (numCols != null) Parts.Add("numCols", "numCols:" + int2JSON((int)numCols) + "");
                    if (dataSource != null) Parts.Add("dataSource", "dataSource:" + dataSource.ToStringAsMemberOfOther() + "");
                    if (titleOrientation != null) Parts.Add("titleOrientation", "titleOrientation:" + enum2JSON(titleOrientation));
                    List<string> _fi = new List<string>();

                    if (fields != null) foreach (var a in fields) _fi.Add(a.ToStringAsMemberOfOther());



                    if (fields != null) Parts.Add("fields", "fields:[" + string.Join(",", _fi) + "]");


                    List<string> _fi1 = new List<string>();

                    if (items != null) foreach (var a in items) _fi1.Add(a.ToStringAsMemberOfOther());



                    if (items != null) Parts.Add("items", "items:[" + string.Join(",", _fi1) + "]");
                    return Parts;
                }

                else
                { return new Dictionary<string, string>(); }


            }

            public override string ToStringAsMemberOfOther()
            {
                if (IsInInitializeTime)
                    return "isc.DynamicForm.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "})";
                else
                    return "";
            }
            public override string ToString()
            {
                if (IsInInitializeTime)
                    return "isc.DynamicForm.create({" + string.Join(",", GetOutPutParts().Values.ToArray()) + "});";
                else
                    return "";
            }
        
    }
}