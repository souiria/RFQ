namespace CDb.CQRS.Query.Masters.TypeCode
{
    public class GetTypeCodesQuery : IQuery<List<TypeCodeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
