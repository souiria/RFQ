namespace CDb.CQRS.Handler.PartNumber
{
    sealed class QueryHandler : IQueryHandler<GetPartNumbersQuery, List<PartNumberGrpc>>
    {
        readonly ICDbRepository<DbPartNumber> _Repository;
        List<PartNumberGrpc> _PartNumbers;

        public QueryHandler(ICDbRepository<DbPartNumber> repository)
        {
            _Repository = repository;
            _PartNumbers = [];
        }

        async Task<Result<List<PartNumberGrpc>>> IQueryHandler<GetPartNumbersQuery, List<PartNumberGrpc>>.Handle(GetPartNumbersQuery query, CancellationToken cancellationToken)
        {
            _PartNumbers.Clear();
            GetPartNumbersSpecification spec = new GetPartNumbersSpecification(query.Position, query.TakeAmount);
            List<DbPartNumber> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartNumber result in results)
            {
                PartNumberGrpc partNumberGrpc = PartNumberExtensions.FromEntity(result);
                _PartNumbers.Add(partNumberGrpc)  ;
            }

            return _PartNumbers;
        }
    }
}
