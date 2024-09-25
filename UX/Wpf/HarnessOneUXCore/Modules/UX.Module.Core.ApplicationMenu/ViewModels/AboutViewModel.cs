using System.Collections.Generic;
using Common.UX.Wpf.Base;
using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using SEWSE.H1.UX.Module.Core.ApplicationMenu.Contracts;

namespace SEWSE.H1.UX.Module.Core.ApplicationMenu.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        #region properties

        private List<ModuleDataItem> _moduleDataItems;

        public List<ModuleDataItem> ModuleDataItems
        {
            get => _moduleDataItems;
            set => SetProperty(ref _moduleDataItems, value);
        }

        #endregion

        public AboutViewModel() 
        {
            ModuleDataItems = new List<ModuleDataItem>();
            var moduleCatalog = ServiceLocator.Current.GetInstance<IModuleCatalog>();
            foreach (var module in moduleCatalog.Modules)
            {
                ModuleDataItems.Add(new ModuleDataItem { Name = module.ModuleName});
            }
        }
    }
}
