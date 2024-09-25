/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name          :   App.xaml.cs
Function           :   Maintain Details for Opening Application
Created By         :  
Created on         :   
Revision History   :   [08-Feb-2024] : Piyush Anand
                   :   [HD-00393919] : Added new Method OnExit
****************************************************************************************************/

using CefSharp;
using CefSharp.Wpf;
using Common.Core.Contracts.Models.SupplyPlanning;
using Common.UX.Api;
using Common.UX.Api.Endpoints;
using Common.UX.Logging;
using Common.UX.Wpf.Helpers;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SEWSE.H1.UX.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            UXLogger.UXLoggingForDebug($"App.xaml :: OnStartup:: started");
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("1. OnStartup-");

            }
            base.OnStartup(e);
            //resolver + initialise cefsharp etc
            //Add Custom assembly resolver
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("2. after resolver attachement-");

            }
            //Any CefSharp references have to be in another method with NonInlining
            // attribute so the assembly rolver has time to do it's thing.
            InitializeCefSharp();

            var newCulture = new CultureInfo("en-US");
            // Set desired date format here
            newCulture.DateTimeFormat.DateSeparator = "/";
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = newCulture;
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("3. Bootstrapper intialize");

            }
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
            UXLogger.UXLoggingForDebug($"App.xaml :: OnStartup:: bootstrapper ran");
            UXLogger.UXLoggingForDebug($"App.xaml :: OnStartup:: ended");
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("4. Bootstrapper Run on startup end");

            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            UXLogger.UXLoggingForDebug($"App.xaml :: CurrentDomain_UnhandledException:: started");
            var cefpath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitOperatingSystem ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");

            var ex = (Exception)e.ExceptionObject;
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine(ex.Message);
                file.WriteLine(ex.InnerException);
                file.WriteLine(ex.StackTrace);
                file.WriteLine(cefpath);
            }
            UXLogger.UXLoggingForDebug($"App.xaml :: CurrentDomain_UnhandledException:: Exception.Message: {  ex.Message }");
            UXLogger.UXLoggingForDebug($"App.xaml :: CurrentDomain_UnhandledException:: Exception.InnerException: {  ex.InnerException }");
            UXLogger.UXLoggingForDebug($"App.xaml :: CurrentDomain_UnhandledException:: Exception.StackTrace: {  ex.StackTrace }");
            UXLogger.UXLoggingForDebug($"App.xaml :: CurrentDomain_UnhandledException:: ended");
        }    


        private static void InitializeCefSharp()
        {
            UXLogger.UXLoggingForDebug($"App.xaml :: InitializeCefSharp:: started");
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("Start : InitializeCefSharp");

            }
            var settings = new CefSettings();

            // Set BrowserSubProcessPath based on app bitness at runtime
            settings.BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitOperatingSystem ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe");

            UXLogger.UXLoggingForDebug($"App.xaml :: InitializeCefSharp:: Client Machine Type : { (Environment.Is64BitProcess ? "x64" : "x86") }");
            UXLogger.UXLoggingForDebug($"App.xaml :: InitializeCefSharp:: CefSharp.BrowserSubprocess.exe path : { settings.BrowserSubprocessPath }");

            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("2." + settings.BrowserSubprocessPath);

            }
            //settings.CefCommandLineArgs.Add("allow-cross-origin-auth-prompt", "1");
            //settings.RegisterScheme(new CefCustomScheme()
            //{
            //    SchemeName = "http",
            //    DomainName = "localhost",
            //    IsCorsEnabled = false
            //});
            // Make sure you set performDependencyCheck false
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            settings.CefCommandLineArgs.Add("disable-gpu", "1");
            settings.CefCommandLineArgs.Add("disable-gpu-vsync", "1");
            settings.CefCommandLineArgs.Add("winhttp-proxy-resolver", "1");
            settings.SetOffScreenRenderingBestPerformanceArgs();
            //Cef.AddCrossOriginWhitelistEntry("http://localhost", "http", "http://ukhqh1live.sews-e.com:19081", true );
            settings.CefCommandLineArgs.Add("disable-web-security", "true");
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("3. intialize start InitializeCefSharp");

            }

            Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);
            UXLogger.UXLoggingForDebug($"App.xaml :: InitializeCefSharp:: ended");
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("4. intialize end InitializeCefSharp");

            }
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        // Required by CefSharp to load the unmanaged dependencies when running using AnyCPU
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            using (var file = new StreamWriter("HarnessOneLog.txt", true))
            {
                file.WriteLine("1. Resolver start ");

            }
            if (args.Name.StartsWith("CefSharp"))
            {
                using (var file = new StreamWriter("HarnessOneLog.txt", true))
                {
                    file.WriteLine("2. inside if of Resolver");

                }
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitOperatingSystem ? "x64" : "x86",
                                                       assemblyName);
                UXLogger.UXLoggingForDebug($"App.xaml :: Resolver path :: { archSpecificPath }");
                using (var file = new StreamWriter("HarnessOneLog.txt", true))
                {
                    file.WriteLine("3. archSpecificPath-" + archSpecificPath);

                }
                var fileexists = File.Exists(archSpecificPath);
                using (var file = new StreamWriter("HarnessOneLog.txt", true))
                {
                    file.WriteLine("4. fileexists-" + fileexists.ToString());

                }

                return File.Exists(archSpecificPath)
                           ? Assembly.LoadFile(archSpecificPath)
                           : null;

            }

            return null;
        }

        // protected override void OnExit(ExitEventArgs e)
        // {
        //     try
        //     {
        //       SingleUserAccess singleUserAccess = new SingleUserAccess();
        //       singleUserAccess.ApplicationGuid = UserPreferenceSetupHelper.CurrentUser.ApplicationGuid;
        //       singleUserAccess.UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid;
        //       singleUserAccess.HostName = UserPreferenceSetupHelper.CurrentUser.HostName;
        //       var errors = Task.Run(() => NetCoreServiceHelper.PostAndGet<SingleUserAccess>(ServiceEndpointRoutes.ProcessOperationSinleUserAccessCloseAll, singleUserAccess)).Result;
        //     }
        //     catch
        //     {
        //         //error handling
        //     }
        //     finally
        //     {
        //         base.OnExit(e);
        //     }
        // }
    }
}
