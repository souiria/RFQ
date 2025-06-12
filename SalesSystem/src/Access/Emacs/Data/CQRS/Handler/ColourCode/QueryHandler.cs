namespace Emacs.Data.CQRS.Handler.ColourCode
{
    public class QueryHandler : IQueryHandler<GetColourCodeQuery, List<ColourCodeDto>>
    {
        readonly IEMACSReadRepository<DbColourCode> _Repository;
        List<ColourCodeDto> _ColourCode;

        public QueryHandler(IEMACSReadRepository<DbColourCode> repository)
        {
            _Repository = repository;
            _ColourCode = [];
        }

        public async Task<Result<List<ColourCodeDto>>> Handle(GetColourCodeQuery query, CancellationToken cancellationToken)
        {
            _ColourCode.Clear();
            GetColourCodeReadOnlySpec spec = new GetColourCodeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbColourCode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbColourCode result in results)
            {
                ColourCodeDto colourCodeDto = result.MapToColourCodeDto();
                _ColourCode.Add(colourCodeDto);
            }

            return _ColourCode;
        }
    }
}
