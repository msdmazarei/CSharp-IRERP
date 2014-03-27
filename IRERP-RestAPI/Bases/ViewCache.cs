using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using MsdLib.ExtensionFuncs;
using MsdLib.ExtentionFuncs;
using System.IO;
namespace IRERP_RestAPI.Bases
{
    public class ViewCache
    {
        public static string getCachePath()
        {
            string cachefolderpath = IRERPApplicationUtilities.PhysicalApplicationPath() + @"WebCache";

            if (ConfigurationManager.AppSettings.HasKeys())
                if (ConfigurationManager.AppSettings.AllKeys.Contains("MsdCachePath"))
                    cachefolderpath = ConfigurationManager.AppSettings["MsdCachePath"];

            if (cachefolderpath[cachefolderpath.Length - 1] != '\\')
                cachefolderpath += @"\";
            return cachefolderpath;
        }
        const string cacheperfixreplacer ="___MSD_HTTP_REQ_CHG__";
        static string makeViewPathCorrect(string ViewPath)
        {
            if(ViewPath!=null)
                return ViewPath.Replace(@"\", "_").Replace("+", "_").Replace("/","_").Replace("~","_");//replace invalid path chars
            return null;
        }
        public static string GetCachedView(string viewPath)
        {
            string rtn = null;
            string cachefolderpath = getCachePath();

            string viewpath = null;
            if (viewPath != null)
                viewpath = makeViewPathCorrect(viewPath); 
            if (viewpath != null)
                if (File.Exists(cachefolderpath + viewpath))
                    rtn = File.ReadAllText(cachefolderpath +  viewpath);
            if (rtn != null)
                rtn = rtn.Replace(cacheperfixreplacer, "_" +new Random().NextDouble().ToString().Replace(".","")+ System.Web.HttpContext.Current.Request.GetHashCode().ToString() + "_");
            
            return rtn;

        }
        public static void CreateCacheForView(string viewPath, string ViewContent,string idsperfix)
        {
            if (ViewContent != null && idsperfix != null && viewPath != null)
            {
                string filecontent = ViewContent.Replace(idsperfix, cacheperfixreplacer);
                File.WriteAllText(getCachePath() + makeViewPathCorrect(viewPath), filecontent);
            }
            
        }

    }
}