namespace Emacs.Data.CQRS.Query
{
    public class GetPartGroupsConstQuery : IQuery<List<PartGroupsConstGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
