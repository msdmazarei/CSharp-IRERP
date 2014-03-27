using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MsdLib.CSharp.DALCore
{
    public class DbSessionManager {
        const string sessionmanagerkey = "DbSessionManager_NHibernateSession";

    public static ISession GetSession() {
        string key = sessionmanagerkey + "_"+HttpContext.Current.GetHashCode().ToString();

        ISession session = (ISession)HttpContext.Current.Items[key];
        if (session == null) {
#if DEBUG
            System.Diagnostics.Trace.WriteLine("---------------------------------------------------------------CREATE SESSION FOR KEY:" + key);
            if (HttpContext.Current.Items.Contains(key + "_SESCOUNT"))
            {
                throw new Exception("OH, Session Exist for this!, Why You Are Creating another one");
            }
            HttpContext.Current.Items.Add(key + "_SESCOUNT", 1);
#endif
            
            session = MsdLib.CSharp.DALCore.DBFactory.Instance.NewSession(true); // Create session
            if (DBFactory.TransactionLevel != 0)
            {
                DBFactory.AllTransactions().Add(
                session.BeginTransaction(DBFactory.TransactionLevel)
                );
            }
            else
            {
                DBFactory.AllTransactions().Add(
               session.BeginTransaction()
               );
            }

            System.Threading.Thread.Sleep(10); // To Be Careful that Session is opened
            if (!(session.IsOpen && session.IsConnected))
            {
                throw new Exception("OH, Session Is Closed After it is initialiaze");
            }
            HttpContext.Current.Items.Add(key, session);
        }

        if (!session.IsOpen)
        {
            throw new Exception("OH!, Why Session Is Closed ????? This is not correct");
        }

        return session;
    }
    public static ITransaction NewTransaction()
    {
        string key = sessionmanagerkey + "_" + HttpContext.Current.GetHashCode().ToString();
         ISession session = (ISession)HttpContext.Current.Items[key];
         if (session != null)
         {
             if (session.Transaction != null && session.Transaction.IsActive && !session.Transaction.WasCommitted)
                 return session.Transaction;

             ITransaction tr =  session.BeginTransaction(DBFactory.TransactionLevel);
             DBFactory.AllTransactions().Add(tr);
             return tr;
         }
         else
         {
             throw new Exception("Oh, Be CareFul you have no Session to Start transaction with");
         }
    }
    public static void CloseSession()
    {
        string key = sessionmanagerkey + "_" + HttpContext.Current.GetHashCode().ToString();
        ISession session = (ISession)HttpContext.Current.Items[key];
        if (session != null) {
            if (session.IsOpen) {
                session.Close();
                session.Dispose();
            }
            HttpContext.Current.Items.Remove(key);
            HttpContext.Current.Items.Remove(key + "_SESCOUNT");
        }
    }
}
    
}