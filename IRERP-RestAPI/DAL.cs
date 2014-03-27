using System.Configuration;

﻿using MsdLib.CSharp.DALCore;
using NHibernate;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel;
using IRERP_RestAPI.Bases.MetaDataDescriptors;

namespace IRERP_RestAPI
{
    public class DAL
    {
        public static ISession Session
        {
            get
            {
                if (!isDbSetuped) SetupDb();
                var rtn = DbSessionManager.GetSession();// DBFactory.Instance.Session;

                rtn.FlushMode = FlushMode.Never;
                return rtn;
            }
        }
        public static ITransaction Transaction
        {
            get
            {
                return DbSessionManager.GetSession().Transaction;
                if (Session.Transaction != null)
                    if (Session.Transaction.IsActive)
                        return Session.Transaction;
                Console.WriteLine("Begin New Transaction. Be Careful! ");
                return DBFactory.Instance.NewTransaction();
                //return Session.Transaction;
            }
        }
        public static bool isDbSetuped = false;
        public static dynamic[] MetaModels { get; set; }
        public static void SetupDb()
        {
            isDbSetuped = true;
            if (!(DBFactory.ConnectionString != null && DBFactory.ConnectionString.Trim() != ""))
                DBFactory.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            if (!(DBFactory.DbType != null ))
                DBFactory.DbType =(dbtype) Enum.Parse(typeof(dbtype), ConfigurationManager.AppSettings["db.type"].ToString());

            List<string> MappingFiles = new List<string>();
            try
            {

                //Add Queries
                var queries = System.IO.Directory.GetFiles("Queries");
                
                if (queries != null)
                    queries.ToList().ForEach(x => MappingFiles.Add(x));
            }
            catch { }

            DBFactory.MappingsFile = MappingFiles.ToArray();
            //MetaModels 
            MetaModels = new dynamic[] 
            { 
               
               new IRERP_RestAPI.Areas.Report.MetaModelMapping.Report_MetaData_Mapping(),
               new IRERP_RestAPI.MetaModelMappings.BasesInformation_MetaModel_Mapping(),
               new IRERP_RestAPI.MetaModelMappings.Support_MetaModel_Mapping(),
               new IRERP_RestAPI.MetaModelMappings.jahad_MetaModel_Mapping(),
               
            };
            List<Type> lst = new List<Type>();
            AppDomain.CurrentDomain.GetAssemblies()
                .ToList().ForEach(
                
                x => {
                    if(x.FullName.IndexOf("IRERP_RestAPI_Models")==0)
                    {
                        x.GetTypes().ToList().ForEach(type =>
                        {
                            if (IRERP_RestAPI.Bases.IRERPApplicationUtilities.IsSubclassOfRawGeneric(
                                typeof(IRERPDescriptor<>), type)
                                )
                                if (!lst.Contains(type))
                                    lst.Add(type);
                        });
                    }
                });

            lst.Add(    typeof(IRERP_RestAPI.Bases.NHComponents.IRERPFileMap));
            lst.Add(
                typeof(IRERP_RestAPI.Bases.NHComponents.IRERPGAddressMap));
            lst.ForEach(x => IRERP_RestAPI.Bases.IRERPApplicationUtilities.NewInstance(x));
            DBFactory.MappingTypes = lst.ToArray();
       


        }


    }

}