namespace Edi.Api.Manager;

public class DuplicateDataManager: IRequestHandler<DuplicatedDispatchDataRequest, List<EdiFileDataUploadDto>>
{
    private readonly IMediator _mediator;

    public DuplicateDataManager(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<List<EdiFileDataUploadDto>> Handle(DuplicatedDispatchDataRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDuplicateEdiFileDataQuery(), cancellationToken);
    }
}
