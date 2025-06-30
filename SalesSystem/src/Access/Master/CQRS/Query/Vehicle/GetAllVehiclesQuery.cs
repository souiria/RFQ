namespace Master.CQRS.Query.Vehicle
{
    public class GetAllVehiclesQuery : IQuery<List<VehicleGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
