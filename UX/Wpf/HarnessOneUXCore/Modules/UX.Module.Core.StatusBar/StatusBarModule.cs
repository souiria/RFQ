using Prism.Modularity;
using Prism.Regions;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;

namespace SEWSE.H1.UX.Module.Core.StatusBar
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "StatusBar, v1.0.0.0", OnDemand = false)]
    public class StatusBarModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public StatusBarModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.StatusBar>();
            _manager.Regions[RegionNames.StatusBarRegion].Add(view);
        }
    }
}