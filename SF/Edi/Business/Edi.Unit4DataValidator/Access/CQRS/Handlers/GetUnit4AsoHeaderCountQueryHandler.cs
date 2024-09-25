using Edi.Unit4DataValidator.Access.CQRS.Queries;
using Edi.Unit4DataValidator.Access.CQRS.Specifications;
using Edi.Unit4DataValidator.Access.Data.Interfaces;
using Edi.Unit4DataValidator.Access.Data.Models;

namespace Edi.Unit4DataValidator.Access.CQRS.Handlers;
internal class GetUnit4AsoHeaderCountQueryHandler : IRequestHandler<GetUnit4AsoHeaderCountQuery, int>
{
    private readonly IUnit4ReadRepository<DbUnit4SalesOrdersView> _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetUnit4AsoHeaderCountQueryHandler> _logger;

    public GetUnit4AsoHeaderCountQueryHandler(IUnit4ReadRepository<DbUnit4SalesOrdersView> repository, IMapper mapper, ILogger<GetUnit4AsoHeaderCountQueryHandler> logger)
    {
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(GetUnit4AsoHeaderCountQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.CountAsync(new GetUnit4AsoHeaderCountReadOnlySpec(request.FinanceCode, request.Client, request.DispatchNumber, request.DispatchDate), cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
