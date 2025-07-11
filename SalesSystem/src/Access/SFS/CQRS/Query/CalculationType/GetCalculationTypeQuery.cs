namespace SFS.CQRS.Query.CalculationType
{
    class GetCalculationTypeQuery : IQuery<List<CalculationTypeViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

