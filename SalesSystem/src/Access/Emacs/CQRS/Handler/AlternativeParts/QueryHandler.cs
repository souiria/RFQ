namespace Emacs.CQRS.Handler.AlternativeParts
{
    public class QueryHandler : IQueryHandler<GetAlternativePartsQuery, List<AlternativePartsGrpc>>
    {
        readonly IEMACSReadRepository<DbAlternativeParts> _Repository;
        List<AlternativePartsGrpc> _AlternativeParts;

        public QueryHandler(IEMACSReadRepository<DbAlternativeParts> repository)
        {
            _Repository = repository;
            _AlternativeParts = [];
        }

        public async Task<Result<List<AlternativePartsGrpc>>> Handle(GetAlternativePartsQuery query, CancellationToken cancellationToken)
        {
            _AlternativeParts.Clear();
            TimeSpan ts = TimeSpan.FromSeconds(120);
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                GetAlternativePartsReadOnlySpec spec = new GetAlternativePartsReadOnlySpec(query.Position, query.TakeAmount);
                List<DbAlternativeParts> results = await _Repository.ListAsync(spec, cts.Token);
                foreach (DbAlternativeParts result in results)
                {
                    AlternativePartsGrpc alternativePartsGrpc = result.MapToAlternativePartsGrpc();
                    _AlternativeParts.Add(alternativePartsGrpc);
                }

                return _AlternativeParts;
            }
        }
    }
}
