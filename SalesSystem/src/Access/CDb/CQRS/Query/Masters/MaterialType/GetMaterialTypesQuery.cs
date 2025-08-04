namespace CDb.CQRS.Query.Masters.MaterialType
{
    public class GetMaterialTypesQuery : IQuery<List<MaterialTypeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
