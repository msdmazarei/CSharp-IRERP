using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MsdLib.CSharp.DALCore
{
    [Serializable]
    public class MsdNHTransFormer : IResultTransformer
    {
        private Func<object[], string[], object> transformer=null;

        public MsdNHTransFormer(Func<object[],string[],object> TransFormer)
        {
            if (TransFormer == null)
            {
                throw new ArgumentNullException("TransFormer");
            }
            this.transformer = TransFormer;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
                return transformer(tuple,aliases);
          
        }

        public IList TransformList(IList collection)
        {
            return collection;
        }

        public bool Equals(MsdNHTransFormer other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.transformer, transformer);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as MsdNHTransFormer);
        }

        public override int GetHashCode()
        {
            return transformer.GetHashCode();
        }
    }
}
