using CDb.Enums;
using Master.Data.Time;
using SharedKernel;

namespace CDb.Data.Model
{
    public class DbAuditEvent
    {
        public Guid Id 
        { get; set; }
        public AuditEvent EventType 
        { get; set; }
        public string Table 
        { get; set; }
        public Guid UserId 
        { get; set; }
        public Guid TableId 
        { get; set; }
        public DateTime Date 
        { get; set; }
        public DbAuditEvent()
        {
            Id = Guid.NewGuid();
            EventType = AuditEvent.Create;
            Table = string.Empty;
            UserId = Guid.Empty;
            TableId = Guid.Empty;
            Date = DateTime.UtcNow;
        }
    }
}
