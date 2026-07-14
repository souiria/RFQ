namespace EngSol.CQRS.Specification
{
    public class GetDerivativeByDerivativeIdReadOnlySpec : Specification<DbDerivatives>
    {
        public GetDerivativeByDerivativeIdReadOnlySpec(int derivativeId)
        {
            Query.Where(x => x.DerivativeId == derivativeId).AsNoTracking();
        }
    }
}
