namespace Rfq.CQRS.Handler.RfqDrawingPartNumbers
{
    public class QueryHandler : IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumbersGrpc>>
    {
        readonly IRfqRepository<DbRfqDrawingPartNumber> _Repository;
        List<RfqDrawingPartNumbersGrpc> _RfqDrawingPartNumbers;

        public QueryHandler(IRfqRepository<DbRfqDrawingPartNumber> repository)
        {
            _Repository = repository;
            _RfqDrawingPartNumbers = [];
        }

        public async Task<Result<List<RfqDrawingPartNumbersGrpc>>> Handle(GetRfqDrawingPartNumberQuery query, CancellationToken cancellationToken)
        {
            _RfqDrawingPartNumbers.Clear();
            GetRfqDrawingPartNumberReadOnlySpec spec = new GetRfqDrawingPartNumberReadOnlySpec(query.Position, query.TakeAmount);
            List<DbRfqDrawingPartNumber> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbRfqDrawingPartNumber result in results)
            {
                RfqDrawingPartNumbersGrpc rfqDrawingPartNumbersGrpc = result.FromEntity();
                _RfqDrawingPartNumbers.Add(rfqDrawingPartNumbersGrpc);
            }

            return _RfqDrawingPartNumbers;
        }
    }
}
