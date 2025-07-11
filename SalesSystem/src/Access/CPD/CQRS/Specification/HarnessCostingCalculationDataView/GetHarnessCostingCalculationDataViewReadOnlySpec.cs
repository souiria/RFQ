namespace CPD.CQRS.Specification.HarnessCostingCalculationDataView
{
    public class GetHarnessCostingCalculationDataViewReadOnlySpec : Specification<DbHarnessCostingCalculationDataView>
    {
        public GetHarnessCostingCalculationDataViewReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                Query.Skip(position.Value).Take(take.Value).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
