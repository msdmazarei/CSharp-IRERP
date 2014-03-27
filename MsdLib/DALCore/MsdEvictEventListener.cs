using NHibernate;
using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Event.Default;
using NHibernate.Impl;
using NHibernate.Persister.Entity;
using NHibernate.Proxy;
using NHibernate.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MsdLib.CSharp.DALCore
{
    public class MsdEvictEventListener : DefaultEvictEventListener
    {
        protected override void DoEvict(object obj, EntityKey key, IEntityPersister persister, IEventSource session)
        {
            base.DoEvict(obj, key, persister, session);
            DBFactory.Instance.ClearMsdCache();
        }
    }
}
