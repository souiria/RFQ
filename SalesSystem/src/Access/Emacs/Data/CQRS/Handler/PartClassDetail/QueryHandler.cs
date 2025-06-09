namespace Emacs.Data.CQRS.Handler.PartClassDetail
{
    public class QueryHandler : IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailDto>>
    {
        readonly IEMACSReadRepository<DbPartClassDetail> _Repository;
        List<PartClassDetailDto> _PartClassDetails;

        public QueryHandler(IEMACSReadRepository<DbPartClassDetail> repository)
        {
            _Repository = repository;
            _PartClassDetails = [];
        }

        public async Task<Result<List<PartClassDetailDto>>> Handle(GetPartClassDetailQuery query, CancellationToken cancellationToken)
        {
            _PartClassDetails.Clear();
            GetPartClassDetailReadOnlySpec spec = new GetPartClassDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartClassDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartClassDetail result in results)
            {
                PartClassDetailDto partClassDetailDto = result.MapToPartClassDetailDto();
                _PartClassDetails.Add(partClassDetailDto);
            }

            return _PartClassDetails;
        }
    }
}
