namespace EngSol.CQRS.Specification
{
    public class GetDerivativesReadOnlySpec : Specification<DbDerivatives>
    {
        public GetDerivativesReadOnlySpec(int? position, int? take)
        {
            if (position != null && take != null)
            {
                DateTime dateFilter = DateTime.Now.AddYears(-1);
                Query.Skip(position.Value).Take(take.Value).Where(x => dateFilter < x.ExpiryDate && x.DrawingChangeControlStatus != 6).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
