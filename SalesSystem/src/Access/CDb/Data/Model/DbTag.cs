namespace CDb.Data.Model
{
    public class DbTag
    {
        public Guid Id
        { get; set; }
        public TagType TagType
        { get; set; }
        public string Name
        { get; set; }
        public string Description
        { get; set; }
        public ICollection<DbComponent> Components
        { get; init; }
        public bool IsActive
        { get; set; }

        public DbTag()
        {
            Id = Guid.NewGuid();
            TagType = TagType.Project;
            Name = string.Empty;
            Description = string.Empty;
            Components = new HashSet<DbComponent>();
            IsActive = false;
        }
    }
}
