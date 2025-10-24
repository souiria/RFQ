namespace Master.CQRS.Specification.Vehicle
{
    public class GetVehicleReadOnlySpec : Specification<DbVehicle>
    {
        public GetVehicleReadOnlySpec(int? position, int? take)
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
