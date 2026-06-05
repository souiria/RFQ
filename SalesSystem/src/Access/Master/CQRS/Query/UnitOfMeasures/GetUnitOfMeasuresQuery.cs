namespace Master.CQRS.Query.UnitOfMeasure
{
    public class GetUnitOfMeasuresQuery : IQuery<List<UnitOfMeasureGrpc>>
    {
        public int? Position
        { get; set; }

        public int? TakeAmount
        { get; set; }
    }
}