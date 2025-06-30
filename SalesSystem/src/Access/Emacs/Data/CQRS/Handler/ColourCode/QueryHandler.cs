namespace Emacs.Data.CQRS.Handler.ColourCode
{
    public class QueryHandler : IQueryHandler<GetColourCodeQuery, List<ColourCodeGrpc>>
    {
        readonly IEMACSReadRepository<DbColourCode> _Repository;
        List<ColourCodeGrpc> _ColourCode;

        public QueryHandler(IEMACSReadRepository<DbColourCode> repository)
        {
            _Repository = repository;
            _ColourCode = [];
        }

        public async Task<Result<List<ColourCodeGrpc>>> Handle(GetColourCodeQuery query, CancellationToken cancellationToken)
        {
            _ColourCode.Clear();
            GetColourCodeReadOnlySpec spec = new GetColourCodeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbColourCode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbColourCode result in results)
            {
                ColourCodeGrpc colourCodeGrpc = result.MapToColourCodeGrpc();
                _ColourCode.Add(colourCodeGrpc);
            }

            return _ColourCode;
        }
    }
}
