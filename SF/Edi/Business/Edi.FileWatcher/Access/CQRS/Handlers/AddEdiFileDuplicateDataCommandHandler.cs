namespace Edi.FileWatcher.Access.CQRS.Handlers;
internal class AddEdiFileDuplicateDataCommandHandler : IRequestHandler<AddEdiFileDuplicateDataCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiFileDataUploadDuplicate> _repository;
    private readonly ILogger<AddEdiFileDuplicateDataCommandHandler> _logger;

    public AddEdiFileDuplicateDataCommandHandler(ISalesEdiRepository<DbEdiFileDataUploadDuplicate> repository, ILogger<AddEdiFileDuplicateDataCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddEdiFileDuplicateDataCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.AddRangeAsync(request.Data, cancellationToken);
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
