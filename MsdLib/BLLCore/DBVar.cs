using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MsdLib.ExtentionFuncs.ObjectFuncs;
namespace MsdLib.CSharp.BLLCore
{
    public class DBVar<T> :  IUserType,ICloneable
    {
        T _value;
        bool _isloaded=false;
        public virtual T value { get { return _value; } set { _value = value; isLoaded = true; } }
        public virtual bool isLoaded { get { return _isloaded; } set { _isloaded = value; } }

        public static implicit operator T(DBVar<T> rhs)
        {
            if (rhs != null)
                return rhs.value;
            else
                return default(T);
        }
        public static implicit operator DBVar<T>(T rhs)
        {
            return new DBVar<T>()
            {
                value =rhs
            };
        }

    

        public override string ToString()
        {
            return value.ToString();
        }


        public virtual object Assemble(object cached, object owner)
        {
            return cached;
        }

        public virtual object DeepCopy(object value)
        {
            if (value == null) return null;
            return ((ICloneable)value).Clone();
        }

        public virtual object Disassemble(object value)
        {
            return value;
        }


        public virtual int GetHashCode(object x)
        {
            if (x != null) return x.GetHashCode();
            return 0;

        }

        public virtual  bool IsMutable
        {
            get { return false; }
        }

        public virtual object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            object rtn = null;
            if (typeof(T) == typeof(Int16) || typeof(T) == typeof(Int16?))
                rtn = new DBVar<T>() { value = (T)NHibernateUtil.Int16.NullSafeGet(rs, names[0]) };
            else
                if (typeof(T) == typeof(Int32) || typeof(T) == typeof(Int32?))
                    rtn = new DBVar<T>() { value = (T)NHibernateUtil.Int32.NullSafeGet(rs, names[0]) };
                else
                    if (typeof(T) == typeof(Int64) || typeof(T) == typeof(Int64?))
                        rtn = new DBVar<T>() { value = (T)NHibernateUtil.Int64.NullSafeGet(rs, names[0]) };
                    else
                        if (typeof(T) == typeof(string))
                            rtn = new DBVar<string>() { value = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]) };
                        else
                            if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?))
                                rtn = new DBVar<T>() { value = (T)NHibernateUtil.DateTime.NullSafeGet(rs, names[0]) };
                            else
                                if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?) || typeof(T) == typeof(Boolean) || typeof(T) == typeof(Boolean?))
                                    rtn = new DBVar<T>() { value = (T)NHibernateUtil.Boolean.NullSafeGet(rs, names[0]) };
                                else
                                    if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
                                        rtn = new DBVar<T>() { value = (T)NHibernateUtil.Double.NullSafeGet(rs, names[0]) };

            return rtn;
            //Byte[] data = NHibernateUtil.NullSafeGet(rs, names[0]) as Byte[];
            //return data;
        }

        public virtual void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            IDbDataParameter p = cmd.CreateParameter();

            p.ParameterName = ((IDbDataParameter)cmd.Parameters[index]).ParameterName;
            if (
                Utils.AppUtils.IsSubclassOfRawGeneric(typeof(CSharp.BLLCore.DBVar<>),
                value.GetType())
                )
            {
                p.Value = ((CSharp.BLLCore.DBVar<T>)value).value;
            }
            else
                p.Value = value;
            cmd.Parameters[index] = p;
        }

        public virtual object Replace(object original, object target, object owner)
        {
            return original;
        }

        public virtual Type ReturnedType
        {
            get
            {
                return this.GetType();
            }
        }

        public virtual NHibernate.SqlTypes.SqlType[] SqlTypes
        {
            get
            {
                DbType ty = DbType.String;
                if (typeof(T) == typeof(string)) ty = DbType.String;
                else
                    if (typeof(T) == typeof(Int16) || typeof(T) == typeof(Int16?)) ty = DbType.Int16;
                    else
                        if (typeof(T) == typeof(Int32)||typeof(T)==typeof(Int32?)) ty = DbType.Int32;
                        else
                            if (typeof(T) == typeof(Int64) || typeof(T) == typeof(Int64?)) ty = DbType.Int64;
                            else
                                if (typeof(T) == typeof(double) || typeof(T) == typeof(double?)) ty = DbType.Double;
                                else
                                    if (typeof(T) == typeof(Boolean)
                                        || typeof(T)== typeof(bool)
                                        || typeof(T)==typeof(bool?) 
                                        || typeof(T)==typeof(Boolean?)
                                        ) ty = DbType.Boolean;
                return (new SqlType[] { new SqlType(ty) });
            }
        }
        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }


        public virtual bool Equals(object x, object y)
        {
            return x.GetHashCode() == y.GetHashCode();
        }


        public virtual object Clone()
        {
            object a  = this;
            return a.Clone();
        }
    }
}
