namespace Emacs.CQRS.Handler.PartCategoryDetail
{
    public class QueryHandler : IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailGrpc>>
    {
        readonly IEMACSReadRepository<DbPartCategoryDetail> _Repository;
        List<PartCategoryDetailGrpc> _PartCategoryDetails;

        public QueryHandler(IEMACSReadRepository<DbPartCategoryDetail> repository)
        {
            _Repository = repository;
            _PartCategoryDetails = [];
        }

        public async Task<Result<List<PartCategoryDetailGrpc>>> Handle(GetPartCatogoryDetailQuery query, CancellationToken cancellationToken)
        {
            _PartCategoryDetails.Clear();
            GetPartCatogoryDetailReadOnlySpec spec = new GetPartCatogoryDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartCategoryDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartCategoryDetail result in results)
            {
                PartCategoryDetailGrpc partCategoryDetailGrpc = result.MapToPartCategoryDetailGrpc();
                _PartCategoryDetails.Add(partCategoryDetailGrpc);
            }

            return _PartCategoryDetails;
        }
    }
}
