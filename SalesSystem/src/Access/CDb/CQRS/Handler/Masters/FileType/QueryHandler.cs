using CDb.CQRS.Query.Masters.FileType;
using CDb.CQRS.Specification.Masters.FileType;

namespace CDb.CQRS.Handler.Masters.FileType
{
    sealed class QueryHandler : IQueryHandler<GetFileTypesQuery, List<FileTypeGrpc>>
    {
        readonly ICDbRepository<DbFileType> _Repository;
        List<FileTypeGrpc> _FileTypes;

        public QueryHandler(ICDbRepository<DbFileType> repository)
        {
            _Repository = repository;
            _FileTypes = [];
        }

        async Task<Result<List<FileTypeGrpc>>> IQueryHandler<GetFileTypesQuery, List<FileTypeGrpc>>.Handle(GetFileTypesQuery query, CancellationToken cancellationToken)
        {
            _FileTypes.Clear();
            GetFileTypesSpecification spec = new GetFileTypesSpecification(query.Position, query.TakeAmount);
            List<DbFileType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbFileType result in results)
            {
                FileTypeGrpc fileTypeGrpc = result.FromEntity();
                _FileTypes.Add(fileTypeGrpc);
            }

            return _FileTypes;
        }
    }
}
