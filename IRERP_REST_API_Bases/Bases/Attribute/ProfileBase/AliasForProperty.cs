using IRERP_RestAPI.Bases.Attribute.ProfileBase;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{
    public class AliasForProperty : IRERPProfileBaseAttribute
    {
        public virtual string PropertyPath { get; set; }
        public static AliasForProperty GetForSpecType<T>(IRERPProfile Profile,System.Reflection.MemberInfo meminfo)
        {
            return GetForSpecType(typeof(T), Profile, meminfo);
            
        }

        public static AliasForProperty GetForSpecType(Type Typ, IRERPProfile Profile, System.Reflection.MemberInfo meminfo)
        {
            AliasForProperty aliasforproperty = null;
            if (IRERPDescriptorVars.STOREAliasForProperty.ContainsKey(new IRERPTypeName(Typ)))
            {
                if (IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)].ContainsKey(Profile))
                {
                    if (IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)][Profile].ContainsKey(meminfo))
                        aliasforproperty = IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)][Profile][meminfo];
                }
                else if (IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)].ContainsKey(IRERPProfile.Any))
                {
                    if (IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)][IRERPProfile.Any].ContainsKey(meminfo))
                        aliasforproperty = IRERPDescriptorVars.STOREAliasForProperty[new IRERPTypeName(Typ)][IRERPProfile.Any][meminfo];
                }
            }
            return aliasforproperty;

        }
    }
}
