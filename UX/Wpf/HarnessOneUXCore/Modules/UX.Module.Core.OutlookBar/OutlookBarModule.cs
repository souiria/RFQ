using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace SEWSE.H1.UX.Module.Core.OutlookBar
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "OutlookBar, v1.0.0.0", OnDemand = false)]
    public class OutlookBarModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public OutlookBarModule(IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<Views.OutlookBar>("OutlookBar");
            _manager.Regions[RegionNames.OutlookBarRegion].RequestNavigate("OutlookBar");
        }
    }
}