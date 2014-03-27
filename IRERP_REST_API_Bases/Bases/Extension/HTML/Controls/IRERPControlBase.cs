using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using IRERP_REST_API_Bases;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
namespace IRERP_RestAPI.Bases.Extension.HTML.Controls
{
    public class IRERPControlBase:ICloneable
    {

        public IRERPControlBase()
        {
            IsInInitializeTime = true;
        }
        public virtual string ToStringWithoutConstructor() { return ""; }
        public bool IsInInitializeTime { get; set; }
        protected bool isEmpty(object obj)
        {
            if (obj == null) return true;
            if (obj.GetType() == typeof(string))
            {
                if (obj == null) return true;
                if (((string)obj) == "") return true;
                return false;
            }
            return false;

        }
        public virtual string ToStringAsMemberOfOther() { return ""; }
        protected string bool2JSON(bool? v) { return v.ToString().ToLower(); }
        protected string float2JSON(float v) { return v.ToString().ToLower(); }
        protected string  stringArray2JSON(string[] a) {
            List<string> str = new List<string>();
            string rtn = "[]";

        if(a!=null) 
            foreach(var s in a) str.Add(string2JSON(s));
        if (str.Count > 0) rtn="["+string.Join(",", str.ToArray())+"]";

        return rtn;

        }

        protected string string2JSON(string a)
        {
            return IRERPApplicationUtilities.ToJson(a);
        //    return "\"" + a + "\""; 
        }
        protected string Object2JSON(object a) {
            if (typeof(string) == a.GetType() || typeof(String)== a.GetType()) return string2JSON((string)a);
           
            
            return a.ToString().ToLower(); }
        protected string enum2JSON(object a){
            if (a.GetType() == typeof(Types.IRERPControlTypes_FieldType))
            {
                if (((Types.IRERPControlTypes_FieldType)a) == Types.IRERPControlTypes_FieldType.Float) return "\"float\"";
                if (((Types.IRERPControlTypes_FieldType)a) == Types.IRERPControlTypes_FieldType.Enum) return "\"enum\"";
                
            }
           


            if (a.GetType() == typeof(Types.IRERPControlTypes_CharacterCasing))
            {
                if (((Types.IRERPControlTypes_CharacterCasing)a) == Types.IRERPControlTypes_CharacterCasing.Default) return "\"default\"";

            }
            if (a.GetType() == typeof(Types.IRERPControlTypes_FormItemType))
            {
                if (((Types.IRERPControlTypes_FormItemType)a) == Types.IRERPControlTypes_FormItemType.Float) return "\"float\"";

            }
            return "\""+a.ToString()+"\"";}
        protected string int2JSON(int? a) { var rtn = a != null ? a.ToString() : ""; return rtn; }
        protected Exception NotImplementerdForIR() { return new NotImplementedException(Res.CANTSETIRPROP); }
        protected virtual Dictionary<string, string> GetOutPutParts() { return new Dictionary<string, string>(); }
        protected virtual Dictionary<string, string> CreateDictionaryFromProperties<T>(T obj,params Expression<Func<T, object>>[] Params)
        {
            Dictionary<string, string> rtn = new Dictionary<string, string>();
            foreach (var p in Params)
            {
                var meminfo = IRERPApplicationUtilities.GetClassMember<T>(p);
                if (
                     isEmpty(((System.Reflection.PropertyInfo)meminfo).GetValue(this, null))
                    ) continue;
                
                bool converted=false;
                if (((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(string))
                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name + ":" +
                               string2JSON((string) ((System.Reflection.PropertyInfo)meminfo).GetValue(this,null))
                               );

                }
                if (
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(bool) ||
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(Nullable<bool>)
                    )
                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name+":"+
                            bool2JSON((bool)((System.Reflection.PropertyInfo)meminfo).GetValue(this, null))
                            );
                }
                if (
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(Enum) //||
                    //((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(Nullable<Enum>)
                    )
                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name + ":" +
                            enum2JSON(((System.Reflection.PropertyInfo)meminfo).GetValue(this, null))
                            );
                }

                if (
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(int) ||
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(Nullable<int>)
                    )
                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name + ":" +
                        int2JSON((int?)((System.Reflection.PropertyInfo)meminfo).GetValue(this, null)));
                }

                if (
                    ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(IRERPControlTypes_FieldType) 
                
                    )

                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name + ":" +
                        enum2JSON((IRERPControlTypes_FieldType)((System.Reflection.PropertyInfo)meminfo).GetValue(this, null)));
                }

                if (
                  ((System.Reflection.PropertyInfo)meminfo).PropertyType == typeof(object)

                  )
                {
                    converted = true;
                    rtn.Add(meminfo.Name, meminfo.Name + ":" +
                        Object2JSON((object)((System.Reflection.PropertyInfo)meminfo).GetValue(this, null)));
                }
                if (!converted) throw new Exception(Res.DTWSNTCNVTOSTR);
                
            }
            return rtn;
        }

        public object Clone()
        {
            //First we create an instance of this specific type.
            object newObject = Activator.CreateInstance(this.GetType());

            //We get the array of fields for the new type instance.
            FieldInfo[] fields = newObject.GetType().GetFields();

            int i = 0;

            foreach (FieldInfo fi in this.GetType().GetFields())
            {
                //We query if the fiels support the ICloneable interface.
                Type ICloneType = fi.FieldType.
                            GetInterface("ICloneable", true);

                if (ICloneType != null)
                {
                    //Getting the ICloneable interface from the object.
                    ICloneable IClone = (ICloneable)fi.GetValue(this);

                    //We use the clone method to set the new value to the field.
                    fields[i].SetValue(newObject, IClone.Clone());
                }
                else
                {
                    // If the field doesn't support the ICloneable 
                    // interface then just set it.
                    fields[i].SetValue(newObject, fi.GetValue(this));
                }

                //Now we check if the object support the 
                //IEnumerable interface, so if it does
                //we need to enumerate all its items and check if 
                //they support the ICloneable interface.
                Type IEnumerableType = fi.FieldType.GetInterface
                                ("IEnumerable", true);
                if (IEnumerableType != null)
                {
                    //Get the IEnumerable interface from the field.
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(this);

                    //This version support the IList and the 
                    //IDictionary interfaces to iterate on collections.
                    Type IListType = fields[i].FieldType.GetInterface
                                        ("IList", true);
                    Type IDicType = fields[i].FieldType.GetInterface
                                        ("IDictionary", true);

                    int j = 0;
                    if (IListType != null)
                    {
                        //Getting the IList interface.
                        IList list = (IList)fields[i].GetValue(newObject);

                        foreach (object obj in IEnum)
                        {
                            //Checking to see if the current item 
                            //support the ICloneable interface.
                            ICloneType = obj.GetType().
                                GetInterface("ICloneable", true);

                            if (ICloneType != null)
                            {
                                //If it does support the ICloneable interface, 
                                //we use it to set the clone of
                                //the object in the list.
                                ICloneable clone = (ICloneable)obj;

                                list[j] = clone.Clone();
                            }

                            //NOTE: If the item in the list is not 
                            //support the ICloneable interface then in the 
                            //cloned list this item will be the same 
                            //item as in the original list
                            //(as long as this type is a reference type).

                            j++;
                        }
                    }
                    else if (IDicType != null)
                    {
                        //Getting the dictionary interface.
                        IDictionary dic = (IDictionary)fields[i].
                                            GetValue(newObject);
                        j = 0;

                        foreach (DictionaryEntry de in IEnum)
                        {
                            //Checking to see if the item 
                            //support the ICloneable interface.
                            ICloneType = de.Value.GetType().
                                GetInterface("ICloneable", true);

                            if (ICloneType != null)
                            {
                                ICloneable clone = (ICloneable)de.Value;

                                dic[de.Key] = clone.Clone();
                            }
                            j++;
                        }
                    }
                }
                i++;
            }
            return newObject;
        }
    }
}