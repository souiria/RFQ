using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.RibbonQat
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "Ribbon QAT, v1.0.0.0", OnDemand = false)]
    public class RibbonQatModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public RibbonQatModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.QuickAccessToolbar>();
            _manager.Regions[RegionNames.RibbonTabRegion].Add(view);
        }
    }
}