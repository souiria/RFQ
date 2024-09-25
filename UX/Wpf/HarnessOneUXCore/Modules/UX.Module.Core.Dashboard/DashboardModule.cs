using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.Dashboard
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    public class DashboardModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public DashboardModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            var view = _container.Resolve<Views.Dashboard>();
            _manager.Regions[RegionNames.ContentRegion].Add(view);
        }
    }
}