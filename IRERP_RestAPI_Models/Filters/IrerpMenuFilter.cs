using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IRERP_RestAPI.Bases;
using IRERP_RestAPI.Models;
using MsdLib.CSharp.BLLCore;

namespace IRERP_RestAPI.Filters
{
    public class IrerpMenuFilter : IRERPFilter<IrerpMenuFilter, MenuItem>
    {
        public IrerpMenuFilter() 
        {
            
             
           /* ParentId = new DBVar<Guid?>();
            id = new DBVar<Guid?>();*/
        }
        public bool useParentIdInFilter { get; set; }
        public bool useidInFilter { get; set; }
        public /*DBVar<Guid?>*/ Guid? ParentId { get; set; }
        public /*DBVar<Guid?>*/ Guid? id { get; set; }
        public User usrMenu { get; set; }
        public virtual Guid? groupmenuId { get; set; }
        public  virtual Guid? userId { get; set; }
        public  override NHibernate.IQueryOver<MenuItem, MenuItem> Query
        {
            get
            {

                var basequery = base.Query; 
               
                basequery.And(x => x.IsDeleted == false);
                if (useParentIdInFilter)
                    basequery.And(x => x.ParentID == ParentId);
                if(id!=null)
                    basequery.And(x => x.id == id);
                if (groupmenuId != null)
                {
                    MsdCriteria crit = new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x => x.GroupMenus[0].Menu.id,true),
                        Operator = MsdCriteriaOperator.equals,
                        value = groupmenuId.ToString()
                    };
                    this.Criterias.Add(crit);
                    this.Criterias.Add(new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x=>x.GroupMenus[0].IsDeleted,true),
                        Operator = MsdCriteriaOperator.equals,
                        value = false.ToString()
                    });
                }

                if (userId != null)
                {

                    this.Criterias.Add(new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x => x.GroupMenus[0].Group.GroupUsers[0].User.id, true),
                        Operator = MsdCriteriaOperator.equals,
                        value = userId.ToString()
                    });
                    this.Criterias.Add(new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x => x.GroupMenus[0].IsDeleted,true),
                        Operator = MsdCriteriaOperator.equals,
                        value = false.ToString()
                    });
                    this.Criterias.Add(new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x=>x.GroupMenus[0].Group.IsDeleted,true),
                        Operator  = MsdCriteriaOperator.equals,
                        value = false.ToString()
                    });
                    this.Criterias.Add(new MsdCriteria()
                    {
                        fieldName = IRERPApplicationUtilities.GPN<MenuItem>(x => x.GroupMenus[0].Group.GroupUsers[0].IsDeleted, true),
                        Operator = MsdCriteriaOperator.equals,
                        value = false.ToString()
                    });

                }

              /*  if(ParentId.isLoaded)
                    basequery.And(x => x.ParentID == ParentId.value);
                if (id.isLoaded)
                    basequery.And(x => x.id == id.value);
                */
                return basequery;
            }
            set
            {
                base.Query = value;
            }
        }
    }
}