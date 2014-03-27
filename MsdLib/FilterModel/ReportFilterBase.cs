using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsdLib.CSharp.BLLCore;
using MsdLib.CSharp.Models;
namespace MsdLib.CSharp.FilterModel
{
    public class ReportFilterBase: FilterBase<ReportFilterBase,Report>
    {
        Guid? _id;
        public Guid? Id { get { return _id; } set { _id = value; OnPropertyChanged(GPN(x => x.Id)); } }

            
    }
}
