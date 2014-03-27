using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.Models;
using MsdLib.CSharp.DALCore;
using MsdLib.ExtentionFuncs;
namespace MsdLib.CSharp.Models.Maps
{
    public class ReportVariable : MsdClassMap<Models.ReportVariable>
    {
        public ReportVariable()
        {
            Models.ReportVariable tmp = new Models.ReportVariable();
            Table(tmp.TableName());
            LazyLoad();
            Id(x => x.id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.IsDeleted).Index(tmp.IndexName(x=>x.IsDeleted));
            Map(x => x.Reportid).Index(tmp.IndexName(x => x.Reportid));
            Map(x => x.DefaultValue);

        }
    }
}
