using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Regions;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.Core.Interfaces;
using UX.Commercial.Edi.Core.Messages.Requests;

namespace UX.Commercial.Edi.ViewModels;
internal class EdiCustomerParametersViewModel : RegionViewModelBase
{
    private readonly IMessageService _messageService;
    private ObservableCollection<EdiCustomerParameterDto> _ediCustomerParameters;

    public ObservableCollection<EdiCustomerParameterDto> EdiCustomerParameters
    {
        get => _ediCustomerParameters;
        set => SetProperty(ref _ediCustomerParameters, value);
    }

    public EdiCustomerParametersViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMessageService messageService) : base(eventAggregator, regionManager)
    {
        Header = "Customer Parameters";
        _messageService = messageService;
        EdiCustomerParameters = new();
    }

    protected override async Task ExecuteViewLoad()
    {
        await base.ExecuteViewLoad();
        await GetCustomerParameters();
    }

    private async void ExecuteReload()
    {
        await GetCustomerParameters();
    }

    private async Task GetCustomerParameters()
    {
        try
        {
            IsBusy = true;
            EdiCustomerParameters.Clear();
            var request = new EdiCustomerParameterRequest();
            var results = _messageService.GetAllCustomerParameterStream("invoiceInformation", request);
            await foreach (var item in results)
            {
                EdiCustomerParameters.Add(item);
                IsBusyContent = $"Loading {EdiCustomerParameters.Count} rows";
            }
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
            //EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidEnabled });
        }
    }
}
