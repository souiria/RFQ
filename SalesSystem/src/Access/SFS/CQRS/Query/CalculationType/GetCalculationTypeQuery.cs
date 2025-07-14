namespace SFS.CQRS.Query.CalculationType
{
    public class GetCalculationTypeQuery : IQuery<List<CalculationTypeViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

