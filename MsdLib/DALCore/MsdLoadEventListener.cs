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
    public class MsdLoadEventListener : DefaultLoadEventListener
    {

        /// <summary>
        /// Given that there is a pre-existing proxy.
        /// Initialize it if necessary; narrow if necessary.
        /// </summary>
        private object ReturnNarrowedProxy(LoadEvent @event, IEntityPersister persister, EntityKey keyToLoad, LoadType options, IPersistenceContext persistenceContext, object proxy)
        {
            var castedProxy = (INHibernateProxy)proxy;
            ILazyInitializer li = castedProxy.HibernateLazyInitializer;
            if (li.Unwrap)
            {
                return li.GetImplementation();
            }
            object impl = null;
            if (!options.IsAllowProxyCreation)
            {
                impl = Load(@event, persister, keyToLoad, options);
                // NH Different behavior : NH-1252
                if (impl == null && !options.IsAllowNulls)
                {
                    @event.Session.Factory.EntityNotFoundDelegate.HandleEntityNotFound(persister.EntityName, keyToLoad.Identifier);
                }
            }
            if (impl == null && !options.IsAllowProxyCreation && options.ExactPersister)
            {
                // NH Different behavior : NH-1252
                return null;
            }
            return persistenceContext.NarrowProxy(castedProxy, persister, keyToLoad, impl);
        }


        /// <summary>
        /// Given that there is no pre-existing proxy.
        /// Check if the entity is already loaded. If it is, return the entity,
        /// otherwise create and return a proxy.
        /// </summary>
        private object CreateProxyIfNecessary(LoadEvent @event, IEntityPersister persister, EntityKey keyToLoad, LoadType options, IPersistenceContext persistenceContext)
        {
            object existing = persistenceContext.GetEntity(keyToLoad);
            if (existing != null)
            {
                // return existing object or initialized proxy (unless deleted)
                
                if (options.IsCheckDeleted)
                {
                    EntityEntry entry = persistenceContext.GetEntry(existing);
                    Status status = entry.Status;
                    if (status == Status.Deleted || status == Status.Gone)
                    {
                        return null;
                    }
                }
                return existing;
            }
            else
            {
                
                // return new uninitialized proxy
                object proxy = persister.CreateProxy(@event.EntityId, @event.Session);
                persistenceContext.BatchFetchQueue.AddBatchLoadableEntityKey(keyToLoad);
                persistenceContext.AddProxy(keyToLoad, (INHibernateProxy)proxy);
                ((INHibernateProxy)proxy)
                    .HibernateLazyInitializer
                    .ReadOnly = @event.Session.DefaultReadOnly || !persister.IsMutable;
                return proxy;
            }
        }


        protected override object DoLoad(LoadEvent @event, IEntityPersister persister, EntityKey keyToLoad, LoadType options)
        {
            return base.DoLoad(@event, persister, keyToLoad, options);
        }
        protected override object LoadFromSessionCache(LoadEvent @event, EntityKey keyToLoad, LoadType options)
        {
            return base.LoadFromSessionCache(@event, keyToLoad, options);
        }
        protected override object LoadFromSecondLevelCache(LoadEvent @event, IEntityPersister persister, LoadType options)
        {
            return base.LoadFromSecondLevelCache(@event, persister, options);
        }
        
        protected override object Load(
            NHibernate.Event.LoadEvent @event, 
            NHibernate.Persister.Entity.IEntityPersister persister, 
            NHibernate.Engine.EntityKey keyToLoad, 
            NHibernate.Event.LoadType options)
        {
            return base.Load(@event, persister, keyToLoad, options);
        }
        protected override object ProxyOrLoad(
            NHibernate.Event.LoadEvent @event, 
            NHibernate.Persister.Entity.IEntityPersister persister, 
            NHibernate.Engine.EntityKey keyToLoad, 
            NHibernate.Event.LoadType options)
        {
        
            if (!persister.HasProxy)
            {
                // this class has no proxies (so do a shortcut)
                return Load(@event, persister, keyToLoad, options);
            }
            else
            {
                IPersistenceContext persistenceContext = @event.Session.PersistenceContext;

                // look for a proxy
                object proxy = persistenceContext.GetProxy(keyToLoad);
                if (proxy != null)
                {
                    return ReturnNarrowedProxy(@event, persister, keyToLoad, options, persistenceContext, proxy);
                }
                else
                {
                    bool isIRERPModelBase = true;
                    
                    if (options.IsAllowProxyCreation || isIRERPModelBase)
                    {
                        return CreateProxyIfNecessary(@event, persister, keyToLoad, options, persistenceContext);
                    }
                    else
                    {
                        // return a newly loaded object
                        return Load(@event, persister, keyToLoad, options);
                    }
                }
            }

            //OLD Method:
            //return base.ProxyOrLoad(@event, persister, keyToLoad, options);
        }
        protected override object LoadFromDatasource(
            NHibernate.Event.LoadEvent @event, 
            NHibernate.Persister.Entity.IEntityPersister persister, 
            NHibernate.Engine.EntityKey keyToLoad, 
            NHibernate.Event.LoadType options)
        {
            
            var msdcache = DBFactory.Instance.MsdCache();
            
            if (msdcache.Keys.Contains(keyToLoad.EntityName))
                if (msdcache[keyToLoad.EntityName].Keys.Contains(keyToLoad.Identifier))
                    return null; //Before Cached in Null Results



            var rtn =  base.LoadFromDatasource(@event, persister, keyToLoad, options);
            if (rtn == null)
            {
                //Start Cache Null Value
            
                if (msdcache.Keys.Contains(keyToLoad.EntityName))
                {
                    msdcache[keyToLoad.EntityName].Add(keyToLoad.Identifier, null);
                }
                else
                {
                    //Setup Cache
                    msdcache.Add(keyToLoad.EntityName, new Dictionary<object, object>());
                    msdcache[keyToLoad.EntityName].Add(keyToLoad.Identifier, null);
                }
            }
            return rtn;
        }
        public override void OnLoad(
            NHibernate.Event.LoadEvent @event, 
            NHibernate.Event.LoadType loadType
            )
        {
           
            base.OnLoad(@event, loadType);
        }
    }
}
