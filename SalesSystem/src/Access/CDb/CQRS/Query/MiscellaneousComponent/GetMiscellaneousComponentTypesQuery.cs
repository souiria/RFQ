namespace CDb.CQRS.Query.MiscellaneousComponentType
{
    public class GetMiscellaneousComponentTypesQuery : IQuery<List<MiscellaneousComponentTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
