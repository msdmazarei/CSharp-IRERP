
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.BLLCore;
using NHibernate.Criterion;
using NHibernate;
using System.Collections;
using System.Diagnostics;


namespace MsdLib.CSharp.DataVirtualization
{

    public class ItemsProvider<T,FilterType> 
        : IItemsProvider<T> ,ICloneable
        where FilterType :FilterBase<T> 
        where T:ModelBase
    {
        FilterType _f;
        FilterType _usedfilter;
        public virtual FilterType Filter
        {
            get
            {
                Type _t = typeof(FilterType);

                if (_f == null) _f =(FilterType) Activator.CreateInstance(_t);
                return _f;
            }
            set
            {
                _f = value;
            }
        }
        
        protected virtual void setUseFilter()
        {
            if (_f != null)
                if (_f.UsedAsFilter)
                    if (_f.IsAvailableFilter)
                    {
                        _usedfilter = _f;
                        _f.UsedAsFilter = false;
                    }
                    else
                    {
                        //Remove Filter
                        _usedfilter = null;
                        _f.UsedAsFilter = false;
                    }
        }

      

        public virtual int FetchCount()
        {
            var session = DbSessionManager.GetSession();

            lock (session)
            {
               // if (BeforeLoad != null) 
                 //   BeforeLoad();
                ICriteria rowcrit = (ICriteria)Filter.Criteria.Clone();
                rowcrit.SetProjection(Projections.RowCount());
                //remove all orders
                rowcrit.ClearOrders();
                //int Count = Filter.Query.RowCount();
                int Count = 0;
                DateTime now = DateTime.Now;
                    Count = rowcrit.UniqueResult<int>();
#if DEBUG
                    System.Diagnostics.Debug.WriteLine("**** To Execute Query: " + DateTime.Now.Subtract(now).TotalSeconds.ToString() + "(s)");
#endif
               
                return Count;

                
            }
        }
        //static DateTime LastRun = DateTime.Now;
     /*   public virtual System.Collections.IList FetchRange(int startIndex, int count)
        {

            //  if (DateTime.Now.Subtract(LastRun).Seconds  < 3 ) return null;
            //DateTime ReqTime = DateTime.Now;
            lock (this)
            {
                //  LastRun = DateTime.Now;
                //if (DateTime.Now.Subtract(ReqTime).Seconds > 1) return null;
                //==============    if (BeforeLoad!=null) BeforeLoad();
                // IList<T> lst = Filter.Query.Skip(startIndex).Take(count).List();
                var crit = (ICriteria)Filter.Criteria.Clone();

                System.Collections.IList lst = crit.SetFirstResult(startIndex).SetMaxResults(count).List();
                //=========  if (AfterLoad != null) AfterLoad();
                return lst;
            }

        }*/
        public virtual Func<object[], string[], object> Transformer { get; set; }
        
        public virtual IList<T> FetchRange(int startIndex, int count)
        {
        
          //  if (DateTime.Now.Subtract(LastRun).Seconds  < 3 ) return null;
            //DateTime ReqTime = DateTime.Now;
            var session = DbSessionManager.GetSession();

            //lock (session)
            //{
                List<T> rtnlst = new List<T>
                ();

               /* if (typeof(T).ToString().ToLower().IndexOf("petiakwifiinvoice") > -1)
                {
                    Trace.WriteLine("Hello");
                }*/
                var crit = (ICriteria) Filter.Criteria.Clone();
                DateTime now = DateTime.Now;
                IList lst = crit.SetFirstResult(startIndex).SetMaxResults(count)
                   //MsdChanged in Future its better to use this. problem wit h menu loading .SetResultTransformer(new MsdLib.CSharp.DALCore.MsdNHTransFormer(this.Transformer))
                    .List();
#if DEBUG
                System.Diagnostics.Debug.WriteLine("**** To Execute Query: " + DateTime.Now.Subtract(now).TotalSeconds.ToString() + "(s)");
#endif

                
                foreach (T m in lst)
                    rtnlst.Add(m);
                //Close Criteria
//                Filter.Session.Close();
//                Filter.Session.Dispose();

                return rtnlst;
            //}
            
        }


        public object Clone()
        {
            ItemsProvider<T, FilterType> rtn = new ItemsProvider<T, FilterType>();
            rtn.Filter = (FilterType)
                (
                (object)this.Filter.Clone()
                );
            return rtn;
        }
    }
}
