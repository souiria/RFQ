using Edi.Unit4DataValidator.Access.CQRS.Queries;
using Edi.Unit4DataValidator.Access.CQRS.Specifications;
using Edi.Unit4DataValidator.Access.Data.Interfaces;
using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Handlers;
internal class GetUnit4BatchInputCountQueryHandler : IRequestHandler<GetUnit4BatchInputCountQuery, int>
{
    private readonly IUnit4ReadRepository<DbAlgBatchInput> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUnit4BatchInputCountQueryHandler> _logger;

    public GetUnit4BatchInputCountQueryHandler(IUnit4ReadRepository<DbAlgBatchInput> repository, IMapper mapper, ILogger<GetUnit4BatchInputCountQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(GetUnit4BatchInputCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.CountAsync(new GetUnit4BatchInputCountReadOnlySpec(request.FinanceCode, request.Client, request.DispatchNumber, request.DispatchDate), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
