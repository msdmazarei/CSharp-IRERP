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
    public class ProcessModel<A, Alog> : ModelBaseLog<A, Alog>
        where A:IRERP_RestAPI.Bases.ModelBase<A>
        where Alog : LogModelBase<Alog>
    {
        public virtual string WFname { get; set; }
        public virtual string WFStep { get; set; }

        public virtual FunctionResult<INHibernateEntity> ProcessSave(ISession session = null, ITransaction transaction = null, Boolean CommitTran = false)
        {
            throw new NotImplementedException();
        }

    }
}
