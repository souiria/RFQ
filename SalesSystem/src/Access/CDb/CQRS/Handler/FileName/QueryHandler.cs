namespace CDb.CQRS.Handler.FileName
{
    sealed class QueryHandler : IQueryHandler<GetFileNamesQuery, List<FileNameGrpc>>
    {
        readonly ICDbRepository<DbFileName> _Repository;
        List<FileNameGrpc> _FileNames;

        public QueryHandler(ICDbRepository<DbFileName> repository)
        {
            _Repository = repository;
            _FileNames = [];
        }

        async Task<Result<List<FileNameGrpc>>> IQueryHandler<GetFileNamesQuery, List<FileNameGrpc>>.Handle(GetFileNamesQuery query, CancellationToken cancellationToken)
        {
            _FileNames.Clear();
            GetFileNamesSpecification spec = new GetFileNamesSpecification(query.Position, query.TakeAmount);
            List<DbFileName> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbFileName result in results)
            {
                FileNameGrpc fileNameGrpc = FileNameExtensions.FromEntity(result);
                _FileNames.Add(fileNameGrpc)  ;
            }

            return _FileNames;
        }
    }
}
