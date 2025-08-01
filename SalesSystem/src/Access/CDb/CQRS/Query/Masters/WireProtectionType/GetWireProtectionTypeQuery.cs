namespace CDb.CQRS.Query.Masters.WireProtectionType
{
    public class GetWireProtectionTypesQuery : IQuery<List<WireProtectionTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
