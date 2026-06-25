namespace EngSol.CQRS.Handler.DerivativeWires
{
    public class QueryHandler : IQueryHandler<GetDerivativeWiresQuery, List<DerivativeWiresGrpc>>
    {
        readonly IEngSolReadRepository<DbDerivativeWires> _Repository;
        List<DerivativeWiresGrpc> _DerivativeWires;

        public QueryHandler(IEngSolReadRepository<DbDerivativeWires> repository)
        {
            _Repository = repository;
            _DerivativeWires = [];
        }

        public async Task<Result<List<DerivativeWiresGrpc>>> Handle(GetDerivativeWiresQuery query, CancellationToken cancellationToken)
        {
            _DerivativeWires.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativeWiresReadOnlySpec spec = new GetDerivativeWiresReadOnlySpec(query.Position, query.TakeAmount);
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
}
