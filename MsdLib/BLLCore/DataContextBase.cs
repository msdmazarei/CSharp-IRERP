using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.DataVirtualization;
using System.Linq.Expressions;
using MsdLib.CSharp.Utils;

namespace MsdLib.CSharp.BLLCore
{
    public class DataContextBase<T, TargetType, FilterType, ItemProviderType,ApplicationGlobalVariable> : INotifyPropertyChanged
        where T : DataContextBase<T, TargetType, FilterType, ItemProviderType, ApplicationGlobalVariable>
        where ItemProviderType : ItemsProvider<TargetType, FilterType>
        where FilterType : FilterBase<TargetType>
        where TargetType : ModelBase<TargetType>
        where ApplicationGlobalVariable: ApplicationGlobalVariables<ApplicationGlobalVariable>
    {
        ItemProviderType _ItemsProvider;

        
        public virtual ApplicationGlobalVariable App { get { return null; } }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));
        }
        public string _GPN(Expression<Func<T, Object>> exp)
        {
            return AppUtils.GPN<T>(exp);
        }
        public virtual FilterType Filter
        {
            get
            {
                return _ItemsProvider.Filter;
            }
            set { _ItemsProvider.Filter = value; OnPropertyChanged(_GPN(x => x.Filter)); }
        }

        TargetType _formitem;
        public virtual TargetType FormItem
        {
            get { return _formitem; }
            set { _formitem = value; OnPropertyChanged(_GPN(x => x.FormItem)); }
        }

        protected IList<TargetType> _all;
        public virtual IList<TargetType> All { get { return _all; } set { _all = value; OnPropertyChanged(_GPN(x => x.All)); } }

        AsyncVirtualizingCollection<TargetType> _asynvirtAll;
        public virtual AsyncVirtualizingCollection<TargetType> asynvirtAll { get { return _asynvirtAll; } set { _asynvirtAll = value; OnPropertyChanged(_GPN(x => x.asynvirtAll)); } }

        public void ReNewCollection()
        {
            _asynvirtAll = new AsyncVirtualizingCollection<TargetType>(_ItemsProvider, 200);
            OnPropertyChanged(_GPN(x => x.asynvirtAll));
        }

        public DataContextBase()
        {
            //object[] parameters = { _filter };
            Type _t = typeof(ItemProviderType);
            _ItemsProvider = Activator.CreateInstance<ItemProviderType>();
            object[] parameters = new object[] { _ItemsProvider, 50 };
            _asynvirtAll = (AsyncVirtualizingCollection<TargetType>)Activator.CreateInstance(typeof(AsyncVirtualizingCollection<TargetType>), parameters);
        }

    }
}
