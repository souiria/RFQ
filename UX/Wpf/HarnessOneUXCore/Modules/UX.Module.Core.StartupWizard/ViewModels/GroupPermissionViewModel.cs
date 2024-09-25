using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Common.Core.Contracts.Models.Core.Security;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Base.Commercial;
using Common.UX.Wpf.Helpers;
using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
   public class GroupPermissionViewModel : BaseViewModel
    {
        public DelegateCommand ReviewCommand { get; private set; }
        public DelegateCommand AdvancedCommand { get; private set; }

        private ObservableCollection<Group> _roles;
        public ObservableCollection<Group> Roles
        {
            get => _roles;
            set => SetProperty(ref _roles, value);
        }

        private Group _selectedRole;
        public Group SelectedRole
        {
            get => _selectedRole;
            set
            {
                SetProperty(ref _selectedRole, value);
                ReviewCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _connected = false;
        public bool Connected
        {
            get => _connected;
            set
            {
                SetProperty(ref _connected, value);
                RaisePropertyChanged("ShowOverlay");
            }
        }

        public Visibility ShowOverlay
        {
            get => (Connected) ? Visibility.Collapsed : Visibility.Visible;
        }

        public GroupPermissionViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            ReviewCommand = new DelegateCommand(() =>
            {
                var parameters = new NavigationParameters();
                parameters.Add("SelectedRole", SelectedRole);
                parameters.Add("PreviousView", "GroupPermission");
                RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("Review", parameters);
            }, () => SelectedRole != null);

            AdvancedCommand = new DelegateCommand(() => RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("CustomisePermissions"));
        }

        protected override async void NavigatedTo(NavigationContext navigationContext)
        {
            await GetRoles();
        }

        private async Task GetRoles()
        {
            Connected = false;
            while (!Connected)
                try
                {
                    Roles = new ObservableCollection<Group>(await ServiceHelper.GetAll<Group>(ServiceEndpointRoutes.HierarchyRoles));
                    Connected = true;
                }
                catch (Exception e)
                {
                    Connected = false;
                    Thread.Sleep(3000);
                }
        }
    }
}
