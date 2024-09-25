namespace Edi.FileWatcher.Access.CQRS.Handlers;
internal class AddEdiFileDataCommandHandler : IRequestHandler<AddEdiFileDataCommand, bool>
{
    private readonly ISalesEdiRepository<DbEdiFileDataUpload> _repository;
    private readonly ILogger<AddEdiFileDataCommandHandler> _logger;

    public AddEdiFileDataCommandHandler(ISalesEdiRepository<DbEdiFileDataUpload> repository, ILogger<AddEdiFileDataCommandHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> Handle(AddEdiFileDataCommand request, CancellationToken cancellationToken)
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
