namespace Rfq.CQRS.Handler.RfqDrawingPartNumbers
{
    public class QueryHandler : IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumberGrpc>>
    {
        readonly IRfqRepository<DbRfqDrawingPartNumber> _Repository;
        List<RfqDrawingPartNumberGrpc> _RfqDrawingPartNumbers;

        public QueryHandler(IRfqRepository<DbRfqDrawingPartNumber> repository)
        {
            _Repository = repository;
            _RfqDrawingPartNumbers = [];
        }

        public async Task<Result<List<RfqDrawingPartNumberGrpc>>> Handle(GetRfqDrawingPartNumberQuery query, CancellationToken cancellationToken)
        {
            _RfqDrawingPartNumbers.Clear();
            GetRfqDrawingPartNumberReadOnlySpec spec = new GetRfqDrawingPartNumberReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqDrawingPartNumber> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqDrawingPartNumber result in results)
            {
                RfqDrawingPartNumberGrpc rfqDrawingPartNumbersGrpc = result.FromEntity();
                _RfqDrawingPartNumbers.Add(rfqDrawingPartNumbersGrpc);
            }

            return _RfqDrawingPartNumbers;
        }
    }
}
