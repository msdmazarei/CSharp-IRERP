using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

namespace MsdLib.CSharp.DALCore
{
    public class SqlStatementInterceptor : EmptyInterceptor
    {
        public override string GetEntityName(object entity)
        {
            return base.GetEntityName(entity);
        }
        public override object GetEntity(string entityName, object id)
        {
            return base.GetEntity(entityName, id);
        }
        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            return base.OnLoad(entity, id, state, propertyNames, types);
        } 
        public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
        {
#if DEBUG
            Trace.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"+sql.ToString());
#endif
            return sql;
        }
    }
    public enum dbtype
    {
        MySql,
        MsSql,
        Oracle
    }
    public sealed class DBFactory
    {
        public static  dbtype? DbType {
            get { return (dbtype?)GetFromRequestContext("___MSD_DbFactory_DbType____"); }
            set { SaveToRequestContext("___MSD_DbFactory_DbType____", value); }
        }
        public static List<NHibernate.ITransaction> AllTransactions()
        {
            string TransactionKey = "____All_Transaction__" + HttpContext.Current.Request.GetHashCode().ToString();
            if (HttpContext.Current.Items.Contains(TransactionKey))
                return (List<NHibernate.ITransaction>)HttpContext.Current.Items[TransactionKey];
            else
            {
                HttpContext.Current.Items.Add(TransactionKey, new List<NHibernate.ITransaction>());
                return (List<NHibernate.ITransaction>)HttpContext.Current.Items[TransactionKey];
            }
        }
        
        public static List<object> AllSessions()
        {
            //List Object to Supprt both ISession and IStatelessSession
            string SessionKey = "____All_Session__" + HttpContext.Current.Request.GetHashCode().ToString();
            if (HttpContext.Current.Items.Contains(SessionKey))
                return (List<object>)HttpContext.Current.Items[SessionKey];
            else
            {
                HttpContext.Current.Items.Add(SessionKey, new List<object>());
                return (List<object>)HttpContext.Current.Items[SessionKey];
            }
        }
        const string MsdNHCacheKey = "__0_o_0_o_MsdNHCache";
        public Dictionary<string, Dictionary<Object,Object>> MsdCache()
        {

            Dictionary<string, Dictionary<Object, Object>> rtn = new Dictionary<string, Dictionary<Object, Object>>();
            if (HttpContext.Current.Items.Contains(MsdNHCacheKey))
                rtn = (Dictionary<string, Dictionary<Object, Object>>)HttpContext.Current.Items[MsdNHCacheKey];
            else
                HttpContext.Current.Items.Add(MsdNHCacheKey, rtn);
            return rtn;
        }
        public void ClearMsdCache()
        {
            if (HttpContext.Current.Items.Contains(MsdNHCacheKey))
                HttpContext.Current.Items.Remove(MsdNHCacheKey);
        }
            
        public void ClearCache()
        {
            this.SessionFactory.EvictQueries();
            var sessionFactory = this.SessionFactory;
            foreach (var collectionMetadata in sessionFactory.GetAllCollectionMetadata())
                sessionFactory.EvictCollection(collectionMetadata.Key);
            foreach (var classMetadata in sessionFactory.GetAllClassMetadata())
                sessionFactory.EvictEntity(classMetadata.Key);
        }
        public NHibernate.IStatelessSession StatelessSession
        {
            get
            {
                var _statelesssession = 
                DBFactory.Instance.SessionFactory.OpenStatelessSession(); //testing
                DBFactory.AllSessions().Add(_statelesssession);
                DBFactory.AllTransactions().Add(
                    _statelesssession.BeginTransaction(TransactionLevel)
                    );

                return _statelesssession;
            }
        }
        public NHibernate.Cfg.Configuration DbConfiguration { get; set; }
        static NHibernate.ISessionFactory _SessionFactory = null;
        public NHibernate.ISessionFactory SessionFactory { 
            get {
                //if not static we have very slow website
                return _SessionFactory;

                //return (NHibernate.ISessionFactory)GetFromRequestContext("___MSD_DbFactory_SessionFactory____");
            } 
            set {
                _SessionFactory = value;

                //SaveToRequestContext("___MSD_DbFactory_SessionFactory____", value);
            }
        }
        static Action<string, object> SaveToRequestContext = (x, y) => { 
            string key = x+HttpContext.Current.Request.GetHashCode().ToString();
        if(HttpContext.Current.Items.Contains(key))
        {
            HttpContext.Current.Items[key]=y;
        }
        else
            HttpContext.Current.Items.Add(key,y);
        };
        static Func<string, object> GetFromRequestContext = x =>
        {
            string key = x + HttpContext.Current.Request.GetHashCode().ToString();
            if (HttpContext.Current.Items.Contains(key))
                return HttpContext.Current.Items[key];
            else
                return null;
        };


        static DBFactory _Instance
        {
            get
            {
                return (DBFactory) GetFromRequestContext("___MSD_DBFactory_Instance____");
                    
            }
            set
            {
                SaveToRequestContext("___MSD_DBFactory_Instance____", value);
            }
        }
        
        public static string ConnectionString {
            get { return (string)GetFromRequestContext("___MSD_DbFactory_Connectionstring____"); }
            set { SaveToRequestContext("___MSD_DbFactory_Connectionstring____", value); }
        }
        public static string[] MappingsFile {
            get { return (string[])GetFromRequestContext("___MSD_DbFactory_MappingsFile____"); }
            set { SaveToRequestContext("___MSD_DbFactory_MappingsFile____", value); }
        }
        public static Type[] MappingTypes { get {
            return (Type[])GetFromRequestContext("___MSD_DbFactory_MappingsTypes____");
        }
            set { SaveToRequestContext("___MSD_DbFactory_MappingsTypes____", value); }
        }
        //LazySessionContext _SessionContext = null;
        
        DBFactory()
        {
            lock (this)
            {
                if (SessionFactory != null) return;

               
                
                ////////////////////////
                SessionFactory =
                    Fluently.Configure()
                    .Database(getPersistenceconf())
                    .Mappings(
                        m =>
                        {
                            if (MappingTypes != null)
                                MappingTypes.ToList()
                                    .ForEach(x => m.FluentMappings.Add(x));
                            

                        }

                        )
                        
                        
                              .ExposeConfiguration(new Action<NHibernate.Cfg.Configuration>(x =>
                              {
                                  var properties = new Dictionary<string, string>();
                                  x.AddProperties(properties);
                                  x.SetInterceptor(new SqlStatementInterceptor());
                                  
                                  x.EventListeners.LoadEventListeners = new NHibernate.Event.ILoadEventListener[]
                                  {
                                      new MsdLoadEventListener()
                                  };
                                  x.EventListeners.EvictEventListeners = new NHibernate.Event.IEvictEventListener[]
                                  {
                                      new MsdEvictEventListener()
                                  };
                                  
                                  
                                  if (MappingsFile != null)
                                      MappingsFile.ToList().ForEach(
                                          y => x.AddFile(y)
                                  );
                                  
                                  //x.AddSqlFunction("convert", new NHibernate.Dialect.Function.StandardSafeSQLFunction("convert", NHibernate.NHibernateUtil.String, 2)); // Define convert Function for NHIbernate
                                  
                              }))


                    .BuildSessionFactory()
                    
                    ;
                
                
            }
        }
//        [ThreadStatic]
        ISession _Session = null;

        public ISession Session
        {
            get
            {
                
                
                //return NewSession();
                if (_Session == null) _Session = DbSessionManager.GetSession(); ;
                if (!_Session.IsConnected) _Session = DbSessionManager.GetSession();
                return _Session;
            }
        }
        
        public ISession NewSession(bool validnewsession =false)
        {
#if DEBUG
            if (!validnewsession)
            {
                throw new Exception("Oh,you are starting new session");
            
            }
#endif
            NHibernate.ISession session = null;
            string key = "MSD_DBCONNECTION_"+HttpContext.Current.GetHashCode().ToString();
            //if there is a connection use that connection to create session
            if (HttpContext.Current.Items[key] == null)
                session =  SessionFactory.OpenSession();
            else
                session = SessionFactory.OpenSession((System.Data.IDbConnection)HttpContext.Current.Items[key]);
            DBFactory.AllSessions().Add(session);
            session.FlushMode = FlushMode.Never;
            return session;
        }
        
        public ITransaction NewTransaction(System.Data.IsolationLevel IsolationLevel = System.Data.IsolationLevel.Unspecified)
        {
            //return _SessionContext.CurrentSession().BeginTransaction();
            //return SessionFactory.OpenSession().BeginTransaction();
            //return Session.BeginTransaction(IsolationLevel);
            return Session.Transaction;
        }

        
        public static DBFactory Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DBFactory();

                
                return _Instance;

            }
        }
        public static System.Data.IsolationLevel TransactionLevel
        {
            get {
                var rtn = GetFromRequestContext("___MSD_DbFactory__TransactionLevel____");
                if (rtn == null) return 0;else 
                return (System.Data.IsolationLevel)rtn; }
            set { SaveToRequestContext("___MSD_DbFactory__TransactionLevel____", value); }
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
        public static IPersistenceConfigurer getPersistenceconf()
        {
            IPersistenceConfigurer persistance = null;
            switch (DBFactory.DbType)
            {
                case dbtype.MsSql:
                    persistance = MsSqlConfiguration.MsSql2008.Dialect<MsdLib.DALCore.SqlFunctions.MsSql2008Dialects>().ConnectionString(ConnectionString);
                    break;
                case dbtype.MySql:
                    persistance = MySQLConfiguration.Standard.Dialect<MsdLib.DALCore.SqlFunctions.IRERPMySqlDialects>().ConnectionString(ConnectionString);
                    break;
            }
            return persistance;
        }
        public static void GenerateDb(string sqlfile="sql.sql",params Type[] Models)
        {
                            

             

            
            Fluently.Configure()
            .Database(getPersistenceconf())
            .Mappings(
                        m => Models.ToList().ForEach(x =>
                            m.FluentMappings.Add(x))
                     )
            .ExposeConfiguration(new Action<NHibernate.Cfg.Configuration>(
                        x =>
                        {
                            x.SetInterceptor(new SqlStatementInterceptor());
                            SchemaExport sx = new SchemaExport(x);
                            sx.SetOutputFile(sqlfile);
                            sx.Create(true, true);
                        }))
            .BuildConfiguration()
            .BuildSessionFactory();
        }

    }
}
