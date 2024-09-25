using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UX.Commercial.Edi.Core.Interfaces;
using UX.Commercial.Edi.Services;
using UX.Commercial.Edi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace UX.Commercial.Edi
{
    [ModuleDependency("Themes, v1.0.0.0")]
    [Roles("H1 Users")]
    [Module(ModuleName = "Commercial Edi Module, v1.0.0.0", OnDemand = false)]
    public class SalesEdiModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public SalesEdiModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        public void Initialize()
        {
            _unityContainer.RegisterType<IMessageService, MessageService>(new ContainerControlledLifetimeManager());

            _unityContainer.RegisterTypeForNavigation<EdiInvalidDispatchesView>();
            _unityContainer.RegisterTypeForNavigation<EdiCustomerParameters>();
        }
    }
}

