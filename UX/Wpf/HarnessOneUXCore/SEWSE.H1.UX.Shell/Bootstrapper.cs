using System;
using System.Security.Principal;
using System.Windows;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Extensions;
using Common.UX.Wpf.Helpers;
using Infragistics.Windows.DockManager;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using SEWSE.H1.UX.Shell.Adapters;
using SEWSE.H1.UX.Shell.Behaviours;
using SEWSE.H1.UX.Shell.Catalogs;
using SEWSE.H1.UX.Shell.Logging;

namespace SEWSE.H1.UX.Shell
{
	class Bootstrapper : UnityBootstrapper
	{
		private readonly CallbackLogger _callbackLogger = new CallbackLogger();
		private IEventAggregator _eventAggregator = new EventAggregator();

		protected override DependencyObject CreateShell()
		{
			AppDomain.CurrentDomain.SetThreadPrincipal(new WindowsPrincipal(WindowsIdentity.GetCurrent()));
            try
			{
                var shell = Container.Resolve<IShell>();
				return shell as DependencyObject;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
			mappings.RegisterMapping(typeof(TabGroupPane), Container.Resolve<TabGroupPaneRegionAdapter>());
			mappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
			mappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonRegionAdapter>());
			mappings.RegisterMapping(typeof(Window), Container.Resolve<WizardRegionAdapter>());
			return mappings;
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
			return new AggregateModuleCatalog();
		}

		protected override void ConfigureModuleCatalog()
		{
			System.IO.Directory.CreateDirectory(@".\Modules");
			var directoryCatalog = new DirectoryModuleCatalog { ModulePath = @".\Modules" };
			((AggregateModuleCatalog)ModuleCatalog).AddCatalog(directoryCatalog);
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();
			
			Container.RegisterType<IShell, Views.Shell>(new ContainerControlledLifetimeManager());
			//Container.RegisterType<IGlobalCommands, GlobalCommands>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IModuleInitializer, RoleBasedModuleInitializer>(new ContainerControlledLifetimeManager());
			Container.RegisterType<IModuleManager, ExtendedModuleManager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<NotificationHelper, NotificationHelper>(new ContainerControlledLifetimeManager());
            Container.RegisterInstance(_callbackLogger);
		}

		protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
		{
			var behaviours = base.ConfigureDefaultRegionBehaviors();
			behaviours.AddIfMissing(XamRibbonRegionBehavior.BehaviorKey, typeof(XamRibbonRegionBehavior));
            behaviours.AddIfMissing(WidgetBarRegionBehaviour.BehaviorKey, typeof(WidgetBarRegionBehaviour));

			return behaviours;
		}

		protected override void InitializeModules()
		{
			IModuleManager manager = ServiceLocator.Current.GetInstance<IModuleManager>();
			manager.Run();
		}
	}
}
