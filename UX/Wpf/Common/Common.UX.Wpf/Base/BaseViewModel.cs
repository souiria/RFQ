/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BaseViewModel.cs
Function           :   Maintain All Basic functionality for ViewModel
Created By         :   Nitesh Kumar
Created on         :   [30-Nov-2018]
Revision History   :   [26-Apr-2019] : Nitesh Kumar
*                  :   [ ] : Change In UpdateModelProperties method for Create and Modified Date related.
                   :   [12-Feb-2020] : Amit Agarwal
*                  :   [ ] : added new virtual tasks (GetAllTask, ProcessOperationTask) to provided overriding in case of NetCoreServiceApi Class
*                  :   [17-Jun-2021] : Shivam Dhingra
*                  :   [ ] : Added new method UserScreenAccessPermission for new security permission rights access
*                  :   [21-Jun-2021] : Shivam Dhingra
*                  :   [ ] : Added optional parameter for UserScreenAccessPermission
*                  :   [06-Aug-2021] : Dharmendra
*                  :   [ ] : Modified method UserScreenAccessPermission() set false access permission when service returning null value
*                  :   [10-Oct-2021] : Ashish Dutta
*                  :   [] : Remove Parallel foreach from method RefreshItems()
*                  :   [4-Apr-2022] : Anmol jain
*                  :   [] : Add Method NetCoreGetGridCollection for getting data for NetCoreService. 
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Common.UX.Api;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Contracts.Models.Dialog;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Infragistics.Windows.DataPresenter;
using Prism;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Common.UX.Wpf.Base
{
    public class BaseViewModel : BindableBase, INavigationAware, IActiveAware, IDockAware, IViewModelAsync
    {
        #region Label Properties
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
        #endregion


        private string _header;
        public string Header { get => _header; set => SetProperty(ref _header, value); }

        private ObservableDictionary<string, string> _labels;
        public ObservableDictionary<string, string> Labels
        {
            get => _labels;
            set => SetProperty(ref _labels, value);
        }

        #region LabelsNeeded
        private Dictionary<string, Tuple<Action<string>, string>> LabelsNeeded { get; set; }

        /// <summary>
        /// Adds a label code to the LabelsNeeded dictionary to be retrieved once the view has loaded. This label is assigned to the property
        /// provided once it's retrieved.
        /// </summary>
        /// <example>
        /// <code>
        /// AddLabelsNeeded("00001", value => PropertyToAssign = value);
        /// </code>
        /// </example>
        /// <param name="labelCode">The label code desired from the label dictionary</param>
        /// <param name="propertyToModify">The property to be assigned. (Usually the private field eg. _materialLabel)</param>
        public void AddLabelNeeded(string labelCode, Action<string> actionToUpdate, string fallbackValue = "")
        {
            if (LabelsNeeded.ContainsKey(labelCode) == true)
            {
                return;
            }
            LabelsNeeded.Add(labelCode, new Tuple<Action<string>, string>(actionToUpdate, fallbackValue));

        }

        #endregion

        #region Outlook bar Binding and View Tab
        public string Function { get; private set; }
        public string Module { get; private set; }
        public string View { get; private set; }
        public string ViewFallback { get; private set; }
        #endregion

        #region Helpers
        protected StatusBarMessageHelper StatusBarMessageHelper { get; private set; }
        protected CustomDialogHelper CustomDialogHelper { get; private set; }
        #endregion

        #region User Scess Access Permission Collection
        private List<UserScreenAccessPermissionModel> _userAccessCollection;

        public List<UserScreenAccessPermissionModel> UserAccessCollection
        {
            get { return _userAccessCollection; }
            set { _userAccessCollection = value; }
        }

        #endregion


        protected IEventAggregator EventAggregator { get; set; }
        protected IRegionManager RegionManager { get; set; }
        protected IDialogService DialogService { get; set; }
        protected bool Initialized { get; private set; }
        protected bool IsGlobalBusyIndicator { get; set; }

        #region Commands
        public AwaitableDelegateCommand PageLoadedCommand { get; set; }
        #endregion

        private LoadingSettings _loadingSettings;

        public event EventHandler IsActiveChanged;

        public LoadingSettings LoadingSettings
        {
            get => _loadingSettings;
            set => SetProperty(ref _loadingSettings, value);
        }
        public bool IsActive { get; set; }

        public BaseViewModel(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null)
        {
            #region Helpers
            if (eventAggregator != null)
            {
                EventAggregator = eventAggregator;
                StatusBarMessageHelper = new StatusBarMessageHelper(eventAggregator);
                CustomDialogHelper = new CustomDialogHelper(eventAggregator);
            }

            if (regionManager != null)
                RegionManager = regionManager;

            if (dialogService != null)
                DialogService = dialogService;
            #endregion

            #region Commands
            PageLoadedCommand = new AwaitableDelegateCommand(PageLoaded);
            #endregion

            LoadingSettings = new LoadingSettings();
            LabelsNeeded = new Dictionary<string, Tuple<Action<string>, string>>();
            Initialized = false;
            IsGlobalBusyIndicator = true;
            AddBaseLabelsNeeded();
        }

        /// <summary>
        /// This method is called when the PageLoadedCommand has been called
        /// </summary>
        /// <returns></returns>
        private async Task PageLoaded()
        {
            Console.WriteLine("\r\nBaseViewModel:: PageLoaded:: Started Loading Resources");
            var stopwatch = Stopwatch.StartNew();


            if (!Initialized)
            {
                ShowBusyIndicator();
                Console.WriteLine($"BaseViewModel:: PageLoaded:: Started acquiring label resources:: Time Elapsed: {stopwatch.Elapsed}");
                FillLabels();
                Console.WriteLine($"BaseViewModel:: PageLoaded:: Finished acquiring label resources:: Time Elapsed: {stopwatch.Elapsed}");
                Console.WriteLine($"BaseViewModel:: PageLoaded:: Starting execution of view tasks:: Time Elapsed: {stopwatch.Elapsed}");
                await ExecuteViewLoad();
                Console.WriteLine($"BaseViewModel:: PageLoaded:: Finished execution of view tasks:: Time Elapsed: {stopwatch.Elapsed}");
                Initialized = true;
                HideBusyIndicator();
            }
            stopwatch.Stop();
            Console.WriteLine($"BaseViewModel:: PageLoaded:: Finished Loading Resources:: Time Elapsed: {stopwatch.Elapsed}");
        }

        /// <summary>
        /// This method is to be overriden to implement methods that need to be called on load. These methods are wrapped with the busy indicator.        
        /// </summary>
        /// 
        /// <returns></returns>
        protected virtual async Task ExecuteViewLoad()
        {

        }

        
        protected virtual void RaiseCanExecuteChanged()
        {

        }

        private void FillLabels()
        {
            try
            {
                var result = new ObservableDictionary<string, string>();
                using (var resxSet = new ResXResourceSet(ResourceLabelProvider._resxFile))
                {
                    foreach (var label in LabelsNeeded.Keys)
                    {
                        if (label != null)
                        {
                            var value = resxSet.GetString(label);
                            if (value != null)
                                //Set stored property to the value retrieved
                                LabelsNeeded[label].Item1(value);
                            else
                                LabelsNeeded[label].Item1(LabelsNeeded[label].Item2);
                        }
                    }
                }

                //if (View != null)
                //    Header = (Labels.ContainsKey(View)) ? Labels[View] : ViewFallback;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }

        #region Interface Implementation

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public async virtual Task<bool> OnClosing()
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (StatusBarMessageHelper != null)     //Modified by Pawan on [11-Jan-2019] to check null condition for StatusBarMessageHelper      
            {
                //Clear StatusBar
                StatusBarMessageHelper.DisplayMessage(string.Empty, View, UXNotificationType.DefaultMessage);
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //Remove any leftover errors from screens which cannot call OnNavigatedFrom
            if (navigationContext.NavigationService.Journal != null)
            {
                if (!navigationContext.NavigationService.Journal.CanGoBack && StatusBarMessageHelper != null)       //Modified by Pawan on [11-Jan-2019] to check null condition for StatusBarMessageHelper
                    StatusBarMessageHelper.DisplayMessage(string.Empty, View, UXNotificationType.DefaultMessage);
            }
            Function = navigationContext.Parameters["Function"] as string;
            Module = navigationContext.Parameters["Module"] as string;
            View = navigationContext.Parameters["View"] as string;
            ViewFallback = navigationContext.Parameters["ViewFallback"] as string;

            if (View != null)
                AddLabelNeeded(View, value => Header = value, ViewFallback);
        }
        #endregion   

        private void AddBaseLabelsNeeded()
        {
            //Ribbon Tab Label Codes
            AddLabelNeeded("00008", value => HelpdeskCaption = value, "Screenshot");
            AddLabelNeeded("00009", value => ActionsCaption = value, "Actions");
            AddLabelNeeded("00010", value => PrintExportCaption = value, "Print/Export");
            AddLabelNeeded("00011", value => XLSExportCaption = value, "Open XLS Export");
            AddLabelNeeded("00012", value => HelpCaption = value, "Screenshot");
            AddLabelNeeded("00013", value => AddCaption = value, "Add");
            AddLabelNeeded("00014", value => DeleteCaption = value, "Delete");
            AddLabelNeeded("00015", value => SaveCaption = value, "Save");
            AddLabelNeeded("00016", value => CancelCaption = value, "Cancel");
            AddLabelNeeded("00017", value => PrintCaption = value, "Print");
            AddLabelNeeded("00018", value => ExportCaption = value, "Export");
            AddLabelNeeded("00019", value => OpenOnExportCaption = value, "Open Excel On Export");
            AddLabelNeeded("00020", value => OpenLastCaption = value, "Open Last Exported File");

            //Error Label Codes
            AddLabelNeeded("50027", value => SaveNotAllowedWhileErrorCaption = value, "[50027] Save not allowed while error in Grid.");
            AddLabelNeeded("50028", value => RecordSavedCaption = value, "[50028] Record saved successfully.");
            AddLabelNeeded("50029", value => RecordUpdatedCaption = value, "[50029] Record updated successfully.");
            AddLabelNeeded("50030", value => RecordDeletedCaption = value, "[50030] Record deleted successfully.");
            AddLabelNeeded("50031", value => DuplicateRecordCaption = value, "[50031] Duplicate Records Exist.");
            AddLabelNeeded("50056", value => AddNotAllowedWhileErrorCaption = value, "[50056] Add not allowed while error in Grid.");
            AddLabelNeeded("50067", value => DoCancelCaption = value, "[50067] Do you want to Cancel?");
            AddLabelNeeded("50068", value => DoSaveCaption = value, "[50068] Do you want to save your changes?");
            //AddLabelNeeded("50069", value =>  = value);
            AddLabelNeeded("50070", value => CannotContinueCaption = value, "[50070] An error exist in the grid so the process cannot continue");
            AddLabelNeeded("50072", value => DoDeleteCaption = value, "[50072] Mark record for deletion?");
            AddLabelNeeded("50168", value => NoDataCaption = value, "[50168] No data in Grid. Cannot Export.");
            AddLabelNeeded("50169", value => NoRecordFound = value, "[50169] No Record Found.");
            AddLabelNeeded("50178", value => UnsavedDataCaption = value, "[50178] Unsaved data. Can not Export!");
            AddLabelNeeded("50179", value => ExportFileNotFoundCaption = value, "[50179] Export File Not Found!");
            AddLabelNeeded("50181", value => DeleteNotAllowedCaption = value, "[50181] Delete not allowed while Error in Grid!!");
            AddLabelNeeded("50337", value => CrossReferenceDataCaption = value, "[50337] Record is cross referenced and cannot be deleted");
            AddLabelNeeded("50413", value => NoDataExportCaption = value, "[50168] No data in Grid. Cannot Export.");
        }

        #region Busy Indicator Methods
        /// <summary>
        /// Reveals the busy indicator.
        /// </summary>
        protected void ShowBusyIndicator()
        {
            if (IsGlobalBusyIndicator)
                EventAggregator.GetEvent<LoadingEvent>().Publish(true);
            else
                LoadingSettings.IsBusy = true;

            RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Hides the busy indicator.
        /// </summary>
        protected void HideBusyIndicator()
        {
            if (IsGlobalBusyIndicator)
                EventAggregator.GetEvent<LoadingEvent>().Publish(false);
            else
                LoadingSettings.IsBusy = false;

            RaiseCanExecuteChanged();
        }
        #endregion
    }

    public class BaseViewModel<T> : BaseViewModel where T : BaseModel<Guid>
    {
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

        public AwaitableDelegateCommand<object> RecordUpdatedCommand { get; set; }
        public AwaitableDelegateCommand CreateCommand { get; set; }
        public AwaitableDelegateCommand SaveCommand { get; set; }
        public AwaitableDelegateCommand DeleteCommand { get; set; }
        public AwaitableDelegateCommand CancelCommand { get; set; }
        public AwaitableDelegateCommand HelpCommand { get; set; }
        public AwaitableDelegateCommand ExportCommand { get; set; }
        public AwaitableDelegateCommand PrintCommand { get; set; }
        public AwaitableDelegateCommand OpenExportCommand { get; set; }

        protected ServiceEndpointRoutes ServiceEndPointRoute { get; private set; }

        public BaseViewModel(ServiceEndpointRoutes serviceEndPointRoute = null, IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null) : base(eventAggregator, regionManager, dialogService)
        {
            ServiceEndPointRoute = serviceEndPointRoute;
            CreateCommand = new AwaitableDelegateCommand(Create, () => !LoadingSettings.IsBusy);
            DeleteCommand = new AwaitableDelegateCommand(Delete, () => !LoadingSettings.IsBusy);
            SaveCommand = new AwaitableDelegateCommand(Save, () => !LoadingSettings.IsBusy);
            CancelCommand = new AwaitableDelegateCommand(Cancel, () => !LoadingSettings.IsBusy);
            HelpCommand = new AwaitableDelegateCommand(ExecuteHelpDeskCall, () => !LoadingSettings.IsBusy);
            ExportCommand = new AwaitableDelegateCommand(ExportGridDataIntoXLS, () => !LoadingSettings.IsBusy);
            OpenExportCommand = new AwaitableDelegateCommand(OpenLastExportedFile, () => !LoadingSettings.IsBusy);
            RecordUpdatedCommand = new AwaitableDelegateCommand<object>(RecordUpdated);

            ItemCollection = new ObservableCollection<T>();
            
        }
        protected virtual Task<IEnumerable<T>> GetAllTask(ServiceEndpointRoutes route)
        {
            return ServiceHelper.GetAllAsync<T>(route);
        }
        protected virtual Task<IEnumerable<T>> GetAllTaskNetCore(ServiceEndpointRoutes route)
        {
            return NetCoreServiceHelper.GetAllAsync<T>(route);
        }
        protected virtual Task<IEnumerable<T>> ProcessOperationTask(ServiceEndpointRoutes route, List<T> itemList)
        {
            return ServiceHelper.ProcessOperation<T>(ServiceEndPointRoute, itemList);
        }

        #region Virtual Command Methods

        protected virtual async Task Create()
        {
            try
            {
                var newData = Activator.CreateInstance<T>();
                newData.CrudOperationType = CrudOperationType.Create;
                newData.IsRowChecked = true;

                if (ItemCollection != null)
                {
                    ItemCollection.Add(newData);
                }
                else
                {
                    ItemCollection = new ObservableCollection<T> { newData };
                }

            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "MaterialViewModel-Create", UXNotificationType.ErrorMessage);
                //ServiceHelper.ProcessOperation(ServiceEndpointRoutes.ErrorLog,(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
        }

        protected virtual async Task Delete()
        {
            try
            {
                if (ActiveItem == null) { return; }
                bool? closeResult = await CustomDialogHelper.GetConfirmation(UserPreferenceSetupHelper.UserPrincipalGuid.ToString(), DoDeleteCaption, UXDialogTypes.YesNoConfirmation);
                if (closeResult == true)
                {
                    if (ActiveItem.CrudOperationType == CrudOperationType.Create)
                    {
                        ItemCollection.Remove(ActiveItem);
                    }
                    else if (ActiveItem.CrudOperationType == CrudOperationType.Delete)
                    {
                        ActiveItem.CrudOperationType = CrudOperationType.Update;
                    }
                    else
                    {
                        ActiveItem.CrudOperationType = CrudOperationType.Delete;
                        ActiveItem.IsRowChecked = true;
                    }
                }

            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CustomerViewModel-Delete", UXNotificationType.ErrorMessage);
            }
        }

        protected virtual async Task<bool> Save()
        {
            ShowBusyIndicator();

            if (Validation())
            {
                UpdateModifiedModelProperties();

                var itemList = ItemCollection.Where(item => item.CrudOperationType != CrudOperationType.Read && item.IsRowChecked == true).ToList();
                if (itemList.Any())
                {
                    try
                    {
                        //var errors = ServiceHelper.ProcessOperation<T>(ServiceEndPointRoute, itemList);
                        var errors = await ProcessOperationTask(ServiceEndPointRoute, itemList);
                        //StatusBarMessageHelper.DisplayMessage(RecordSavedCaption, "CustomerViewModel-Save", UXNotificationType.SuccessMessage);
                    }
                    catch (Exception ex)
                    {
                        string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                        StatusBarMessageHelper.DisplayMessage(error, "BaseViewModel-Save", UXNotificationType.ErrorMessage);
                    }

                    await ExecuteViewLoad();
                    HideBusyIndicator();
                    return true;
                }
            }
            else
            {
                StatusBarMessageHelper.DisplayMessage(SaveNotAllowedWhileErrorCaption, "BaseViewModel-Save", UXNotificationType.ErrorMessage);
            }

            HideBusyIndicator();
            return false;
        }

        protected virtual async Task Cancel()
        {
            if (!IsUnSavedGrid())
            {
                return;
            }
            bool? result = await CustomDialogHelper.GetConfirmation("Would you like to cancel?", DoCancelCaption, UXDialogTypes.YesNoConfirmation);

            if (result == true)
            {
                await ExecuteViewLoad();
            }
            else if (result == false) { }
        }

        protected virtual async Task ExecuteHelpDeskCall()
        {
            try
            {
                HelpDeskHelper.GetUserScreen();
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "BaseViewModel-ExecuteHelp", UXNotificationType.ErrorMessage);
            }
        }

        protected virtual async Task ExportGridDataIntoXLS()
        {
            try
            {
                if (!IsGridValid())
                    StatusBarMessageHelper.DisplayMessage(CannotContinueCaption, "BaseViewModel-ExportGridDataIntoXLS", UXNotificationType.ErrorMessage);

                else if (IsUnSavedGrid())
                    StatusBarMessageHelper.DisplayMessage(UnsavedDataCaption, "BaseViewModel-ExportGridDataIntoXLS", UXNotificationType.ErrorMessage);

                else if (ItemCollection.Count == 0)
                    StatusBarMessageHelper.DisplayMessage(NoDataCaption, "BaseViewModel-ExportGridDataIntoXLS", UXNotificationType.DefaultMessage);

                EventAggregator.GetEvent<ExportGridDataEvent>().Publish(ServiceEndPointRoute);
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "BaseViewModel-ExportGridDataIntoXLS", UXNotificationType.ErrorMessage);
            }
        }

        protected virtual async Task OpenLastExportedFile()
        {
            Process xlsWindowsProcess = new Process();
            try
            {
                xlsWindowsProcess.StartInfo.FileName = XamDataGridExportHelper.ExportedExcelValue;
                bool exists = File.Exists(xlsWindowsProcess.StartInfo.FileName);
                if (exists == true)
                {
                    xlsWindowsProcess.Start();
                }
                else
                {
                    StatusBarMessageHelper.DisplayMessage(ExportFileNotFoundCaption, "BaseViewModel-OpenLastExportedFile", UXNotificationType.DefaultMessage);
                    return;
                }
            }
            finally
            {
                xlsWindowsProcess.Dispose();
            }
        }

        protected virtual async Task RecordUpdated(object updatedObject)
        {
            var values = (object[])updatedObject;
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
        #endregion

        protected async Task<List<T>> GetGridCollection(ServiceEndpointRoutes route)
        {
            try
            {
                if (route == null) { throw new Exception("The service endpoint route has not been passed to the base viewmodel and cannot perform GetGridCollection"); }

                //List<T> DataFromService = (await ServiceHelper.GetAllAsync<T>(route)).ToList();
                List<T> DataFromService = (await GetAllTask(route)).ToList();
                return DataFromService;

            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CountryViewModel-GetDataFromApi", UXNotificationType.ErrorMessage);
                return null;
            }
        }

        protected async Task<List<T>> NetCoreGetGridCollection(ServiceEndpointRoutes route)
        {
            try
            {
                if (route == null) { throw new Exception("The service endpoint route has not been passed to the base viewmodel and cannot perform GetGridCollection"); }

                //List<T> DataFromService = (await ServiceHelper.GetAllAsync<T>(route)).ToList();
                List<T> DataFromService = (await GetAllTaskNetCore(route)).ToList();
                return DataFromService;

            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, "CountryViewModel-GetDataFromApi", UXNotificationType.ErrorMessage);
                return null;
            }
        }
        protected virtual IEnumerable<X> RefreshItems<X>(List<X> models) where X : BaseModel<Guid>
        {
            if (models.Any())
            {
                var tasks = new List<Task>();
                //Parallel.ForEach(models, item =>
                //{
                foreach (var item in models)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        item.IsRowChecked = false;
                        item.CrudOperationType = CrudOperationType.Read;
                    }));
                }
                Task.WhenAll(tasks);
            }
            return models;
            
        }

        protected override void RaiseCanExecuteChanged()
        {
            CreateCommand.RaiseCanExecuteChanged();
            DeleteCommand.RaiseCanExecuteChanged();
            SaveCommand.RaiseCanExecuteChanged();
            CancelCommand.RaiseCanExecuteChanged();
            HelpCommand.RaiseCanExecuteChanged();
            ExportCommand.RaiseCanExecuteChanged();
            OpenExportCommand.RaiseCanExecuteChanged();
        }

        protected override async Task ExecuteViewLoad()
        {
            List<T> models = null;
            if (ServiceEndPointRoute != null)
                models = await Task.Run(() => GetGridCollection(ServiceEndPointRoute));
            ItemCollection = models != null ? new ObservableCollection<T>(RefreshItems(models)) : new ObservableCollection<T>();
        }
        
        protected void UpdateModifiedModelProperties()
        {
            DateTime dateTimeUpdate = DateTime.UtcNow;
            ItemCollection.ToList().ForEach((item) =>
            {
                if (item.CrudOperationType == CrudOperationType.Create)
                {
                    
                    item.CreatedBy = UserPreferenceSetupHelper.UserPrincipalGuid;
                    item.CreatedDate = dateTimeUpdate;
                    item.ModifiedBy = UserPreferenceSetupHelper.UserPrincipalGuid;
                    item.ModifiedDate = dateTimeUpdate;
                }
                else if (item.CrudOperationType == CrudOperationType.Update)
                {
                    item.ModifiedBy = UserPreferenceSetupHelper.UserPrincipalGuid;
                    item.ModifiedDate = dateTimeUpdate;
                }
            });
            //foreach (var item in ItemCollection.Where(item => item.CrudOperationType == CrudOperationType.Update))
            //{
            //    item.ModifiedBy = UserPreferenceSetupHelper.UserPrincipalGuid;
            //    item.ModifiedDate = DateTime.UtcNow;
            //}
        }

        #region Validation
        protected async Task SecurityOverrides()
        {
            try
            {
                var fieldOverrideFilters = new FieldOverrideRequestModel
                {
                    UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid,
                    GroupGuids = UserPreferenceSetupHelper.Groups?.Select(x => x.Id).ToList(),
                    ViewName = ViewFallback
                };
                var securityOverrideValues = await ServiceHelper.PostAsBytes<IEnumerable<FieldOverrideModel>>(ServiceEndpointRoutes.FieldOverrideAccess, fieldOverrideFilters);
                if (securityOverrideValues != null)
                {
                    foreach (var fieldoverride in securityOverrideValues)
                    {
                        var currentVariable = GetType().GetProperty(fieldoverride.VariableName);
                        currentVariable?.SetValue(this, fieldoverride.FieldValue, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }
        protected virtual bool Validation()
        {
            if (!IsGridValid()) { return false; }
            return true;
        }

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
                StatusBarMessageHelper.DisplayMessage(error, "MaterialViewModel-IsGridValid", UXNotificationType.ErrorMessage);
                //ServiceHelper.ProcessOperation(ServiceEndpointRoutes.ErrorLog,(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
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
                StatusBarMessageHelper.DisplayMessage(error, "MaterialViewModel-IsUnSavedGrid", UXNotificationType.ErrorMessage);
                //ServiceHelper.ProcessOperation(ServiceEndpointRoutes.ErrorLog,(ServiceHelperExceptionLogging.Exception(ex, new Guid()));
            }
            return false;
        }
        #endregion

        #region New Security Permission Method

        protected async Task<List<UserScreenAccessPermissionModel>> UserScreenAccessPermission(string viewName = null)
        {
            try
            {
                UserScreenAccessPermissionParameterModel paramData = new UserScreenAccessPermissionParameterModel();
                paramData.UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid;
                paramData.DisplayName = viewName== null ? this.ViewFallback : viewName;
                UserAccessCollection = new List<UserScreenAccessPermissionModel>();

                var data = await NetCoreServiceHelper.PostAndGet<UserScreenAccessPermissionModel>(ServiceEndpointRoutes.UserScreenAccessPermission, paramData);
                if (data != null && data.Count() > 0)
                {
                    UserAccessCollection.AddRange(data);
                }
                else
                {
                    UserScreenAccessPermissionModel model = new UserScreenAccessPermissionModel();
                    model.ScreenName = paramData.DisplayName;
                    model.CreateStatus = false;
                    model.DeleteStatus = false;
                    model.UpdateStatus = false;
                    UserAccessCollection.Add(model);
                }
                return UserAccessCollection;
            }
            catch (Exception ex)
            {

                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
                return UserAccessCollection = new List<UserScreenAccessPermissionModel>(); ;
            }
        }

        #endregion
    }
}
