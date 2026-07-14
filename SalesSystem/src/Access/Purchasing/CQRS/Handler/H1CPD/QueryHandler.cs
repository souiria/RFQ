namespace Purchasing.CQRS.Handler.H1CPD
{
    public class QueryHandler : IQueryHandler<GetH1CPDQuery, List<H1CPDGrpc>>
    {
        readonly IPurchasingRepository<DbH1CPD> _Repository;
        List<H1CPDGrpc> _H1CPDGrpc;

        public QueryHandler(IPurchasingRepository<DbH1CPD> repository)
        {
            _Repository = repository;
            _H1CPDGrpc = new List<H1CPDGrpc>();
        }

        public async Task<Result<List<H1CPDGrpc>>> Handle(GetH1CPDQuery query, CancellationToken cancellationToken)
        {
            _H1CPDGrpc.Clear();
            GetH1CPDReadOnlySpec spec = new GetH1CPDReadOnlySpec(query.Position, query.TakeAmount);
            List<DbH1CPD> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach(DbH1CPD result in results)
            {
                H1CPDGrpc h1CPDGrpc = result.FromEntity();
                _H1CPDGrpc.Add(h1CPDGrpc);
            }

            return _H1CPDGrpc;
        }
    }
}
