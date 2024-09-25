namespace Edi.FileWatcher.Access.CQRS.Handlers;
internal class CheckForExistingFileNameRequestHandler : IRequestHandler<CheckForExistingFileNameRequest, List<EdiFileDataUploadDto>>
{
    private readonly ISalesEdiReadRepository<DbEdiFileDataUpload> _repository;
    private readonly ISalesEdiReadRepository<DbEdiFileDataUploadDuplicate> _repositoryDuplicate;
    private readonly IMapper _mapper;
    private List<EdiFileDataUploadDto> _data;

    public CheckForExistingFileNameRequestHandler(ISalesEdiReadRepository<DbEdiFileDataUpload> repository, IMapper mapper, ISalesEdiReadRepository<DbEdiFileDataUploadDuplicate> repositoryDuplicate)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryDuplicate = repositoryDuplicate;
        _data = [];
    }

    public async Task<List<EdiFileDataUploadDto>> Handle(CheckForExistingFileNameRequest request, CancellationToken cancellationToken)
    {
        _data.Clear();
        try
        {
            var results = await _repository.ListAsync(new CheckForExistingFileNameReadOnlySpec(request.FileName), cancellationToken);
            var resultDuplicates = await _repositoryDuplicate.ListAsync(new CheckForExistingFileNameDuplicatesReadOnlySpec(request.FileName), cancellationToken);
            _data.AddRange(_mapper.Map<List<EdiFileDataUploadDto>>(results));
            _data.AddRange(_mapper.Map<List<EdiFileDataUploadDto>>(resultDuplicates));
            return _data;
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            // TODO: Log error
            throw;
        }
    }
}
