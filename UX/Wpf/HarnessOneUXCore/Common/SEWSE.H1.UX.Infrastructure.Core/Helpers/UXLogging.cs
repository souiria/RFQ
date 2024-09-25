using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public static class UXLogging
    {

        public static string Filepath { get; set; }
        private static object locker = new object();
        //public static void UXLoggingForDebug(string logMessage)
        //{

        //    string currentStartupPath = Path.Combine(Environment.CurrentDirectory, "Logs");
        //    //FileStream myFileStream = null;

        //    string currentLogPath = currentStartupPath + "\\UXLogging_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        //    if (!Directory.Exists(currentStartupPath))
        //    {
        //        Directory.CreateDirectory(currentStartupPath);
        //    }
        //    if (!File.Exists(currentLogPath))
        //    {
        //        var currentFile = File.Create(currentLogPath);
        //        currentFile.Close();
        //    }
        //    lock (locker)
        //    {
        //        using(FileStream file = new FileStream(currentLogPath, FileMode.Append, FileAccess.Write, FileShare.Read))
        //        {
        //            StreamWriter writer = new StreamWriter(file, Encoding.Unicode);
        //            //DateTime.Now.ToLongTimeString()
        //            //streamWriter.WriteLine("{0} {1} {2}", DateTime.Now.ToString("hh:mm:ss:fff tt"), DateTime.Now.ToLongDateString(), logMessage);
        //            writer.WriteLine($"{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:fff")} -- { logMessage }");
        //            writer.Close();
        //        }
        //    }       

        //    //    if (!File.Exists(currentLogPath))
        //    //{
        //    //    var currentFile = File.Create(currentLogPath);
        //    //    //TextWriter tw = new StreamWriter(path, true);
        //    //    //tw.WriteLine(DateTime.Now.ToString() + " " + "Class:" + " " + ClassName + " " + "Message:" + Message);
        //    //    //tw.Close();
        //    //    currentFile.Close();
        //    //}
        //    //lock (locker)
        //    //{
        //    //    using (StreamWriter streamWriter = File.AppendText(currentLogPath))
        //    //    {

        //    //        //DateTime.Now.ToLongTimeString()
        //    //        //streamWriter.WriteLine("{0} {1} {2}", DateTime.Now.ToString("hh:mm:ss:fff tt"), DateTime.Now.ToLongDateString(), logMessage);
        //    //        streamWriter.WriteLine($"{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:fff")} -- { logMessage }");
        //    //        streamWriter.Close();
        //    //    }
        //    //}

        //    //, TextWriter txtWriter

        //    //else if (File.Exists(path))
        //    //{
        //    //    //TextWriter tw = new StreamWriter(path, true);
        //    //    //tw.WriteLine(DateTime.Now.ToString() + " " + "Class:" + " " + ClassName + " " + "Message:" + Message);
        //    //    //tw.Close();
        //    //}

        //    //if (!Directory.Exists("Logs"))
        //    //{
        //    //    Directory.CreateDirectory("Logs");
        //    //}

        //}


        public static void  UXLoggingForDebug(string logMessage)
        {
            string currentStartupPath = Path.Combine(Environment.CurrentDirectory, "Logs");
            Filepath = currentStartupPath + "\\UXLogging_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            while (true)
            {
                try
                {
                    //Wait for resource to be free
                    lock (locker)
                    {
                        using (FileStream file = new FileStream(Filepath, FileMode.Append, FileAccess.Write, FileShare.Read))
                        using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                        {
                            writer.WriteLine($"{ DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:fff")} -- { logMessage }");
                        }
                    }
                    break;
                }
                catch
                {
                    //File not available, conflict with other class instances or application
                }
            }
        }

    }
}
