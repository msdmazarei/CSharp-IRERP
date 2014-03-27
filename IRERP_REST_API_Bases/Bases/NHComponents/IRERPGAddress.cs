using IRERP_RestAPI.Bases.Extension.HTML.Controls.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.ExtentionFuncs.Strings;
namespace IRERP_RestAPI.Bases.NHComponents
{
    public class IRERPGAddress : IRERPNHComponent
    {
        public virtual double? Lat { get; set; }
        public virtual double? Lng { get; set; }
        public virtual string Address { get; set; }
        public virtual string Roof { get; set; }
        public virtual string ApartmentNo { get; set; }
        public virtual string GoogleAddress { get; set; }

        public static List<IRERPControlTypes_DataSourceField> GetFields(string Path)
        {
            var rtn = new List<IRERPControlTypes_DataSourceField>();

            rtn.Add(
                new IRERPControlTypes_DataSourceField()
                {
                    name = Path + ".Lat".ToClientDsFieldName(),
                    type = IRERPControlTypes_FieldType.text,
                    hidden = true
                });

            rtn.Add(
                new IRERPControlTypes_DataSourceField()
                {
                    name = Path + ".Lng".ToClientDsFieldName(),
                    type = IRERPControlTypes_FieldType.text,
                    hidden = true
                });
            rtn.Add(
                new IRERPControlTypes_DataSourceField()
                {
                    name = Path + ".Address".ToClientDsFieldName(),
                    type = IRERPControlTypes_FieldType.irerpGAddress,

                });
            rtn.Add(
                new IRERPControlTypes_DataSourceField()
                {
                    name = Path + ".Roof".ToClientDsFieldName(),
                    type = IRERPControlTypes_FieldType.text,
                    hidden = true
                });
            rtn.Add(
               new IRERPControlTypes_DataSourceField()
               {
                   name = Path + ".ApartmentNo".ToClientDsFieldName(),
                   type = IRERPControlTypes_FieldType.text,
                   hidden = true
               });
            rtn.Add(
               new IRERPControlTypes_DataSourceField()
               {
                   name = Path + ".GoogleAddress".ToClientDsFieldName(),
                   type = IRERPControlTypes_FieldType.text,
                   hidden = true
               });
            return rtn;


        }

    }
    public class IRERPGAddressMap : FluentNHibernate.Mapping.ComponentMap<IRERPGAddress>
    {
        public IRERPGAddressMap()
        {
            Map(x => x.Address).Column("_Addr");
            Map(x => x.ApartmentNo).Column("_AptNo");
            Map(x => x.GoogleAddress).Column("_GAddr");
            Map(x => x.Lat).Column("_Lat");
            Map(x => x.Lng).Column("_Lng");
            Map(x => x.Roof).Column("_Roof");

        }
    }
}
