using IRERP_RestAPI.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Areas.Report.Models
{
    public class ReportModel : ModelBase<ReportModel>
    {
        public virtual string fullname { get; set; }
        public virtual string Name { get; set; }
        public virtual string NameSpace { get; set; }
        public virtual Type ReportModelType { get; set; }
        public virtual IList<ReportModelProperty> Properties
        {
            get
            {
                List<ReportModelProperty> rtn = new List<ReportModelProperty>();
                if (fullname == null) return rtn;
                Type t = 
                    ReportModelType==null? 
                    IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetTypeFromString(fullname):
                    ReportModelType;


                t.GetProperties().ToList().ForEach(
                    x=>{
                        //Remove _____x properties cause they use only in NH 
                        if(x.Name.IndexOf("_____")==0) return;
                        //TODO: IList properties can be used for filter but in future not now
                        //Remove IList Implemented Properties 

                        if(
                            IRERP_RestAPI.Bases.IRERPApplicationUtilities.IsSubclassOfRawGeneric(typeof(IList<>),
                            IRERP_RestAPI.Bases.IRERPApplicationUtilities.GetClassPropertyType(t,x.Name)
                            )
                            ) return;
                        var item = new ReportModelProperty(){ 
                        Name = x.Name, 
                        fullpath = fullname+"."+x.Name, 
                        Type =x.DeclaringType.Name.ToString(),
                        ParentPath = fullname
                        };
                        rtn.Add(item);
                    }
                    );
                return rtn;
                    
            }
        }
    }
}