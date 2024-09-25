using SEWSE.H1.UX.Module.Core.ErrorWindow.Views;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using System.Windows;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.ErrorWindow
{
    [ModulePriority(1)]
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "ErrorWindow, v1.0.0.0", OnDemand = false)]
    public class ErrorWindowModule : IModule
    {
        private IUnityContainer _container;
        private IEventAggregator _eventAggregator;

        public ErrorWindowModule(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _container = container;
            _eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            Application.Current.MainWindow = _container.Resolve<Error>();
            Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth * 0.3;
            Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight * 0.4;
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Activate();
            Application.Current.MainWindow.Focus();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            _eventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
        }
    }
}