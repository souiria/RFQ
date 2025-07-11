namespace CPD.CQRS.Handler.HarnessCostingCalculationDataView
{
    public class QueryHandler : IQueryHandler<GetHarnessCostingCalculationDataViewQuery, List<HarnessCostingCalculationDataGrpc>>
    {
        readonly ICPDDbRepository<DbHarnessCostingCalculationDataView> _Repository;
        List<HarnessCostingCalculationDataGrpc> _HarnessCostingCalculationDataViews;

        public QueryHandler(ICPDDbRepository<DbHarnessCostingCalculationDataView> repository)
        {
            _Repository = repository;
            _HarnessCostingCalculationDataViews = [];
        }

        public async Task<Result<List<HarnessCostingCalculationDataGrpc>>> Handle(GetHarnessCostingCalculationDataViewQuery query, CancellationToken cancellationToken)
        {
            _HarnessCostingCalculationDataViews.Clear();
            GetHarnessCostingCalculationDataViewReadOnlySpec spec = new GetHarnessCostingCalculationDataViewReadOnlySpec(0, 100);
            List<DbHarnessCostingCalculationDataView> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbHarnessCostingCalculationDataView result in results)
            {
                HarnessCostingCalculationDataGrpc harnessCostingCalculationDataGrpc = result.MapToHarnessCostingCalculationDataGrpc();
                _HarnessCostingCalculationDataViews.Add(harnessCostingCalculationDataGrpc);
            }

            return _HarnessCostingCalculationDataViews;
        }
    }
}
