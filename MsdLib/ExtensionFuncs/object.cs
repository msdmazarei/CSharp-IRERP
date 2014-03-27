using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MsdLib.ExtentionFuncs.ObjectFuncs
{
    public static class @object
    {
        public static object Clone(this object objthis)
        {
            //First we create an instance of objthis specific type.
            object newObject = Activator.CreateInstance(objthis.GetType());

            //We get the array of fields for the new type instance.
            FieldInfo[] fields = newObject.GetType().GetFields();

            int i = 0;

            foreach (FieldInfo fi in objthis.GetType().GetFields())
            {
                //We query if the fiels support the ICloneable interface.
                Type ICloneType = fi.FieldType.
                            GetInterface("ICloneable", true);

                if (ICloneType != null)
                {
                    //Getting the ICloneable interface from the object.
                    ICloneable IClone = (ICloneable)fi.GetValue(objthis);

                    //We use the clone method to set the new value to the field.
                    fields[i].SetValue(newObject, IClone.Clone());
                }
                else
                {
                    // If the field doesn't support the ICloneable 
                    // interface then just set it.
                    fields[i].SetValue(newObject, fi.GetValue(objthis));
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
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(objthis);

                    //objthis version support the IList and the 
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
                            //cloned list objthis item will be the same 
                            //item as in the original list
                            //(as long as objthis type is a reference type).

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

            PropertyInfo[] props = newObject.GetType().GetProperties();
            i = 0;
            foreach (PropertyInfo p in props)
            {
                if (p.CanWrite)
                {
                    //We query if the fiels support the ICloneable interface.
                    Type ICloneType = p.PropertyType.
                                GetInterface("ICloneable", true);

                    if (ICloneType != null)
                    {
                        //Getting the ICloneable interface from the object.
                        ICloneable IClone = (ICloneable)p.GetValue(objthis, null);
                        if (IClone != null) 
                        //We use the clone method to set the new value to the field.
                        p.SetValue(newObject, IClone.Clone(), null);
                    }
                    else
                    {
                        // If the field doesn't support the ICloneable 
                        // interface then just set it.
                        p.SetValue(newObject, p.GetValue(objthis, null), null);
                    }


                    //Now we check if the object support the 
                    //IEnumerable interface, so if it does
                    //we need to enumerate all its items and check if 
                    //they support the ICloneable interface.
                    Type IEnumerableType = p.PropertyType.GetInterface
                                    ("IEnumerable", true);
                    if (IEnumerableType != null)
                    {
                        //Get the IEnumerable interface from the field.
                        IEnumerable IEnum = (IEnumerable)p.GetValue(objthis, null);

                        //objthis version support the IList and the 
                        //IDictionary interfaces to iterate on collections.
                        Type IListType = p.PropertyType.GetInterface
                                            ("IList", true);
                        Type IDicType = p.PropertyType.GetInterface
                                            ("IDictionary", true);

                        int j = 0;
                        if (IListType != null)
                        {
                            //Getting the IList interface.
                            IList list = (IList)p.GetValue(newObject, null);

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
                                //cloned list objthis item will be the same 
                                //item as in the original list
                                //(as long as objthis type is a reference type).

                                j++;
                            }
                        }
                        else if (IDicType != null)
                        {
                            //Getting the dictionary interface.
                            IDictionary dic = (IDictionary)props[i].
                                                GetValue(newObject, null);
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
            }
            return newObject;

            //FilterBase<T> rtn = new FilterBase<T>();
            //rtn.Session = this.Session;
            //rtn.IsAvailableFilter = this.IsAvailableFilter;
            //rtn.UsedAsFilter = this.UsedAsFilter;
            //if(this.PropertyChanged!=null)
            //rtn.PropertyChanged = (PropertyChangedEventHandler)this.PropertyChanged.Clone();
            //rtn.Orders.AddRange(this.Orders);
            //rtn.Criterias.AddRange(this.Criterias);
            //return rtn;

           
        }
    }
}