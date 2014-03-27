
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRERP_RestAPI.Bases;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.DALCore;
using NHibernate;


namespace IRERP_RestAPI.Bases
{
   public class ModelBaseLog<A, Alog> : ModelBase<A>
        where A:ModelBase<A>
        where Alog : LogModelBase<Alog>
    {

       public virtual Alog CreateLog(ModelBaseLog<A, Alog> input)
       {
           Alog loginstance = IRERPApplicationUtilities.NewInstance<Alog>();
           IRERPApplicationUtilities.CopyObjByPropName(input, loginstance, new string[]{"Session","Transaction","StatelessSession"});
           return loginstance;

           throw new NotImplementedException();
       }
       
       public override FunctionResult<INHibernateEntity> SaveAnotherObjectExceptMe(ISession session = null, ITransaction transaction = null, bool CommitTran = false, MsdLib.CSharp.DALCore.ModelBase ObjToSave = null)
       {
           if (ObjToSave == null)
               ObjToSave = this;
           if (session == null)
               session = this.Session;
           if (transaction == null)
               transaction = Transaction;

           var r1 = base.SaveAnotherObjectExceptMe(session, transaction, false, ObjToSave);
           if (!r1.Result)
               return r1;
           
           Alog a = CreateLog((ModelBaseLog<A,Alog>)ObjToSave);
           r1 = a.Save(session, transaction, false);
           if (!r1.Result)
               return r1;

           if (CommitTran)
           {
               var rtn1 = RunTransaction(transaction);
               if (rtn1.Result)
               {
                   rtn1.ResultValue = ObjToSave;
                   return rtn1;
               }
               else
               {
                   //                   session.Close();
                   //                   session.Dispose();
                   return rtn1;
               }
           }
           else
               return r1;
       }
       public  override MsdLib.CSharp.BLLCore.FunctionResult<MsdLib.CSharp.DALCore.INHibernateEntity> Save(NHibernate.ISession session = null, NHibernate.ITransaction transaction = null, bool CommitTran = false)
       {
          
           
           if (session == null)
               session = this.Session;
           if (transaction == null)
               transaction = Transaction;
           var r1 = base.Save(session, transaction, false);
           if (!r1.Result)
               return r1;
           Alog a = CreateLog(this);
           r1 = a.Save(session, transaction, false);
           if (!r1.Result)
               return r1;

            if (CommitTran)
           {
               var rtn1 = RunTransaction(transaction);
               if (rtn1.Result)
               {
                   rtn1.ResultValue = this;
                   return rtn1;
               }
               else
               {
//                   session.Close();
//                   session.Dispose();
                   return rtn1;
               }
           }
           else
               return r1;

       }


      
    }
}

