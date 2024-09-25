using Edi.Api.Access.Data.Models;

namespace Edi.Api.Engine;

public class ReprocessEngine : IRequestHandler<ReprocessEngineRequest, List<EdiInvoiceInformationDto>>
{
    private readonly ILogger<ReprocessEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    private List<EdiInvoiceInformationDto> _ediInvoiceInformation;

    public ReprocessEngine(ILogger<ReprocessEngine> logger, IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(ReprocessEngineRequest request, CancellationToken cancellationToken)
    {
        // Select all outstanding rows from Edi Invoice Information
        await GetEdiInvoiceInformationDataAsync(cancellationToken);
        var dispatches = _ediInvoiceInformation.GroupBy(x => x.DispatchNumber);
        foreach (var dispatch in dispatches)
        {
            await _publishEndpoint.Publish(new DispatchDataInserted { DispatchData = dispatch.ToList() },
                cancellationToken);
        }
        _ediInvoiceInformation.Clear();
        return _ediInvoiceInformation;
    }

    private async Task GetEdiInvoiceInformationDataAsync(CancellationToken cancellationToken)
    {
        _ediInvoiceInformation = await _mediator.Send(new GetEdiInvoiceInformationQuery(), cancellationToken);
    }

    private async Task<bool> SaveEdiInvoiceInformationAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new AddEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(_ediInvoiceInformation)), cancellationToken);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
