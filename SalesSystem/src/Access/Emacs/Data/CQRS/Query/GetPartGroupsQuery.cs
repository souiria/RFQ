namespace Emacs.Data.CQRS.Query
{
    public class GetPartGroupsQuery : IQuery<List<PartGroupsData>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
