namespace Edi.FileWatcher.Access.CQRS.Handlers;
internal class GetDuplicateEdiFileDataQueryHandler : IRequestHandler<GetDuplicateEdiFileDataQuery, List<EdiFileDataUploadDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiFileDataUpload> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetDuplicateEdiFileDataQueryHandler> _logger;

    public GetDuplicateEdiFileDataQueryHandler(ISalesEdiReadRepository<DbEdiFileDataUpload> repository, IMapper mapper, ILogger<GetDuplicateEdiFileDataQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<EdiFileDataUploadDto>> Handle(GetDuplicateEdiFileDataQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _repository.ListAsync(new GetDuplicateEdiFileDataReadOnlySpec(request.Filename, request.DispatchDate, request.DispatchNumber), cancellationToken);
            return _mapper.Map<List<EdiFileDataUploadDto>>(results);
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
