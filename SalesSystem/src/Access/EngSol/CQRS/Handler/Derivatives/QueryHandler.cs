namespace EngSol.CQRS.Handler.Derivatives
{
    public class QueryHandler : IQueryHandler<GetDerivativesQuery, List<DerivativeGrpc>>
    {
        readonly IEngSolReadRepository<DbDerivatives> _Repository;
        List<DerivativeGrpc> _Derivatives;

        public QueryHandler(IEngSolReadRepository<DbDerivatives> repository)
        {
            _Repository = repository;
            _Derivatives = [];
        }

        public async Task<Result<List<DerivativeGrpc>>> Handle(GetDerivativesQuery query, CancellationToken cancellationToken)
        {
            _Derivatives.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativesReadOnlySpec spec = new GetDerivativesReadOnlySpec(query.Position, query.TakeAmount);
                List<DbDerivatives> results = await _Repository.ListAsync(spec, cts.Token);
                foreach (DbDerivatives result in results)
                {
                    DerivativeGrpc derivativesGrpc = result.MapToDerivativeGrpc();
                    _Derivatives.Add(derivativesGrpc);
                }

                return _Derivatives;
            }
        }
    }
}
