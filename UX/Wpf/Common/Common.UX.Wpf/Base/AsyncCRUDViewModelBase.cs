using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Contracts.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace Common.UX.Wpf.Base
{
    [Obsolete("This ViewModel is obsolete. Please use BaseViewModel instead.")]
    public abstract class AsyncCRUDViewModelBase : AsyncViewModelBase
    {
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

        public bool FirstPageLoad = true;

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

        public DelegateCommand<object> RecordUpdatedCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand HelpCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand OpenExportCommand { get; set; }

        public AsyncCRUDViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null) : base(eventAggregator, regionManager, dialogService)
        {
            CreateCommand = new AwaitableDelegateCommand(() => TaskWrapper(Create));
            SaveCommand = new AwaitableDelegateCommand(() => ShowBusyIndicator(Save));
            DeleteCommand = new AwaitableDelegateCommand(() => TaskWrapper(Delete));
            CancelCommand = new AwaitableDelegateCommand(Cancel);
            HelpCommand = new AwaitableDelegateCommand(() => ShowBusyIndicator(ExecuteHelpDeskCall));
            ExportCommand = new AwaitableDelegateCommand(() => ShowBusyIndicator(ExportGridDataIntoXLS));
            OpenExportCommand = new AwaitableDelegateCommand(() => ShowBusyIndicator(OpenLastExportedFile));

            RecordUpdatedCommand = new DelegateCommand<object>(RecordUpdated);

            Initialize();
        }

        protected void Initialize()
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

        protected override void PreLoad()
        {
            if (FirstPageLoad)
            {
                FillLabelsFromResxFileInUX(LabelsNeeded);
                FillRibbonLabels();
                FillErrorLabels();
                ExecuteViewLoad();
                FirstPageLoad = false;
            }

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

        public async Task TaskWrapper(Action action)
        {
            action();
        }

        private void FillRibbonLabels()
        {
            HelpdeskCaption = Labels["00008"] ?? "Screenshot";
            HelpCaption = Labels["00012"] ?? "Send Screenshot";
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

        protected abstract void Create();
        protected abstract void Save();
        protected abstract void Delete();
        protected abstract Task Cancel();
        protected abstract void ExecuteHelpDeskCall();
        protected abstract void ExportGridDataIntoXLS();
        protected abstract void RecordUpdated(object updatedRecord);
        protected abstract void OpenLastExportedFile();
    }
}
