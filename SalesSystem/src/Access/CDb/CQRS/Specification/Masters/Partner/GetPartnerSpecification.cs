namespace CDb.CQRS.Specification.Masters.Partner
{
    public class GetPartnersSpecification : Specification<DbPartner>
    {
        public GetPartnersSpecification(int? position, int? take)
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
