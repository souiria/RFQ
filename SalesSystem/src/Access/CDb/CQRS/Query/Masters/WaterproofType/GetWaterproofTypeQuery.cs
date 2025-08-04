namespace CDb.CQRS.Query.Masters.WaterproofType
{
    public class GetWaterproofTypesQuery : IQuery<List<WaterproofTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
