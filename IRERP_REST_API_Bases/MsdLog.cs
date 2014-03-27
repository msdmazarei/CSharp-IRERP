using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace IRERP_RestAPI.Bases
{
    public enum LogType
    {
        Info=5555,
        Warn = 5556,
        Fatal = 5557,
        Bank = 5558,
        BackBankWorkflow = 5559,
        PerformaInvoice = 5560
    
    }
    public class MsdLog
    {
        public bool LogsWritten = false;
        EventLog syslog = null;
        /// <summary>
        /// example c:\1\logs
        /// </summary>
        public string LogPath { get; set; }
        string sysSourceName
        {
            get
            {
                string now = DateTime.Now.ToShortDateString().Replace("/","S").Replace("-","S");
                return
                    "MSDACC" + now;
            }
        }
        DateTime instancecreatedatetime = DateTime.Now;
        public MsdLog()
        {
            return;
            LogsWritten = false;
            //LogPath = IRERPApplicationUtilities.PhysicalApplicationPath();
            if (System.Configuration.ConfigurationManager.AppSettings["msd.log.path"] != null)
                LogPath = System.Configuration.ConfigurationManager.AppSettings["msd.log.path"];
            
            if(!EventLog.SourceExists(sysSourceName))
            IRERPApplicationUtilities.ResumeNext(() => EventLog.CreateEventSource(sysSourceName, sysSourceName));
            syslog = new EventLog();
            syslog.Source = sysSourceName;
            
        }
        
        public List<Tuple<LogType, string>> LOGs = new List<Tuple<LogType, string>>();
        public bool log(LogType type, string Message)
        {
            
            LOGs.Add(new Tuple<LogType, string>(type, Message));
            return true;
        }
        string _correctpath;
        public string correctpath
        {

            get
            {
                if (_correctpath == null)
                {
                    string path = LogPath;
                    if (path.Substring(path.Length - 1, 1) != "\\") path += "\\";
                    _correctpath = path + DateTime.Now.ToShortDateString().Replace("/", "-") + "\\MSDSYS\\NULLCORRECTPATH\\";
                }
                return _correctpath;
            }
            set { _correctpath = value; }
        }
        void correctfolders()
        {
            string path = correctpath;
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
        }
        public int eventID { get; set; }
        public void WriteToFiles()
        {
            return;
            LogsWritten = true;
            Enum.GetNames(typeof(LogType)).ToList().ForEach(y =>
            {
                var items = (from x in LOGs where x.Item1.ToString() == y select x.Item2).ToList();
                if (items != null && items.Count > 0)
                {
                    string logcontent = string.Join("\r\n", items);
                    logcontent="---- Requests From Client Inputed @"+instancecreatedatetime.ToString()+
                        " And Responded @" + DateTime.Now.ToString() + " From Ip Address " +
                IRERPApplicationUtilities.GetClientIP() +
                " Http Request No. " + HttpContext.Current.Request.GetHashCode().ToString()
                + "------------------\r\n" + logcontent + "\r\n";

                    if ((LogType)Enum.Parse(typeof(LogType), y) == LogType.Fatal)
                    {
                        IRERPApplicationUtilities.ResumeNext(() =>
                        syslog.WriteEntry(logcontent, EventLogEntryType.Error, eventID,(short)LogType.Fatal)
                        );
                    }
                    else
                    {
                        LogType l = (LogType)Enum.Parse(typeof(LogType), y);
                        IRERPApplicationUtilities.ResumeNext(() =>
                            syslog.WriteEntry(
                           logcontent, 
                            EventLogEntryType.Information, 
                            eventID, 
                            (short)l
                            )
                            );
                    }

                }
            });
                    

            return;

            System.Threading.Mutex Mutex = null;
            try
            {

                correctfolders();
               
                //Write infos
                //get mutex 
                
                string mutexname = correctpath.Replace(":", "").Replace("\\", "");
                try
                {
                    Mutex = System.Threading.Mutex.OpenExisting(mutexname);
                }
                catch
                {
                    Mutex = new System.Threading.Mutex(true, mutexname);
                }
                if (Mutex.WaitOne(5000))
                {
                    if(LOGs!=null && LOGs.Count>0)
                    
                    Enum.GetNames(typeof(LogType)).ToList().ForEach(y =>
                    {
                        var items = (from x in LOGs where x.Item1 .ToString()==y select x.Item2).ToList();
                        if (items != null && items.Count > 0)
                            WriteFile(
                                (LogType)Enum.Parse(typeof(LogType), y), 
                                items.ToArray());
                    });
                    
                    Mutex.ReleaseMutex();
                }
            }
            catch {
                IRERPApplicationUtilities.ResumeNext(() => Mutex.ReleaseMutex());
            }
            
        }
        void WriteFile(LogType type, string[] strs)
        {
            if (strs != null && strs.Length > 0)
            {
                string content = string.Join("\r\n", strs);
                content = "------------------ After Flush @" + DateTime.Now.ToString() + " From Ip Address " +
                IRERPApplicationUtilities.GetClientIP() +
                " Http Request No. " + HttpContext.Current.Request.GetHashCode().ToString()
                + "------------------\r\n" + content+"\r\n";
                string path = correctpath;
                string filename = path + type.ToString();
                System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Append);
                byte[] buf = System.Text.Encoding.Unicode.GetBytes(content);
                fs.Write(buf, 0, buf.Length);
                fs.Close();
            }
        }
    }
}