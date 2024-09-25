using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;

namespace SEWSE.H1.UX.Module.Core.ApplicationMenu
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "ApplicationMenu, v1.0.0.0", OnDemand = false)]
    public class ApplicationMenuModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public ApplicationMenuModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.ApplicationMenu>();
            _manager.Regions[RegionNames.RibbonTabRegion].Add(view);
        }
    }
}