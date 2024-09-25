using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;

namespace SEWSE.H1.UX.Module.Core.RibbonTabs
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "RibbonTabs, v1.0.0.0", OnDemand = false)]
    public class RibbonTabsModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public RibbonTabsModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.HomeTab>();
            _manager.Regions[RegionNames.RibbonTabRegion].Add(view);
        }
    }
}