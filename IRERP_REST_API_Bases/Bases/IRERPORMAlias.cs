using MsdLib.CSharp.BLLCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public class IRERPORMAlias
    {
        public string AliasName { get; set; }
        public string association {get;set;}
        public NHibernate.SqlCommand.JoinType JoinType { get; set; }

        public IRERPORMAlias()
        {
            this.JoinType = NHibernate.SqlCommand.JoinType.LeftOuterJoin;
        }

        public static FunctionResult<List<IRERPORMAlias>> GetAliasList(string PropertyName)
        {
            FunctionResult<List<IRERPORMAlias>> Rtn = new FunctionResult<List<IRERPORMAlias>>();

            try
            {
                string[] parts = PropertyName.Split(new string[] { "." }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    Rtn.ResultValue = new List<IRERPORMAlias>();
                    IRERPORMAlias POA = new IRERPORMAlias();
                    POA.association = parts[0];
                    POA.AliasName = "_" + parts[0];

                    Rtn.ResultValue.Add(POA);
                    /*
                     * A.B.C.D
                     * will Generte
                     * A _A
                     * _A.B _AB
                     * _AB.C _ABC
                     */
                    string alias = "";
                    for (int i = 0; i < parts.Length-1; i++)
                    {
                        Rtn.ResultValue.Add(
                            new IRERPORMAlias()
                            {
                                AliasName = "_" + alias + parts[i],
                                association = alias==""? parts[i] : "_"+alias+parts[i]
                            });
                        alias += parts[i];
                    }
                }
                else
                {
                    Rtn.Result = false;
                    Rtn.Time = DateTime.Now;
                    Rtn.FunctionName = "IRERP_RestAPI.Bases.IRERPORMAlias.GetAliasList";
                    Rtn.Error = new PException("There is no need to aliasing", null);
                }
            }
            catch (Exception ex)
            {
                Rtn.Result = false;
                Rtn.Time = DateTime.Now;
                Rtn.FunctionName = "IRERP_RestAPI.Bases.IRERPORMAlias.GetAliasList";
                Rtn.Error = new PException(ex.Message, ex);
            }
            return Rtn;
        }
        public static string PropertyName2AliasBase(string propertyName)
        {
            string[] parts = propertyName.Split('.');
            if (parts.Length > 1)
            {
                string[] sparts = new string[parts.Length - 1];
                Array.Copy(parts, sparts, sparts.Length);
                return "_" + string.Join("", sparts) + "." + parts[parts.Length - 1];
            }
            else
                return propertyName;
        }
            
        
    }
}