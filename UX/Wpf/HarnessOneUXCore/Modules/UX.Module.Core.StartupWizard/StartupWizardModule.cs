using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using SEWSE.H1.UX.Module.Core.StartupWizard.Views;
using System.Windows;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Events;

namespace SEWSE.H1.UX.Module.Core.StartupWizard
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [ModulePriority(2)]
    [Roles("H1 Users")]
    [Module(ModuleName = "StartupWizard, v1.0.0.0", OnDemand = false)]
    public class StartupWizardModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;
        private readonly IEventAggregator _eventAggregator;

        public StartupWizardModule(IRegionManager manager, IUnityContainer container, IEventAggregator eventAggregator)
        {
            _manager = manager;
            _container = container;
            _eventAggregator = eventAggregator;
        }

        public void Initialize()
        {
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading start-up process" });

            _container.RegisterTypeForNavigation<Welcome>();
            _container.RegisterTypeForNavigation<GroupPermission>();
            _container.RegisterTypeForNavigation<Review>();
            _container.RegisterTypeForNavigation<AwaitingApproval>();
            _container.RegisterTypeForNavigation<CustomisePermissions>();
            //_container.RegisterTypeForNavigation<DataPermissions>();
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = _container.Resolve<Views.StartupWizard>();
            Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth * 0.5;
            Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight * 0.5;
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            _eventAggregator.GetEvent<CloseSplashEvent>().Publish(new CloseSplashEvent());
            //
            Application.Current.MainWindow.Activate();
            Application.Current.MainWindow.Show();
            Application.Current.MainWindow.Focus();
        }
    }
}
