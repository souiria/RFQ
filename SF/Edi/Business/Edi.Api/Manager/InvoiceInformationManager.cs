namespace Edi.Api.Manager;

public class InvoiceInformationManager : IRequestHandler<InvalidDispatchRequest, List<EdiInvoiceInformationDto>>,
    IRequestHandler<ReprocessOutstandingDispatchesRequest, List<EdiInvoiceInformationDto>>,
    IRequestHandler<EdiCustomerParameterRequest, List<EdiCustomerParameterDto>>
{
    private readonly ILogger<InvoiceInformationManager> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public InvoiceInformationManager(ILogger<InvoiceInformationManager> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Return a list of invalid dispatch data
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List&lt;EdiInvoiceInformationDto&gt;</returns>
    public async Task<List<EdiInvoiceInformationDto>> Handle(InvalidDispatchRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetEdiInvoiceInformationQuery(), cancellationToken);
    }

    /// <summary>
    /// Reprocess Outstanding Edi Invoice Information
    /// </summary>
    /// <returns>List&lt;EdiInvoiceInformationDto&gt;</returns>
    public async Task<List<EdiInvoiceInformationDto>> Handle(ReprocessOutstandingDispatchesRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetEdiInvoiceInformationQuery(), cancellationToken);
    }

    /// <summary>
    /// Get Edi Customer Parameters
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<EdiCustomerParameterDto>> Handle(EdiCustomerParameterRequest request,
        CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetCustomerParameterQuery(), cancellationToken);
    }

}
