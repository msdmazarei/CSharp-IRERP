using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRERP_RestAPI.Models;
using IRERP_RestAPI.ModelRepositories;
using MsdLib.ExtensionFuncs.ISessionExtension;
using MsdLib.CSharp.DALCore;
using System.Linq;
using System.Linq.Expressions;
namespace IRERP_RestAPI.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var q11 = new IRERP_RestAPI.Mappings.Petiak_Wifi_ActiveSessionsMap();
             Generals.startup();
             DBFactory.GenerateDb("dbgen.sql",DBFactory.MappingTypes);
             Generals.fillTables();
           
        }
    }
}
