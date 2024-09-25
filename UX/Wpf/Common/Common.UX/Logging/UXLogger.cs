using Common.UX.Contracts.Interfaces.Core;
using System;
using System.IO;
using System.Text;

namespace Common.UX.Logging
{
    public static class UXLogger
    {
        public static string Filepath { get; set; }
        public static IUXLogger UXLoggerProxyInstance;
        public static void UXLoggingForDebug(string logMessage)
        {
            if (UXLoggerProxyInstance == null)
            {
                UXLoggerProxyInstance = new UXLoggerProxy();
                UXLoggerProxyInstance.Filepath = Filepath;
            }
            UXLoggerProxyInstance.UXLoggingForDebug(logMessage);
        }

    }
    public class UXLoggerProxy : IUXLogger
    {
        private static readonly object Locker = new object();

        public string Filepath { get; set; }

        public void UXLoggingForDebug(string logMessage)
        {
            var currentStartupPath = Path.Combine(Environment.CurrentDirectory, "Logs");
            Filepath = currentStartupPath + "\\UXLogging_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            while (true)
            {
                try
                {
                    //Wait for resource to be free
                    lock (Locker)
                    {
                        using (FileStream file = new FileStream(Filepath, FileMode.Append, FileAccess.Write, FileShare.Read))
                        using (StreamWriter writer = new StreamWriter(file, Encoding.Unicode))
                        {
                            writer.WriteLine($"{ DateTime.Now:dd/MM/yyyy hh:mm:ss:fff} -- { logMessage }");
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
