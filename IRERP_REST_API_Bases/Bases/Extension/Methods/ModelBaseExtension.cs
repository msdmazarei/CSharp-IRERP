using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases.Extension.HTML.Controls;
using IRERP_RestAPI.Bases.MetaDataDescriptors;
using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;

using System.Linq.Expressions;
namespace IRERP_RestAPI.Bases.Extension.Methods
{
    public static class ModelBaseExtension
    {
       
        public static IRERP_SM_DataSource GetDataSource<T>(this ModelBase<T> Model,IRERPProfile Profile)
            where T: ModelBase<T>
        {
            return IRERP_SM_DataSource.GetDataSource<T>(Profile);
        }

        public static IRERP_SM_DataSource GetDataSource<T,T1>(this ModelBase<T> Model, IRERPProfile Profile, Expression<Func<T, IList<T1>>> Member)
            where T : ModelBase<T>
            where T1 : ModelBase<T1>
        {
            return IRERP_SM_DataSource.GetDataSource<T, T1>(Profile, Member); 
        }


            
    
    }
}