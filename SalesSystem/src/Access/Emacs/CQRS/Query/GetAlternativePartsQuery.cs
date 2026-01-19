namespace Emacs.CQRS.Query
{
    public class GetAlternativePartsQuery : IQuery<List<AlternativePartsGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
