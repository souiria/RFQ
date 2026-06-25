namespace SharedModels.DocumentConverter.DSI.DTOs
{
    public class CompositeOptionDto
    {
        public Guid CompositeOptionId
        { get; set; }
        public string? OptionName
        { get; set; }
        public string? Description
        { get; set; }
        public Guid? HarnessID
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
    }
}
