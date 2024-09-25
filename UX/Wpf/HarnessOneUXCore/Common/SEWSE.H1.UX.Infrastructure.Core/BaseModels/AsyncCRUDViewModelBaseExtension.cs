using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.ExcelExporter;
using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using SEWSE.H1.Common.Contracts;
using SEWSE.H1.Common.Infrastructure.Extensions;
using SEWSE.H1.UX.Infrastructure.Core.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using SEWSE.H1.UX.Infrastructure.Core.Models;
using SEWSE.H1.UX.Infrastructure.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SEWSE.H1.UX.Infrastructure.Core
{

    //TODO: Finish implementation of generic ViewModelBase
    public class AsyncCRUDViewModelBase<T> : BindableBase, INavigationAware, /*IActiveAware,*/ IDockAware, IViewModelAsync where T : BaseModel<Guid>
    {
        #region Properties
        private readonly ServiceEndPointRoutes endPointRoutes;

        #region Ribbon Tab Label Properties

        private string _helpdeskCaption;
        public string HelpdeskCaption
        {
            get => _helpdeskCaption;
            set => SetProperty(ref _helpdeskCaption, value);
        }

        private string _helpCaption;
        public string HelpCaption
        {
            get => _helpCaption;
            set => SetProperty(ref _helpCaption, value);
        }

        private string _actionsCaption;
        public string ActionsCaption
        {
            get => _actionsCaption;
            set => SetProperty(ref _actionsCaption, value);
        }

        private string _addCaption;
        public string AddCaption
        {
            get => _addCaption;
            set => SetProperty(ref _addCaption, value);
        }

        private string _createCaption;
        public string CreateCaption
        {
            get => _createCaption;
            set => SetProperty(ref _createCaption, value);
        }

        private string _deleteCaption;
        public string DeleteCaption
        {
            get => _deleteCaption;
            set => SetProperty(ref _deleteCaption, value);
        }

        private string _saveCaption;
        public string SaveCaption
        {
            get => _saveCaption;
            set => SetProperty(ref _saveCaption, value);
        }

        private string _cancelCaption;
        public string CancelCaption
        {
            get => _cancelCaption;
            set => SetProperty(ref _cancelCaption, value);
        }

        private string _printExportCaption;
        public string PrintExportCaption
        {
            get => _printExportCaption;
            set => SetProperty(ref _printExportCaption, value);
        }

        private string _printCaption;
        public string PrintCaption
        {
            get => _printCaption;
            set => SetProperty(ref _printCaption, value);
        }

        private string _exportCaption;
        public string ExportCaption
        {
            get => _exportCaption;
            set => SetProperty(ref _exportCaption, value);
        }

        private string _xlsExportCaption;
        public string XLSExportCaption
        {
            get => _xlsExportCaption;
            set => SetProperty(ref _xlsExportCaption, value);
        }

        private string _openOnExportCaption;
        public string OpenOnExportCaption
        {
            get => _openOnExportCaption;
            set => SetProperty(ref _openOnExportCaption, value);
        }

        private string _openLastCaption;
        public string OpenLastCaption
        {
            get => _openLastCaption;
            set => SetProperty(ref _openLastCaption, value);
        }

        private string _uploadCaption;
        public string UploadCaption
        {
            get => _uploadCaption;
            set => SetProperty(ref _uploadCaption, value);
        }
        #endregion

        #region Error Labels

        private string _saveNotAllowedWhileErrorCaption;
        public string SaveNotAllowedWhileErrorCaption
        {
            get => _saveNotAllowedWhileErrorCaption;
            set => SetProperty(ref _saveNotAllowedWhileErrorCaption, value);
        }

        private string _recordSavedCaption;
        public string RecordSavedCaption
        {
            get => _recordSavedCaption;
            set => SetProperty(ref _recordSavedCaption, value);
        }

        private string _recordUpdatedCaption;
        public string RecordUpdatedCaption
        {
            get => _recordUpdatedCaption;
            set => SetProperty(ref _recordUpdatedCaption, value);
        }

        private string _recordDeletedCaption;
        public string RecordDeletedCaption
        {
            get => _recordDeletedCaption;
            set => SetProperty(ref _recordDeletedCaption, value);
        }

        private string _duplicateRecordCaption;
        public string DuplicateRecordCaption
        {
            get => _duplicateRecordCaption;
            set => SetProperty(ref _duplicateRecordCaption, value);
        }

        private string _addNotAllowedWhileErrorCaption;
        public string AddNotAllowedWhileErrorCaption
        {
            get => _addNotAllowedWhileErrorCaption;
            set => SetProperty(ref _addNotAllowedWhileErrorCaption, value);
        }

        private string _doCancelCaption;
        public string DoCancelCaption
        {
            get => _doCancelCaption;
            set => SetProperty(ref _doCancelCaption, value);
        }

        private string _doSaveCaption;
        public string DoSaveCaption
        {
            get => _doSaveCaption;
            set => SetProperty(ref _doSaveCaption, value);
        }

        private string _cannotContinueCaption;
        public string CannotContinueCaption
        {
            get => _cannotContinueCaption;
            set => SetProperty(ref _cannotContinueCaption, value);
        }

        private string _doDeleteCaption;
        public string DoDeleteCaption
        {
            get => _doDeleteCaption;
            set => SetProperty(ref _doDeleteCaption, value);
        }

        private string _noDataCaption;
        public string NoDataCaption
        {
            get => _noDataCaption;
            set => SetProperty(ref _noDataCaption, value);
        }

        private string _noDataExportCaption;
        public string NoDataExportCaption
        {
            get => _noDataExportCaption;
            set => SetProperty(ref _noDataExportCaption, value);
        }

        private string _noRecordFound;
        public string NoRecordFound
        {
            get => _noRecordFound;
            set => SetProperty(ref _noRecordFound, value);
        }

        private string _unsavedDataCaption;
        public string UnsavedDataCaption
        {
            get => _unsavedDataCaption;
            set => SetProperty(ref _unsavedDataCaption, value);
        }

        private string _crossReferenceDataCaption;
        public string CrossReferenceDataCaption
        {
            get => _crossReferenceDataCaption;
            set => SetProperty(ref _crossReferenceDataCaption, value);
        }

        private string _exportFileNotFoundCaption;
        public string ExportFileNotFoundCaption
        {
            get => _exportFileNotFoundCaption;
            set => SetProperty(ref _exportFileNotFoundCaption, value);
        }

        private string _deleteNotAllowedCaption;
        public string DeleteNotAllowedCaption
        {
            get => _deleteNotAllowedCaption;
            set => SetProperty(ref _deleteNotAllowedCaption, value);
        }

        #endregion

        #region Labels and Outlook Bar Tracking
        protected IList<string> LabelsNeeded { get; set; }
        public string Function { get; protected set; }
        public string Module { get; protected set; }
        public string View { get; protected set; }
        public string ViewFallback { get; protected set; }

        //Bindable Properties
        private string _header;
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        private string _iconSource;
        public string IconSource
        {
            get => _iconSource;
            set
            {
                SetProperty(ref _iconSource, value);
            }
        }

        private ObservableDictionary<string, string> _labels;
        public ObservableDictionary<string, string> Labels
        {
            get => _labels;
            set => SetProperty(ref _labels, value);
        }
        #endregion

        #region Helpers
        protected StatusBarMessageHelper StatusBarMessageHelper { get; private set; }
        protected CustomDialogHelper CustomDialogHelper { get; private set; }
        #endregion


        protected IEventAggregator _eventAggregator { get; set; }
        protected IRegionManager _regionManager { get; set; }
        protected IDialogService _dialogService { get; set; }

        #region Commands
        public ICommand PageLoadedCommand { get; set; }
        public ICommand RecordUpdatedCommand { get; set; }
        public DelegateCommand CreateCommand { get; set; }
        public AwaitableDelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public AwaitableDelegateCommand CancelCommand { get; set; }
        public AwaitableDelegateCommand HelpCommand { get; set; }
        public AwaitableDelegateCommand ExportCommand { get; set; }
        public DelegateCommand PrintCommand { get; set; }
        public AwaitableDelegateCommand OpenExportCommand { get; set; }
        #endregion

        private LoadingSettings _loadingSettings;
        public LoadingSettings LoadingSettings
        {
            get => _loadingSettings;
            set => SetProperty(ref _loadingSettings, value);
        }

        private ObservableCollection<T> _itemCollection;
        public ObservableCollection<T> ItemCollection
        {
            get => _itemCollection;
            set => SetProperty(ref _itemCollection, value);
        }

        private T _activeItem;
        public T ActiveItem
        {
            get => _activeItem;
            set => SetProperty(ref _activeItem, value);
        }
        #endregion

        #region Setup

        public AsyncCRUDViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null)
        {
            #region Helpers
            if (eventAggregator != null)
            {
                _eventAggregator = eventAggregator;
                StatusBarMessageHelper = new StatusBarMessageHelper(eventAggregator);
                CustomDialogHelper = new CustomDialogHelper(eventAggregator);
            }

            if (regionManager != null)
                _regionManager = regionManager;

            if (dialogService != null)
                _dialogService = dialogService;
            #endregion
            #region Commands
            PageLoadedCommand = new AwaitableDelegateCommand(PageLoaded);
            CreateCommand = new DelegateCommand(Create, () => !LoadingSettings.IsBusy);
            DeleteCommand = new DelegateCommand(Delete, () => !LoadingSettings.IsBusy);
            SaveCommand = new AwaitableDelegateCommand(Save, () => !LoadingSettings.IsBusy);
            CancelCommand = new AwaitableDelegateCommand(Cancel, () => !LoadingSettings.IsBusy);
            HelpCommand = new AwaitableDelegateCommand(ExecuteHelpDeskCall, () => !LoadingSettings.IsBusy);
            ExportCommand = new AwaitableDelegateCommand(ExportGridDataIntoXLS, () => !LoadingSettings.IsBusy);
            OpenExportCommand = new AwaitableDelegateCommand(OpenLastExportedFile, () => !LoadingSettings.IsBusy);
            RecordUpdatedCommand = new DelegateCommand<object>(RecordUpdated);
            #endregion

            LoadingSettings = new LoadingSettings();
            ItemCollection = new ObservableCollection<T>();
            LabelsNeeded = new List<string>();
            AddBaseLabelsNeeded();
            AddLabelsNeeded();
        }

        public AsyncCRUDViewModelBase(ServiceEndPointRoutes endPointRoutes, IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null)
        {
            #region Helpers
            if (eventAggregator != null)
            {
                _eventAggregator = eventAggregator;
                StatusBarMessageHelper = new StatusBarMessageHelper(eventAggregator);
                CustomDialogHelper = new CustomDialogHelper(eventAggregator);
            }

            if (regionManager != null)
                _regionManager = regionManager;

            if (dialogService != null)
                _dialogService = dialogService;
            #endregion
            this.endPointRoutes = endPointRoutes ?? throw new NullReferenceException(nameof(endPointRoutes));
            #region Commands
            PageLoadedCommand = new AwaitableDelegateCommand(PageLoaded);
            CreateCommand = new DelegateCommand(Create, () => !LoadingSettings.IsBusy);
            DeleteCommand = new DelegateCommand(Delete, () => !LoadingSettings.IsBusy);
            SaveCommand = new AwaitableDelegateCommand(Save, () => !LoadingSettings.IsBusy);
            CancelCommand = new AwaitableDelegateCommand(Cancel, () => !LoadingSettings.IsBusy);
            HelpCommand = new AwaitableDelegateCommand(ExecuteHelpDeskCall, () => !LoadingSettings.IsBusy);
            ExportCommand = new AwaitableDelegateCommand(ExportGridDataIntoXLS, () => !LoadingSettings.IsBusy);
            OpenExportCommand = new AwaitableDelegateCommand(OpenLastExportedFile, () => !LoadingSettings.IsBusy);
            RecordUpdatedCommand = new DelegateCommand<object>(RecordUpdated);
            #endregion

            LoadingSettings = new LoadingSettings();
            ItemCollection = new ObservableCollection<T>();
            LabelsNeeded = new List<string>();
            AddBaseLabelsNeeded();
            AddLabelsNeeded();
        }

        protected virtual void RaiseCanExecuteChanged()
        {
            CreateCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
            HelpCommand.RaiseCanExecuteChanged();
            ExportCommand.RaiseCanExecuteChanged();
            OpenExportCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #region Base Methods

        #region Navigation
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Function = navigationContext.Parameters["Function"] as string;
            Module = navigationContext.Parameters["Module"] as string;
            View = navigationContext.Parameters["View"] as string;
            ViewFallback = navigationContext.Parameters["ViewFallback"] as string;

            if (View != null)
                LabelsNeeded.Add(View);
        }

        #endregion

        #region Load/Close

        #region Labels
        private async Task FillLabelsTask()
        {
            RetrieveLabels(LabelsNeeded);
            FillRibbonLabels();
            FillErrorLabels();
            FillUXLabels();
        }

        protected void RetrieveLabels(IEnumerable<string> labelCodes)
        {
            try
            {
                var result = new ObservableDictionary<string, string>();
                using (var resxSet = new ResXResourceSet(ResourceLabelProvider._resxFile))
                {
                    foreach (var label in labelCodes)
                    {
                        if (label != null)
                            if (!result.ContainsKey(label))
                            {
                                var value = resxSet.GetString(label);
                                if (value != null)
                                    result.Add(label, value);
                            }
                    }
                }

                Labels = result;

                if (View != null)
                    Header = (Labels.ContainsKey(View)) ? Labels[View] : ViewFallback;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }
        private void FillRibbonLabels()
        {
            HelpdeskCaption = Labels["00008"] ?? "Helpdesk";
            HelpCaption = Labels["00012"] ?? "Help";
            ActionsCaption = Labels["00009"] ?? "Actions";
            AddCaption = Labels["00013"] ?? "Add";
            DeleteCaption = Labels["00014"] ?? "Delete";
            SaveCaption = Labels["00015"] ?? "Save";
            CancelCaption = Labels["00016"] ?? "Cancel";
            PrintExportCaption = Labels["00010"] ?? "Print/Export";
            PrintCaption = Labels["00017"] ?? "Print";
            ExportCaption = Labels["00018"] ?? "Export";
            XLSExportCaption = Labels["00011"] ?? "Open Excel Export";
            OpenOnExportCaption = Labels["00019"] ?? "Open Excel on Export";
            OpenLastCaption = Labels["00020"] ?? "Open Last Excel Exported";
        }
        private void FillErrorLabels()
        {
            SaveNotAllowedWhileErrorCaption = Labels["50027"] ?? "[50027] Save not allowed while error in Grid.";
            RecordSavedCaption = Labels["50028"] ?? "[50028] Record saved successfully.";
            RecordUpdatedCaption = Labels["50029"] ?? "[50029] Record updated successfully.";
            RecordDeletedCaption = Labels["50030"] ?? "[50030] Record deleted successfully.";
            DuplicateRecordCaption = Labels["50031"] ?? "[50031] Duplicate Records Exist.";
            AddNotAllowedWhileErrorCaption = Labels["50056"] ?? "[50056] Add not allowed while error in Grid.";
            DoCancelCaption = Labels["50067"] ?? "[50067] Do you want to Cancel?";
            DoSaveCaption = Labels["50068"] ?? "[50068] Do you want to Save the changes?";
            CannotContinueCaption = Labels["50070"] ?? "[50070] Error in grid,can not continue!";
            DoDeleteCaption = Labels["50072"] ?? "[50072] Mark for Deletion?";
            NoDataCaption = Labels["50168"] ?? "[50168] No data in Grid. Cannot Export.";
            NoRecordFound = Labels["50169"] ?? "[50169] No Record Found.";
            UnsavedDataCaption = Labels["50178"] ?? "[50178] Unsaved data. Can not Export!";
            ExportFileNotFoundCaption = Labels["50179"] ?? "[50179] Export File Not Found!";
            DeleteNotAllowedCaption = Labels["50181"] ?? "[50181] Delete not allowed while Error in Grid!!";
            CrossReferenceDataCaption = Labels["50337"] ?? "[50337] Record is cross referenced. Can not be deleted!";
            NoDataExportCaption = Labels["50413"] ?? "[50413] No Data found to Export!";
        }
        protected virtual void FillUXLabels()
        { }
        #endregion

        public async Task PageLoaded()
        {
            LoadingSettings.IsBusy = true;
            RaiseCanExecuteChanged();
            var task = FillLabelsTask();
            var task2 = OnLoaded();
            await Task.WhenAll(task, task2);
            LoadingSettings.IsBusy = false;
            RaiseCanExecuteChanged();
        }

        private async Task ReloadData()
        {
            LoadingSettings.IsBusy = true;
            await RefreshData();
            LoadingSettings.IsBusy = false;
        }

        protected async Task GetGridCollection()
        {
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Started {typeof(T).Name} collection service call");
            try
            {
                if(endPointRoutes == null) { throw new Exception("The service endpoint route has not been passed to the base viewmodel and cannot make\r\n" +
                    "perform GetGridCollection"); }
                IEnumerable<T> DataFromService = new ObservableCollection<T>(ServiceHelper.GetAll<T>(endPointRoutes));
                //Because there is no other criteria order by, the base orders by Id. This can be changed by overriding the
                // OrderBy method.
                ItemCollection = new ObservableCollection<T>(DataFromService.OrderBy(OrderBy));
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CountryViewModel-GetDataFromApi", UXNotificationType.ErrorMessage);
            }
            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Completed {typeof(T).Name} collection service call");
        }

        protected virtual void RefreshItems()
        {
            if (ItemCollection != null)
            {
                if (ItemCollection.Any())
                {
                    foreach (var item in ItemCollection)
                    {
                        item.IsRowChecked = false;
                        item.CrudOperationType = CrudOperationType.Read;
                    }
                }
            }
            else
            {
                //StatusBarMessageHelper.DisplayMessage(NoRecordFound, "CustomerViewModel -RefreshItems", UXNotificationType.DefaultMessage);
            }
        }

        protected void RefreshItems(IEnumerable<BaseModel<Guid>> collection)
        {
            if (collection != null)
            {
                if (collection.Any())
                {
                    foreach (var item in collection)
                    {
                        item.IsRowChecked = false;
                        item.CrudOperationType = CrudOperationType.Read;
                    }
                }
            }
            else
            {
                //StatusBarMessageHelper.DisplayMessage(NoRecordFound, "CustomerViewModel -RefreshItems", UXNotificationType.DefaultMessage);
            }
        }

        public virtual async Task<bool> OnClosing()
        {
            if (IsUnSavedGrid())
            {
                bool? closeResult = CustomDialogHelper.GetCloseConfirmation(UserPreferenceSetupHelper.UserPrincipalUsername, DoSaveCaption);
                if (closeResult == true)
                {
                    //in case of Yes
                    #region Check for the error(s) in the grid if any!            
                    if (!IsGridValid())
                    {
                        //StatusBarMessageHelper.DisplayMessage(SaveNotAllowedWhileErrorCaption, "BusinessUnitType", UXNotificationType.ErrorMessage);
                        return false;
                    }
                    #endregion
                    #region To check duplicate rows
                    if (IsGridHaveDuplicate())
                    {
                        return false;
                    }
                    #endregion
                    await Save();
                }
                else if (closeResult == false)
                {
                    //in case of No
                    //do nothing
                }
                else
                {
                    //in case of Cancel
                    return false;
                }
            }
            return true;
        }


        #endregion

        #region Operations

        #region Create

        protected virtual void Create()
        {
            try
            {             

                //if (ItemCollection.Count == 0)
                //{
                //    try
                //    {
                //        //GetDataFromApi();
                //    }
                //    catch (WebException webex)
                //    {
                //        string error = $"{webex.Message}. {Environment.NewLine} {(webex.InnerException == null ? string.Empty : webex.InnerException.Message)}";
                //        StatusBarMessageHelper.DisplayMessage(error, "ContactViewModel-Create", UXNotificationType.ErrorMessage);
                //    }
                //    catch (Exception ex)
                //    {
                //        string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                //        StatusBarMessageHelper.DisplayMessage(error, "ContactViewModel-Create", UXNotificationType.ErrorMessage);
                //    }
                //}

                InitializeNewEntry();
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "ContactViewModel-Create", UXNotificationType.ErrorMessage);
                //ServiceHelper.RuntimeException<ErrorLogModel>(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
        }

        private void InitializeNewEntry()
        {
            //TODO:[GUID]Replacement: CreatedBy and ModifiedBy Guid will be replaced with the User info.
            var NewData = (T)Activator.CreateInstance(typeof(T));
            NewData.Id = Guid.NewGuid();
            NewData.CreatedBy = Guid.Parse(UserPreferenceSetupHelper.CurrentUser.UserGuid.ToString());
            NewData.ModifiedBy = Guid.Parse(UserPreferenceSetupHelper.CurrentUser.UserGuid.ToString());
            NewData.CreatedDate = DateTime.UtcNow;
            NewData.ModifiedDate = DateTime.UtcNow;
            NewData.CrudOperationType = CrudOperationType.Create;
            NewData.IsRowChecked = true;

            if (ItemCollection != null)
            {
                ItemCollection.Add(NewData);
            }
            else
            {
                ItemCollection = new ObservableCollection<T>();
                ItemCollection.Add(NewData);
            }
        }

        #endregion

        #region Cancel

        protected virtual async Task Cancel()
        {
            //Might remove. Makes it harder to manually refresh the grid when you want to...
            if (!IsUnSavedGrid())
            {
                return;
            }
            bool? result = await CustomDialogHelper.GetConfirmation(UserPreferenceSetupHelper.CurrentUser.GivenName, DoCancelCaption, UXDialogTypes.YesNoConfirmation);

            if (result == true)
            {
                await ReloadData();
                ActiveItem = null;
            }
            else if (result == false) { }
        }

        #endregion

        #region Delete

        protected virtual async void Delete()
        {
            try
            {
                if (ActiveItem == null) { return; }
                if (!CheckForCrossReference())
                {
                    StatusBarMessageHelper.DisplayMessage(CrossReferenceDataCaption, "Delete", UXNotificationType.ErrorMessage);
                    return;
                }
                bool? closeResult = await CustomDialogHelper.GetConfirmation(UserPreferenceSetupHelper.UserPrincipalGuid.ToString(), DoDeleteCaption, UXDialogTypes.YesNoConfirmation);
                if (closeResult == true)
                {
                    if (ActiveItem.CrudOperationType == CrudOperationType.Create)
                    {
                        ItemCollection.Remove(ActiveItem);
                    }
                    else
                    {
                        ActiveItem.CrudOperationType = CrudOperationType.Delete;
                        ActiveItem.IsRowChecked = true;
                    }
                }
                else if (closeResult == false)
                {
                    //in case of No
                    return;
                }
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-Delete", UXNotificationType.ErrorMessage);
            }
        }

        #endregion

        #region Save

        protected virtual async Task Save()
        {
            #region Check for the error(s) in the grid if any!            
            if (!IsGridValid())
            {
                StatusBarMessageHelper.DisplayMessage(SaveNotAllowedWhileErrorCaption, "TODO: Change this text", UXNotificationType.ErrorMessage);
                return;
            }
            #endregion
            #region To check duplicate rows
            if (IsGridHaveDuplicate())
            {
                return;
            }
            #endregion
            UpdateModifiedModelProperties();

            var itemList = ItemCollection.Where(item => item.CrudOperationType != CrudOperationType.Read && item.IsRowChecked == true).ToList();

            if (itemList.Any())
            {
                try
                {
                    var errors = ServiceHelper.ProcessOperation<T>(endPointRoutes, itemList);
                    //StatusBarMessageHelper.DisplayMessage(RecordSavedCaption, "CustomerViewModel-Save", UXNotificationType.SuccessMessage);
                }
                catch (Exception ex)
                {
                    string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                    //StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-Save", UXNotificationType.ErrorMessage);
                }
                await ReloadData();
            }
        }

        #endregion

        #region Others
        protected virtual void RecordUpdated(object updatedRecord)
        {
            var values = (object[])updatedRecord;
            if (values[1] != null)
            {
                var fieldName = ((Cell)values[1]).Field.Name as string;
                if (fieldName == null || fieldName == "IsRowChecked")
                {
                    return;
                }
            }
            var item = (T)values[0];
            if ((item.CrudOperationType != CrudOperationType.Create) &&
                (item.CrudOperationType != CrudOperationType.Delete))
            {
                item.CrudOperationType = CrudOperationType.Update;
                item.IsRowChecked = true;
            }
        }

        protected async Task ExecuteHelpDeskCall()
        {
            HelpDeskHelper.GetUserScreen();
        }

        protected async Task ExportGridDataIntoXLS()
        {
            throw new NotImplementedException();
        }

        protected async Task OpenLastExportedFile()
        {
            throw new NotImplementedException();
        }

        protected void UpdateModifiedModelProperties()
        {
            foreach (var item in ItemCollection.Where(item => item.CrudOperationType == CrudOperationType.Update))
            {
                item.ModifiedBy = UserPreferenceSetupHelper.UserPrincipalGuid;
                item.ModifiedDate = DateTime.UtcNow;
            }
        }
        #endregion

        #endregion

        #region Security Overrides
        protected void SecurityOverrides()
        {
            try
            {
                dynamic fieldOverrideFilters = new FieldOverrideRequestModel
                {
                    UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid,
                    ViewName = ViewFallback
                };
                var securityOverrideValues = ServiceHelper.Get<IEnumerable<FieldOverrideModel>>(fieldOverrideFilters, ServiceEndPointRoutes.FieldOverrideAccess);
                foreach (var fieldoverride in securityOverrideValues)
                {
                    var currentVariable = GetType().GetProperty(fieldoverride.FieldName);
                    currentVariable?.SetValue(this, fieldoverride.FieldValue, null);
                }
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }
        #endregion

        #region Validation

        protected bool IsGridValid()
        {
            try
            {
                if (ItemCollection != null)
                {
                    bool IsError = ItemCollection.Any(ColumnName => ColumnName.HasErrors() == true && ColumnName.IsRowChecked == true && (ColumnName.CrudOperationType == CrudOperationType.Update || ColumnName.CrudOperationType == CrudOperationType.Create));
                    if (IsError)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-IsGridValid", UXNotificationType.ErrorMessage);
                //ServiceHelper.RuntimeException<ErrorLogModel>(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
            return false;
        }
        protected bool IsUnSavedGrid()
        {
            try
            {
                if (ItemCollection != null)
                {
                    bool UnsavedRows = ItemCollection.Any(c => c.CrudOperationType == CrudOperationType.Update || c.CrudOperationType == CrudOperationType.Delete || c.CrudOperationType == CrudOperationType.Create);
                    if (UnsavedRows)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-IsUnSavedGrid", UXNotificationType.ErrorMessage);
                //ServiceHelper.RuntimeException<ErrorLogModel>(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
            return false;
        }
        protected bool IsGridHaveDuplicate()
        {
            try
            {
                var hasDuplicate = ItemCollection.Where(c => c.HasErrors() == false).HasDuplicateOnFields(DuplicateFieldKeySelector/*it => it.Name.Trim().ToLower()*/);
                if (hasDuplicate)
                {
                    CustomDialogHelper.ErrorMessage(UserPreferenceSetupHelper.UserPrincipalGuid.ToString(), DuplicateRecordCaption);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-IsGridHaveDuplicate", UXNotificationType.ErrorMessage);
                //ServiceHelper.RuntimeException<ErrorLogModel>(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
            return false;
        }
        protected virtual bool CheckForCrossReference()
        {
            return true;
        }

        #region Selectors

        protected virtual object DuplicateFieldKeySelector(T arg)
        {
            return arg.Id;
        }
        protected virtual object OrderBy(T obj)
        {
            return obj.Id;
        }
        #endregion

        #endregion

        #endregion

        #region Virtual Methods
        protected virtual async Task OnLoaded()
        {
            await GetGridCollection();
            RefreshItems();
        }

        protected virtual async Task RefreshData()
        {
            await OnLoaded();
        }

        #region Label Methods
        /// <summary>
        /// Used to programatically add the necessary label keys to Labels dictionary. this method in your viewmodel
        /// to implement this method using the example below as base. Both this method and <see cref="FillUXLabels"/>
        /// need to be implemented for this to work properly
        /// </summary>
        /// <example>
        /// <code>
        /// LabelsNeeded.Add("00001");
        /// LabelsNeeded.Add("00002");
        /// LabelsNeeded.Add("00003");
        /// </code>
        /// </example>
        protected virtual void AddLabelsNeeded()
        {

        }

        private void AddBaseLabelsNeeded()
        {
            //Ribbon Tab Label Codes
            LabelsNeeded.Add("00008");
            LabelsNeeded.Add("00009");
            LabelsNeeded.Add("00010");
            LabelsNeeded.Add("00011");
            LabelsNeeded.Add("00012");
            LabelsNeeded.Add("00013");
            LabelsNeeded.Add("00014");
            LabelsNeeded.Add("00015");
            LabelsNeeded.Add("00016");
            LabelsNeeded.Add("00017");
            LabelsNeeded.Add("00018");
            LabelsNeeded.Add("00019");
            LabelsNeeded.Add("00020");

            //Error Label Codes
            LabelsNeeded.Add("50027");
            LabelsNeeded.Add("50028");
            LabelsNeeded.Add("50029");
            LabelsNeeded.Add("50030");
            LabelsNeeded.Add("50031");
            LabelsNeeded.Add("50056");
            LabelsNeeded.Add("50067");
            LabelsNeeded.Add("50068");
            LabelsNeeded.Add("50069");
            LabelsNeeded.Add("50070");
            LabelsNeeded.Add("50072");
            LabelsNeeded.Add("50168");
            LabelsNeeded.Add("50169");
            LabelsNeeded.Add("50178");
            LabelsNeeded.Add("50179");
            LabelsNeeded.Add("50181");
            LabelsNeeded.Add("50337");
            LabelsNeeded.Add("50413");
        }

        #endregion

        #endregion
    }
}
