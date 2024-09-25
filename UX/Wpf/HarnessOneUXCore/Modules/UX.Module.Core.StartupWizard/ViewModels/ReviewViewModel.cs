using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Core.Security;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Base.Commercial;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Helpers;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class ReviewViewModel : BaseViewModel
    {
        private string previousView;
        private Group Role { get; set; }
        private ObservableCollection<FunctionHierarchyModel> Hierarchy { get; set; }

        private string helpdeskId;


        private string _permissionDescription;
        public string PermissionDescription
        {
            get => _permissionDescription;
            set => SetProperty(ref _permissionDescription, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _error;
        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }


        public AwaitableDelegateCommand AwaitingCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }

        public ReviewViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(eventAggregator, regionManager)
        {
            AwaitingCommand = new AwaitableDelegateCommand(CompleteReview);
            BackCommand = new DelegateCommand(Back);
        }

        private async Task CompleteReview()
        {
            IsBusy = true;

            try
            {
                await AssignPermissions();

                var parameters = new NavigationParameters();
                parameters.Add("HelpdeskId", helpdeskId);
                RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("AwaitingApproval", parameters);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong during the creation of the your request. Please contact a Harness One Administrator. -- {ex.Message}";
            }

            IsBusy = false;
        }

        protected override void NavigatedTo(NavigationContext navigationContext)
        {
            previousView = (string)navigationContext.Parameters["PreviousView"];
            Hierarchy = (ObservableCollection<FunctionHierarchyModel>)navigationContext.Parameters["Hierarchy"];
            Role = (Group)navigationContext.Parameters["SelectedRole"];
            //selectedDataFilters = (navigationContext.Parameters["DataPermissions"] as IEnumerable<ServiceSecurityModel>)?.ToList();
            if (Role != null) PermissionDescription = CreateRoleDescription();
            if (Hierarchy != null) PermissionDescription = CreateHierarchyDescription();
            //PermissionDescription += (selectedDataFilters != null) ? CreateDataPermissionsDescription() : "";
        }

        private async Task AssignPermissions()
        {
            Error = "";

            PermissionChangeCollectionModel added = null;

            if (Role != null)
                added = new PermissionChangeCollectionModel(new List<Group> { Role });

            else if (Hierarchy != null)
                added = GenerateChangeCollectionFromHierarchy(Hierarchy);

            else
            {
                //Throw error
            }

            var changeModel = new PermissionChangeModel(UserPreferenceSetupHelper.UserPrincipalGuid, null, added);
            helpdeskId = await ServiceHelper.Post<string>(ServiceEndpointRoutes.Access, changeModel);
        }

        private void Back()
        {
            RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate(previousView);
        }

        private PermissionChangeCollectionModel GenerateChangeCollectionFromHierarchy(IEnumerable<FunctionHierarchyModel> hierarchy)
        {
            PermissionChangeCollectionModel collectionModel = new PermissionChangeCollectionModel();

            var modules = hierarchy.Where(x => x.IsSelected != false).SelectMany(x => x.Modules);
            var views = modules.Where(x => x.IsSelected != false).SelectMany(x => x.Views);
            collectionModel.Views.AddRange(views.Where(x => x.IsSelected == true));
            collectionModel.Fields.AddRange(views.Where(x => x.IsSelected == true).SelectMany(x => x.Fields).Where(x => x.IsSelected == true));

            return collectionModel;
        }

        private string CreateHierarchyDescription()
        {
            var description = "=== Views ===\r\n";
            foreach (var function in Hierarchy.Where(x => x.IsSelected != false))
            {
                foreach (var module in function.Modules.Where(x => x.IsSelected != false))
                {
                    foreach (var view in module.Views.Where(x => x.IsSelected == true))
                    {
                        description += $"+ {view.ViewName}\r\n";
                    }
                }
            }

            foreach (var function in Hierarchy.Where(x => x.IsSelected != false))
            {
                foreach (var module in function.Modules.Where(x => x.IsSelected != false))
                {
                    foreach (var view in module.Views.Where(x => x.IsSelected == true))
                    {
                        if (view.Fields.Any())
                        {
                            description += $"\r\n\r\n === {view.ViewName} Fields ===\r\n";
                            foreach (var field in view.Fields.Where(x => x.IsSelected == true))
                            {
                                description += $"+ {field.FieldName}";
                            }
                        }
                    }
                }
            }

            return description;
        }

        private string CreateRoleDescription()
        {
            var description = "=== Roles ===\r\n";
            description += $"+ {Role.ActiveDirectoryName}\r\n";
            description += $"\r\n -- This will give you access to the following items -- \r\n";
            foreach (var member in Role.MemberOf)
            {
                description += $"{member}\r\n";
            }
            return description;
        }

        //private string CreateDataPermissionsDescription()
        //{
        //    var description = $"\n\nSelected Data Permissions: \n";
        //    foreach (var service in selectedDataFilters)
        //    {
        //        if (service.Data != null && service.Data.Any())
        //        {
        //            description += $"\n\t{service.DisplayName}:";
        //            foreach (var dataFilter in service.Data.Where(x => x.IsSelected == true || x.IsSelected == null))
        //            {
        //                description += $"\n\t\t - {dataFilter.DisplayName}";
        //            }
        //        }
        //    }
        //    return description;
        //}

        //private List<ViewHierarchyModel> GetSelectedViewPermissions()
        //{
        //    var selectedViewPermissions = new List<ViewHierarchyModel>();
        //    if (selectedModules != null)
        //        foreach (var module in selectedModules)
        //        {
        //            selectedViewPermissions.AddRange(module.Views.Where(x => x.IsSelected == true || x.IsSelected == null));
        //        }

        //    return selectedViewPermissions;
        //}

        //private List<FieldHierarchyModel> GetSelectedFieldPermissions()
        //{
        //    var selectedFieldPermissions = new List<FieldHierarchyModel>();
        //    if (selectedModules != null)
        //        foreach (var module in selectedModules)
        //        {
        //            foreach (var view in module.Views)
        //            {
        //                selectedFieldPermissions.AddRange(view.Fields.Where(field => field.IsSelected == true));
        //            }
        //        }

        //    return selectedFieldPermissions;
        //}

        //private List<ServiceSecurityModel> GetSelectedDataPermissions()
        //{
        //    var dataPermissions = new List<ServiceSecurityModel>();
        //    if (selectedDataFilters != null)
        //        selectedDataFilters.ForEach(service =>
        //        {
        //            if (service.Data != null && service.Data.Any(x => x.IsSelected == true))
        //            {
        //                dataPermissions.Add(service);
        //            }
        //        });

        //    return dataPermissions;
        //}

        //private List<UXSecurityDataFilterServiceModel> GetSelectedDataPermissions()
        //{
        //    var selectedDataPermissions = new List<GenericServiceDataFilterModel>();
        //    try
        //    {
        //        var filters = selectedDataFilters.Where(filter => filter.IsSelected == true);
        //        filters.ForEach(filter =>
        //        {
        //            selectedDataPermissions.Add(new UserDataFilterAssociationModel
        //            {
        //                CrudOperationType = CrudOperationType.Create,
        //                UserGuid = UserPreferenceSetupHelper.UserPrincipalGuid,
        //                ModelGuid = filter.Id,
        //                DisplayName = filter.DisplayName
        //            });
        //        });
        //    }
        //    catch (Exception e)
        //    {
        //        //TODO: error log
        //    }
        //    return selectedDataPermissions;
        //}
    }
}
