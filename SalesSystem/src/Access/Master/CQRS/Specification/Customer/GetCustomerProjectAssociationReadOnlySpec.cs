namespace Master.CQRS.Specification.Customer
{
    public class GetCustomerProjectAssociationReadOnlySpec : Specification<DbCustomerProjectAssociation>
    {
        public GetCustomerProjectAssociationReadOnlySpec(int? position, int? take)
        {
            Query.Where(x => x.IsActive == true);
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
