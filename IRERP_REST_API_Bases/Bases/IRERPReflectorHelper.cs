using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using MsdLib.CSharp.BLLCore;
namespace IRERP_RestAPI.Bases
{
    public class IRERPReflectorHelper 
    {
        public static FunctionResult<Object> GetInstance(string ClassName)
        {
            FunctionResult<Object> rtn = new FunctionResult<Object>();
            Type T = rtn.GetType().Assembly.GetType(ClassName);
            try
            {
                rtn.ResultValue = Activator.CreateInstance(T);
                rtn.Time = DateTime.Now;
                rtn.FunctionName = "IRERPReflectorHelper.GetInstance";
                rtn.Result = true;
            }
            catch (Exception ex)
            {
                rtn.Result = false;
                rtn.Error = new PException(ex.Message, ex);
                rtn.FunctionName = "IRERPReflectorHelper.GetInstance";
                rtn.Time = DateTime.Now;
                rtn.ResultValue = null;

            }

            return rtn;

        }
        public static FunctionResult<Type> GetPropertyTypeUsingPropertyName(object Obj, string PropertyName)
        {
            FunctionResult<Type> rtn = new FunctionResult<Type>() { FunctionName = "IRERPReflectorHelper.GetPropertyTypeUsingPropertyName" };
            try
            {
                string[] parts = PropertyName.Split('.');
                var ty = Obj.GetType();
                parts.ToList().ForEach(p => ty = ty.GetProperty(p).DeclaringType);
                rtn.ResultValue = ty;
                rtn.Result = true;
            }
            catch (Exception ex)
            {
                rtn.Result = false;
                rtn.Error = new PException(ex.Message, ex);
            }

            return rtn;
        }
        public static FunctionResult<List<ATT>> GetPropertyAttribute<ATT>(Type T, string Property)
        {
            FunctionResult<List<ATT>> rtn = new FunctionResult<List<ATT>>() { FunctionName = "GetPropertyAttribute" };
            rtn.ResultValue = new List<ATT>();
            try
            {
                var res = T.GetProperty(Property).GetCustomAttributes(typeof(ATT), true);
                
                if (res != null)
                {
                    foreach (var a in res)
                        rtn.ResultValue.Add((ATT)a);
                }
                else
                {
                    rtn.ResultValue = null;
                }
            }
            catch (Exception ex) { rtn.Result = false; rtn.Error = new PException(ex.Message, ex); }
            return rtn;
        }
    }
}