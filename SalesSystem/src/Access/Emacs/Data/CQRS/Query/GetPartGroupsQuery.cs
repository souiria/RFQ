namespace Emacs.Data.CQRS.Query
{
    public class GetPartGroupsQuery : IQuery<List<PartGroupsDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
