namespace Emacs.Data.CQRS.Handler.PartCategoryDetail
{
    public class QueryHandler : IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailData>>
    {
        readonly IEMACSReadRepository<DbPartCategoryDetail> _Repository;
        List<PartCategoryDetailData> _PartCategoryDetails;

        public QueryHandler(IEMACSReadRepository<DbPartCategoryDetail> repository)
        {
            _Repository = repository;
            _PartCategoryDetails = [];
        }

        public async Task<Result<List<PartCategoryDetailData>>> Handle(GetPartCatogoryDetailQuery query, CancellationToken cancellationToken)
        {
            _PartCategoryDetails.Clear();
            GetPartCatogoryDetailReadOnlySpec spec = new GetPartCatogoryDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartCategoryDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartCategoryDetail result in results)
            {
                PartCategoryDetailData partCategoryDetailData = result.MapToPartCategoryDetailData();
                _PartCategoryDetails.Add(partCategoryDetailData);
            }

            return _PartCategoryDetails;
        }
    }
}
