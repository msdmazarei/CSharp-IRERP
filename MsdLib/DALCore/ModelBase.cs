using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MsdLib.ExtentionFuncs.Strings;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.Utils;
using System.Web;

namespace MsdLib.CSharp.DALCore
{
    public interface ModelBaseInterface<out T>
    { }
    public class ModelBase:
        INHibernateEntity,
        INotifyPropertyChanged,
                       IDataErrorInfo
    {
        public virtual FunctionResult<INHibernateEntity> SaveAnotherObjectExceptMe(ISession session = null, ITransaction transaction = null, Boolean CommitTran = false, ModelBase ObjToSave = null)
        {
            if (ObjToSave == null)
                ObjToSave = this;

            FunctionResult<INHibernateEntity> rtn = new FunctionResult<INHibernateEntity>();
            if (session == null) session = this.Session;
            if (CommitTran)
                if (transaction == null) transaction = Transaction;

            //Check Validity
            if (ObjToSave.Error != null)
                if (ObjToSave.Error != "" && ObjToSave.IsDeleted == false)
                {
                    if (ObjToSave.Error == "ValidationError")
                    {
                        rtn.Result = false;
                        rtn.ErrorType = ErrorType.ValidationError;
                        return rtn;
                    }
                    else
                    {
                        rtn.Result = false;
                        rtn.ErrorType = ErrorType.GeneralError;
                        rtn.Error = new PException(ObjToSave.Error, null);
                        return rtn;
                    }
                }
            try
            {

                session.SaveOrUpdate(ObjToSave);
                if (CommitTran)
                {
                    session.Flush();
                    transaction.Commit(); 
                }
                rtn.Result = true;
                rtn.ResultValue = ObjToSave;
                rtn.Time = DateTime.Now;
            }
            catch (Exception ex)
            {
                if (CommitTran)
                {
                    session.Flush();
                    transaction.Rollback();
                }

                rtn.Result = false;
                rtn.Error = new PException(ex.Message, ex);
                rtn.Time = DateTime.Now;
                transaction.Dispose();
                //session.Close();
                //session.Dispose();
            }
            finally
            {
                if (CommitTran)
                {
                    transaction.Dispose();
                }
            }

            return rtn;
        }
        #region "Variables"
        protected IStatelessSession _statelessSession;

        Guid _id;
        protected ISession _session;
        protected ITransaction _transaction;
        protected string[] ClassProperties = { };
        public virtual event PropertyChangedEventHandler PropertyChanged;
        #endregion
#region "Properties"
        public virtual IStatelessSession StatelessSession
        {
            get
            {
                if (_statelessSession != null)
                    if (_statelessSession.IsOpen && _statelessSession.IsConnected)
                        return _statelessSession;
                _statelessSession = DBFactory.Instance.StatelessSession;
                return _statelessSession;
                    
            }
            set
            {
                _statelessSession = value;
            }
        }
        public virtual bool UseStatelessSession { get; set; }
        bool? _isSaved = null;
        public virtual bool IsSaved
        {
            get
            {
             //   return NHibernateUtil.IsInitialized(this);
                if (_isSaved.HasValue) return _isSaved.Value;
                else
               return id != Guid.Empty;
            }
            set
            {
                _isSaved = value;
            }
        }
        public virtual long Version { get; set; }

       
        public virtual Guid id
        {
            get { return _id; }
            set
            {
                _id = value; OnPropertyChanged("id");
            }
        }

        public virtual bool IsDeleted { get; set; }
        
        public virtual ISession Session
        {
            get
            {
                  if (_session != null)
                    if (_session.IsConnected && _session.IsOpen)
                        return _session;
                  _session = DbSessionManager.GetSession();//DBFactory.Instance.Session;
                return _session;
                 
            }
            set { _session = value; }
        }
        public virtual ITransaction Transaction
        {
            get
            {

                if (UseStatelessSession)
                {
                    if(StatelessSession.Transaction!=null)
                        if(StatelessSession.Transaction.IsActive)
                            return StatelessSession.Transaction;
                    
#if DEBUG 
                    throw new Exception("Oh!, You Are Starting New Transaction , This is Not Correct");
#else
                    
                    DBFactory.AllTransactions().Add(
                    StatelessSession.BeginTransaction(DBFactory.TransactionLevel)
                    );
#endif

                    return StatelessSession.Transaction;

                }

                if (_transaction != null)
                    if (_transaction.IsActive)
                        return _transaction;

                if (Session.Transaction != null)
                    if (Session.Transaction.IsActive)
                    {
                        _transaction = Session.Transaction;
                        return _transaction;
                    }
#if DEBUG
                throw new Exception("Oh!, You Are Starting New Transaction , This is Not Correct");
                
#endif

                return _transaction;
            }
            set { _transaction = value; }
        }
        string _error;
        public virtual string Error
        {
            get
            {
                if (_error != null)
                    return _error;
                if (columnsError != null)
                    if (columnsError.Keys.Count > 0)
                        return _error= ErrorType.ValidationError.ToString();
                //get All Properties
                foreach (var p in this.GetType().GetProperties()){
                    string err= this[p.Name];
                }
                if (columnsError != null)
                    if (columnsError.Keys.Count > 0)
                        return _error = ErrorType.ValidationError.ToString();

                return _error;
            }
            set
            {
                _error=value;
            }
        }
        public virtual Dictionary<string, string> columnsError { get; set; }
        
        public virtual string this[string columnName]
        {
            get {
                if (columnsError.Keys.Contains(columnName))
                    return columnsError[columnName];
                return null;
 
                }
        }

        public virtual Dictionary<string, bool> IsCollectionLoaded { get; set; }
        #endregion
#region "Methods"
        public virtual string getColumnError(string columnName)
        {
            if (columnsError.Keys.Contains(columnName))
                return columnsError[columnName];
            return null;
        }
        public virtual void setColumnError(string columnName, string Error)
        {
           
            if (columnsError.Keys.Contains(columnName))
                columnsError[columnName] = Error;
            else
                columnsError.Add(columnName, Error);
        }
        public virtual FunctionResult<INHibernateEntity> RunTransaction(ITransaction tr)
        {
            
            
            FunctionResult<INHibernateEntity> rtn = new FunctionResult<INHibernateEntity>();
            if (tr == null)
                tr = Transaction;
            try
            {
                //Flush Session
                if(!UseStatelessSession)
                    Session.Flush();

                tr.Commit();
                if (UseStatelessSession)
                {
                    StatelessSession.Close();
                    StatelessSession.Dispose();
                }
                rtn.FunctionName = "RunTransaction";
                rtn.Result = true;
                rtn.Time = DateTime.Now;

            }
            catch (Exception ex)
            {
                try
                {
                    Session.Flush();
                    tr.Rollback();
                }
                catch { }
                rtn.FunctionName = "RunTransaction";
                rtn.Result = false;
                rtn.Time = DateTime.Now;
                rtn.Error = new PException(ex.Message, ex);
            }
            finally
            {
                    tr.Dispose();
            
            }
            return rtn;
        }
      
        public virtual IList<INHibernateEntity> GetSampleList()
        {
            var rtn = new List<INHibernateEntity>();
            for (int i = 0; i < 100; i++)
            {
                rtn.Add
                    (GetSampleObject());
            }
            return rtn;
        }

        public virtual INHibernateEntity GetSampleObject() { return null; }

        // Returns string which be sent to client
        public virtual Object GetSummaryMessage(string Profile, FilterBaseCore Filter, string MessageName = null)
        {
            throw new NotImplementedException();
        }
        public virtual List<Tuple<string, string>> GetSummary(string Profile,FilterBaseCore Filter)
        {
            throw new NotImplementedException();
        }

        public virtual FunctionResult<INHibernateEntity> Save(ISession session, ITransaction transaction, Boolean CommitTransaction = false, params IList[] subItems)
        //public virtual FunctionResult<INHibernateEntity> Save(INHibernateEntity Obj = null, Boolean CommitTransaction = false, params IList[] subItems)
        {
            if (CommitTransaction) Transaction = Transaction;
            subItems.ToList().ForEach(
                x =>
                {
                    foreach (var m in x)
                    {
                        INHibernateEntity y = (INHibernateEntity)m;
                        y.Transaction = this.Transaction;
                        y.Save(null, null, false);
                    }

                }
            );
            FunctionResult<INHibernateEntity> Rtn = new FunctionResult<INHibernateEntity>();
            //Check Validity
            if (
                this.Error != null && IsDeleted == false
                )
            {
                Rtn.Result = false;
                Rtn.Error = new PException(this.Error, null);
                return Rtn;
            }

            try
            {
                var tr = Transaction;
                //Session.FlushMode = FlushMode.Auto;
                Session.SaveOrUpdate(this);


                if (CommitTransaction)
                {
                    Session.Flush();
                    tr.Commit(); 
                }
                Rtn.Time = DateTime.Now;
                Rtn.Result = true;
                Rtn.ResultValue = this;
                return Rtn;
            }
            catch (Exception ex)
            {
                try
                { if (CommitTransaction) { Session.Flush(); Transaction.Rollback(); } }
                catch { }

                Rtn.Result = false;
                Rtn.ResultValue = null;
                Rtn.Error = new PException(ex.Message, ex);
                Rtn.Time = DateTime.Now;
                return Rtn;
            }
        }
        
        public virtual FunctionResult<INHibernateEntity> Save(ISession session = null, ITransaction transaction = null, Boolean CommitTran = false)
        {
            FunctionResult<INHibernateEntity> rtn = new FunctionResult<INHibernateEntity>();
            if (session == null) session = this.Session;
            if (CommitTran)
                if (transaction == null) transaction = Transaction;

            //Check Validity
            if(this.Error!=null)
            if (this.Error != "" && IsDeleted == false)
            {
                if (this.Error == "ValidationError")
                {
                    rtn.Result = false;
                    rtn.ErrorType = ErrorType.ValidationError;
                    return rtn;
                }
                else
                {
                    rtn.Result = false;
                    rtn.ErrorType = ErrorType.GeneralError;
                    rtn.Error = new PException(this.Error, null);
                    return rtn;
                }
            }
            try
            {
                
                
                session.SaveOrUpdate(this);
                if (CommitTran)
                {
                    session.Flush();
                    transaction.Commit(); 
                }
                rtn.Result = true;
                rtn.ResultValue = this;
                rtn.Time = DateTime.Now;
            }
             catch (Exception ex)
            {
                if (CommitTran)
                {
                    session.Flush();
                    transaction.Rollback();
                }

                rtn.Result = false;
                rtn.Error = new PException(ex.Message, ex);
                rtn.Time = DateTime.Now;
                transaction.Dispose();
                //session.Close();
                //session.Dispose();
            }
            finally
            {
                if(CommitTran)
                {
                    transaction.Dispose();
//                    session.Close();
//                    session.Dispose();
                 //   session = this.Session;
                }
            }

            return rtn;
        }
      
        public virtual FunctionResult<INHibernateEntity> Remove(ISession session, ITransaction transaction, Boolean CommitTransaction = false)
        {
            throw new NotImplementedException();
        }

        public virtual FunctionResult<INHibernateEntity> Remove(INHibernateEntity Obj = null, Boolean CommitTransaction=true)
        {
            if (Obj == null) Obj = this;
            ((ModelBase)Obj).IsDeleted = true;
            return Save(CommitTran: CommitTransaction);
            //return this.Save(Obj, true);

        }
        public virtual FunctionResult<IList<T>> FetchList<T>(int startRow, int EndRow, IList<ICriterion> Criterias, IList<OrderBy> Orders)
        {
            FunctionResult<IList<T>> rtn = new FunctionResult<IList<T>>();
            var crit = this.Session
                .CreateCriteria(this.GetType())
                .SetFirstResult(startRow)
                .SetMaxResults(EndRow - startRow);
            if (Criterias != null)
                foreach (var c in Criterias)
                    if (c != null) crit.Add((ICriterion)c);

            if (Orders != null)
                foreach (var o in Orders)
                    if (o != null) crit.AddOrder(new Order(o.PropertyName, o.SortType == SortType.Asc));

            rtn.ResultValue = crit.List<T>();
            rtn.Result = true;

            return rtn;
        }
        public virtual FunctionResult<IEnumerable<string>> SerializeToJSON(string Profile)
        {
            FunctionResult<IEnumerable<string>> rtn = new FunctionResult<IEnumerable<string>>();
            try
            {

            }
            catch (Exception Ex)
            {
                rtn.Result = false;
                rtn.Time = DateTime.Now;
                rtn.Error = new PException(Ex.Message, Ex);
            }

            return rtn;
        }
        public virtual FunctionResult<IEnumerable<string>> DeSerializeFromJSON(string Profile)
        {
            throw new NotImplementedException();
        }

        public virtual void OnPropertyChanged(string PropName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropName));

        }
        public virtual IList<SubItemType> GetSubItems<SubItemType>(Expression<Func<SubItemType, bool>> Cond)
            where SubItemType : ModelBase<SubItemType>
        {
            return
                Session.QueryOver<SubItemType>().Where(Cond).List();
        }
     
        public ModelBase()
        {
            IsCollectionLoaded = new Dictionary<string, bool>();
            UseStatelessSession = false;
            columnsError = new Dictionary<string, string>();
        }

        #endregion
        public virtual List<string> ForcedJoinTables()
        {
            return new List<string>();
        }
        public virtual Tuple<string, NHibernate.SqlCommand.JoinType, ICriterion> GetAssociation(string PropertyPath)
        {
            throw new NotImplementedException();
        }
        public virtual NHibernate.Criterion.Order GetOrder(OrderBy ordr)
        {
            string[] str = ordr.PropertyName.Split('.');
            string aliasname = string.Join(".", str, 0, str.Length - 1).ToClientDsFieldName();
            if(aliasname.Length>0)
            return new Order(
                aliasname+"."+str[str.Length-1],
                ordr.SortType== SortType.Asc? true:false
                ); 
            else
                return new Order(
                 str[str.Length - 1],
                ordr.SortType == SortType.Asc ? true : false
                ); 

            // return new Order(ordr.AliasBaseName
            // throw new NotImplementedException();

        }
        public virtual NHibernate.Criterion.ICriterion GetCritertion(MsdCriteria crit)
        {
            //Get property Type 
            return crit.ToCriterion();
        }
       
        public virtual INHibernateEntity LoadByPrimaryKeys(Dictionary<string,object> primarykeys_value)
        {

            throw new NotImplementedException() ;
        }



        public virtual FunctionResult<INHibernateEntity> Get(INHibernateEntity Obj)
        {
            throw new NotImplementedException();
        }
    }

    public class ModelBase<MyType> :
                       ModelBase,
                       ModelBaseInterface<MyType>,
                       IMsdCore
     where MyType : ModelBase
    {
        public virtual void SetRelationProperty(Expression<Func<MyType, Object>> PropertyPath, Expression<Func<MyType, Object>> RelationPath, object localvar, dynamic value)
        {
            AppUtils.SetProperty(this, _GPN(RelationPath), value);
            AppUtils.CallMethod(localvar,"SetValue",new object[]{value});
            
            OnPropertyChanged(_GPN(PropertyPath));
        }
        
        public override FunctionResult<INHibernateEntity> Get(INHibernateEntity Obj = null)
        {

            FunctionResult<INHibernateEntity> Rtn = new FunctionResult<INHibernateEntity>();
            IList<ICriterion> crts;
            if (Obj == null)
                crts = this.PrimaryKeyCriterion(this);
            else
                crts = this.PrimaryKeyCriterion(
                    (ModelBase<MyType>)
                    Obj
                    );

            IList<INHibernateEntity> res = null;
            try
            {
                ICriteria tmp = Session.CreateCriteria(this.GetType());
                foreach (ICriterion c in crts) tmp.Add(c);
                res = tmp.List<INHibernateEntity>();
            }
            catch (Exception ex)
            {
                Rtn.Result = false;
                Rtn.ResultValue = null;
                Rtn.Error = new PException(ex.Message, ex);
                Rtn.Time = DateTime.Now;
                return Rtn;
            }

            if (res.Count == 1 || res.Count == 0)
            {
                Rtn.Result = true;
                if (res.Count > 0)
                    Rtn.ResultValue = (INHibernateEntity)res[0];
                else
                    Rtn.ResultValue = null;
                Rtn.Time = DateTime.Now;
                return Rtn;

            }
            else
            {
                PException excp = new PException("ErrorMessages.ModelBase_Get_MultiInstancesReturn", null);
                Rtn.Result = false;
                Rtn.ResultValue = null;
                Rtn.Time = DateTime.Now;
                return Rtn;

            }



        }
        public virtual dynamic GetConditionForSubItems(Expression<Func<MyType, object>> Property)
        {
            return null;
        }
        public virtual IList<SubItemType> GetSubItems<SubItemType>(Expression<Func<MyType, object>> Property)
        {
            return GetSubItems(GetConditionForSubItems(Property));
        }
        public virtual IList<ICriterion> PrimaryKeyCriterion(ModelBase<MyType> Obj)
        {
            var rtn = new List<ICriterion>();
            rtn.Add(NHibernate.Criterion.Expression.Eq("id", Obj.id));
            return rtn;
        }
        public virtual string _GPN(Expression<Func<MyType, Object>> exp)
        {
            return AppUtils.GPN<MyType>(exp);
        }

        
        public virtual Type GetNHType(Expression<Func<MyType, object>> Property)
        {
            throw new NotImplementedException();
        }


      
    }

}
