namespace Unit4.Data.Model
{
    public class DbUnit4SalesOrdersView : IAggregateRoot
    {
        public string? FinanceCode
        { get; set; }
        public string? Client
        { get; set; }
        public string? DispatchNumber
        { get; set; }
        public DateTime DispatchDate
        { get; set; }
        public string? ProductNumber
        { get; set; }
        public string? Status
        { get; set; }
        public long OrderId
        { get; set; }
    }
}
