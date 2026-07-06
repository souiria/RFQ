namespace EngSol.CQRS.Specification
{
    public class GetDerivativePartByDerivativeIdReadOnlySpec : Specification<DbDerivativeParts>
    {
        public GetDerivativePartByDerivativeIdReadOnlySpec(int? id)
        {
            if (0 < id)
            {
                Query.Where(x => x.DerivativeId == id).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
