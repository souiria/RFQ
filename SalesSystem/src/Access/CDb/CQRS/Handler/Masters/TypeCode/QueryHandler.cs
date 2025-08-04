namespace CDb.CQRS.Handler.Masters.TypeCode
{
    sealed class QueryHandler : IQueryHandler<GetTypeCodesQuery, List<TypeCodeGrpc>>
    {
        readonly ICDbRepository<DbTypeCode> _Repository;
        List<TypeCodeGrpc> _TypeCodes;

        public QueryHandler(ICDbRepository<DbTypeCode> repository)
        {
            _Repository = repository;
            _TypeCodes = [];
        }

        async Task<Result<List<TypeCodeGrpc>>> IQueryHandler<GetTypeCodesQuery, List<TypeCodeGrpc>>.Handle(GetTypeCodesQuery query, CancellationToken cancellationToken)
        {
            _TypeCodes.Clear();
            GetTypeCodesSpecification spec = new GetTypeCodesSpecification(query.Position, query.TakeAmount);
            List<DbTypeCode> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbTypeCode result in results)
            {
                TypeCodeGrpc typeCodeGrpc = result.FromEntity();
                _TypeCodes.Add(typeCodeGrpc);
            }

            return _TypeCodes;
        }
    }
}
