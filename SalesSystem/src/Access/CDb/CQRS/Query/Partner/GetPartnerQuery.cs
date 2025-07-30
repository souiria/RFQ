namespace CDb.CQRS.Query.Partner
{
    public class GetPartnersQuery : IQuery<List<PartnerGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
