namespace Emacs.Data.CQRS.Handler.ColourCode
{
    public class QueryHandler : IQueryHandler<GetColourCodeQuery, List<ColourCodeData>>
    {
        readonly IEMACSReadRepository<DbColourCode> _Repository;
        List<ColourCodeData> _ColourCode;

        public QueryHandler(IEMACSReadRepository<DbColourCode> repository)
        {
            _Repository = repository;
            _ColourCode = [];
        }

        public async Task<Result<List<ColourCodeData>>> Handle(GetColourCodeQuery query, CancellationToken cancellationToken)
        {
            _ColourCode.Clear();
            GetColourCodeReadOnlySpec spec = new GetColourCodeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbColourCode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbColourCode result in results)
            {
                ColourCodeData colourCodeData = result.MapToColourCodeData();
                _ColourCode.Add(colourCodeData);
            }

            return _ColourCode;
        }
    }
}
