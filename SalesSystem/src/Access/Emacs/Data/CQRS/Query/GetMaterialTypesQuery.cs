namespace Emacs.Data.CQRS.Query
{
    public class GetMaterialTypesQuery : IQuery<List<MaterialTypesGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
