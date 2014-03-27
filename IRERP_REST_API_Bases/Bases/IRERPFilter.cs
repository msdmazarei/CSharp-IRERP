using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.BLLCore;
using MsdLib.ExtentionFuncs.Strings;
using System.Linq.Expressions;
namespace IRERP_RestAPI.Bases
{
   
    public class IRERPFilter<MyType,T>: MsdLib.CSharp.BLLCore.FilterBase<MyType,T>
        where MyType: IRERPFilter<MyType,T>
        where T : ModelBase
    {
        public virtual ICriteria AddAlias(string OldPath, string CurrPath, ICriteria CurrentQuery)
        {
            Type LastAvailablePropertyType =null;
            List<string> RemainPath = new List<string>();
            RemainPath.AddRange(CurrPath.Substring(OldPath.Length, CurrPath.Length - OldPath.Length).Split('.'));
            if (OldPath.Length>0)
            {
               LastAvailablePropertyType=  IRERPApplicationUtilities.GetClassPropertyType(typeof(T), OldPath.Split('.'));
            }
            else
            {
                LastAvailablePropertyType = typeof(T);
            }
            string createdpath = OldPath;
            Type curType = LastAvailablePropertyType;
            foreach (var prop in RemainPath)
            {
                if (prop.Length < 1) continue;
                //Check That CurType is IList<A> ,if is thencurType = A
                if(IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>),curType))
                    curType= IRERPApplicationUtilities.GetGenericTypeConstructor(curType, 0);

                var modelinstance = IRERPApplicationUtilities.NewInstance(curType);
                var relationinfo = modelinstance.GetAssociation(prop);
                string curalias = createdpath.ToAliasName();//.Replace(".", "___");
                string basealias = createdpath.ToAliasName();//.Replace(".", "___");
                if (basealias.Length > 0) basealias += ".";
                if (curalias.Length > 0) 
                    curalias += "___" + prop;
                else 
                    curalias = prop;

                CurrentQuery.CreateAlias(basealias+relationinfo.Item1, curalias, relationinfo.Item2, relationinfo.Item3);
                

                curType = IRERPApplicationUtilities.GetClassPropertyType(curType, prop);


            }
           
            return CurrentQuery;
        }
        public virtual List<string> AdditionalJoinTables { get; set; }
        public IRERPFilter() :base()
        {
            AdditionalJoinTables = new List<string>();
        }
        public override ICriteria Criteria
        {
            get
            {
                var crit = Query.RootCriteria;
                

                List<string> joinTables = new List<string>();
                Action<string> addtojointable =
                    x =>
                    {
                        if (x != null)
                        {
                            var parts = x.Split('.');
                            if (parts.Length > 1)
                            {
                                string joinpath = string.Join(".", parts, 0, parts.Length - 1);
                                //Check that joinpath was not a NHComponent
                                if (!joinTables.Contains(joinpath))
                                    joinTables.Add(joinpath);
                            }
                        }
                    };
                if (Orders != null) if (Orders.Count > 0) 
                    Orders.ForEach(x => addtojointable(x.PropertyName));
                
                AdditionalJoinTables.ForEach(x => {
                 
                    if (!joinTables.Contains(x))
                        joinTables.Add(x);
                });

                List<string> AllPropertiesName = new List<string>();
                Func<MsdCriteria,List<string>> GetPropsName = null;
                
                GetPropsName = x=>
                {
                    List<string> rtn = new List<string>();
                    if (x.Operator == MsdCriteriaOperator.or || x.Operator == MsdCriteriaOperator.and || x.Operator == MsdCriteriaOperator.not)
                    {
                        if (x.criteria != null)
                            x.criteria.ToList().ForEach(y => rtn.AddRange(GetPropsName(y)));
                    }else
                    rtn.Add(x.PropertyName);
                    return rtn;
                };
                if (Criterias != null) if (Criterias.Count > 0)
                        Criterias.ForEach(x =>  
                            AllPropertiesName.AddRange(GetPropsName(x))
                        );
                    
                AllPropertiesName.ForEach(x => addtojointable(x));

                List<string> GeneratedPathes = new List<string>();
                
                if (joinTables != null)
                    if (joinTables.Count > 0)
                    {

                        ///Remove IREPComponent From joinTables
                        joinTables.ToList().ForEach(x => { 
                            Type JoinPathType = IRERPApplicationUtilities.GetClassPropertyType(typeof(T), x);
                            if (IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IRERP_RestAPI.Bases.NHComponents.IRERPNHComponent), JoinPathType))
                                joinTables.Remove(x);
                        });

                        joinTables.ForEach(
                            x =>
                            {
                                string[] subAliases = x.Split('.');
                                string currentPath = "";
                                subAliases.ToList().ForEach(
                                    y =>
                                    {
                                        string oldPath = currentPath;
                                        if (currentPath != "")
                                            currentPath += "." + y;
                                        else
                                            currentPath = y;
                                        if (!GeneratedPathes.Contains(currentPath))
                                        {
                                            crit = AddAlias(oldPath, currentPath, crit);
                                            string addedPath = oldPath;
                                            currentPath.Substring(oldPath.Length, currentPath.Length - oldPath.Length).Split('.').ToList().ForEach(
                                                z =>
                                                {
                                                    if (z.Length < 1) return;
                                                    if (addedPath.Length > 0)
                                                        addedPath += "." + z;
                                                    else
                                                        addedPath = z;
                                                    GeneratedPathes.Add(addedPath);
                                                });
                                            
                                        }
                                    }
                                );

                            }
                        );
                    }

                T _tmp = IRERPApplicationUtilities.NewInstance<T>();

   
                //var sql = IRERPApplicationUtilities.GenerateSQL(crit);
                crit.ClearOrders(); //Clear Orders before adding them
                List<string> _orders = new List<string>();
                Orders.ForEach(
                    x =>{
                        if (_orders.Contains(x.PropertyName)) return;
                        crit.AddOrder(_tmp.GetOrder(x));
                        _orders.Add(x.PropertyName);
                    }
                    );
                Criterias.ForEach(x => 
                    {
                        var a = _tmp.GetCritertion(x);
                        if (a != null)
                            crit.Add(a);
                        else
                        {
                            throw new Exception("Can Not Get Criterion");
                        }

                    }
                    );
            //    sql = IRERPApplicationUtilities.GenerateSQL(crit);

                return crit;
            }
        }
        public override NHibernate.IQueryOver<T, T> Query
        {
            get
            {
                var _Query =  base.Query;
               
                return _Query;
            }
            set
            {
                base.Query = value;
            }
        }
        public override object Clone()
        {
            IRERPFilter<MyType, T> rtn = (IRERPFilter<MyType, T>)base.Clone();
           rtn.Orders = new List<MsdLib.CSharp.BLLCore.OrderBy>();
           rtn.Orders.AddRange(this.Orders);
           rtn.Criterias = new List<MsdLib.CSharp.BLLCore.MsdCriteria>();
           rtn.Criterias.AddRange(this.Criterias);
           return rtn;
        }
                public virtual void AddSimpleCriteria(Expression<Func<T, object>> path, MsdCriteriaOperator op, dynamic value)
        {
            this.Criterias.Add(new MsdCriteria() { fieldName = GPN(path), Operator = op, value = value });
        }
                public virtual void AddSimpleCriteria(NHibernate.Criterion.ICriterion Criterion)
                {
                    MsdCriteria crit = new MsdCriteria() { Criterion = Criterion };
                    this.Criterias.Add(crit);
                }

    }
}