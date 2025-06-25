namespace Master.CQRS.Query.Vehicle
{
    public class GetAllVehiclesQuery : IQuery<List<VehicleData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
