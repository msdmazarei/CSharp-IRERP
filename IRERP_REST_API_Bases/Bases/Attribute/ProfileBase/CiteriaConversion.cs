using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases.Attribute.ProfileBase
{

    public class CriteriaConversion : IRERPProfileBaseAttribute
    {
        
            public Func<object, PCriteria,ICriterion>
            ConvertorMethod { get; set; }

        public ICriterion Convert(object Model, PCriteria inp)
        {
            return ConvertorMethod(Model,inp);
/*                case CiteriaConversionType.Delegate:
                    return
                    (
                    (Converter<PCriteria, ICriteria>)
                    Model.GetType().GetField(ConvertorMethod).GetValue(Model)
                    ).Invoke(inp);

                    

                case CiteriaConversionType.Method:
                    return
                        (ICriteria)
                        Model.GetType().GetMethod(ConvertorMethod).Invoke
                    (Model, new object[] { inp });*/
            }
            //return null;
        }

    }
