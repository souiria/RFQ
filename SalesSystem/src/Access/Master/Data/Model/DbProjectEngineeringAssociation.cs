namespace Master.Data.Model
{
    public class DbProjectEngineeringAssociation : IAggregateRoot
    {
        public Guid? ProjectGuid
        { get; set; }
        public string? EngineeringADName
        { get; set; }
        public string? EngineeringFullName
        { get; set; }
        public string? EmailAddress
        { get; set; }
        public Guid? Id
        { get; set; }
        public DateTime? CreatedDate
        { get; set; }
        public DateTime? ModifiedDate
        { get; set; }
        public Guid? CreatedBy
        { get; set; }
        public Guid? ModifiedBy
        { get; set; }
        public bool? IsActive
        { get; set; }
        public Guid? CustomerGuid
        { get; set; }
    }
}
