namespace Emacs.Data.CQRS.Query
{
    public class GetMaterialGroupsQuery : IQuery<List<MaterialGroupsData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
