using MsdLib.CSharp.DALCore;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MsdLib.CSharp.Utils
{
    public class AppUtils
    {
        public static string GetReferencedObjects(DbConnection con = null)
        {
            if (con == null)
            {
                con = (DbConnection)MsdLib.CSharp.DALCore.DbSessionManager.GetSession().Connection;
            }

            System.Text.StringBuilder result = new StringBuilder();
            Type t = con.GetType();
            object innerConnection = t.GetField("_innerConnection", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(con);
            Type tin = innerConnection.GetType();
            object rc;
            FieldInfo fi;
            if (con is System.Data.SqlClient.SqlConnection)
                fi = tin.BaseType.BaseType.GetField("_referenceCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            else
                fi = tin.BaseType.GetField("_referenceCollection", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fi == null)
                return "";
            rc = fi.GetValue(innerConnection);
            if (rc == null)
                return "";
            object items = rc.GetType().BaseType.GetField("_items", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rc);
            int count = Convert.ToInt32(items.GetType().GetProperty("Length", BindingFlags.Instance | BindingFlags.Public).GetValue(items, null));
            MethodInfo miGetValue = items.GetType().GetMethod("GetValue", new Type[] { typeof(int) });
            result.AppendFormat("<ReferencedItems timestamp=\"{0}\">" + Environment.NewLine, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            for (int i = 0; i < count; i++)
            {
                object referencedObj = miGetValue.Invoke(items, new object[] { i });
                bool hasTarget = Convert.ToBoolean(referencedObj.GetType().GetProperty("HasTarget").GetValue(referencedObj, null));
                if (hasTarget)
                {
                    bool inUse = Convert.ToBoolean(referencedObj.GetType().GetProperty("InUse").GetValue(referencedObj, null));
                    object objTarget = referencedObj.GetType().GetProperty("Target").GetValue(referencedObj, null);
                    result.AppendFormat("\t<Item id=\"{0}\" inUse=\"{1}\"  type=\"{2}\"  hashCode=\"{3}\">" + Environment.NewLine, i, inUse.ToString(), objTarget.GetType().ToString(), objTarget.GetHashCode().ToString());
                    DbCommand cmd = null;
                    if (objTarget is DbDataReader)
                    {
                        DbDataReader rdr = objTarget as DbDataReader;
                        try
                        {
                            cmd = objTarget.GetType().GetProperty("Command", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(objTarget, null) as DbCommand;
                        }
                        catch { }
                    }
                    else if (objTarget is DbCommand)
                        cmd = objTarget as DbCommand;
                    if (cmd != null)
                    {
                        PropertyInfo[] properties = cmd.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                        result.AppendFormat("\t\t<Command type=\"{0}\" hashCode=\"{1}\">" + Environment.NewLine, cmd.GetType().ToString(), cmd.GetHashCode().ToString());
                        foreach (PropertyInfo pi in properties)
                        {
                            if (pi.PropertyType.IsPrimitive || pi.PropertyType == typeof(string))
                                result.AppendFormat("\t\t\t<{0}>{1}</{0}>" + Environment.NewLine, pi.Name, pi.GetValue(cmd, null).ToString());
                            if (pi.PropertyType == typeof(DbConnection) && pi.Name == "Connection")
                            {
                                DbConnection con1 = pi.GetValue(cmd, null) as DbConnection;
                                result.AppendFormat("\t\t\t<Connection type=\"{0}\" hashCode=\"{1}\">" + Environment.NewLine, con1.GetType().ToString(), con1.GetHashCode().ToString());
                                PropertyInfo[] propertiesCon = con1.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                                result.AppendFormat("\t\t\t\t<State>{0}</State>" + Environment.NewLine, con1.State.ToString());
                                foreach (PropertyInfo picon in propertiesCon)
                                {
                                    if (picon.PropertyType.IsPrimitive || picon.PropertyType == typeof(string))
                                        result.AppendFormat("\t\t\t\t<{0}>{1}</{0}>" + Environment.NewLine, picon.Name, picon.GetValue(con1, null).ToString());
                                }
                                result.Append("\t\t\t</Connection>" + Environment.NewLine);
                            }
                        }
                        result.AppendFormat("\t\t</Command>" + Environment.NewLine);
                    }
                    result.AppendFormat("\t</Item>" + Environment.NewLine);
                }
            }
            result.AppendFormat("</ReferencedItems>" + Environment.NewLine);
            return result.ToString();
        }
        public static void ResumeNext(Action inpfunc)
        {
            try
            {
                inpfunc();
            }
            catch(Exception ex)
            {
            }
        }
        public static Type GetGenericTypeConstructor(Type generic, int ArgumentIndex)
        {
            var rtn = generic.GetGenericArguments();
            if (rtn != null)
                if (rtn.Length > 0)
                    return rtn[ArgumentIndex];
            return null;
        }

        public static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
        public static Object GetObjectFromString(Type targetType, object value)
        {
            if(IsSubclassOfRawGeneric(typeof(Array),value.GetType()))
                return value;
            if (value.GetType().FullName == "Newtonsoft.Json.Linq.JArray")
                return value;
            if (value.GetType().FullName == "Newtonsoft.Json.Linq.JValue")
                return GetObjectFromString(targetType, value.ToString());
            return GetObjectFromString(targetType, (string)value);
        }
        public static Object GetObjectFromString(Type targetType, string value)
        {
            if (targetType == typeof(Boolean) || targetType == typeof(Boolean?))
            {
                Boolean rtn;
                if (Boolean.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if(targetType==typeof(bool) || targetType==typeof(bool?))
            {
                 bool rtn;
                if (bool.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if (targetType == typeof(int) || targetType== typeof(int?))
            {
                int rtn;
                if (int.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if (targetType == typeof(double) || targetType == typeof(double?))
            {
                double rtn;
                if (double.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if (targetType == typeof(DateTime) || targetType == typeof(DateTime?))
            {
                DateTime rtn;
                if (DateTime.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;

            }
            if (targetType == typeof(Int64) || targetType == typeof(Int64?))
            {
                Int64 rtn;
                if (Int64.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;

            }
            if (targetType == typeof(Guid) || targetType == typeof(Guid?))
            {
                Guid rtn;
                if (Guid.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if (targetType == typeof(byte) || targetType == typeof(byte?))
            {
                byte rtn;
                if (byte.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if(targetType==typeof(Byte) || targetType==typeof(Byte?))
            {
                  Byte rtn;
                if (Byte.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;
            }
            if (targetType == typeof(sbyte) || targetType == typeof(sbyte?))
            {
                sbyte rtn;
                if (sbyte.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;

            }

            if (targetType == typeof(SByte) || targetType == typeof(SByte?))
            {
                SByte rtn;
                if (SByte.TryParse(value, out rtn))
                    return rtn;
                else
                    return null;

            }

                
            if (targetType == typeof(string))
                return value;

            if (targetType.IsSubclassOf(typeof(Enum)))
            {
                object rtn=null;
                AppUtils.ResumeNext(()=>
                    rtn = Enum.Parse(targetType, value)
                        );
                return rtn;
            }
                
            return null;
        }
        public static string GenerateSQL(ICriteria criteria)
        {
            NHibernate.Impl.CriteriaImpl criteriaImpl = (NHibernate.Impl.CriteriaImpl)criteria;
            NHibernate.Engine.ISessionImplementor session = criteriaImpl.Session;
            NHibernate.Engine.ISessionFactoryImplementor factory = session.Factory;

            NHibernate.Loader.Criteria.CriteriaQueryTranslator translator =
                new NHibernate.Loader.Criteria.CriteriaQueryTranslator(
                    factory,
                    criteriaImpl,
                    criteriaImpl.EntityOrClassName,
                    NHibernate.Loader.Criteria.CriteriaQueryTranslator.RootSqlAlias);

            String[] implementors = factory.GetImplementors(criteriaImpl.EntityOrClassName);

            NHibernate.Loader.Criteria.CriteriaJoinWalker walker = new NHibernate.Loader.Criteria.CriteriaJoinWalker(
                (NHibernate.Persister.Entity.IOuterJoinLoadable)factory.GetEntityPersister(implementors[0]),
                                    translator,
                                    factory,
                                    criteriaImpl,
                                    criteriaImpl.EntityOrClassName,
                                    session.EnabledFilters);

            return walker.SqlString.ToString();
        }
        //public static void DoEvents()
        //{
        //    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
        //                                          new Action(delegate { }));
        //}
        public static string GPN<T, Tout>(Expression<Func<T, Tout>> exp) //Get Property Name 
            where Tout : class
            where T : class
        {
            string[] arr = exp.Body.ToString().Replace("Convert(", "").Replace(")", "").Split('.');
            return string.Join(".", arr, 1, arr.Length - 1);
        }

        public static string GPN<T>(Expression<Func<T, object>> exp, bool cancelindex = false) //Get Property Name 
        {
          
            string[] arr = exp.Body.ToString().Replace("Convert(", "").Replace(")", "").Split('.');
            var rtn = string.Join(".", arr, 1, arr.Length - 1);
            if (cancelindex)
                rtn = rtn.Replace(".get_Item(0","");
            return rtn;
        }
        public static Type NewInstance<Type>()
        {
            return Activator.CreateInstance<Type>();
        }
        public static dynamic NewInstance(Type t)
        {
            return Activator.CreateInstance(t);
            
        }

        public static void SetProperty(object obj, string propname, object value,bool recursive=true)
        {
            
            obj.GetType().GetProperty(propname).SetValue(obj, value, null);
        }
        public static dynamic GetProperty(object obj, string propname)
        {
            //For Recursive propname
            var parts = propname.Split('.');
            object value = obj;
            if (parts.Length > 1)
            {
                foreach (var prop in parts)
                {
                    value = GetProperty(value, prop);
                    if (value == null) return value;
                }
            } else
                 value = obj.GetType().GetProperty(propname).GetValue(obj, null); 
            return value;
        }
        public static dynamic CallMethod(object obj, string methodName, object[] pars)
        {
            return obj.GetType().GetMethod(methodName).Invoke(obj, pars);
        }

        public static string TableName<Model>()
            where Model : ModelBase<Model>
        {
            return "IrErpTb_"+typeof(Model).Name;
        }
        public static void CopyObjByPropName(object From,object To,string[] DontCopy= null)
        {
            if(To==null || From==null)
                return;
            From.GetType().GetProperties()
                .ToList().ForEach(x => {
                    try
                    {
                        if (DontCopy != null && DontCopy.Contains(x.Name)) return;
                            
                        SetProperty(To, x.Name, GetProperty(From, x.Name), false);
                    }
                    catch { }
                });
        }
    }
}
