namespace CDb.CQRS.Query.Masters.TemperatureRange
{
    public class GetTemperatureRangesQuery : IQuery<List<TemperatureRangeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
