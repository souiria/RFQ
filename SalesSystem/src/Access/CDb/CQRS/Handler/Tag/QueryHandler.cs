namespace CDb.CQRS.Handler.Tag
{
    sealed class QueryHandler : IQueryHandler<GetTagsQuery, List<TagGrpc>>
    {
        readonly ICDbRepository<DbTag> _Repository;
        List<TagGrpc> _Tags;

        public QueryHandler(ICDbRepository<DbTag> repository)
        {
            _Repository = repository;
            _Tags = [];
        }

        async Task<Result<List<TagGrpc>>> IQueryHandler<GetTagsQuery, List<TagGrpc>>.Handle(GetTagsQuery query, CancellationToken cancellationToken)
        {
            _Tags.Clear();
            GetTagsSpecification spec = new GetTagsSpecification(query.Position, query.TakeAmount);
            List<DbTag> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbTag result in results)
            {
                TagGrpc tagGrpc = TagExtensions.FromEntity(result);
                _Tags.Add(tagGrpc)  ;
            }

            return _Tags;
        }
    }
}
