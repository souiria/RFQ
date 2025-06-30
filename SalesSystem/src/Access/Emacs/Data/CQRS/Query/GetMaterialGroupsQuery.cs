namespace Emacs.Data.CQRS.Query
{
    public class GetMaterialGroupsQuery : IQuery<List<MaterialGroupsGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
