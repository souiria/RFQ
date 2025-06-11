namespace Emacs.Data.CQRS.Query
{
    public class GetPartGroupsConstQuery : IQuery<List<PartGroupsConstDto>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
