namespace CPD.CQRS.Handler.MatSuppMstView
{
    public class QueryHandler : IQueryHandler<GetMattSuppMstViewQuery, List<MatSuppMstViewGrpc>>
    {
        readonly ICPDDbRepository<DbMattSuppMstView> _Repository;
        List<MatSuppMstViewGrpc> _MatSuppMstViews;

        public QueryHandler(ICPDDbRepository<DbMattSuppMstView> repository)
        {
            _Repository = repository;
            _MatSuppMstViews = [];
        }

        public async Task<Result<List<MatSuppMstViewGrpc>>> Handle(GetMattSuppMstViewQuery query, CancellationToken cancellationToken)
        {
            _MatSuppMstViews.Clear();
            GetMatSuppMstViewReadOnlySpec spec = new GetMatSuppMstViewReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMattSuppMstView> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbMattSuppMstView result in results)
            {
                MatSuppMstViewGrpc matSuppMstViewGrpc = result.MapToMatSuppMstViewGrpc();
                _MatSuppMstViews.Add(matSuppMstViewGrpc);
            }

            return _MatSuppMstViews;
        }
    }
}
