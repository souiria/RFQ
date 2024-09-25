using Microsoft.Practices.ObjectBuilder2;
using Prism.Commands;
using Prism.Regions;
using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core;
using SEWSE.H1.UX.Infrastructure.Core.Services;
using SEWSE.H1.UX.Module.Core.StartupWizard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class DataPermissionsViewModel : ViewModelBase
    {
        private string previousView;
        private List<ModuleSecurityModel> permissions;

        public DelegateCommand ReviewCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }

        private ObservableCollection<ServiceSecurityModel> _services;
        public ObservableCollection<ServiceSecurityModel> Services
        {
            get
            {
                _services = GetServices();
                return _services;
            }
            set => SetProperty(ref _services, value);
        }

        private ServiceSecurityModel _selectedService;
        public ServiceSecurityModel SelectedService
        {
            get => _selectedService;
            set
            {
                SetProperty(ref _selectedService, value);
                if (SelectedService.Data == null)
                    SelectedService.Data = GetDataFilters(SelectedService);
            }
        }

        public DataPermissionsViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            BackCommand = new DelegateCommand(() => _regionManager.Regions[RegionNames.WizardRegion].RequestNavigate(previousView));

            ReviewCommand = new DelegateCommand(() =>
            {
                var parameters = new NavigationParameters();
                parameters.Add("PreviousView", "DataPermissions");
                parameters.Add("Permissions", permissions);
                parameters.Add("DataPermissions", _services);
                _regionManager.Regions[RegionNames.WizardRegion].RequestNavigate("Review", parameters);
            });
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            var prevView = (string)navigationContext.Parameters["PreviousView"];
            if (prevView != null)
                previousView = prevView;
            permissions = (List<ModuleSecurityModel>)navigationContext.Parameters["Permissions"];
        }

        private ObservableCollection<ServiceSecurityModel> GetServices()
        {
            var services = ServiceHelper.GetAll<ServiceSecurityModel>(ServiceEndPointRoutes.ServiceDataFilter);
            if (services.Any())
            {
                return new ObservableCollection<ServiceSecurityModel>(services);
            }
            return new ObservableCollection<ServiceSecurityModel>();
        }

        private ObservableCollection<GenericDataFilterModel> GetDataFilters(ServiceSecurityModel service)
        {
            var dataFilters = ServiceHelper.Post<List<GenericDataFilterModel>>(ServiceEndPointRoutes.ServiceDataFilterDataPermissions, service, compress: false);
            if (dataFilters.Any())
            {
                return new ObservableCollection<GenericDataFilterModel>(dataFilters);
            }
            return new ObservableCollection<GenericDataFilterModel>();
        }
    }
}
