
namespace Edi.DataProcessor.Engine;
internal class EdiCustomerParameterEngine : IRequestHandler<EdiCustomerParameterRequest, List<EdiCustomerParameterDto>>
{
    private readonly ILogger<EdiCustomerParameterEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public EdiCustomerParameterEngine(ILogger<EdiCustomerParameterEngine> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<List<EdiCustomerParameterDto>> Handle(EdiCustomerParameterRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        var result = await _mediator.Send(new GetEdiCustomerParametersQuery(), cancellationToken);
        _logger.LogInformation($"Updating Customer Parameters - {result.Count} customers loaded");
        return result;
    }
}
