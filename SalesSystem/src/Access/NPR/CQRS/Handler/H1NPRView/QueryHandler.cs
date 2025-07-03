namespace NPR.CQRS.Handler.H1NPRView
{
    public class QueryHandler : IQueryHandler<GetH1NPRViewQuery, List<H1NPRViewGrpc>>
    {
        readonly INPRDbRepository<DbH1NPRView> _Repository;
        List<H1NPRViewGrpc> _H1NPRViews;

        public QueryHandler(INPRDbRepository<DbH1NPRView> repository)
        {
            _Repository = repository;
            _H1NPRViews = [];
        }
        public async Task<Result<List<H1NPRViewGrpc>>> Handle(GetH1NPRViewQuery query, CancellationToken cancellationToken)
        {
            _H1NPRViews.Clear();
            GetH1NPRViewReadOnlySpec spec = new GetH1NPRViewReadOnlySpec(query.Position, query.TakeAmount);
            List<DbH1NPRView> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbH1NPRView result in results)
            {
                H1NPRViewGrpc h1NPRViewGrpc = result.MapToH1NPRViewGrpc();
                _H1NPRViews.Add(h1NPRViewGrpc);
            }

            return _H1NPRViews;
        }
    }
}
