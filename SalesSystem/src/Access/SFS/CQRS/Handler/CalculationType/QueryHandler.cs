
namespace SFS.CQRS.Handler.CalculationType
{
    public class QueryHandler : IQueryHandler<GetCalculationTypeQuery, List<CalculationTypeViewGrpc>>
    {
        readonly ISFSReadRepository<DbCalculationType> _Repository;
        List<CalculationTypeViewGrpc> _Calculationtype;

        public QueryHandler(ISFSReadRepository<DbCalculationType> repository)
        {
            _Repository = repository;
            _Calculationtype = [];
        }
        public async Task<Result<List<CalculationTypeViewGrpc>>> Handle(GetCalculationTypeQuery query, CancellationToken cancellationToken)
        {
            _Calculationtype.Clear();
            CalculationTypeReadOnlySpec spec = new CalculationTypeReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCalculationType> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbCalculationType result in results)
            {
                CalculationTypeViewGrpc calculationTypeGrpc = result.MapToCalculationTypeGrpc();
                _Calculationtype.Add(calculationTypeGrpc);
            }

            return _Calculationtype;
        }
    }
}
