namespace EngSol.CQRS.Handler.DerivativeParts
{
    public class QueryByDerivativeIdHandler : IQueryHandler<GetDerivativePartsByDerivativeIdQuery, List<DerivativePartsGrpc>>
    {
        readonly IEngSolReadRepository<DbDerivativeParts> _Repository;
        List<DerivativePartsGrpc> _DerivativeParts;

        public QueryByDerivativeIdHandler(IEngSolReadRepository<DbDerivativeParts> repository)
        {
            _Repository = repository;
            _DerivativeParts = [];
        }

        public async Task<Result<List<DerivativePartsGrpc>>> Handle(GetDerivativePartsByDerivativeIdQuery query, CancellationToken cancellationToken)
        {
            _DerivativeParts.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativePartByDerivativeIdReadOnlySpec spec = new GetDerivativePartByDerivativeIdReadOnlySpec(query.Id);
                List<DbDerivativeParts> results = await _Repository.ListAsync(spec, cts.Token);
                foreach (DbDerivativeParts result in results)
                {
                    DerivativePartsGrpc derivativePartsGrpc = result.MapToDerivativePartsGrpc();
                    _DerivativeParts.Add(derivativePartsGrpc);
                }

                return _DerivativeParts;
            }
        }
    }
}
