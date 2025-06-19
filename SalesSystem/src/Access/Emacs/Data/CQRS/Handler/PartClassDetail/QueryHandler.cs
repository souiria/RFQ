namespace Emacs.Data.CQRS.Handler.PartClassDetail
{
    public class QueryHandler : IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailData>>
    {
        readonly IEMACSReadRepository<DbPartClassDetail> _Repository;
        List<PartClassDetailData> _PartClassDetails;

        public QueryHandler(IEMACSReadRepository<DbPartClassDetail> repository)
        {
            _Repository = repository;
            _PartClassDetails = [];
        }

        public async Task<Result<List<PartClassDetailData>>> Handle(GetPartClassDetailQuery query, CancellationToken cancellationToken)
        {
            _PartClassDetails.Clear();
            GetPartClassDetailReadOnlySpec spec = new GetPartClassDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartClassDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartClassDetail result in results)
            {
                PartClassDetailData partClassDetailData = result.MapToPartClassDetailData();
                _PartClassDetails.Add(partClassDetailData);
            }

            return _PartClassDetails;
        }
    }
}
