using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MsdLib.ExtensionFuncs.PersianDateTime;
namespace IRERP_RestAPI.Areas.Report.Models
{
    public class GeneralReportVariables
    {
        public virtual string CompanyName { get { return "پتیاک"; } } // depend on current site language descite petiak or پتیاک
        public virtual string persianToday { get { return DateTime.Now.ToPersianDateTime().ToString(); } }
        public virtual string CompanyAddress { get { return "شهید قلندی - تهران - بزرگراه شهید صدر"; } }
        public virtual string CompanyShoar { get { return "همه چیز خوبست مگر اینکه تو نخواهی که باشد"; } }
        public virtual System.Drawing.Bitmap CompanyLogo { get { return new System.Drawing.Bitmap(IRERP_RestAPI.Bases.IRERPApplicationUtilities.PhysicalApplicationPath()+@"Images\logo.png"); } }
    }
}