namespace Unit4.CQRS.Handler
{
    sealed class QueryHandler : IQueryHandler<GetUnit4AsoHeaderCountQuery, int>,
        IQueryHandler<GetUnit4BatchInputCountQuery, int>,
        IQueryHandler<GetUnit4InputProductsCountQuery, int>,
        IQueryHandler<GetUnit4InputProductsQuery, List<DbAlgProductInput>>,
        IQueryHandler<GetUnit4ProductMasterQuery, List<DbMinAlgArticle>>
    {
        readonly ILogger<QueryHandler> _Logger;
        readonly IUnit4ReadRepository<DbUnit4SalesOrdersView> _Unit4SalesOrdersViewRepository;
        readonly IUnit4ReadRepository<DbAlgBatchInput> _AlgBatchInputRepository;
        readonly IUnit4ReadRepository<DbAlgProductInput> _AlgProductInputRepository;
        readonly IUnit4ReadRepository<DbMinAlgArticle> _MinAlgArticleRepository;

        public QueryHandler(ILogger<QueryHandler> logger,
            IUnit4ReadRepository<DbUnit4SalesOrdersView> unit4SalesOrdersViewRepository,
            IUnit4ReadRepository<DbAlgBatchInput> algBatchInputRepository,
            IUnit4ReadRepository<DbAlgProductInput> algProductInputRepository,
            IUnit4ReadRepository<DbMinAlgArticle> minAlgArticleRepository)
        {
            _Logger = logger;
            _Unit4SalesOrdersViewRepository = unit4SalesOrdersViewRepository;
            _AlgBatchInputRepository = algBatchInputRepository;
            _AlgProductInputRepository = algProductInputRepository;
            _MinAlgArticleRepository = minAlgArticleRepository;
        }

        public async Task<Result<int>> Handle(GetUnit4AsoHeaderCountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetUnit4AsoHeaderCountReadOnlySpec spec = new GetUnit4AsoHeaderCountReadOnlySpec(query.FinanceCode, query.Client, query.DispatchNumber, query.DispatchDate);
                return await _Unit4SalesOrdersViewRepository.CountAsync(spec, cancellationToken);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Result<int>> Handle(GetUnit4BatchInputCountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetUnit4BatchInputCountReadOnlySpec spec = new GetUnit4BatchInputCountReadOnlySpec(query.FinanceCode, query.Client, query.DispatchNumber, query.DispatchDate);
                return await _AlgBatchInputRepository.CountAsync(spec, cancellationToken);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Result<int>> Handle(GetUnit4InputProductsCountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetUnit4InputProductsCountReadOnlySpec spec = new GetUnit4InputProductsCountReadOnlySpec(query.PartNumber, query.Client);
                return await _AlgProductInputRepository.CountAsync(spec, cancellationToken);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Result<List<DbAlgProductInput>>> Handle(GetUnit4InputProductsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetUnit4InputProductsReadOnlySpec spec = new GetUnit4InputProductsReadOnlySpec();
                return await _AlgProductInputRepository.ListAsync(spec, cancellationToken);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<Result<List<DbMinAlgArticle>>> Handle(GetUnit4ProductMasterQuery query, CancellationToken cancellationToken)
        {
            try
            {
                GetUnit4ProductMasterReadOnlySpec spec = new GetUnit4ProductMasterReadOnlySpec();
                return await _MinAlgArticleRepository.ListAsync(spec, cancellationToken);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(ex.Message, ex);
                throw;
            }
        }
    }
}
