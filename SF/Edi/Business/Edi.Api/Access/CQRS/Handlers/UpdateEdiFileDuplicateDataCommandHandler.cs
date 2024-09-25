namespace Edi.Api.Access.CQRS.Handlers;
internal class UpdateEdiFileDuplicateDataCommandHandler : IRequestHandler<UpdateEdiFileDuplicateDataCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiFileDataUploadDuplicate> _repository;
    private readonly ILogger<UpdateEdiFileDuplicateDataCommandHandler> _logger;

    public UpdateEdiFileDuplicateDataCommandHandler(ISalesEdiRepository<DbEdiFileDataUploadDuplicate> repository, ILogger<UpdateEdiFileDuplicateDataCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateEdiFileDuplicateDataCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.UpdateRangeAsync(request.Data, cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            Console.WriteLine(e);
            return false;
        }
        
    }
}
