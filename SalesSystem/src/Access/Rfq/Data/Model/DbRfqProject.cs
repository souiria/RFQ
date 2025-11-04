namespace Rfq.Data.Model
{
    public class DbRfqProject : IAggregateRoot
    {
        public long RowId
        { get; set; }
        public string RfqNumber
        { get; set; } = string.Empty;
        public Guid? CustomerBusinessUnitGuid
        { get; set; }
        public Guid? CustomerLocationGuid
        { get; set; }
        public Guid? ProjectGuid
        { get; set; }
        public int? RfqReasonId
        { get; set; }
        public DateTime? RfqResponseDeadline
        { get; set; }
        public Guid? CarModelGuid
        { get; set; }
        public int? VehicleVolume
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }

        public virtual ICollection<DbRfqDrawingPartNumber> RfqDrawingPartNumbers
        { get; } = new HashSet<DbRfqDrawingPartNumber>();

        public virtual ICollection<DbRfqNotes> RfqNotes
        { get; } = new HashSet<DbRfqNotes>();

        public DbRfqReason? RfqReason
        { get; set; }
        public bool IsActive 
        { get; set; } = true;
    }
}
