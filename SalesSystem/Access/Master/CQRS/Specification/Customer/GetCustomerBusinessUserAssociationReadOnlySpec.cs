namespace Master.CQRS.Specification.Customer
{
    public class GetCustomerBusinessUserAssociationReadOnlySpec : Specification<DbCustomerBusinessUserAssociation>
    {
        public GetCustomerBusinessUserAssociationReadOnlySpec(Guid? id)
        {
            if (id != null)
            {
                Query.Where(x => x.UserGuid == id).AsNoTracking();
            }
            else
            {
                Query.AsNoTracking();
            }
        }
    }
}
