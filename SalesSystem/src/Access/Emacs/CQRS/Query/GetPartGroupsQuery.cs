namespace Emacs.CQRS.Query
{
    public class GetPartGroupsQuery : IQuery<List<PartGroupsGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
