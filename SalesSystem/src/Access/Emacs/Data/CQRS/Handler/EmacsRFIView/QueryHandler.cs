
namespace Emacs.Data.CQRS.Handler.EmacsRFIView
{
    public class QueryHandler : IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewData>>
    {
        readonly IEMACSReadRepository<DbEmacsRFIView> _Repository;
        List<EmacsRFIViewData> _EmacsRFIView;

        public QueryHandler(IEMACSReadRepository<DbEmacsRFIView> repository)
        {
            _Repository = repository;
            _EmacsRFIView = [];
        }
        public async Task<Result<List<EmacsRFIViewData>>> Handle(GetEmacsRFIViewQuery query, CancellationToken cancellationToken)
        {
            _EmacsRFIView.Clear();
            GetEmacsRFIViewReadOnlySpec spec = new GetEmacsRFIViewReadOnlySpec(query.Position, query.TakeAmount);
            List<DbEmacsRFIView> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbEmacsRFIView result in results)
            {
                EmacsRFIViewData emacsRFIViewData = result.MapToEmacsRFIViewData();
                _EmacsRFIView.Add(emacsRFIViewData);
            }

            return _EmacsRFIView;
        }
    }
}
