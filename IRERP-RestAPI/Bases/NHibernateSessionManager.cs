using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public class DbSessionManager {
        const string sessionmanagerkey = "DbSessionManager_NHibernateSession";
    public static ISession GetSession() {
        ISession session = (ISession)HttpContext.Current.Items[sessionmanagerkey];
        if (session == null) {
            session = MsdLib.CSharp.DALCore.DBFactory.Instance.NewSession(); // Create session
            session.BeginTransaction();
            HttpContext.Current.Items.Add(sessionmanagerkey, session);
        }
        return session;
    }

    public static void CloseSession()
    {
        ISession session = (ISession)HttpContext.Current.Items[sessionmanagerkey];
        if (session != null) {
            if (session.IsOpen) {
                session.Close();
            }
            HttpContext.Current.Items.Remove(sessionmanagerkey);
        }
    }
}
    
}