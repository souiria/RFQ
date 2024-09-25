using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Base.Commercial;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Helpers;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.ViewModels
{
    public class CustomisePermissionsViewModel : BaseViewModel
    {
        private LoadingSettings _loadingSettings;
        public LoadingSettings LoadingSettings
        {
            get => _loadingSettings;
            set => SetProperty(ref _loadingSettings, value);
        }

        #region Customise Permissions Variables

        private ObservableCollection<FunctionHierarchyModel> _hierarhcy;
        public ObservableCollection<FunctionHierarchyModel> Hierarchy
        {
            get => _hierarhcy;
            set => SetProperty(ref _hierarhcy, value);
        }

        public new ICommand PageLoadedCommand { get; private set; }
        public DelegateCommand PermissionCommand { get; private set; }
        public DelegateCommand DataPermissionsCommand { get; private set; }

        #endregion

        public CustomisePermissionsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            LoadingSettings = new LoadingSettings();
            PageLoadedCommand = new AwaitableDelegateCommand(ExecuteLoad);
            PermissionCommand = new DelegateCommand(() => RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("GroupPermission"));
            DataPermissionsCommand = new DelegateCommand(NavigateToReview);
        }

        private void NavigateToReview()
        {
            var permissions = new List<ModuleSecurityModel>();
            var parameters = new NavigationParameters();
            parameters.Add("PreviousView", "CustomisePermissions");
            parameters.Add("Hierarchy", Hierarchy);
            //_regionManager.Regions[RegionNames.WizardRegion].RequestNavigate("DataPermissions", parameters);
            RegionManager.Regions[RegionNames.WizardRegion].RequestNavigate("Review", parameters);
        }

        private async Task ExecuteLoad()
        {
            LoadingSettings.IsBusy = true;
            if (Hierarchy == null)
                Hierarchy = await Task.Run(GetMasterHierarchy);
            LoadingSettings.IsBusy = false;
        }

        #region Service Data Retrieval

        private async Task<ObservableCollection<FunctionHierarchyModel>> GetMasterHierarchy()
        {
            return new ObservableCollection<FunctionHierarchyModel>(await ServiceHelper.Get<IEnumerable<FunctionHierarchyModel>>(ServiceEndpointRoutes.Hierarchy));
        }

        //private List<ModuleHierarchyModel> FilterModules()
        //{

        //    var functions = HarnessOneFunctions.ToList();
        //    List<ModuleHierarchyModel> modules = new List<ModuleHierarchyModel>();

        //    foreach (var module in functions.SelectMany(x => x.Modules))
        //    {
        //        if (!module.IsSelected.HasValue || module.IsSelected.Value)
        //        {
        //            var views = new ObservableCollection<ViewHierarchyModel>();
        //            foreach (var view in module.Views)
        //            {
        //                if (view.IsSelected.HasValue && view.IsSelected.Value)
        //                {
        //                    var fields = new ObservableCollection<FieldHierarchyModel>();

        //                    foreach (var field in view.Fields)
        //                    {
        //                        if (field.IsSelected.Value)
        //                            fields.Add(CreateFieldCopy(field));
        //                    }
        //                    var tmpView = CreateViewCopy(view);
        //                    tmpView.Fields = fields;
        //                    views.Add(tmpView);
        //                }
        //            }
        //            var tmpModule = CreateModuleCopy(module);
        //            tmpModule.Views = views;
        //            modules.Add(tmpModule);
        //        }
        //    }
        //    return modules;
        //}

        private List<FunctionHierarchyModel> DeepCopyHierarchy(IEnumerable<FunctionHierarchyModel> functions)
        {
            var hierarchyCopy = new List<FunctionHierarchyModel>();
            foreach (var function in functions)
            {
                var modules = new ObservableCollection<ModuleHierarchyModel>();
                foreach (var module in function.Modules)
                {
                    var views = new ObservableCollection<ViewHierarchyModel>();
                    foreach (var view in module.Views)
                    {
                        var fields = new ObservableCollection<FieldHierarchyModel>();
                        foreach (var field in view.Fields)
                        {
                            fields.Add(CreateFieldCopy(field));
                        }
                        views.Add(CreateViewCopy(view, fields));
                    }
                    modules.Add(CreateModuleCopy(module, views));
                }
                hierarchyCopy.Add(CreateFunctionCopy(function, modules));
            }
            return hierarchyCopy;
        }

        private FunctionHierarchyModel CreateFunctionCopy(FunctionHierarchyModel function, ObservableCollection<ModuleHierarchyModel> modules)
        {
            return new FunctionHierarchyModel
            {
                Id = function.Id,
                ActiveDirectoryName = function.ActiveDirectoryName,
                FunctionName = function.FunctionName,
                IsSelected = function.IsSelected,
                Modules = modules
            };
        }

        private ModuleHierarchyModel CreateModuleCopy(ModuleHierarchyModel module, ObservableCollection<ViewHierarchyModel> views)
        {
            return new ModuleHierarchyModel
            {
                Id = module.Id,
                ActiveDirectoryName = module.ActiveDirectoryName,
                ModuleName = module.ModuleName,
                IsSelected = module.IsSelected,
                Views = views
            };
        }

        private ViewHierarchyModel CreateViewCopy(ViewHierarchyModel view, ObservableCollection<FieldHierarchyModel> fields)
        {


            var result = new ViewHierarchyModel
            {
                Id = view.Id,
                ActiveDirectoryName = view.ActiveDirectoryName,
                ViewName = view.ViewName,
                IsSelected = view.IsSelected,
                Fields = fields
            };

            return result;
        }

        private FieldHierarchyModel CreateFieldCopy(FieldHierarchyModel field)
        {
            return new FieldHierarchyModel
            {
                Id = field.Id,
                FieldDescription = field.FieldDescription,
                FieldName = field.FieldName,
                FieldSecurityGuid = field.FieldSecurityGuid,
                VariableName = field.VariableName,
                ViewId = field.ViewId,
                IsSelected = field.IsSelected
            };
        }

        //public ObservableCollection<UXH1FunctionMasterModel> GetFunctions()
        //{
        //    var functions = ServiceHelper.GetAll<H1FunctionMasterModel>(ServiceEndPointRoutes.H1FunctionMaster);
        //    if (functions.Any())
        //    {
        //        return new ObservableCollection<UXH1FunctionMasterModel>(functions.Select(function => new UXH1FunctionMasterModel
        //        { Id = function.Id, FunctionName = function.FunctionName, ActiveDirectoryName = function.ActiveDirectoryName }));
        //    }
        //    //Todo: Remove below test data and handle no results
        //    //return GetFunctionTestData();
        //    return new ObservableCollection<UXH1FunctionMasterModel>();
        //}

        //public ObservableCollection<ModuleSecurityModel> GetFunctionPermissions()
        //{
        //    var functionPermissions = ServiceHelper.Post<List<ModuleSecurityModel>>(ServiceEndPointRoutes.FunctionPermissionHierarchy, SelectedFunction, compress: false).ToList();
        //    if (functionPermissions.Any())
        //    {
        //        return new ObservableCollection<ModuleSecurityModel>(functionPermissions.OrderBy(x => x.DisplayName));
        //    }
        //    //todo: Remove below test data and handle no results
        //    // return GetFunctionPermissionsTestData();
        //    return new ObservableCollection<ModuleSecurityModel>();
        //}

        #endregion            
    }
}
