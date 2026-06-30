namespace EngSol.CQRS.Handler.DerivativeWires
{
    public class QueryByDerivativeIdHandler : IQueryHandler<GetDerivativeWireByDerivativeIdQuery, List<DerivativeWiresGrpc>>
    {
        readonly IEngSolReadRepository<DbDerivativeWires> _Repository;
        List<DerivativeWiresGrpc> _DerivativeWires;

        public QueryByDerivativeIdHandler(IEngSolReadRepository<DbDerivativeWires> repository)
        {
            _Repository = repository;
            _DerivativeWires = [];
        }

        public async Task<Result<List<DerivativeWiresGrpc>>> Handle(GetDerivativeWireByDerivativeIdQuery query, CancellationToken cancellationToken)
        {
            _DerivativeWires.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativeWireByDerivativeIdReadOnlySpec spec = new GetDerivativeWireByDerivativeIdReadOnlySpec(query.Id);
                List<DbDerivativeWires> results = await _Repository.ListAsync(spec, cts.Token);
                foreach (DbDerivativeWires result in results)
                {
                    DerivativeWiresGrpc derivativeWiresGrpc = result.MapToDerivativeWiresGrpc();
                    _DerivativeWires.Add(derivativeWiresGrpc);
                }

                return _DerivativeWires;
            }
        }
    }
}
