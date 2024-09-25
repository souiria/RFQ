using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using Infragistics.Documents.Excel;
using Prism.Events;
using Prism.Regions;
using System.Windows.Input;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.Core.Enums;
using UX.Module.Edi.Core.Events;
using UX.Module.Edi.Core.Interfaces;
using UX.Module.Edi.Core.Messages;
using UX.Module.Edi.Core.Messages.Requests;
using System.Windows;
using Google.Protobuf.Collections;
using GrpcServices;

namespace UX.Module.Edi.ViewModels
{
    internal class EdiInvalidDispatchesViewModel : RegionViewModelBase
    {
        private readonly IMessageService _messageService;

        #region Properties

        private bool _isEnabled;
        private bool _openOnExportIsSelected;
        private string _lastExportFileName;
        private ObservableCollection<EdiInvoiceInformationDto> _invoiceInformationData;
        private string _myMessage;

        public string MyMessage
        {
            get => _myMessage;
            set => SetProperty(ref _myMessage, value);
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        public bool OpenOnExportIsSelected
        {
            get => _openOnExportIsSelected;
            set => SetProperty(ref _openOnExportIsSelected, value);
        }

        public string LastExportFileName
        {
            get => _lastExportFileName;
            set => SetProperty(ref _lastExportFileName, value);
        }

        public ObservableCollection<EdiInvoiceInformationDto> InvoiceInformationData
        {
            get => _invoiceInformationData;
            set => SetProperty(ref _invoiceInformationData, value);
        }


        #endregion

        public EdiInvalidDispatchesViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMessageService messageService) : base(eventAggregator, regionManager)
        {
            Header = "Invalid Dispatches";
            _messageService = messageService;
            InvoiceInformationData = new();
            EventAggregator.GetEvent<InvalidDispatchesReprocessDataEvent>().Subscribe(ExecuteReprocess);
            EventAggregator.GetEvent<InvalidDispatchesReloadDataEvent>().Subscribe(ExecuteReload);
            EventAggregator.GetEvent<InvalidDispatchesExportDataEvent>().Subscribe(ExecuteExport);
            EventAggregator.GetEvent<ReprocessDuplicatesEvent>().Subscribe(ReprocessDuplicates);
        }

        

        protected override async Task ExecuteViewLoad()
        {
            await base.ExecuteViewLoad();
            await GetInvoiceInformation();
        }

        private async Task GetInvoiceInformation()
        {

            try
            {
                //ShowBusyIndicator();
                IsBusy = true;
                InvoiceInformationData.Clear();
                EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.Empty });
                
                //IsEnabled = false;

                EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
                var request = new InvoiceInformationRequest()
                {
                    IsCompressed = false,
                    RequestType = InvoiceInformationRequestType.GetAllInvoiceInformation
                };
                var results = _messageService.GetAllInvoiceInformationStream("invoiceInformation", request);
                await foreach (var item in results)
                {
                    InvoiceInformationData.Add(item);
                    IsBusyContent = $"Loading {InvoiceInformationData.Count} rows";
                    //if (InvoiceInformationData.Count == 50)
                    //{
                    //    IsBusy = false;
                    //    EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
                    //}
                }

                EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                IsBusyContent = $"Loading rows";
                IsBusy = false;
                EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidEnabled });
                //IsEnabled = true;
                //HideBusyIndicator();
            }
        }

        private async void ExecuteReprocess(ProcessDataMessage message)
        {
            switch (message.Operation)
            {
                case RibbonTabOperation.ReprocessInvalidDispatches:
                    var request = new ReprocessRequest();
                    await _messageService.ReprocessDispatchData("invoiceInformation", request);
                    break;
            }
        }

        private async void ReprocessDuplicates(ObservableCollection<DuplicateDataDto> duplicateData)
        {
            IsBusy = true;
            IsBusyContent = "Reprocessing Duplicate Dispatches";
            var duplicateRequest = new ProcessDuplicatesRequest();
            foreach (var data in duplicateData)
            {
                duplicateRequest.DuplicateData.Add(new DuplicateData
                {
                    FileName = data.FileName,
                    DispatchNumber = data.DispatchNumber,
                    IsMarkedForReprocessing = data.IsMarkedForReprocessing,
                    IsMarkedForDeletion = data.IsMarkedForDeletion,
                    Id = data.Id.ToString()
                });
            }
            await _messageService.ProcessDuplicatesRequest("invoiceInformation", duplicateRequest);
            IsBusy = false;
            EventAggregator.GetEvent<InvalidDispatchesReloadDuplicateDataEvent>().Publish();
        }

        private async void ExecuteReload()
        {
            
            await GetInvoiceInformation();
            
        }

        private async void ExecuteExport(ExportDataMessage message)
        {
            OpenOnExportIsSelected = message.IsSelected;
            switch (message.Message)
            {
                case "ExportData":
                    await ExportToExcel();
                    break;
                case "OpenLastExport":
                    OpenLastExport();
                    break;
            }
        }

        private async Task ExportToExcel()
        {
            ShowBusyIndicator();
            //IsBusy = true;
            IsEnabled = false;

            var workbook1 = new Workbook();
            var worksheet1 = workbook1.Worksheets.Add("Sheet 1");

            #region Add Headers
            // add Orders
            worksheet1.Rows[0].Cells[0].Value = "File Name";
            worksheet1.Rows[0].Cells[1].Value = "Business Unit";
            worksheet1.Rows[0].Cells[2].Value = "CustomerLookupAggregate Location Name";
            worksheet1.Rows[0].Cells[3].Value = "CustomerLookupAggregate Order Number";
            worksheet1.Rows[0].Cells[4].Value = "Finance Code";
            worksheet1.Rows[0].Cells[5].Value = "WMS Invoice Number";
            worksheet1.Rows[0].Cells[6].Value = "Part Number";
            worksheet1.Rows[0].Cells[7].Value = "CustomerLookupAggregate Part Number";
            worksheet1.Rows[0].Cells[8].Value = "Is Using Part Number";
            worksheet1.Rows[0].Cells[9].Value = "Part Description";
            worksheet1.Rows[0].Cells[10].Value = "Dispatch Date";
            worksheet1.Rows[0].Cells[11].Value = "Dispatch Number";
            worksheet1.Rows[0].Cells[12].Value = "Price Lag";
            worksheet1.Rows[0].Cells[13].Value = "Held Up";
            worksheet1.Rows[0].Cells[14].Value = "Quantity";
            worksheet1.Rows[0].Cells[15].Value = "Reason";

            worksheet1.Rows[0].CellFormat.Font.Bold = ExcelDefaultableBoolean.True;

            worksheet1.FilterSettings.SetRegion("A1:P1");

            #endregion

            #region Add Rows

            var row = 1;

            foreach (var item in InvoiceInformationData.Where(x => x.Status != EdiInvoiceStatus.SentToUnit4 && x.Status != EdiInvoiceStatus.ConfirmedInUnit4).OrderBy(x => x.DispatchNumber))
            {
                var itemReason = string.Empty;
                if (item.Status == EdiInvoiceStatus.Duplicate) itemReason = "Duplicate Dispatch data";
                else if (item.Status == EdiInvoiceStatus.MissingPrice) itemReason = "Invalid Price";
                else if (item.Status == EdiInvoiceStatus.MissingPart) itemReason = "Invalid Product";
                else if (item.Status == EdiInvoiceStatus.HeldUp) itemReason = "Held Up Dispatch data";

                worksheet1.Rows[row].Cells[0].Value = item.FileName;
                worksheet1.Rows[row].Cells[1].Value = item.Customer;
                worksheet1.Rows[row].Cells[2].Value = item.CustomerLocation;
                worksheet1.Rows[row].Cells[3].Value = item.CustomerOrderNumber;
                worksheet1.Rows[row].Cells[4].Value = item.FinanceCode;
                worksheet1.Rows[row].Cells[5].Value = item.WmsInvoiceNumber;
                worksheet1.Rows[row].Cells[6].Value = item.PartNumber;
                worksheet1.Rows[row].Cells[7].Value = item.CustomerPartNumber;
                worksheet1.Rows[row].Cells[8].Value = item.IsUsingPartNumber;
                worksheet1.Rows[row].Cells[9].Value = item.PartDescription;
                worksheet1.Rows[row].Cells[10].Value = item.DispatchDate;
                worksheet1.Rows[row].Cells[10].CellFormat.FormatString = "dd/mm/yyyy";
                worksheet1.Rows[row].Cells[11].Value = item.DispatchNumber;
                worksheet1.Rows[row].Cells[12].Value = (DateTime.Now - item.DispatchDate).Days;
                worksheet1.Rows[row].Cells[13].Value = item.TotalInvoicePrice;
                worksheet1.Rows[row].Cells[13].CellFormat.FormatString = "€ #,##0.00";
                worksheet1.Rows[row].Cells[14].Value = item.Quantity;
                worksheet1.Rows[row].Cells[15].Value = itemReason;

                row++;
            }

            

            for (int i = 0; i < 16; i++)
            {
                worksheet1.Columns[i].AutoFitWidth();
            }


            #endregion


            workbook1.SetCurrentFormat(WorkbookFormat.Excel2007);
            string fileName = "";
            if (GetFileName(out fileName))
            {
                workbook1.Save(fileName);
                LastExportFileName = fileName;
                if (OpenOnExportIsSelected)
                {
                    OpenLastExport();
                }
            }

            await Task.Delay(500);
            //IsBusy = false;
            IsEnabled = true;
            HideBusyIndicator();
        }

        private async Task OpenLastExport()
        {
            await Task.Delay(0);
            if (LastExportFileName.Length > 0 &&
                File.Exists(LastExportFileName))
            {
                // shell execute command
                Process.Start(new ProcessStartInfo(LastExportFileName) { UseShellExecute = true });
            }
        }

        bool GetFileName(out string fileName)
        {
            // Configure save file dialog box
            fileName = "";
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            var ts = DateTime.UtcNow.ToString("yyyyMMdd HHmmss");
            dlg.FileName = $"InvalidDespatches {ts}"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel workbooks (.xlsx)|*.xlsx"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                fileName = dlg.FileName;
                return true;
            }
            return false;
        }

        private DelegateCommand<object> _activeDocumentChangedCommand;
        public ICommand ActiveDocumentChangedCommand => _activeDocumentChangedCommand ??= new DelegateCommand<object>(ActiveDocumentChanged);

        private void ActiveDocumentChanged(object sender)
        {
            var e = (RoutedPropertyChangedEventArgs<Infragistics.Windows.DockManager.ContentPane>)sender;
            if (e is { NewValue: not null } && e.NewValue.TabHeader.ToString() == "Duplicate Dispatches")
            {
                if (e.OldValue != null && e.NewValue.TabHeader != e.OldValue.TabHeader)
                    EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidDisabled });
                if (e.OldValue == null)
                    EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidDisabled });
            }
            else
            {
                if (e.OldValue != null && e.NewValue != null && e.OldValue.TabHeader.ToString() == "Duplicate Dispatches")
                    EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidEnabled });
            }

        }
    }
}
