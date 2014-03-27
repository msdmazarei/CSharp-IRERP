using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MsdLib.CSharp;
using MsdLib.ExtentionFuncs;
using MsdLib.Types.NH;

namespace MsdLib.CSharp.Models.Maps
{
    public class Report:ClassMap<Models.Report>
    {
        public Report()
        {
            Models.Report tmp = new Models.Report();
            Table(tmp.TableName());
            LazyLoad();
            Id(x=>x.id);
            Map(x => x.IsDeleted).Index(tmp.IndexName(x => x.IsDeleted));
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.ClassName).Index(tmp.IndexName(x => x.ClassName));
            Map(x => x.Content).CustomType<ByteArrayUserType>();
        }
    }
}
