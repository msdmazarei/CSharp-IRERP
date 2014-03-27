using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.Utils;
using System.Collections;
using System.Reflection;

namespace MsdLib.CSharp.BLLCore
{
    public interface IFilterBaseInterface<out T> { }
    
    public class FilterBase<T>: FilterBaseTModelBase<T>
        where T:ModelBase
    {
    }
    public class FilterBaseTModelBase<T> :FilterBaseCore
        where T:ModelBase
    {
        //protected IQueryOver<T, T> _Query;
     public virtual T ModelInstance
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public virtual IQueryOver<T,T> Query {
            get {
                if (UseStatelessSession)
                    _Query = StatelessSession.QueryOver<T>();
                else
                    _Query = Session.QueryOver<T>();
                return (IQueryOver<T, T>)_Query; 
            }
            set { _Query = value; } 
        }
          public void OnPropertyChanged(Expression<Func<T, object>> x)
        {
            OnPropertyChanged(AppUtils.GPN<T,object>(x));
        }
        public virtual string GPN(Expression<Func<T, object>> x) { return AppUtils.GPN<T>(x,true); }
        public virtual ICriteria Criteria
        {
            get
            {
                var crit = Session.CreateCriteria<T>();
                return crit;

            }
        }
    }
    
    public class FilterBaseCore : 
        
        IDataErrorInfo, INotifyPropertyChanged,ICloneable

        //where T:ModelBase<T>
    {
        protected IStatelessSession _statelessSession;
        public IStatelessSession StatelessSession
        {
            get
            {
                if (_statelessSession != null)
                    if (_statelessSession.IsOpen && _statelessSession.IsConnected)
                        return _statelessSession;
#if DEBUG
                System.Diagnostics.Trace.WriteLine("---Create New StatelessSession:" );

#endif

                _statelessSession = DBFactory.Instance.StatelessSession;
#if DEBUG
                System.Diagnostics.Trace.WriteLine("--- StatelessSession:" +_statelessSession.GetHashCode().ToString()+" created");

#endif

                return _statelessSession;
            }
        }
        public bool _useStatelessSession = false;
        public bool UseStatelessSession
        {
            get { return _useStatelessSession; }
            set { _useStatelessSession = value; }
        }

        protected ISession _session;
        public ISession Session { get {
            if (_session == null) _session = DBFactory.Instance.Session;
            if (!_session.IsConnected) _session = DBFactory.Instance.Session;
            /*lock (this)
	        {
            //_session = PetiakDBFactory.Instance.NewSession();
	        }*/
            
            return _session; 
        
        } set { _session = value; } } 
        /*public virtual void AfterDbOperation()
        {
            lock (this)
            {
            if (_session != null) 
                if(_session.IsConnected)
                    if(_session.IsOpen)
                            _session.Close();
            }
        }
        */
        protected IQueryOver _Query;
      
      
        public virtual bool IsAvailableFilter { get; set; }
        public virtual bool UsedAsFilter { get; set; }

        public virtual string Error
        {
            get { return null; }
        }

        public virtual string this[string columnName]
        {
            get { return null; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this,new PropertyChangedEventArgs(PropName));
        }
      
        public List<OrderBy> Orders { get; set; }
        public List<MsdCriteria> Criterias { get; set; }
        
        public FilterBaseCore()
        {
            Orders = new List<OrderBy>();
            Criterias = new List<MsdCriteria>();
        
        }


        public virtual object Clone()
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
                        ICloneable IClone = (ICloneable)p.GetValue(this,null);
                        if (IClone != null)
                            //We use the clone method to set the new value to the field.
                            p.SetValue(newObject, IClone.Clone(), null);
                        else
                            p.SetValue(newObject, null, null);
                    }
                    else
                    {
                        // If the field doesn't support the ICloneable 
                        // interface then just set it.
                        p.SetValue(newObject, p.GetValue(this,null),null);
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
                    IEnumerable IEnum = (IEnumerable)p.GetValue(this,null);

                    //This version support the IList and the 
                    //IDictionary interfaces to iterate on collections.
                    Type IListType =p.PropertyType.GetInterface
                                        ("IList", true);
                    Type IDicType =p.PropertyType.GetInterface
                                        ("IDictionary", true);

                    int j = 0;
                    if (IListType != null)
                    {
                        //Getting the IList interface.
                        IList list = (IList)p.GetValue(newObject,null);
                        lock (IEnum)
                        {
                            List<object> tst = new List<object>();
                            var enumerable= IEnum.GetEnumerator();

                            enumerable.Reset();

                            while (enumerable.MoveNext())
                            {
                                tst.Add(enumerable.Current);
                            }



                            foreach (object obj in tst)
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
                    }
                    else if (IDicType != null)
                    {
                        //Getting the dictionary interface.
                        IDictionary dic = (IDictionary)props[i].
                                            GetValue(newObject,null);
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

    public class FilterBase<MyType, T> : FilterBase<T>
        where T :ModelBase
        where MyType : FilterBase<T>
    {
        public void OnPropertyChanged(Expression<Func<MyType, object>> x)
        {
            OnPropertyChanged(AppUtils.GPN(x));
        }
        public string GPN(Expression<Func<MyType, object>> x)
        {
            return AppUtils.GPN(x);
        }
            
    }
}
