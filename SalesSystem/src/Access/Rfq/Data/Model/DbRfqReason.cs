namespace Rfq.Data.Model
{
    public class DbRfqReason : IAggregateRoot
    {
        public int RowId
        { get; set; }
        public string ReasonTitle
        { get; set; } = string.Empty;
        public virtual ICollection<DbRfqProject> RfqReasons
        { get; } = new HashSet<DbRfqProject>();
    }
}
