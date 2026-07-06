namespace EngSol.CQRS.Handler.Derivatives
{
    public class QueryByDerivativeIdHandler : IQueryHandler<GetDerivativeByDerivativeIdQuery, DerivativeGrpc>
    {
        readonly IEngSolReadRepository<DbDerivatives> _Repository;
        DerivativeGrpc _Derivative;
        public QueryByDerivativeIdHandler(IEngSolReadRepository<DbDerivatives> repository)
        {
            _Repository = repository;
            _Derivative = new DerivativeGrpc();
        }
        public async Task<Result<DerivativeGrpc>> Handle(GetDerivativeByDerivativeIdQuery query, CancellationToken cancellationToken)
        {
            //TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativeByDerivativeIdReadOnlySpec spec = new GetDerivativeByDerivativeIdReadOnlySpec(query.Id);
                List<DbDerivatives> results = await _Repository.ListAsync(spec, cts.Token);
                _Derivative = results.FirstOrDefault()?.MapToDerivativeGrpc() ?? new DerivativeGrpc();

                return _Derivative;
            }
        }
    }
}
