namespace CDb.Data.Model.Masters
{
    public class DbPerson :IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public PersonType PersonType
        { get; set; }

        public string Name
        { get; set; }
        public string? Description
        { get; set; }
        public string Phone
        { get; set; }
        public string Email
        { get; set; }
        public string? Address
        { get; set; }
        public bool IsActive
        { get; set; }
        public ICollection<DbComponent> Components
        { get; init; }

        public DbPerson()
        {
            Id = Guid.NewGuid();
            PersonType = PersonType.Contact;
            Name = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            Components = new List<DbComponent>();
            IsActive = false;
        }
    }
}
