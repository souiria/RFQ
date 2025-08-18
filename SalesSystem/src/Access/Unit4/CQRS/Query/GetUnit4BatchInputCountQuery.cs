namespace Unit4.CQRS.Query
{
    class GetUnit4BatchInputCountQuery : IQuery<int>
    {
        public string? FinanceCode
        { get; set; }
        public string? Client
        { get; set; }
        public string? DispatchNumber
        { get; set; }
        public DateTime DispatchDate
        { get; set; }
    }
}
