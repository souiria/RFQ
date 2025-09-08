namespace Rfq.Data.Model
{
    public class DbRfqNotes : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public long RfqId
        { get; set; }
        public string Note
        { get; set; } = string.Empty;
        public Guid UserGuid
        { get; set; }
        public DateTime? LastModifiedOn
        { get; set; }
        public virtual DbRfqProject RfqProject
        { get; set; } = null!;
    }
}
