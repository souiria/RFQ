using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Infragistics.Windows.DataPresenter.Events;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Events;
using Prism.Regions;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.Core.Enums;
using UX.Commercial.Edi.Core.Events;
using UX.Commercial.Edi.Core.Interfaces;
using UX.Commercial.Edi.Core.Messages;
using UX.Commercial.Edi.Core.Messages.Requests;

namespace UX.Commercial.Edi.ViewModels;
internal class DuplicateDispatchesViewModel : RegionViewModelBase
{
    private readonly IMessageService _messageService;

    #region properties

    private bool _isValueChanged;
    public bool IsValueChanged
    {
        get { return _isValueChanged; }
        set { SetProperty(ref _isValueChanged, value); }
    }
    private bool _isDuplicateDataProcessingSelected;

    public bool DuplicateDataProcessingSelected
    {
        get { return _isDuplicateDataProcessingSelected; }
        set { SetProperty(ref _isDuplicateDataProcessingSelected, value); }
    }
    private ObservableCollection<EdiFileDataUploadDto> _duplicateDispatchesData;

    public ObservableCollection<EdiFileDataUploadDto> DuplicateDispatchesData
    {
        get => _duplicateDispatchesData;
        set { SetProperty(ref _duplicateDispatchesData, value); }
    }
    private ObservableCollection<DuplicateDataDto> _duplicateDataProcessing;
    public ObservableCollection<DuplicateDataDto> DuplicateDataProcessing
    {
        get => _duplicateDataProcessing;
        set { SetProperty(ref _duplicateDataProcessing, value); }
    }

    #endregion

    public DuplicateDispatchesViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMessageService messageService) : base(
        eventAggregator, regionManager)
    {
        _messageService = messageService;
        EventAggregator.GetEvent<InvalidDispatchesReprocessDataEvent>().Subscribe(ExecuteReprocessData);
        EventAggregator.GetEvent<InvalidDispatchesReloadDataEvent>().Subscribe(ExecuteReload);
        EventAggregator.GetEvent<InvalidDispatchesReloadDuplicateDataEvent>().Subscribe(ExecuteReload);
        Header = "Duplicate Dispatches";

        DuplicateDispatchesData = [];
        DuplicateDataProcessing = [];

    }

    private async void ExecuteReload()
    {
        await GetDuplicateData();
    }

    protected override async Task ExecuteViewLoad()
    {
        await base.ExecuteViewLoad();
        //IsBusy = true;
        await GetDuplicateData();
        //IsBusy = false;
    }

    private async Task GetDuplicateData()
    {
        IsBusyContent = "Loading";
        IsBusy = true;
        DuplicateDispatchesData.Clear();
        DuplicateDataProcessing.Clear();
        var request = new DuplicatedDispatchDataRequest
        {
            IsCompressed = false
        };
        var results = _messageService.GetDuplicateInvoiceInformationStream("invoiceInformation", request);
        await foreach (var item in results)
        {
            DuplicateDispatchesData.Add(item);
            IsBusyContent = $"Loading {DuplicateDispatchesData.Count} rows";
        }

        var grouped = DuplicateDispatchesData.GroupBy(x => new { x.FileName, x.DispatchNumber });
        grouped.ForEach(g =>
        {
            DuplicateDataProcessing.Add(new DuplicateDataDto
            {
                DispatchNumber = g.Key.DispatchNumber,
                FileName = g.Key.FileName,
                IsMarkedForDeletion = false,
                IsMarkedForReprocessing = false
            });
        });
        IsBusy = false;
    }

    private void PopulateData(ObservableCollection<EdiInvoiceInformationDto> ediInvoiceInformation)
    {
        DuplicateDataProcessing.Clear();
        DuplicateDispatchesData.Clear();
        //DuplicateDispatchesData.AddRange(ediInvoiceInformation.Where(x => x.Status == EdiInvoiceStatus.Duplicate));
        var grouped = DuplicateDispatchesData.GroupBy(x => new { x.FileName, x.DispatchNumber });
        grouped.ForEach(g =>
        {
            DuplicateDataProcessing.Add(new DuplicateDataDto
            {
                DispatchNumber = g.Key.DispatchNumber,
                FileName = g.Key.FileName,
                IsMarkedForDeletion = false,
                IsMarkedForReprocessing = false
            });
        });
    }

    private async void ExecuteReprocessData(ProcessDataMessage message)
    {
        if (message.Operation == RibbonTabOperation.ReprocessDuplicateDispatches)
        {
            EventAggregator.GetEvent<ReprocessDuplicatesEvent>().Publish(DuplicateDataProcessing);
        }

    }

    private void OnDataValueChanged(object sender, DataValueChangedEventArgs e)
    {
        var item = (DuplicateDataDto)e.Record.DataItem;

        switch (e.Field.Name)
        {
            case "IsMarkedForReprocessing" when item.IsMarkedForReprocessing:
                item.IsMarkedForDeletion = false;
                break;
            case "IsMarkedForDeletion" when item.IsMarkedForDeletion:
                item.IsMarkedForReprocessing = false;
                break;
        }
    }

}
