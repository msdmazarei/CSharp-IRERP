using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.DALCore;
using MsdLib.CSharp.Utils;

namespace MsdLib.ExtentionFuncs
{
    public static class ModelBaseExtensions
    {
        public static string TableName<Model>(this ModelBase<Model> Mod)
            where Model: ModelBase<Model>
        {
            return "PTKINVMNGR_" + Mod.GetType().Name;
        }
        public static string IndexName<Model>(this ModelBase<Model> Mod, System.Linq.Expressions.Expression<Func<Model, Object>> PropertyName)
             where Model : ModelBase<Model>
        {
            return "INDX_"+TableName(Mod) + "_" + AppUtils.GPN(PropertyName);
        }

    }
}
