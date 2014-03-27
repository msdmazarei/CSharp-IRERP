using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using MsdLib.ExtensionFuncs;
using MsdLib.ExtentionFuncs;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
namespace IRERP_RestAPI.Bases
{
    public class FileManager
    {
        public static string getUploadPath()
        {
            string uploadfolderpath = IRERPApplicationUtilities.PhysicalApplicationPath() + @"Upload";

            if (ConfigurationManager.AppSettings.HasKeys())
                if (ConfigurationManager.AppSettings.AllKeys.Contains("UploadPath"))
                    uploadfolderpath = ConfigurationManager.AppSettings["UploadPath"];

            if (uploadfolderpath[uploadfolderpath.Length - 1] != '\\')
                uploadfolderpath += @"\";
            return uploadfolderpath;
        }
        public static string getTempUploadPath()
        {
            string tempuploadfolderpath = IRERPApplicationUtilities.PhysicalApplicationPath() + @"TempUpload";

            if (ConfigurationManager.AppSettings.HasKeys())
                if (ConfigurationManager.AppSettings.AllKeys.Contains("TempUploadPath"))
                    tempuploadfolderpath = ConfigurationManager.AppSettings["TempUploadPath"];

            if (tempuploadfolderpath[tempuploadfolderpath.Length - 1] != '\\')
                tempuploadfolderpath += @"\";
            return tempuploadfolderpath;
        }
        public static string saveFileToTempFolder(byte[] FileContent)
        {
            string filename = Guid.NewGuid().ToString();
            var path = getTempUploadPath() + filename;
            File.WriteAllBytes(path, FileContent);
            return filename;
        }
        public static string MoveFileFromTemp(string filename)
        {

            if (File.Exists(getTempUploadPath() + filename))
            {
                if (File.Exists(getUploadPath() + filename))
                    return "Your Specified filename exists in upload directory before";
                try
                {
                    File.Copy(getTempUploadPath() + filename, getUploadPath() + filename);
                    return filename;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "There is no file with your passed filename";
            }
        }
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );

        public static string getMimeFromFile(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException(filename + " not found");

            byte[] buffer = new byte[256];
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                if (fs.Length >= 256)
                    fs.Read(buffer, 0, 256);
                else
                    fs.Read(buffer, 0, (int)fs.Length);
            }
            try
            {
                System.UInt32 mimetype;
                FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                string mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
                return mime;
            }
            catch (Exception e)
            {
                return "unknown/unknown";
            }
        }
        public static string getmd5CheckSum(string filepath)
        {
            string rtn = "NOTFindFile";
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filepath))
                {
                    var bys = md5.ComputeHash(stream);
                    rtn = "";
                    bys.ToList().ForEach(x =>
                    {
                        rtn += x.ToString("x2");
                    });
                    
                }
            }
            return rtn;
        }
    }
}