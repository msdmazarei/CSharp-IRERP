using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRERP_RestAPI.Bases.NHComponents
{
    public class IRERPFile : IRERPNHComponent
    {
        public virtual Guid? FileName { get; set; }
        public virtual long? FileSize { get; set; }
        public virtual DateTime? FileCreationDate { get; set; }
        public virtual string FileCRC { get; set; }
        public virtual string RealFileName { get; set; }
        public virtual string FileType { get; set; }
        public virtual void CompleteOtherProperties()
        {
            if (FileName != null)
            {
                string filepath = FileManager.getTempUploadPath() + FileName.ToString();
                if(!System.IO.File.Exists(filepath))
                    filepath = FileManager.getUploadPath()+FileName.ToString();
                if(!System.IO.File.Exists(filepath))
                    return;
                var fi = new System.IO.FileInfo(filepath);
                FileSize = fi.Length;
                FileType = FileManager.getMimeFromFile(filepath);
                FileCreationDate = fi.CreationTime;
                FileCRC = FileManager.getmd5CheckSum(filepath);
                FileManager.MoveFileFromTemp(FileName.ToString());

            }
        }
    }
    public class IRERPFileMap : FluentNHibernate.Mapping.ComponentMap<IRERPFile>
    {
        public IRERPFileMap()
        {
            Map(x => x.FileName).Column("_FiN");
            Map(x => x.FileSize).Column("_FiS");
            Map(x => x.FileCreationDate).Column("_FiC");
            Map(x => x.FileCRC).Column("_FiCC");
            Map(x => x.RealFileName).Column("_FiR");
            Map(x => x.FileType).Column("_FiT");
        }
    }

}
