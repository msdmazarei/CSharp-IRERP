using MsdLib.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public class ApplicationStatics : MsdLib.ApplicationGlobalVariables<ApplicationStatics>
    {
        protected const string UserSessionKey = "User";
        protected static string GetSessionKey(string Key)
        {
            return "IRERPSESSIONKEY_"+Key;
        }
    
        public static string Lang { get; set; }
        public static LoadableVar<System.Reflection.Assembly> Resourceassem = new LoadableVar<System.Reflection.Assembly>();
        public static string T(string label)
        {
            if (Lang == null || Lang == "") Lang = "Fa";
             global::System.Resources.ResourceManager temp=null;
            
            if(!Resourceassem.isLoaded)
                try{
                    //if(System.IO.File.Exists("App_GlobalResources.dll"))
                    Resourceassem.Value = global::System.Reflection.Assembly.Load("App_GlobalResources"); //System.Reflection.Assembly.LoadFrom("IRERP-RestAPI.dll");
                    Resourceassem.isLoaded = true;
                        
                        //System.Reflection.Assembly.GetExecutingAssembly();// global::System.Reflection.Assembly.Load("App_GlobalResources");
                    
                    //else if(System.IO.File.Exists("App_GlobalResources."+Lang+".Designer.cs.dll"))
                      //  Resourceassem.Value = global::System.Reflection.Assembly.Load("App_GlobalResources."+Lang+".Designer.cs");

                }catch{
                    Resourceassem.Value = null;
                    Resourceassem.isLoaded = true;
                }
            
            switch (Lang)
            {
                case "Fa":

                    if (Resourceassem.Value != null)
                         temp=  new global::System.Resources.ResourceManager("Resources.Fa",Resourceassem.Value );
                        //temp = new global::System.Resources.ResourceManager("IRERP_RestAPI.App_GlobalResources.Fa", Resourceassem.Value);
                    

            break;
                case "En":
                    if(Resourceassem.Value!=null)
                        temp = new global::System.Resources.ResourceManager("IRERP_RestAPI.App_GlobalResources.En", Resourceassem.Value);
            break;
            }
            if (temp != null)
                return temp.GetString(label);
            else
                return
                    "APPLCIATIONSTATICS.T.LINE 46";
                   
        
        }
    }
}