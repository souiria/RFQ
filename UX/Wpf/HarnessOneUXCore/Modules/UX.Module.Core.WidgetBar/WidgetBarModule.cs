using Prism.Modularity;
using Prism.Regions;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;

namespace SEWSE.H1.UX.Module.Core.WidgetBar
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "WidgetBar, v1.0.0.0", OnDemand = false)]
    public class WidgetBarModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public WidgetBarModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.WidgetBar>();
            _manager.Regions[RegionNames.WidgetBarRegion].Add(view);
        }
    }
}