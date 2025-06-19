namespace Emacs.Data.CQRS.Query
{
    public class GetMaterialTypesQuery : IQuery<List<MaterialTypesData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
