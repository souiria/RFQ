using System;
using System.Threading;
using System.Windows.Threading;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using SEWSE.H1.UX.Module.Core.Splash.ViewModels;
using SEWSE.H1.UX.Module.Core.Splash.Views;
using System.Windows;
using System.Net;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;

namespace SEWSE.H1.UX.Module.Core.Splash
{
    [ModulePriority(1)]
    [Roles("H1 Users")]
    [Module(ModuleName = "Splash, v1.0.0.0", OnDemand = false)]
    public class SplashModule : IModule
    {
        #region ctors
        public SplashModule(IUnityContainer container, IEventAggregator eventAggregator, IShell shell, IModuleInitializer moduleInitializer)
        {
            Container = container;
            EventAggregator = eventAggregator;
            Shell = shell;
            ModuleInitializer = ModuleInitializer;
        }
        #endregion

        #region Private Properties
        private IUnityContainer Container { get; set; }

        private IEventAggregator EventAggregator { get; set; }

        private IShell Shell { get; set; }

        private IModuleInitializer ModuleInitializer { get; set; }

        private AutoResetEvent WaitForCreation { get; set; }

        private WaitHandle[] WaitHandles { get; set; }
        #endregion

        public void Initialize()
        {


            WaitForCreation = new AutoResetEvent(false);
            WaitHandles = new WaitHandle[]
                {
                    WaitForCreation
                };

            ThreadStart showSplash =
                () =>
                {
                    Dispatcher.CurrentDispatcher.BeginInvoke(
                        (Action)(() =>
                        {
                            Container.RegisterType<SplashViewModel, SplashViewModel>();
                            Container.RegisterType<SplashView, SplashView>();

                            var splash = Container.Resolve<SplashView>();
                            EventAggregator.GetEvent<CloseSplashEvent>().Subscribe(
                                e => splash.Dispatcher.BeginInvoke((Action)splash.Close),
                                ThreadOption.PublisherThread, true);

                            splash.Show();

                            WaitForCreation.Set();
                        }));

                    Dispatcher.Run();
                };

            var thread = new Thread(showSplash) { Name = "Splash Thread", IsBackground = true };

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            //Perform initializations
            StartupHelper.Start(EventAggregator, Container);

            try
            {      
                //Check if user has completed first time login
                if (WaitHandle.WaitAll(WaitHandles))
                {
                    if(StartupHelper.GetLaunchStatusTask.Result == LaunchStatus.Completed)
                    Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() =>
                    {
                        Application.Current.MainWindow = (Window)Shell;
                        Shell.Show();
                        Application.Current.MainWindow.Focus();
                        Application.Current.MainWindow.Activate();
                        Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                        EventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
                    }));
                }
            }
            catch (WebException webex)
            {
                switch ((webex.Response as HttpWebResponse).StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        throw new Exception("Could not connect to Harness One Secuirty services. The services could not be found.\r\n", webex);

                    case HttpStatusCode.InternalServerError:
                        throw new Exception("Something went wrong in one of the Harness One services. Please check the inner exception for more details:\r\n", webex);
                }
            }

        }      
    }
}