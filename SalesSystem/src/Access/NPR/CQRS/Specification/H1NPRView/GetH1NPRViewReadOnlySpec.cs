namespace NPR.CQRS.Specification.H1NPRView
{
    public class GetH1NPRViewReadOnlySpec : Specification<DbH1NPRView>
    {
        public GetH1NPRViewReadOnlySpec(int? position, int? take)
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
