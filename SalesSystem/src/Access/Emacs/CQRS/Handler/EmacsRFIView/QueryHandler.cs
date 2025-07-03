namespace Emacs.CQRS.Handler.EmacsRFIView
{
    public class QueryHandler : IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewGrpc>>
    {
        readonly IEMACSReadRepository<DbEmacsRFIView> _Repository;
        List<EmacsRFIViewGrpc> _EmacsRFIView;

        public QueryHandler(IEMACSReadRepository<DbEmacsRFIView> repository)
        {
            _Repository = repository;
            _EmacsRFIView = [];
        }
        public async Task<Result<List<EmacsRFIViewGrpc>>> Handle(GetEmacsRFIViewQuery query, CancellationToken cancellationToken)
        {
            _EmacsRFIView.Clear();
            GetEmacsRFIViewReadOnlySpec spec = new GetEmacsRFIViewReadOnlySpec(query.Position, query.TakeAmount);
            List<DbEmacsRFIView> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbEmacsRFIView result in results)
            {
                EmacsRFIViewGrpc emacsRFIViewGrpc = result.MapToEmacsRFIViewGrpc();
                _EmacsRFIView.Add(emacsRFIViewGrpc);
            }

            return _EmacsRFIView;
        }
    }
}
