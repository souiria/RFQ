using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Modularity;

namespace UX.Core.ShellDialog
{
	[ModuleDependency("Themes, v1.0.0.0")]
	[Roles("H1 Users")]
	[Module(ModuleName = "ShellDialog, v1.0.0.0", OnDemand = false)]
	public class ShellDialogModule : IModule
	{
		private readonly IUnityContainer _container;
		public void Initialize()
		{
			_container.RegisterType<IDialogService, DialogService>();
		}
		public ShellDialogModule(IUnityContainer container)
		{
			_container = container;
		}
	}
}
