using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MsdLib.CSharp.Types;
namespace MsdLib.Types.NH
{
    public class PersianDateUserType : IUserType
    {
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object DeepCopy(object value)
        {
            if (value == null) return null;
            return ((ICloneable)value).Clone();
        }

        public object Disassemble(object value)
        {
            return value;
        }


        public int GetHashCode(object x)
        {
            if (x != null) return x.GetHashCode();
            return 0;

        }

        public bool IsMutable
        {
            get { return false; }
        }

        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            string data = NHibernateUtil.String.NullSafeGet(rs, names[0]) as string;
            PersianDateTime rtn = PersianDateTime.ParsePersian(data);
            return  rtn;
        }

        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            IDbDataParameter p = cmd.CreateParameter();

            p.ParameterName = ((IDbDataParameter)cmd.Parameters[index]).ParameterName;
            p.Value = value.ToString();
            cmd.Parameters[index] = p;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public Type ReturnedType
        {
            get { return typeof(PersianDateTime); }
        }

        public NHibernate.SqlTypes.SqlType[] SqlTypes
        {
            get { return (new SqlType[] { new SqlType(DbType.String) }); }
        }
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }




        public new bool  Equals(object x, object y)
        {
            throw new NotImplementedException();
        }
    }
}