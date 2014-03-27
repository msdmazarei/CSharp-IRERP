using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.CSharp.DataVirtualization;
using IRERP_RestAPI.Bases.Extension.Methods;
using MsdLib.ExtentionFuncs.Strings;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using NHibernate;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.BLLCore;
namespace IRERP_RestAPI.Bases.DataVirtualization
{
    public class IRERPVList_ParentChildSpec<TParent,TChild,TFilter> : IRERPVList<TChild,TFilter>
        where TChild : ModelBase
        where TFilter : IRERPFilter<TFilter,TChild>
        where TParent : ModelBase
    {
        protected void GeneralCollectionOpSets()
        {
            this.AddToCollection = new Func<TParent, TChild, FunctionResult<INHibernateEntity>>(GeneralAddToCollection);
            this.RemoveFromCollection = new Func<TParent, TChild, FunctionResult<INHibernateEntity>>(GeneralRemoveFromCollection);
        }
        #region CTOR
        public IRERPVList_ParentChildSpec() : base()
        {GeneralCollectionOpSets();}
        public IRERPVList_ParentChildSpec(IItemsProvider<TChild> i ):base(i)
        { GeneralCollectionOpSets(); }
        public IRERPVList_ParentChildSpec(IItemsProvider<TChild> itemPr,int PageSize):base(itemPr,PageSize)
        { GeneralCollectionOpSets(); }
        public IRERPVList_ParentChildSpec(IItemsProvider<TChild> itemPr, int PageSize, int Timeout)
            : base(itemPr, PageSize, Timeout)
        { GeneralCollectionOpSets(); }
        #endregion 
        public static FunctionResult<INHibernateEntity> GeneralAddToCollection(TParent parent, TChild child)
        {
            throw new NotImplementedException();
        }

        public static FunctionResult<INHibernateEntity> GeneralRemoveFromCollection(TParent parent, TChild child)
        {
            throw new NotImplementedException();
        }

        public virtual TParent ParentInstance { get; set; }
        public virtual Func<TParent, TChild, FunctionResult<INHibernateEntity>> AddToCollection { get; set; }
        public virtual Func<TParent, TChild, FunctionResult<INHibernateEntity>> RemoveFromCollection { get; set; }
        public override void Remove(TChild Item)
        {
            if (RemoveFromCollection != null)
                RemoveFromCollection(ParentInstance, Item);
            else 
                base.Remove(Item);
        }
        public override void Add(TChild item)
        {
            if(this.AddToCollection!=null)
            this.AddToCollection(ParentInstance, item);
            else
            base.Add(item);
        }
        
        
    }
}
