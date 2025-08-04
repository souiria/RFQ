namespace CDb.Data.Model
{
    public class DbFileName : IAggregateRoot
    {
        public Guid Id
        { get; set; }
        public DateTime LastModified
        { get; set; }
        public Guid FileTypeId
        { get; set; }
        public DbFileType FileType
        { get; set; }
        public string Name
        { get; set; }
        public string Description
        { get; set; }
        public ICollection<DbComponent> Components
        { get; init; }
        public DbFileName()
        {
            Id = Guid.NewGuid();
            LastModified = DateTime.UtcNow;
            FileTypeId = Guid.Empty;
            FileType = null!;
            Name = string.Empty;
            Description = string.Empty;
            Components = new List<DbComponent>();
        }
    }
}
