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
namespace IRERP_RestAPI.Bases.DataVirtualization
{
    public class IRERPVList<T,FilterType> :
        VirtualizingCollection<T>, ICloneable, ITypedList
        where FilterType : IRERPFilter<FilterType,T>
        where T: MsdLib.CSharp.DALCore.ModelBase
        
    {
        
        public virtual object TransFormer(object[] Tuples, string[] aliases)
        {
            
            Dictionary<int, Dictionary<string, object>> tran = new Dictionary<int, Dictionary<string, object>>();
            Dictionary<string, object> listreplacer = new Dictionary<string, object>();

            for (int i = 0; i < aliases.Length; i++)
            {
                if (aliases[i] == null) continue;
                string alias = aliases[i].FromAliasName();
                int aliasparts = alias.Split('.').Length;

                if (!tran.Keys.Contains(aliasparts))
                    tran.Add(aliasparts, new Dictionary<string, object>());

                tran[aliasparts].Add(alias, Tuples[i]);
            }
            var sortedaliasparts = (from x in tran.Keys orderby x select x).ToList();
            object rtn = tran[1]["this"];

            Action<string,object> SaveValue = new Action<string,object>(
                (fullproppath,value) => {
                if (listreplacer.Count > 0)
                {
                    List<string> keyList = listreplacer.Keys.ToList();
                    for (var i = listreplacer.Keys.Count - 1; i >= 0; i--)
                    {
                        string key = keyList[i];
                        if (fullproppath.IndexOf(key) > -1)
                        {
                            string newpath = fullproppath.Substring(key.Length+1/*for .*/,fullproppath.Length-key.Length-1);
                            IRERPApplicationUtilities.SetProperty(listreplacer[key], newpath, value, true);
                            break;
                        }
                    }
                }
                else
                {
                    IRERPApplicationUtilities.SetProperty(rtn, fullproppath, value);
                }

            });


            sortedaliasparts.ForEach(x =>
            {
                tran[x].Keys.ToList().ForEach(y =>
                {
                    if (y == "this") return;
                    Type propty = IRERPApplicationUtilities.GetClassPropertyType(rtn.GetType(), y);
                    //Implemented IList Type
                    if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>), propty))
                    {

                        if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>), tran[x][y].GetType()))
                            IRERPApplicationUtilities.SetProperty(rtn, y, tran[x][y]);
                        else
                        {
                            //List Property
                            listreplacer.Add(y, tran[x][y]);
                        }

                    }
                    else
                        SaveValue(y, tran[x][y]);
                });
            });
            if (listreplacer.Count > 0)
            {
                List<string> keys = listreplacer.Keys.ToList();
                for (int i = keys.Count - 1; i > 0; i--)
                {
                    Type generictype = typeof(List<>).MakeGenericType(listreplacer[keys[i]].GetType());
                    IList inst = IRERPApplicationUtilities.NewInstance(generictype);
                    inst.Add(listreplacer[keys[i]]);
                    string proppath = keys[i].Substring(keys[i-1].Length+1,keys[i].Length-keys[i-1].Length-1);
                    IRERPApplicationUtilities.SetProperty(listreplacer[keys[i]], proppath,inst,true);

                }
                Type generictypeMain = typeof(List<>).MakeGenericType(listreplacer[keys[0]].GetType());
                IList instMain = IRERPApplicationUtilities.NewInstance(generictypeMain);
                instMain.Add(listreplacer[keys[0]]);
                string proppathMain = keys[0];
                IRERPApplicationUtilities.SetProperty(rtn, proppathMain,instMain, true);
            }
            return rtn;
        }
        public FilterType Filter {
            get{
                return
                    (
                    (ItemsProvider<T,FilterType>)
                    this.ItemsProvider
                    )
                    .Filter;
            }
            set{
                (
                 (ItemsProvider<T,FilterType>)
                  this.ItemsProvider
                )
                    .Filter=value
                    ;
            }
        }

       // IItemsProvider<T> itemProvider1;
        public IRERPVList(IItemsProvider<T> itemPr)
            : base(itemPr)
        {
            ((MsdLib.CSharp.
                DataVirtualization
                .ItemsProvider<T, FilterType>)
                this.ItemsProvider)
                .Transformer = new Func<object[],string[],object>(
                    //(new NHibernate.Transform.ToListResultTransformer()).TransformTuple
                    this.TransFormer
                    )
                ;
        }
        public IRERPVList(IItemsProvider<T> itemPr,int PageSize)
            : base(itemPr,PageSize)
        {
            (
                (
                    MsdLib.CSharp.
                    DataVirtualization.
                    ItemsProvider<T, FilterType>
                )
                this.ItemsProvider
                )
                .Transformer = new Func<object[], string[], object>(
                    //(new NHibernate.Transform.ToListResultTransformer()).TransformTuple
                    this.TransFormer
                    )
                ;
            
        }
        public IRERPVList(IItemsProvider<T> itemPr,int PageSize,int Timeout)
            : base(itemPr,PageSize,Timeout)
        {
            
            ((MsdLib.CSharp.
                DataVirtualization
                .ItemsProvider<T, FilterType>)
                this.ItemsProvider)
                .Transformer = new Func<object[], string[], object>(
                    //(new NHibernate.Transform.ToListResultTransformer()).TransformTuple
                    this.TransFormer
                    )
                ;            
             
        }
        public IRERPVList()
            :base(null)
        {
        }
        public object Clone()
        {

            IRERPVList<T, FilterType> rtn = new IRERPVList<T, FilterType>(
                (ItemsProvider<T,FilterType>)this.ItemsProvider.Clone(), 
                this.PageSize, 
               (int) this.PageTimeout);
            rtn.Filter = (FilterType)
                (
                (object)this.Filter.Clone()
                );
            return rtn;

        }
        #region "Use In StimulSoftReport"
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyInfo[] props = typeof(T).GetProperties();
            PropertyDescriptor[] descs = new PropertyDescriptor[props.Length];

            int index = 0;
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name.ToLower().IndexOf("user") > -1) continue;
                if(prop.DeclaringType.Name.ToLower().IndexOf("user")>-1) continue;
                descs[index] = new PropertyDescriptor<T>(prop.Name);//new PhonePropertyDescriptor(prop.Name);
                index++;
            }
            return new PropertyDescriptorCollection(descs);
            
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }
        #endregion
    }
}