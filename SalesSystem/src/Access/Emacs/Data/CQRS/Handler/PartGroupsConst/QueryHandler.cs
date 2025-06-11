namespace Emacs.Data.CQRS.Handler.PartGroupsConst
{
    public class QueryHandler : IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstDto>>
    {
        readonly IEMACSReadRepository<DbPartGroupsConst> _Repository;
        List<PartGroupsConstDto> _PartGroupsConst;

        public QueryHandler(IEMACSReadRepository<DbPartGroupsConst> repository)
        {
            _Repository = repository;
            _PartGroupsConst = [];
        }
        public async Task<Result<List<PartGroupsConstDto>>> Handle(GetPartGroupsConstQuery query, CancellationToken cancellationToken)
        {
            _PartGroupsConst.Clear();
            GetPartGroupsConstReadOnlySpec spec = new GetPartGroupsConstReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPartGroupsConst> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartGroupsConst result in results)
            {
                PartGroupsConstDto partGroupsDto = result.MapToPartGroupsConstDto();
                _PartGroupsConst.Add(partGroupsDto);
            }

            return _PartGroupsConst;
        }
    }
}
