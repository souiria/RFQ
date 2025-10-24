namespace Rfq.Data.Model
{
    public class DbDsiManualBomQuantity : IAggregateRoot
    {
        public long RowId 
        { get; set; }
        public string? SplitValue 
        { get; set; }
        public string? ModuleCode 
        { get; set; }
        public double Percentage 
        { get; set; }
        public Guid HarnessID 
        { get; set; }
        public DateTime CreatedDate 
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid CreatedBy 
        { get; set; }
        public Guid ModifiedBy
        { get; set; }
    }
}
