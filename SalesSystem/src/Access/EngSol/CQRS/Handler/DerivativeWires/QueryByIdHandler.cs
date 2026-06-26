namespace EngSol.CQRS.Handler.DerivativeWires
{
    public class QueryByIdHandler
    {
        readonly IEngSolReadRepository<DbDerivativeWires> _Repository;
        List<DerivativeWiresGrpc> _DerivativeWires;

        public QueryByIdHandler(IEngSolReadRepository<DbDerivativeWires> repository)
        {
            _Repository = repository;
            _DerivativeWires = [];
        }

        public async Task<Result<List<DerivativeWiresGrpc>>> Handle(GetDerivativeWireByIdQuery query, CancellationToken cancellationToken)
        {
            _DerivativeWires.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetDerivativeWireByIdReadOnlySpec spec = new GetDerivativeWireByIdReadOnlySpec(query.Id);
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
