namespace CDb.CQRS.Query.Masters.MiscellaneousComponent
{
    public class GetMiscellaneousComponentTypesQuery : IQuery<List<MiscellaneousComponentTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
