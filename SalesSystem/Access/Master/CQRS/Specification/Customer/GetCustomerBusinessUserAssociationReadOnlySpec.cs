namespace Master.CQRS.Specification.Customer
{
    public class GetCustomerBusinessUserAssociationReadOnlySpec : Specification<DbCustomerBusinessUserAssociation>
    {
        public GetCustomerBusinessUserAssociationReadOnlySpec(int? position, int? take, Guid? id)
        {
            if (id != null)
            {
                Query.Where(x => x.UserGuid == id);
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
}
