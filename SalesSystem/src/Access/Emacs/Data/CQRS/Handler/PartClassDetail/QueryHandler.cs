namespace Emacs.Data.CQRS.Handler.PartClassDetail
{
    public class QueryHandler : IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailGrpc>>
    {
        readonly IEMACSReadRepository<DbPartClassDetail> _Repository;
        List<PartClassDetailGrpc> _PartClassDetails;

        public QueryHandler(IEMACSReadRepository<DbPartClassDetail> repository)
        {
            _Repository = repository;
            _PartClassDetails = [];
        }

        public async Task<Result<List<PartClassDetailGrpc>>> Handle(GetPartClassDetailQuery query, CancellationToken cancellationToken)
        {
            _PartClassDetails.Clear();
            GetPartClassDetailReadOnlySpec spec = new GetPartClassDetailReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartClassDetail> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartClassDetail result in results)
            {
                PartClassDetailGrpc PartClassDetailGrpc = result.MapToPartClassDetailGrpc();
                _PartClassDetails.Add(PartClassDetailGrpc);
            }

            return _PartClassDetails;
        }
    }
}
