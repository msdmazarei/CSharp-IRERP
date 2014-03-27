using MsdLib.CSharp.DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using System.Collections;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using System.Linq.Expressions;
namespace IRERP_RestAPI.Bases.IRERPController.IRERPControllerMetaModel
{
    public class ControllerMetaModelBase<T> : ModelBase<T>
        where T: ControllerMetaModelBase<T>,INHibernateEntity
    {
        public virtual IRERP_SM_DataSource GenDS<TMember>(IRERPProfile Profile)
            where TMember : ModelBase<TMember>
        {
            return IRERP_SM_DataSource.GetDataSource<TMember>(Profile);
        }

        public virtual IRERP_SM_DataSource GenDS<TMember>(Expression<Func<T, IList<TMember>>> Member, IRERPProfile? SpecMetaModelProfile = null,string ControllerUrl = null,string ID=null)
            where TMember : ModelBase<TMember>
        {
            IRERP_SM_DataSource ds = new IRERP_SM_DataSource();
            //var properties = IRERPDescriptorVars.STOREDSFieldProperty[new IRERPTypeName(typeof(T))];
            IRERPProfile _Profile = SpecMetaModelProfile != null ? (IRERPProfile)SpecMetaModelProfile : Profile;
            
            
            //Validate Member in Controller Meta Data

            IList<string> _Props  = IRERPApplicationUtilities.SplitPropertiesInExpression(Member);
            Type curType = this.GetType();
            IRERPProfile __Profile = _Profile;
            //bool __isValidate = false;
            if(
                IRERPApplicationUtilities.GetMemberPropertyTypeProfile(this.GetType(),_Profile,_Props.ToArray())
                ==IRERPProfile.Unknown)
                return null;
            __Profile = IRERPApplicationUtilities.GetMemberPropertyTypeProfile(this.GetType(), _Profile, _Props.ToArray());
/*            for(int i=0;i < _Props.Count;i++)
            {
                //Check User For Profile
                var useasprofile = IRERPDescriptorVars.STOREUseAsProfile[new IRERPTypeName(curType)];
                var __meminfo = IRERPApplicationUtilities.GetClassMember(curType,_Props[i]);
                if (useasprofile == null) break;
                if (!useasprofile.Keys.Contains(__meminfo)) break;
                //Check Profile
                if (useasprofile[__meminfo].Profiles == null) break;
                if (
                    !
                    (
                    useasprofile[__meminfo].Profiles.Contains(_Profile) 
                    ||
                    useasprofile[__meminfo].Profiles.Contains(IRERPProfile.Any) 
                    )
                    ) break;
                
                    curType = ((System.Reflection.PropertyInfo)(__meminfo)).PropertyType;
                    __Profile = useasprofile[__meminfo].TargetProfile;
                
                if (i == _Props.Count - 1)
                    __isValidate = true;
            }
            if (!__isValidate) 
                return null;
  */          
            //Generate From type of TMember using __Profile
            ds = GenDS<TMember>(__Profile);
            ds.dataURL =new Extension.HTML.Controls.Types.IRERPControlTypes_URL(
                ControllerUrl +"DataSource/"+_Profile.ToString()+"/"
                + string.Join("/",IRERPApplicationUtilities.SplitPropertiesInExpression(Member))
                );
            if (ID != null) ds.ID = ID;
            return ds;

        }
    }
}